using System.Collections.Generic;

namespace senai.inLock.webAPI.Domains
{
    /// <summary>
    /// Classe que representa a entidade (tabela) de estúdios
    /// </summary>
    public class Estudio
    {
        public int IdEstudio { get; set; }
        public string NomeEstudio { get; set; }
        public List<Jogo> ListaJogos { get; set; }
    }
}
