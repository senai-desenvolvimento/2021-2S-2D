using Microsoft.EntityFrameworkCore;
using senai_InLock_webApi_CodeFrist.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_InLock_webApi_CodeFrist.Contexts
{
    /// <summary>
    /// Classe responsável pelo contexto do projeto
    /// Faz a comunicação entre a API e o banco de dados
    /// </summary>
    public class InLockContext : DbContext
    {
        //Define as entidades do banco de dados
        public DbSet<TiposUsuario> TiposUsuarios { get; set; }
        public DbSet<Estudios> Estudios { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Jogos> Jogos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer("Server=DESKTOP-U20H53U; Database=InLock_Games_CodeFirst; user ID=sa; pwd=Senai@132");

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //Define as entidade já com dados.
            
            //Not NULL
            //modelBuilder.Entity<TiposUsuario>(entity =>
            //{
            //    entity.HasIndex(u => u.titulo).IsUnique();
            //}
            //);



            modelBuilder.Entity<TiposUsuario>().HasData(

                new TiposUsuario
                {
                    idTipoUsuario = 2,
                    titulo = "Administrador"
                },

                 new TiposUsuario
                 {
                     idTipoUsuario = 4,
                     titulo = "Cliente"
                 }
                );


            modelBuilder.Entity<Usuarios>().HasData(

                new Usuarios
                {
                    idUsuario = 1,
                    email = "admim@admin.com",
                    senha = "admin",
                    idTipoUsuario = 2
                },
                new Usuarios
                {
                    idUsuario = 2,
                    email = "cliente@cliente.com",
                    senha = "cliente",
                    idTipoUsuario = 4
                }

                );

            modelBuilder.Entity<Estudios>().HasData(
                
                new Estudios { idEstudio = 1, nomeEstudio = "Blizzard" },
                new Estudios { idEstudio =2 , nomeEstudio = "RockStar Studios" },
                new Estudios { idEstudio = 3, nomeEstudio = "Square Enix" }

                );

            modelBuilder.Entity<Jogos>().HasData(

                new Jogos
                {
                    idJogo = 1,
                    nomeJogo = "Diablo 3",
                    dataLancamento = Convert.ToDateTime("15/05/2021"),
                    descricao = "É um jogo que contém bastante ação...",
                    valor = Convert.ToDecimal("99,00"),
                    idEstudio = 1
                }
                ,
                 new Jogos
                 {
                     idJogo = 2,
                     nomeJogo = "Red Dead Redemption II",
                     dataLancamento = Convert.ToDateTime("26/10/2018"),
                     descricao = "É um jogo eletônico de ação-aventura...",
                     valor = Convert.ToDecimal("120,00"),
                     idEstudio = 2
                 }
                );


            base.OnModelCreating(modelBuilder);

        }
    }
}
