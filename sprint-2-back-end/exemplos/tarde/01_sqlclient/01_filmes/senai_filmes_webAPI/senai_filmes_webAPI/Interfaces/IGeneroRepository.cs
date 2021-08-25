using senai_filmes_webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_filmes_webAPI.Interfaces
{
    /// <summary>
    /// Interface responsável pelo repositório GeneroRepository
    /// </summary>
    interface IGeneroRepository
    {
        // Estrutura dos métodos
        // TipoRetorno NomeMetodo(TipoParametro NomeParametro);
        // Ex: GeneroDomain Cadastrar(GeneroDomain novoGenero);

        /// <summary>
        /// Lista todos os gêneros
        /// </summary>
        /// <returns>Uma lista de gêneros</returns>
        List<GeneroDomain> ListarTodos();

        /// <summary>
        /// Busca um gênero através do seu id
        /// </summary>
        /// <param name="idGenero">id do gênero que será buscado</param>
        /// <returns>Um gênero buscado</returns>
        GeneroDomain BuscarPorId(int idGenero);

        /// <summary>
        /// Cadastra um novo gênero
        /// </summary>
        /// <param name="novoGenero">Objeto novoGenero com os novos dados</param>
        void Cadastrar(GeneroDomain novoGenero);

        /// <summary>
        /// Atualiza um gênero existente
        /// </summary>
        /// <param name="generoAtualizado">Objeto generoAtualizado com os novos dados atualizados</param>
        void AtualizarIdCorpo(GeneroDomain generoAtualizado);

        /// <summary>
        /// Atualiza um gênero existente
        /// </summary>
        /// <param name="idGenero">id do gênero que será atualizado</param>
        /// <param name="generoAtualizado">Objeto generoAtualizado com os novos dados atualizados</param>
        void AtualizarIdUrl(int idGenero, GeneroDomain generoAtualizado);

        /// <summary>
        /// Deleta um gênero existente
        /// </summary>
        /// <param name="idGenero">id do gênero que será deletado</param>
        void Deletar(int idGenero);
    }
}
