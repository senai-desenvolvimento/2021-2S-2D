using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace senai_InLock_webAPI_CodeFirst.Domains
{
    [Table("Usuarios")]
    public class Usuarios
    {
        //Define que será uma chave primaria
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idUsuario { get; set; }

        [Column(TypeName ="varchar(150)")]
        [Required(ErrorMessage ="O e-mail do usuário é obrigatório!")]
        public string email { get; set; }

        [Column(TypeName = "varchar(30)")]
        [Required(ErrorMessage = "A senha do usuário é obrigatória!")]
        [StringLength(30,MinimumLength = 5, ErrorMessage ="A senha deve conter entre 5 e 30 carateres.")]
        public string senha { get; set; }
        public int idTipoUsuario { get; set; }

        //Define a chave estrangeira
        [ForeignKey("idTipoUsuario")]
        public TiposUsuario tipoUsuario { get; set; }      

    }
}
