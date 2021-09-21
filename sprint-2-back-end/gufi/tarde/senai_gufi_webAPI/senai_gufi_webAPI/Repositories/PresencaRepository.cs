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
    /// Repositório responsável pelas presenças
    /// </summary>
    public class PresencaRepository : IPresencaRepository
    {
        /// <summary>
        /// Objeto contexto por onde serão chamados os métodos do EF Core
        /// </summary>
        GufiContext ctx = new();

        public void AprovarRecusar(int idPresenca, string status)
        {
            Presenca presencaBuscada = ctx.Presencas
                .FirstOrDefault(p => p.IdPresenca == idPresenca);

            switch (status)
            {
                case "1":
                    presencaBuscada.IdSituacao = 1;
                    break;

                case "2":
                    presencaBuscada.IdSituacao = 2;
                    break;

                case "3":
                    presencaBuscada.IdSituacao = 3;
                    break;

                default:
                    presencaBuscada.IdSituacao = presencaBuscada.IdSituacao;
                    break;
            }

            ctx.Presencas.Update(presencaBuscada);

            ctx.SaveChanges();
        }

        public void Inscrever(Presenca inscricao)
        {
            ctx.Presencas.Add(inscricao);

            ctx.SaveChanges();
        }

        public List<Presenca> ListarMinhas(int idUsuario)
        {
            return ctx.Presencas
                //.Include(p => p.IdEventoNavigation).ThenInclude(e => e.IdTipoEventoNavigation)
                .Include(p => p.IdEventoNavigation.IdTipoEventoNavigation)
                .Include("IdSituacaoNavigation")
                .Include(p => p.IdEventoNavigation.IdInstituicaoNavigation)
                .Where(p => p.IdUsuario == idUsuario)
                .ToList();
        }
    }
}
