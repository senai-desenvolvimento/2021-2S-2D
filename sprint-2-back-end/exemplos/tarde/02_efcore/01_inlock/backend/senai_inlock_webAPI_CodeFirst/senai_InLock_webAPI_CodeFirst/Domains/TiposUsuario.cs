using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace senai_InLock_webAPI_CodeFirst.Domains
{
    /// <summary>
    /// Classe que representa a entidade TiposUsuario
    /// </summary>
    /// 


    //Define o nome da tabela que será criada no banco de dados.
    [Table("TiposUsuario")]
    public class TiposUsuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]       
        public int idTipoUsuario { get; set; }


        [Column(TypeName ="varchar(150)")]
        [Required(ErrorMessage ="O título de usuário é obrigatório!")]
        public string titulo { get; set; }

    }
}
