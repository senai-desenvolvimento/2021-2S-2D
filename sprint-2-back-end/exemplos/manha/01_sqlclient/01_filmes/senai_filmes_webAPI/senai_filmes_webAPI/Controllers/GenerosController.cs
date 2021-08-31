using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai_filmes_webAPI.Domains;
using senai_filmes_webAPI.Interfaces;
using senai_filmes_webAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
/// <summary>
/// Controlador responsável pelo end points referentes aos genreros.
/// </summary>
namespace senai_filmes_webAPI.Controllers
{
    //Define que o tipo de resposta da API será no Formato JSON.
    [Produces("application/json")]

    //Define que a rota de uma requisição será no formato dominio/api/nomeController.
     // ex: http://localhost:5000/api/generos
    [Route("api/[controller]")]
    //Define que é um controlador de API.
    [ApiController]
    public class GenerosController : ControllerBase
    {
        /// <summary>
        /// Objeto que irá receber todos os métodos definidos na interface IGeneroRepository 
        /// </summary>
        private IGeneroRepository _GeneroRepository { get; set; }

        /// <summary>
        /// Instacia um objeto _GeneroRepository para que haja a referencia dos método no reposotório.
        /// </summary>
        public GenerosController()
        {
            _GeneroRepository = new GeneroRepository();
        }

        [HttpGet]
        //IActionResult = Resultado de uma acao.
        //Get() = nome generico
        public IActionResult Get()
        {
            //Lista de generos
            //Se conectar com o Repositorio.

            //Criar uma lista nomeada listaGeneros para receber os dados.
            List<GeneroDomain> listaGeneros = _GeneroRepository.ListarTodos();

            //Retorna os status code 200(OK) com a lista generos no formato JSON
            return Ok(listaGeneros);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            GeneroDomain generoBuscado = _GeneroRepository.BuscarPorId(id);

            if (generoBuscado == null)
            {
                return NotFound("Nenhum gênero encontrado!");
            }

            return Ok(generoBuscado);
            //return StatusCode(200, generoBuscado);
        }

        [HttpPost]
        public IActionResult Post(GeneroDomain novoGenero)
        {
            //Fazer a chamada para o método .Cadastrar();
            _GeneroRepository.Cadastrar(novoGenero);

            //Retorna um status code 201 - Created.
            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public IActionResult PutUrl(int id, GeneroDomain generoAtualizado)
        {
            GeneroDomain generoBuscado = _GeneroRepository.BuscarPorId(id);

            if (generoBuscado == null)
            {
                return NotFound
                    (new
                    {
                        mensagem = "Gênero não encontrado!",
                        erro = true
                    });
            }

            try
            {
                _GeneroRepository.AtualizarIdUrl(id, generoAtualizado);

                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpPut]
        public IActionResult PutBody(GeneroDomain generoAtualizado)
        {
            if (generoAtualizado.nomeGenero != null || generoAtualizado.idGenero == 0)
            {
                return BadRequest(
                    new
                    {
                        mensagemErro = "Nome do gênero ou id do gênero não foi informado!"
                    }
                );
            }

            GeneroDomain generoBuscado = _GeneroRepository.BuscarPorId(generoAtualizado.idGenero);

            if (generoBuscado != null)
            {
                try
                {
                    _GeneroRepository.AtualizarIdCorpo(generoAtualizado);

                    return NoContent();
                }
                catch (Exception ex)
                {
                    return BadRequest(ex);
                }
            }

            return NotFound(
                    new
                    {
                        mensagemErro = "Gênero não encontrado!",
                        codErro = true
                    }
                );
        }

        /// <summary>
        /// Deleta um gênero existente
        /// </summary>
        /// <param name="id">id do gênero que será deletado</param>
        /// <returns>Um status code 204 - No Content</returns>
        /// ex: http://localhost:5000/api/generos/excluir/7
        [HttpDelete("excluir/{id}")]
        public IActionResult Delete(int id)
        {
            // Faz a chamada para o método .Deletar()
            _GeneroRepository.Deletar(id);

            // Retorna um status code 204 - No Content
            return StatusCode(204);
        }

    }
}
