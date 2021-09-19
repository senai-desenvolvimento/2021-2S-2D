using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace senai_InLock_webApi_CodeFrist.Domains
{
    /// <summary>
    /// Classe que representa a entidade Usuarios
    /// </summary>
    /// 

    [Table("Usuarios")]
    public class Usuarios
    { 
        //Define que será chave primária
        [Key]
        //Define auto-incremento
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idUsuario { get; set; }

        [Column(TypeName = "varchar(150)")]
        [Required(ErrorMessage ="O e-mail é obrigatório")]
        public string email { get; set; }

        //Define o tipo de dado
        [Column(TypeName = "varchar(30)")]
        //Define que a propriedae é obrigatória
        [Required(ErrorMessage = "A senha é obrigatória")]
        //Define os requisitos da propriedade
        [StringLength(30, MinimumLength = 5, ErrorMessage ="A senha do usuário deve contem de 5 a 30 caracteres.")]
        public string senha { get; set; }

        public int  idTipoUsuario { get; set; }

        [ForeignKey("idTipoUsuario")]
        public TiposUsuario  tipoUsuario { get; set; }
    }
}
