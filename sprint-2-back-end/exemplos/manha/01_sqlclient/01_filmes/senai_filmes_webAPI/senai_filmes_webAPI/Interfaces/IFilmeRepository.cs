using senai_filmes_webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_filmes_webAPI.Interfaces
{
    /// <summary>
    /// Interface responsável pelo repositório FilmeRepository
    /// </summary>
    interface IFilmeRepository
    {
        List<FilmeDomain> ListarTodos();

        FilmeDomain BuscarPorId(int idFilme);

        void Cadastrar(FilmeDomain novoFilme);

        void AtualizarIdUrl(int idFilme, FilmeDomain filme);

        void Deletar(int idFilme);
    }
}
