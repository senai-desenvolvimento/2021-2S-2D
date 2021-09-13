using senai.inLock.webAPI.Domains;
using System.Collections.Generic;

namespace senai.inLock.webAPI.Interfaces
{
    /// <summary>
    /// Interface responsável pelo EstudioRepository
    /// </summary>
    interface IEstudioRepository
    {
        /// <summary>
        /// Lista todos os estúdios com suas respectivas listas de jogos
        /// </summary>
        /// <returns>Uma lista de estúdios com seus jogos</returns>
        List<Estudio> ListarComJogos();
    }
}
