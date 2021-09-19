using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai_InLock_webAPI_CodeFirst.Domains;
using senai_InLock_webAPI_CodeFirst.Interfaces;
using senai_InLock_webAPI_CodeFirst.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_InLock_webAPI_CodeFirst.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]

    // Controller responsável pelos endpoints (URLs) referentes aos estúdios
    public class EstudiosController : ControllerBase
    {
        /// <summary>
        /// Objeto _estudioRepository que irá receber todos os métodos definidos na interface IEstudioRepository
        /// </summary>
        private IEstudioRepository _estudioRepository { get; set; }

        /// <summary>
        /// Instancia o objeto _estudioRepository para que haja referência às implementações feitas no repositório EstudioRepository
        /// </summary>
        public EstudiosController()
        {
            _estudioRepository = new EstudioRepository();
        }

        /// <summary>
        /// Lista todos os estúdios
        /// </summary>
        /// <returns>Uma lista de estúdios com o status code 200 - Ok</returns>
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_estudioRepository.Listar());
        }

        /// <summary>
        /// Busca um estúdio através do seu id
        /// </summary>
        /// <param name="idEstudio">ID do estúdio que será buscado</param>
        /// <returns>Um estúdio encontrado com o status code 200 - Ok</returns>
        [HttpGet("{idEstudio}")]
        public IActionResult BuscarPorId(int idEstudio)
        {
            // Retorna um estúdio encontrado
            return Ok(_estudioRepository.BuscarPorId(idEstudio));
        }

        /// <summary>
        /// Cadastra um estúdio
        /// </summary>
        /// <param name="novoEstudio">Objeto novoEstudio com as informações</param>
        /// <returns>Um status code 201 - Created</returns>
        [HttpPost]
        public IActionResult Cadastrar(Estudios novoEstudio)
        {
            // Faz a chamada para o método .Cadastrar enviando as informações de cadastro
            _estudioRepository.Cadastrar(novoEstudio);

            // Retorna um status code
            return StatusCode(201);
        }

        /// <summary>
        /// Atualiza um estúdio existente
        /// </summary>
        /// <param name="idEstudio">ID do estúdio que será atualizado</param>
        /// <param name="estudioAtualizado">Objeto estudioAtualizado com as novas informações</param>
        /// <returns>Um status code 204 - No Content</returns>
        [HttpPut("{idEstudio}")]
        public IActionResult Atualizar(int idEstudio, Estudios estudioAtualizado)
        {
            // Faz a chamada para o método .Atualizar enviando as novas informações
            _estudioRepository.Atualizar(idEstudio, estudioAtualizado);

            // Retorna um status code
            return StatusCode(204);
        }

        /// <summary>
        /// Deleta um estúdio existente
        /// </summary>
        /// <param name="idEstudio">ID do estúdio que será deletado</param>
        /// <returns>Um status code 204 - No Content</returns>
        [HttpDelete("{idEstudio}")]
        public IActionResult Deletar(int idEstudio)
        {
            // Faz a chamada para o método .Deletar enviando o id do estúdio como parâmetro
            _estudioRepository.Deletar(idEstudio);

            // Retorna um status code
            return StatusCode(204);
        }

        /// <summary>
        /// Lista todos os estúdios com seus jogos
        /// </summary>
        /// <returns>Uma lista com um status code 200 - Ok</returns>
        [HttpGet("jogos")]
        public IActionResult ListarComJogos()
        {
            // Retorna uma lista de estúdios com seus respectivos jogos e um status code
            return Ok(_estudioRepository.ListarComJogos());
        }
    }
}
