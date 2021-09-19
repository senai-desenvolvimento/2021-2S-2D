using Microsoft.EntityFrameworkCore;
using senai_InLock_webApi_CodeFrist.Contexts;
using senai_InLock_webApi_CodeFrist.Domains;
using senai_InLock_webApi_CodeFrist.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_InLock_webApi_CodeFrist.Repositories
{
    public class EstudioRepository : IEstudioRepository
    {
        InLockContext ctx = new InLockContext();

        public void Atualizar(int idEstudio, Estudios estudioAtualizado)
        {
            Estudios estudioBuscado = ctx.Estudios.Find(idEstudio);

            if (estudioAtualizado.nomeEstudio != null)
            {
                estudioBuscado.nomeEstudio = estudioAtualizado.nomeEstudio;
                
                ctx.Estudios.Update(estudioBuscado);

                ctx.SaveChanges();
            }
        }

        public Estudios BuscarPorId(int idEstudio)
        {
            // Retorna um estúdio encontrado com o id informado
            return ctx.Estudios.FirstOrDefault(e => e.idEstudio == idEstudio);
        }

        public void Cadastrar(Estudios novoEstudio)
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

        public List<Estudios> Listar()
        {
            // Retorna uma lista de estúdios
            return ctx.Estudios.ToList();
        }

        public List<Estudios> ListarComJogos()
        {
            return ctx.Estudios.Include(e => e.jogos).ToList();
        }
    }
}
