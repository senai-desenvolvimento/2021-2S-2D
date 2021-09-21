using senai_gufi_webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_gufi_webAPI.Interfaces
{
    /// <summary>
    /// Interface responsável pelo PresencaRepository
    /// </summary>
    interface IPresencaRepository
    {
        /// <summary>
        /// Lista todos os eventos que um determinado usuário participa
        /// </summary>
        /// <param name="idUsuario">ID do usuário que participa dos eventos listados</param>
        /// <returns>Uma lista de presenças com os dados dos eventos</returns>
        List<Presenca> ListarMinhas(int idUsuario);

        /// <summary>
        /// Cria uma nova presença
        /// </summary>
        /// <param name="inscricao">Objeto com as informações da inscrição</param>
        void Inscrever(Presenca inscricao);

        /// <summary>
        /// Altera o status de uma presença
        /// </summary>
        /// <param name="idPresenca">ID da presença que terá a situação alterada</param>
        /// <param name="status">Parâmetro que atualiza a situação da presença para 1 - APROVADA, 2 - RECUSADA ou 3 - AGUARDANDO</param>
        void AprovarRecusar(int idPresenca, string status);
    }
}
