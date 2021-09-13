using System.ComponentModel.DataAnnotations;

namespace senai.inLock.webAPI.Domains
{
    /// <summary>
    /// Classe que representa a entidade (tabela) de usuários
    /// </summary>
    public class Usuario
    {
        public int IdUsuario { get; set; }

        // Define que o campo é obrigatório
        [Required(ErrorMessage = "Informe o e-mail")]
        public string Email { get; set; }

        // Define que o campo é obrigatório
        [Required(ErrorMessage = "Informe a senha")]
        // Define que os pré-requisitos do campo
        [StringLength(100, MinimumLength = 5, ErrorMessage = "A senha deve conter no mínimo 5 caracteres")]
        public string Senha { get; set; }
        public int IdTipoUsuario { get; set; }
        public TipoUsuario TipoUsuario { get; set; }
    }
}
