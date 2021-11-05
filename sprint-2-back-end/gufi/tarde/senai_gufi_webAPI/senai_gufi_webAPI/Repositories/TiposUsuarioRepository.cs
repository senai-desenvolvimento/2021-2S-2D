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
    /// Classe responsável pelo repositório dos tipos de usuários
    /// </summary>
    public class TiposUsuarioRepository : ITiposUsuarioRepository
    {
        /// <summary>
        /// Objeto contexto por onde serão chamados os métodos do EF Core
        /// </summary>
        GufiContext ctx = new GufiContext();

        /// <summary>
        /// Atualiza um tipo de usuário existente
        /// </summary>
        /// <param name="id">ID do tipo de usuário que será atualizado</param>
        /// <param name="tipoUsuarioAtualizado">Objeto com as novas informações</param>
        public void Atualizar(int id, TipoUsuario tipoUsuarioAtualizado)
        {
            // Busca um tipo de usuário através do id
            TipoUsuario tipoUsuarioBuscado = ctx.TipoUsuarios.Find(id);

            // Verifica se o título do tipo de usuário foi informado
            if (tipoUsuarioAtualizado.TituloTipoUsuario != null)
            {
                // Atribui os novos valores ao campos existentes
                tipoUsuarioBuscado.TituloTipoUsuario = tipoUsuarioAtualizado.TituloTipoUsuario;
            }

            // Atualiza o tipo de usuário que foi buscado
            ctx.TipoUsuarios.Update(tipoUsuarioBuscado);

            // Salva as informações para serem gravadas no banco
            ctx.SaveChanges();
        }

        /// <summary>
        /// Busca um tipo de usuário através do ID
        /// </summary>
        /// <param name="id">ID do tipo de usuário que será buscado</param>
        /// <returns>Um tipo de usuário buscado</returns>
        public TipoUsuario BuscarPorId(int id)
        {
            // Retorna o primeiro tipo de usuário encontrado para o ID informado
            return ctx.TipoUsuarios.FirstOrDefault(tu => tu.IdTipoUsuario == id);
        }

        /// <summary>
        /// Cadastra um novo tipo de usuário
        /// </summary>
        /// <param name="novoTipoUsuario">Objeto novoTipoUsuario que será cadastrado</param>
        public void Cadastrar(TipoUsuario novoTipoUsuario)
        {
            // Adiciona este novoTipoUsuario
            ctx.TipoUsuarios.Add(novoTipoUsuario);

            // Salva as informações para serem gravadas no banco de dados
            ctx.SaveChanges();
        }

        /// <summary>
        /// Deleta um tipo de usuário existente
        /// </summary>
        /// <param name="id">ID do tipo de usuário que será deletado</param>
        public void Deletar(int id)
        {
            // Busca um tipo de usuário através do id
            TipoUsuario tipoUsuarioBuscado = ctx.TipoUsuarios.Find(id);

            // Remove o tipo de usuário que foi buscado
            ctx.TipoUsuarios.Remove(tipoUsuarioBuscado);

            // Salva as alterações
            ctx.SaveChanges();
        }

        /// <summary>
        /// Lista todos os tipos de usuários
        /// </summary>
        /// <returns>Uma lista de tipos de usuários</returns>
        public List<TipoUsuario> Listar()
        {
            // Retorna uma lista com todas as informações dos tipos de usuários
            return ctx.TipoUsuarios.ToList();
        }
    }
}
