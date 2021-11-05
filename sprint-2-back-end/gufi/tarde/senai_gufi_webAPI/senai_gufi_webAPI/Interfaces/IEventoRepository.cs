using senai_gufi_webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_gufi_webAPI.Interfaces
{
    /// <summary>
    /// Interface responsável pelo EventoRepository
    /// </summary>
    interface IEventoRepository
    {
        /// <summary>
        /// Lista todos os eventos
        /// </summary>
        /// <returns>Uma lista de eventos</returns>
        List<Evento> Listar();

        /// <summary>
        /// Busca um evento através do ID
        /// </summary>
        /// <param name="id">ID do evento que será buscado</param>
        /// <returns>Um evento buscado</returns>
        Evento BuscarPorId(int id);

        /// <summary>
        /// Cadastra um novo evento
        /// </summary>
        /// <param name="novoEvento">Objeto novoEvento que será cadastrado</param>
        void Cadastrar(Evento novoEvento);

        /// <summary>
        /// Atualiza um evento existente
        /// </summary>
        /// <param name="id">ID do evento que será atualizado</param>
        /// <param name="eventoAtualizado">Objeto com as novas informações</param>
        void Atualizar(int id, Evento eventoAtualizado);

        /// <summary>
        /// Deleta um evento existente
        /// </summary>
        /// <param name="id">ID do evento que será deletado</param>
        void Deletar(int id);
    }
}
