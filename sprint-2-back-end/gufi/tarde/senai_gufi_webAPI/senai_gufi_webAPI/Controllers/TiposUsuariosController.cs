using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using senai_gufi_webAPI.Domains;
using senai_gufi_webAPI.Interfaces;
using senai_gufi_webAPI.Repositories;
using System;

namespace senai_gufi_webAPI.Controllers
{ /// <summary>
  /// Controller responsável pelos endpoints (URLs) referentes aos tipos de usuários
  /// </summary>

    // Define que o tipo de resposta da API será no formato JSON
    [Produces("application/json")]

    // Define que a rota de uma requisição será no formato dominio/api/nomeController
    // ex: http://localhost:5000/api/tiposUsuarios
    [Route("api/[controller]")]

    // Define que é um controlador de API
    [ApiController]

    // Define que somente o administrador pode acessar os métodos
    [Authorize(Roles = "1")]
    public class TiposUsuariosController : ControllerBase
    {
        /// <summary>
        /// Objeto _tiposUsuarioRepository que irá receber todos os métodos definidos na interface ITiposUsuarioRepository
        /// </summary>
        private ITiposUsuarioRepository _tiposUsuarioRepository { get; set; }

        /// <summary>
        /// Instancia o objeto _tiposUsuarioRepository para que haja a referência aos métodos no repositório
        /// </summary>
        public TiposUsuariosController()
        {
            _tiposUsuarioRepository = new TiposUsuarioRepository();
        }

        /// <summary>
        /// Lista todos os tipos de usuários
        /// </summary>
        /// <returns>Uma lista de tipos de usuários e um status code 200 - Ok</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                // Retorna a resposta da requisição fazendo a chamada para o método
                return Ok(_tiposUsuarioRepository.Listar());
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        /// <summary>
        /// Busca um tipo de usuário através do ID
        /// </summary>
        /// <param name="id">ID do tipo de usuário que será buscado</param>
        /// <returns>Um tipo de usuário buscado e um status code 200 - Ok</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                // Retora a resposta da requisição fazendo a chamada para o método
                return Ok(_tiposUsuarioRepository.BuscarPorId(id));
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        /// <summary>
        /// Cadastra um novo tipo de usuário
        /// </summary>
        /// <param name="novoTipousuario">Objeto novoTipoUsuario que será cadastrado</param>
        /// <returns>Um status code 201 - Created</returns>
        [HttpPost]
        public IActionResult Post(TipoUsuario novoTipousuario)
        {
            try
            {
                // Faz a chamada para o método
                _tiposUsuarioRepository.Cadastrar(novoTipousuario);

                // Retorna um status code
                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Atualiza um tipo de usuário existente
        /// </summary>
        /// <param name="id">ID do tipo de usuário que será atualizado</param>
        /// <param name="tipoUsuarioAtualizado">Objeto com as novas informações</param>
        /// <returns>Um status code 204 - No Content</returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, TipoUsuario tipoUsuarioAtualizado)
        {
            try
            {
                // Faz a chamada para o método
                _tiposUsuarioRepository.Atualizar(id, tipoUsuarioAtualizado);

                // Retorna um status code
                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Deleta um tipo de usuário existente
        /// </summary>
        /// <param name="id">ID do tipo de usuário que será deletado</param>
        /// <returns>Um status code 204 - No Content</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                // Faz a chamada para o método
                _tiposUsuarioRepository.Deletar(id);

                // Retorna um status code
                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
