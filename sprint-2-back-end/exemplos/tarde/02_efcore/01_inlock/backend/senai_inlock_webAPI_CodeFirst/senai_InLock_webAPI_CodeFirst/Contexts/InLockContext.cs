using Microsoft.EntityFrameworkCore;
using senai_InLock_webAPI_CodeFirst.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_InLock_webAPI_CodeFirst.Contexts
{
    /// <summary>
    /// Classe responsável pelo contexto do projeto
    /// Faz a comunicação entre a API e o banco de Dados.
    /// </summary>
    public class InLockContext : DbContext
    {
        //Define as entidade do banco de dados
        public DbSet<TiposUsuario> TiposUsuario { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Jogos> Jogos { get; set; }
        public DbSet<Estudios> Estudios { get; set; }


        /// <summary>
        /// Define as opções de construção do banco de dados
        /// </summary>
        /// <param name="optionsBuilder">Objeto com as configurações definidas</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-U20H53U; DataBase=InLock_Games_CodeFirst; user ID=sa; pwd=Senai@132;");

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

           // modelBuilder.Entity<TiposUsuario>(entity => entity.HasIndex(u => u.titulo).IsUnique());


            modelBuilder.Entity<TiposUsuario>().HasData(

                    new TiposUsuario
                    {
                        idTipoUsuario = 2,
                        titulo = "Administrador"
                    },
                    new TiposUsuario
                    {
                        idTipoUsuario = 3,
                        titulo = "Cliente"
                    }                    

                );


            modelBuilder.Entity<Usuarios>().HasData(

                new Usuarios
                {
                    idUsuario = 1,
                    email = "admin@admin.com",
                    senha = "admin",
                    idTipoUsuario = 2
                },

                new Usuarios
                {
                    idUsuario = 2,
                    email = "cliente@cliente.com",
                    senha = "cliente",
                    idTipoUsuario = 3
                }
                );

            modelBuilder.Entity<Estudios>().HasData(

                 new Estudios { idEstudio = 1, nomeEstudio = "Blizzard" },
                 new Estudios { idEstudio = 2, nomeEstudio = "Rockstar Studios" },
                 new Estudios { idEstudio = 3, nomeEstudio = "Square Enix" }
                );

            modelBuilder.Entity<Jogos>().HasData(

                new Jogos
                {
                    idJogo = 1,
                    nomeJogo = "Diablo 3",
                    dataLancamento = Convert.ToDateTime("15/05/2012"),
                    descricao = "É uma jogo que contém bastante ação...",
                    valor = Convert.ToDecimal("99,00"),
                    idEstudio = 1
                },

                 new Jogos
                 {
                     idJogo = 2,
                     nomeJogo = "Red Dead Remption II",
                     dataLancamento = Convert.ToDateTime("26/10/2018"),
                     descricao = "Jogo Eletrônico de ação-aventura...",
                     valor = Convert.ToDecimal("120,00"),
                     idEstudio = 2
                 }
                );

            base.OnModelCreating(modelBuilder);
        }
    }
}
