using Microsoft.EntityFrameworkCore;
using senai_InLock_webAPI_CodeFirst.Contexts;
using senai_InLock_webAPI_CodeFirst.Domains;
using senai_InLock_webAPI_CodeFirst.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_InLock_webAPI_CodeFirst.Repositories
{
    public class EstudioRepository : IEstudioRepository
    {
        /// <summary>
        /// Objeto contexto por onde serão chamados os métodos do EF Core
        /// </summary>
        InLockContext ctx = new InLockContext();

        public void Atualizar(int idEstudio, Estudios estudioAtualizado)
        {
            // Busca um estúdio através do seu id
            //Estudio estudioBuscado = ctx.Estudios.Find(idEstudio);

            // Outra forma
            Estudios estudioBuscado = BuscarPorId(idEstudio);

            // Verifica se o novo nome do estúdio foi informado
            if (estudioAtualizado.nomeEstudio != null)
            {
                // Se sim, altera o valor da propriedade NomeEstudio
                estudioBuscado.nomeEstudio = estudioAtualizado.nomeEstudio;
            }

            // Atualiza o estúdio que foi buscado
            ctx.Estudios.Update(estudioBuscado);

            // Salva as informações que serão gravadas no banco de dados
            ctx.SaveChanges();
        }

        public Estudios BuscarPorId(int idEstudio)
        {
            // Retorna o primeiro estúdio encontrado para o ID informado
            return ctx.Estudios.FirstOrDefault(e => e.idEstudio == idEstudio);
        }

        public void Cadastrar(Estudios novoEstudio)
        {
            // Adiciona um novo estúdio
            ctx.Estudios.Add(novoEstudio);

            // Salva as informações que serão gravadas no banco de dados
            ctx.SaveChanges();
        }

        public void Deletar(int idEstudio)
        {
            // Busca um estúdio através do seu id
            Estudios estudioBuscado = BuscarPorId(idEstudio);

            // Remove o estúdio que foi buscado
            ctx.Estudios.Remove(estudioBuscado);

            // Salva as alterações que serão gravadas no banco de dados
            ctx.SaveChanges();
        }

        public List<Estudios> Listar()
        {
            // Retorna uma lista com todas as informações dos estúdios
            return ctx.Estudios.ToList();
        }

        public List<Estudios> ListarComJogos()
        {
            return ctx.Estudios.Include(e => e.jogos).ToList();
        }
    }
}
