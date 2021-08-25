using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_filmes_webAPI.Domains
{
    /// <summary>
    /// Classe que representa a entidade (tabela) FILME
    /// </summary>
    public class FilmeDomain
    {
        public int idFilme { get; set; }
        public int idGenero { get; set; }
        public string nomeFilme { get; set; }
        public GeneroDomain genero { get; set; }
    }
}
