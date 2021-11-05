using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace senai_gufi_webAPI.Domains
{
    /// <summary>
    /// Classe que representa a entidade (tabela) de situações
    /// </summary>
    public partial class Situacao
    {
        public Situacao()
        {
            Presencas = new HashSet<Presenca>();
        }

        public int IdSituacao { get; set; }

        // Define que o campo é obrigatório!
        [Required(ErrorMessage = "A descrição da situação é obrigatória!")]
        public string Descricao { get; set; }

        public virtual ICollection<Presenca> Presencas { get; set; }
    }
}
