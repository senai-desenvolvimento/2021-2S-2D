
using senai_InLock_webAPI_CodeFirst.Domains;
using System.Collections.Generic;

namespace senai_InLock_webAPI_CodeFirst.Interfaces
{
    /// <summary>
    /// Interface responsável pelo EstudioRepository
    /// </summary>
    interface IEstudioRepository
    {
        /// <summary>
        /// Lista todos os estúdios
        /// </summary>
        /// <returns>Uma lista de estúdios</returns>
        List<Estudios> Listar();

        /// <summary>
        /// Busca um estúdio através do seu ID
        /// </summary>
        /// <param name="idEstudio">ID do estúdio que será buscado</param>
        /// <returns>Um estúdio encontrado</returns>
        Estudios BuscarPorId(int idEstudio);

        /// <summary>
        /// Cadastra um novo estúdio
        /// </summary>
        /// <param name="novoEstudio">Objeto novoEstudio com as informações</param>
        void Cadastrar(Estudios novoEstudio);

        /// <summary>
        /// Atualiza os dados de um estúdio existente
        /// </summary>
        /// <param name="idEstudio">ID do estúdio que será atualizado</param>
        /// <param name="estudioAtualizado">Objeto estudioAtualizado com as novas informações</param>
        void Atualizar(int idEstudio, Estudios estudioAtualizado);

        /// <summary>
        /// Deleta um estúdio existente
        /// </summary>
        /// <param name="idEstudio">ID do estúdio que será deletado</param>
        void Deletar(int idEstudio);

        /// <summary>
        /// Lista todos os estúdios com a lista de jogos
        /// </summary>
        /// <returns>Uma lista de estúdios com os seus respectivos jogos</returns>
        List<Estudios> ListarComJogos();
    }
}
