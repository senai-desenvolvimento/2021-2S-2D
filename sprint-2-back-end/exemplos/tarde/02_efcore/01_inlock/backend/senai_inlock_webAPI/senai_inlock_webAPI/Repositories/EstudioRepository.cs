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
        InLockContext ctx = new InLockContext();

        public void Atualizar(int idEstudio, Estudio estudioAtualizado)
        {
            Estudio estudioBuscado = ctx.Estudios.Find(idEstudio);

            if (estudioAtualizado.NomeEstudio != null)
            {
                estudioBuscado.NomeEstudio = estudioAtualizado.NomeEstudio;
                
                ctx.Estudios.Update(estudioBuscado);

                ctx.SaveChanges();
            }
        }

        public Estudio BuscarPorId(int idEstudio)
        {
            // Retorna um estúdio encontrado com o id informado
            return ctx.Estudios.FirstOrDefault(e => e.IdEstudio == idEstudio);
        }

        public void Cadastrar(Estudio novoEstudio)
        {
            // Adiciona este novoEstudio
            ctx.Estudios.Add(novoEstudio);

            // Salva as informações que serão gravadas no banco de dados
            ctx.SaveChanges();
        }

        public void Deletar(int idEstudio)
        {
            // Outra forma
            // Estudio estudioBuscado = BuscarPorId(idEstudio);

            ctx.Estudios.Remove(BuscarPorId(idEstudio));

            ctx.SaveChanges();
        }

        public List<Estudio> Listar()
        {
            // Retorna uma lista de estúdios
            return ctx.Estudios.ToList();
        }

        public List<Estudio> ListarComJogos()
        {
            return ctx.Estudios.Include(e => e.Jogos).ToList();
        }
    }
}
