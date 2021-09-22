using Microsoft.AspNetCore.Http;
using senai_gufi_webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_gufi_webAPI.Interfaces
{
    interface IUsuarioRepository
    {
        /// <summary>
        /// Valida o usuário
        /// </summary>
        /// <param name="email">E-mail do usuário</param>
        /// <param name="senha">Senha do usuário</param>
        /// <returns>Um objeto do tipo Usuario que foi buscado</returns>
        Usuario Login(string email, string senha);


        //IFormFile = Representa um arquivo enviado pelo HttpRequest.
        void SalvarPerfilBD(IFormFile foto, int id_usuario);
        void SalvarPerfilDir(IFormFile foto, int id_usuario);
        string ConsultarPerfilBD(int id_usuario);
        string ConsultarPerfilDir(int id_usuario);

    }
}
