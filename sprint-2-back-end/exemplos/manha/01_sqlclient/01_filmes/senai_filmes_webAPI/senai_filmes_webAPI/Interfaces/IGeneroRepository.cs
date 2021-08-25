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
        // Estrutura de métodos da Interface
        // TipoRetorno NomeMetodo (TipoParametro NomeParametro);
        // void Cadastrar(GeneroDomain novoGenero);

        /// <summary>
        /// Retorna todos os gêneros
        /// </summary>
        /// <returns>Uma lista de gêneros</returns>
        List<GeneroDomain> ListarTodos();

        /// <summary>
        /// Busca um gênero através do seu id
        /// </summary>
        /// <param name="idGenero">id do gênero que será buscado</param>
        /// <returns>Um objeto do tipo GeneroDomain que foi buscado</returns>
        GeneroDomain BuscarPorId(int idGenero);

        /// <summary>
        /// Cadastra um novo gênero
        /// </summary>
        /// <param name="novoGenero">Objeto novoGenero com os dados que serão cadastrados</param>
        void Cadastrar(GeneroDomain novoGenero);

        /// <summary>
        /// Atualiza um gênero existente passando o id pelo corpo da requisição
        /// </summary>
        /// <param name="generoAtualizado">Objeto generoAtualizado com os novos dados</param>
        /// ex: http://localhost:5000/api/generos
        void AtualizarIdCorpo(GeneroDomain generoAtualizado);

        /// <summary>
        /// Atualiza um gênero existente passando o id pela URL da requisição
        /// </summary>
        /// <param name="idGenero">id do gênero que será atualizado</param>
        /// <param name="generoAtualizado">Objeto generoAtualizado com os novos dados</param>
        /// ex: http://localhost:5000/api/generos/4
        void AtualizarIdUrl(int idGenero, GeneroDomain generoAtualizado);

        /// <summary>
        /// Deleta um gênero
        /// </summary>
        /// <param name="idGenero">id do gênero que será deletado</param>
        void Deletar(int idGenero);
    }
}
