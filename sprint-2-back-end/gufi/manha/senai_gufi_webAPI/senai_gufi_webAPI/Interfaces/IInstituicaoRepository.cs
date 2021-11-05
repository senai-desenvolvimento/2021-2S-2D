using senai_gufi_webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_gufi_webAPI.Interfaces
{
    /// <summary>
    /// Interface responsável pelo InstituicaoRepository
    /// </summary>
    interface IInstituicaoRepository
    {
        /// <summary>
        /// Lista todas as Instituicaoes
        /// </summary>
        /// <returns>Uma lista de Instituicaoes</returns>
        List<Instituicao> Listar();

        /// <summary>
        /// Busca uma instituicao através do ID
        /// </summary>
        /// <param name="id">ID da instituicao que será buscada</param>
        /// <returns>Uma instituicao buscada</returns>
        Instituicao BuscarPorId(int id);

        /// <summary>
        /// Cadastra uma nova instituicao
        /// </summary>
        /// <param name="novaInstituicao">Objeto novaInstituicao que será cadastrada</param>
        void Cadastrar(Instituicao novaInstituicao);

        /// <summary>
        /// Atualiza uma instituicao existente
        /// </summary>
        /// <param name="id">ID da instituicao que será atualizada</param>
        /// <param name="instituicaoAtualizada">Objeto com as novas informações</param>
        void Atualizar(int id, Instituicao instituicaoAtualizada);

        /// <summary>
        /// Deleta uma instituicao existente
        /// </summary>
        /// <param name="id">ID da instituicao que será deletada</param>
        void Deletar(int id);
    }
}
