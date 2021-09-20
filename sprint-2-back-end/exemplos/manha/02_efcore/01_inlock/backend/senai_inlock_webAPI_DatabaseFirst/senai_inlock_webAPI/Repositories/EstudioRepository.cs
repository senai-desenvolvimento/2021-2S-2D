using Microsoft.EntityFrameworkCore;
using senai_inlock_webAPI.Contexts;
using senai_inlock_webAPI.Domains;
using senai_inlock_webAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_inlock_webAPI.Repositories
{
    public class EstudioRepository : IEstudioRepository
    {
        /// <summary>
        /// Objeto contexto por onde serão chamados os métodos do EF Core
        /// </summary>
        InLockContext ctx = new InLockContext();

        public void Atualizar(int idEstudio, Estudio estudioAtualizado)
        {
            // Busca um estúdio através do seu id
            //Estudio estudioBuscado = ctx.Estudios.Find(idEstudio);

            // Outra forma
            Estudio estudioBuscado = BuscarPorId(idEstudio);

            // Verifica se o novo nome do estúdio foi informado
            if (estudioAtualizado.NomeEstudio != null)
            {
                // Se sim, altera o valor da propriedade NomeEstudio
                estudioBuscado.NomeEstudio = estudioAtualizado.NomeEstudio;
            }

            // Atualiza o estúdio que foi buscado
            ctx.Estudios.Update(estudioBuscado);

            // Salva as informações que serão gravadas no banco de dados
            ctx.SaveChanges();
        }

        public Estudio BuscarPorId(int idEstudio)
        {
            // Retorna o primeiro estúdio encontrado para o ID informado
            return ctx.Estudios.FirstOrDefault(e => e.IdEstudio == idEstudio);
        }

        public void Cadastrar(Estudio novoEstudio)
        {
            // Adiciona um novo estúdio
            ctx.Estudios.Add(novoEstudio);

            // Salva as informações que serão gravadas no banco de dados
            ctx.SaveChanges();
        }

        public void Deletar(int idEstudio)
        {
            // Busca um estúdio através do seu id
            Estudio estudioBuscado = BuscarPorId(idEstudio);

            // Remove o estúdio que foi buscado
            ctx.Estudios.Remove(estudioBuscado);

            // Salva as alterações que serão gravadas no banco de dados
            ctx.SaveChanges();
        }

        public List<Estudio> Listar()
        {
            // Retorna uma lista com todas as informações dos estúdios
            return ctx.Estudios.ToList();
        }

        public List<Estudio> ListarComJogos()
        {
            return ctx.Estudios.Include(e => e.Jogos).ToList();
        }
    }
}
