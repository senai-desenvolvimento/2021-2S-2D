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
        GufiContext ctx = new GufiContext();

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
            //inscricao.IdSituacao = 3;

            ctx.Presencas.Add(inscricao);

            ctx.SaveChanges();
        }

        public List<Presenca> ListarMinhas(int idUsuario)
        {
            // Retorna uma lista com todas as informações das presenças
            return ctx.Presencas
                .Include(p => p.IdUsuarioNavigation)
                .Include(p => p.IdEventoNavigation.IdTipoEventoNavigation)
                .Include(p => p.IdEventoNavigation.IdInstituicaoNavigation)
                .Include("IdSituacaoNavigation")
                // Estabele como parâmetro de consulta o ID do usuário recebido
                .Where(p => p.IdUsuario == idUsuario)
                .ToList();
        }
    }
}
