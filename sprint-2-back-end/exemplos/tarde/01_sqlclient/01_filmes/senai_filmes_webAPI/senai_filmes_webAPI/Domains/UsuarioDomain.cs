using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace senai_filmes_webAPI.Domains
{
    /// <summary>
    /// Classe que representa a entidade (tabela) Usuarios
    /// </summary>
    public class UsuarioDomain
    {
        public int idUsuario { get; set; }

        [Required(ErrorMessage ="Informe o e-mail.")]
        public string email { get; set; }

        [Required(ErrorMessage = "Informe a senha.")]
        [StringLength(10, MinimumLength = 3 , ErrorMessage = "O campo senha precisa ter no mínimo 3 e no máximo 10 caracteres.")]
        public string senha { get; set; }
        public string permissao { get; set; }
    }
}
