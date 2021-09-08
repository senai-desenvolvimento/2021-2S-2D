using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai_filmes_webAPI.Domains;
using senai_filmes_webAPI.Interfaces;
using senai_filmes_webAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_filmes_webAPI.Controllers
{
    //Define que o tipo de resposta da API será no formato JSON
    [Produces("application/json")]

    //Define que a rota de uma requisição será no formato domino/api/nomeController.
    // ex: http://localhost:5000/api/generos
    [Route("api/[controller]")]
    //Define que é um controlador de API.
    [ApiController]
    
    // Define que todos os endpoints serão restritos
    // ou seja, apenas usuários logados podem acessar
    [Authorize]

    /// <summary>
    /// Controller responsavel pelos endpoints referentes aos generos.
    /// </summary>
    public class GenerosController : ControllerBase
    {
        /// <summary>
        /// Obejto _generoRepository que irá receber todos os metodos definidor na interface IGeneroRepository
        /// </summary>
        private IGeneroRepository _generoRepository { get; set; }
        /// <summary>
        /// Instancia um objeto _generoRepository para que haja a referencia aos metodos no repositorio.
        /// </summary>
        public GenerosController()
        {
            _generoRepository = new GeneroRepository();
        }
        /// <summary>
        /// Lista todos os gêneros
        /// </summary>
        /// <returns>Uma lista de gêneros e um status code.</returns>
        [HttpGet]
        public IActionResult Get()
        {
            //Criar uma lista nomeada listaGeneros para receber os dados.
            List<GeneroDomain> listaGeneros = _generoRepository.ListarTodos();

            //Retorna o status code 200(OK) com a lista de gêneros no formato JSON
            return Ok(listaGeneros);

        }

        [Authorize(Roles = "administrador, comum")]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            GeneroDomain generoBuscado = _generoRepository.BuscarPorId(id);

            if (generoBuscado == null)
            {
                return NotFound("Nenhum gênero encontrado!");
            }

            return Ok(generoBuscado);
        }

        /// <summary>
        /// Cadastra um novo gênero
        /// </summary>
        /// <returns>Um status code 201 - Created</returns>
        [HttpPost]
        public IActionResult Post(GeneroDomain novoGenero)
        {
            //Faz a chamada para o método .cadastrar
            _generoRepository.Cadastrar(novoGenero);

            //Retorna um status code 201 - Created
            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public IActionResult PutIdUrl(int id, GeneroDomain generoAtualizado)
        {
            GeneroDomain generoBuscado = _generoRepository.BuscarPorId(id);

            if (generoBuscado == null)
            {
                return NotFound(
                        new
                        {
                            mensagem = "Gênero não encontrado!",
                            erro = true
                        }
                    );
            }

            try
            {
                _generoRepository.AtualizarIdUrl(id, generoAtualizado);

                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpPut]
        public IActionResult PutIdBody(GeneroDomain generoAtualizado)
        {
            if (generoAtualizado.nomeGenero == null || generoAtualizado.idGenero <= 0)
            {
                return BadRequest(
                    new
                    {
                        mensagemErro = "Nome ou o id do gênero não foi informado!"
                    });
            }

            GeneroDomain generoBuscado = _generoRepository.BuscarPorId(generoAtualizado.idGenero);

            if (generoBuscado != null)
            {
                try
                {
                    _generoRepository.AtualizarIdCorpo(generoAtualizado);

                    return NoContent();
                }
                catch (Exception codErro)
                {
                    return BadRequest(codErro);
                }
            }

            return NotFound(
                    new
                    {
                        mensagem = "Gênero não encontrado!",
                        errorStatus = true
                    }
                );
        }

        /// <summary>
        /// Deleta um gênero existente
        /// </summary>
        /// <param name="id">id do gênero que será deletado</param>
        /// <returns>Um status code 204 - No Content</returns>
        /// ex: http://localhost:5000/api/generos/excluir/9
        [HttpDelete("excluir/{id}")]
        public IActionResult Delete(int id)
        {
            // Faz a chamada para o método .Deletar()
            _generoRepository.Deletar(id);

            // Retorna um status code 204 - No Content
            return NoContent();
        }
    }
}
