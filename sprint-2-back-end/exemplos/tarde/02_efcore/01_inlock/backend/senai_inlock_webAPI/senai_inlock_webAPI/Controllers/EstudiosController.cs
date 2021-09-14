using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai_inlock_webAPI.Domains;
using senai_inlock_webAPI.Interfaces;
using senai_inlock_webAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_inlock_webAPI.Controllers
{
    // Define que o formato de dados da API será em JSON
    [Produces("application/json")]

    // Define que a rota de uma requisição será no formato domínio/api/nomeController
    // ex: http://localhost:5000/api/estudios
    [Route("api/[controller]")]

    // Define que é um controlador de API
    [ApiController]

    // Controller responsável pelos endpoints (URLs) referentes aos estúdios
    public class EstudiosController : ControllerBase
    {
        /// <summary>
        /// Objeto _estudioRepository que irá receber todos os métodos definidos na interface IEstudioRepository
        /// </summary>
        private IEstudioRepository _estudioRepository { get; set; }

        /// <summary>
        /// Instancia o objeto _estudioRepository para que haja referência aos métodos implementados no repositório EstudioRepository
        /// </summary>
        public EstudiosController()
        {
            _estudioRepository = new EstudioRepository();
        }

        /// <summary>
        /// Lista todos os estúdios
        /// </summary>
        /// <returns>Uma lista de estúdios com um status code 200 - Ok</returns>
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_estudioRepository.Listar());
        }

        /// <summary>
        /// Busca um estúdio através do seu id
        /// </summary>
        /// <param name="idEstudio">ID do estúdio que será buscado</param>
        /// <returns>Um estúdio e um status code 200 - Ok</returns>
        [HttpGet("{idEstudio}")]
        public IActionResult BuscarPorId(int idEstudio)
        {
            return Ok(_estudioRepository.BuscarPorId(idEstudio));
        }

        /// <summary>
        /// Cadastra um novo estúdio
        /// </summary>
        /// <param name="novoEstudio">Objeto com os dados que serão cadastrados</param>
        /// <returns>Um status code 201 - Created</returns>
        [HttpPost]
        public IActionResult Cadastrar(Estudio novoEstudio)
        {
            _estudioRepository.Cadastrar(novoEstudio);

            return StatusCode(201);
        }

        /// <summary>
        /// Atualiza um estúdio existente
        /// </summary>
        /// <param name="idEstudio">ID do estúdio que será atualizado</param>
        /// <param name="estudioAtualizado">Objeto com os novos dados</param>
        /// <returns>Um status code 204 - No Content</returns>
        [HttpPut("{idEstudio}")]
        public IActionResult Atualizar(int idEstudio, Estudio estudioAtualizado)
        {
            _estudioRepository.Atualizar(idEstudio, estudioAtualizado);

            return StatusCode(204);
        }

        [HttpDelete("{idEstudio}")]
        public IActionResult Deletar(int idEstudio)
        {
            _estudioRepository.Deletar(idEstudio);

            return StatusCode(204);
        }

        [HttpGet("jogos")]
        public IActionResult ListarComJogos()
        {
            return Ok(_estudioRepository.ListarComJogos());
        }
    }
}
