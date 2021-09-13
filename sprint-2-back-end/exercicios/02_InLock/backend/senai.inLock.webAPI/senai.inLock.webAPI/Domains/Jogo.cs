using System;

namespace senai.inLock.webAPI.Domains
{
    /// <summary>
    /// Classe que representa a entidade (tabela) de jogos
    /// </summary>
    public class Jogo
    {
        public int IdJogo { get; set; }
        public string NomeJogo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataLancamento { get; set; }
        public decimal Valor { get; set; }
        public int IdEstudio { get; set; }
        public Estudio Estudio { get; set; }
    }
}
