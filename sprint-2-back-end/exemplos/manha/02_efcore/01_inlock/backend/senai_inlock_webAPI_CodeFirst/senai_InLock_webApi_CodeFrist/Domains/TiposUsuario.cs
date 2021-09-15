using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace senai_InLock_webApi_CodeFrist.Domains
{
    /// <summary>
    /// Classe que representa a entidade TiposUsuario
    /// </summary>
    /// 

    [Table("TiposUsuario")]
    public class TiposUsuario
    {
        //Define que será uma chave primarária
        [Key]
        //Define o auto-incremento
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idTipoUsuario { get; set; }
        
        //Define o tipo de dado
        [Column(TypeName = "varchar(150)")]

        //Define que a propriedade é obrigatória
        [Required(ErrorMessage ="O título do tipo de usuário é obrigatório.")]
        public string titulo { get; set; }


    }
}
