using senai_inlock_webAPI.Domains;
using System.Collections.Generic;

namespace senai_inlock_webAPI.Interfaces
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
        List<Estudio> Listar();

        /// <summary>
        /// Busca um estúdio através do seu id
        /// </summary>
        /// <param name="idEstudio">ID do estúdio que será buscado</param>
        /// <returns>Um estúdio encontrado</returns>
        Estudio BuscarPorId(int idEstudio);

        /// <summary>
        /// Cadastra um novo estúdio
        /// </summary>
        /// <param name="novoEstudio">Objeto novoEstudio com os dados que serão cadastrados</param>
        void Cadastrar(Estudio novoEstudio);

        /// <summary>
        /// Atualiza um estúdio existente
        /// </summary>
        /// <param name="idEstudio">ID do estúdio que será atualizado</param>
        /// <param name="estudioAtualizado">Objeto estudioAtualizado com as novas informações</param>
        void Atualizar(int idEstudio, Estudio estudioAtualizado);

        /// <summary>
        /// Deleta um estúdio existente
        /// </summary>
        /// <param name="idEstudio">ID do estúdio que será deletado</param>
        void Deletar(int idEstudio);

        /// <summary>
        /// Lista todos os estúdios com seus respectivos jogos
        /// </summary>
        /// <returns>Uma lista de estúdios com jogos</returns>
        List<Estudio> ListarComJogos();
    }
}
