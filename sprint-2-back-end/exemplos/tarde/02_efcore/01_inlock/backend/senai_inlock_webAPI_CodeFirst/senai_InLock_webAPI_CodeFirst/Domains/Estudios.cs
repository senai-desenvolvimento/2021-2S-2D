using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace senai_InLock_webAPI_CodeFirst.Domains
{
    /// <summary>
    /// Classe que representa a entidade Estudios
    /// </summary>
    /// 

    [Table("Estudios")]
    public class Estudios
    {
        //Define que será uma chave primária
        [Key]
        //Define o auto-incremento
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idEstudio { get; set; }

         //Define o nome da coluna e o tipo de dado
        [Column(TypeName ="varchar(150)")]
        [Required(ErrorMessage ="O nome do estúdio é obrigatório")]
        public string nomeEstudio { get; set; }
        public List<Jogos> jogos { get; set; }

    }
}
