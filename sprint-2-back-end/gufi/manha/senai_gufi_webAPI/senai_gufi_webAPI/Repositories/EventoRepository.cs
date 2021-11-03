using Microsoft.EntityFrameworkCore;
using senai_gufi_webAPI.Context;
using senai_gufi_webAPI.Domains;
using senai_gufi_webAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_gufi_webAPI.Repositories
{
    /// <summary>
    /// Classe responsável pelo repositório dos eventos
    /// </summary>
    public class EventoRepository : IEventoRepository
    {
        /// <summary>
        /// Objeto contexto por onde serão chamados os métodos do EF Core
        /// </summary>
        GufiContext ctx = new GufiContext();

        /// <summary>
        /// Atualiza um evento existente
        /// </summary>
        /// <param name="id">ID do evento que será atualizado</param>
        /// <param name="eventoAtualizado">Objeto com as novas informações</param>
        public void Atualizar(int id, Evento eventoAtualizado)
        {
            // Busca um evento através do id
            Evento eventoBuscado = ctx.Eventos.Find(id);

            // Verifica se o nome do evento foi informado
            if (eventoAtualizado.NomeEvento != null)
            {
                // Atribui os novos valores ao campos existentes
                eventoBuscado.NomeEvento = eventoAtualizado.NomeEvento;
            }

            // Verifica se o tipo do evento foi informado
            if (eventoAtualizado.IdTipoEvento != null)
            {
                // Atribui os novos valores ao campos existentes
                eventoBuscado.IdTipoEvento = eventoAtualizado.IdTipoEvento;
            }

            // Verifica se o tipo do evento foi informado
            if (eventoAtualizado.IdTipoEvento > 0)
            {
                // Atribui os novos valores ao campos existentes
                eventoBuscado.IdTipoEvento = eventoAtualizado.IdTipoEvento;
            }

            // Verifica se a privacidade do evento foi informada
            if (eventoAtualizado.AcessoLivre == true || eventoAtualizado.AcessoLivre == false)
            {
                // Atribui os novos valores ao campos existentes
                eventoBuscado.AcessoLivre = eventoAtualizado.AcessoLivre;
            }

            // Verifica se a instituição do evento foi informada
            if (eventoAtualizado.IdInstituicao > 0)
            {
                // Atribui os novos valores ao campos existentes
                eventoBuscado.IdInstituicao = eventoAtualizado.IdInstituicao;
            }

            // Verifica se a descrição do evento foi informada
            if (eventoAtualizado.Descricao != null)
            {
                // Atribui os novos valores ao campos existentes
                eventoBuscado.Descricao = eventoAtualizado.Descricao;
            }

            // Verifica se a data do evento é superior ou igual à data de hoje
            if (eventoAtualizado.DataEvento >= DateTime.Today)
            {
                // Atribui os novos valores ao campos existentes
                eventoBuscado.DataEvento = eventoAtualizado.DataEvento;
            }

            // Atualiza o evento que foi buscado
            ctx.Eventos.Update(eventoBuscado);

            // Salva as informações para serem gravadas no banco
            ctx.SaveChanges();
        }

        /// <summary>
        /// Busca um evento através do ID
        /// </summary>
        /// <param name="id">ID do evento que será buscado</param>
        /// <returns>Um evento buscado</returns>
        public Evento BuscarPorId(int id)
        {
            // Retorna o primeiro evento encontrado para o ID informado
            return ctx.Eventos.FirstOrDefault(e => e.IdEvento == id);
        }

        /// <summary>
        /// Cadastra um novo evento
        /// </summary>
        /// <param name="novoEvento">Objeto novoEvento que será cadastrado</param>
        public void Cadastrar(Evento novoEvento)
        {
            // Adiciona este novoEvento
            ctx.Eventos.Add(novoEvento);

            // Salva as informações para serem gravadas no banco de dados
            ctx.SaveChanges();
        }

        /// <summary>
        /// Deleta um evento existente
        /// </summary>
        /// <param name="id">ID do evento que será deletado</param>
        public void Deletar(int id)
        {
            // Remove o evento que foi buscado
            ctx.Eventos.Remove(BuscarPorId(id));

            // Salva as alterações
            ctx.SaveChanges();
        }

        /// <summary>
        /// Lista todos os eventos
        /// </summary>
        /// <returns>Uma lista de eventos</returns>
        public List<Evento> Listar()
        {
            // Retorna uma lista com todas as informações dos eventos
            return ctx.Eventos
                // Adiciona na busca as informações do tipo de evento
                .Include(e => e.IdTipoEventoNavigation)
                // Adiciona na busca as informações da instituição
                .Include(e => e.IdInstituicaoNavigation)
                .ToList();
        }
    }
}
