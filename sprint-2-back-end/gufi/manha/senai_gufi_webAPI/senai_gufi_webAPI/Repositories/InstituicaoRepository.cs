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
    /// Classe responsável pelo repositório das instituições
    /// </summary>
    public class InstituicaoRepository : IInstituicaoRepository
    {
        /// <summary>
        /// Objeto contexto por onde serão chamados os métodos do EF Core
        /// </summary>
        GufiContext ctx = new GufiContext();

        /// <summary>
        /// Atualiza uma instituicao existente
        /// </summary>
        /// <param name="id">ID da instituicao que será atualizada</param>
        /// <param name="instituicaoAtualizada">Objeto com as novas informações</param>
        public void Atualizar(int id, Instituicao instituicaoAtualizada)
        {
            // Busca uma instituição através do id
            Instituicao instituicaoBuscada = ctx.Instituicaos.Find(id);

            // Verifica se o CNPJ foi informado
            if (instituicaoAtualizada.Cnpj != null)
            {
                // Atribui os novos valores ao campos existentes
                instituicaoBuscada.Cnpj = instituicaoAtualizada.Cnpj;
            }

            // Verifica se o endereço foi informado
            if (instituicaoAtualizada.Endereco != null)
            {
                // Atribui os novos valores ao campos existentes
                instituicaoBuscada.Endereco = instituicaoAtualizada.Endereco;
            }

            // Verifica se o nome fantasia foi informado
            if (instituicaoAtualizada.NomeFantasia != null)
            {
                // Atribui os novos valores ao campos existentes
                instituicaoBuscada.NomeFantasia = instituicaoAtualizada.NomeFantasia;
            }

            // Atualiza a instituição que foi buscada
            ctx.Instituicaos.Update(instituicaoBuscada);

            // Salva as informações para serem gravadas no banco
            ctx.SaveChanges();
        }

        /// <summary>
        /// Busca uma instituicao através do ID
        /// </summary>
        /// <param name="id">ID da instituicao que será buscada</param>
        /// <returns>Uma instituicao buscada</returns>
        public Instituicao BuscarPorId(int id)
        {
            // Retorna a primeira instituição encontrada para o ID informado
            return ctx.Instituicaos.FirstOrDefault(i => i.IdInstituicao == id);
        }

        /// <summary>
        /// Cadastra uma nova instituicao
        /// </summary>
        /// <param name="novaInstituicao">Objeto novaInstituicao que será cadastrada</param>
        public void Cadastrar(Instituicao novaInstituicao)
        {
            // Adiciona esta novaInstituicao
            ctx.Instituicaos.Add(novaInstituicao);

            // Salva as informações para serem gravadas no banco de dados
            ctx.SaveChanges();
        }

        /// <summary>
        /// Deleta uma instituicao existente
        /// </summary>
        /// <param name="id">ID da instituicao que será deletada</param>
        public void Deletar(int id)
        {
            // Remove a instituição que foi buscada
            ctx.Instituicaos.Remove(BuscarPorId(id));

            // Salva as alterações
            ctx.SaveChanges();
        }

        /// <summary>
        /// Lista todas as instituicoes
        /// </summary>
        /// <returns>Uma lista de instituicoes</returns>
        public List<Instituicao> Listar()
        {
            // Retorna uma lista com todas as informações das instituições
            return ctx.Instituicaos.ToList();
        }
    }
}
