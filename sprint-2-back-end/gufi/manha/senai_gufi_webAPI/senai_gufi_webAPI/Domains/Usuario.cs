using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace senai_gufi_webAPI.Domains
{
    /// <summary>
    /// Classe que representa a entidade (tabela) de usuários
    /// </summary>
    public partial class Usuario
    {
        public Usuario()
        {
            Presencas = new HashSet<Presenca>();
        }

        public int IdUsuario { get; set; }
        public int? IdTipoUsuario { get; set; }

        // Define que o campo é obrigatório
        [Required(ErrorMessage = "Informe o nome do usuário")]
        public string NomeUsuario { get; set; }

        // Define que o campo é obrigatório
        [Required(ErrorMessage = "Informe o e-mail")]
        public string Email { get; set; }

        // Define que o campo é obrigatório
        [Required(ErrorMessage = "Informe a senha")]
        // Define que os pré-requisitos do campo
        [StringLength(100, MinimumLength = 5, ErrorMessage = "A senha deve conter no mínimo 5 caracteres")]
        public string Senha { get; set; }

        public virtual TipoUsuario IdTipoUsuarioNavigation { get; set; }
        public virtual ImagemUsuario ImagemUsuario { get; set; }
        public virtual ICollection<Presenca> Presencas { get; set; }
    }
}
