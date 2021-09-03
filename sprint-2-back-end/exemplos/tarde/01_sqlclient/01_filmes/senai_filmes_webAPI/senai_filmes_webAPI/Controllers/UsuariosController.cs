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
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository { get; set; }

        public UsuariosController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        [HttpPost("login")]
        public IActionResult Login(UsuarioDomain login)
        {
            UsuarioDomain usuarioBuscado =  _usuarioRepository.BuscarPorEmailSenha(login.email, login.senha);

            if (usuarioBuscado == null)
                return NotFound("E-mail ou senha inválidos!");

            return Ok(usuarioBuscado);
        }
    }
}
