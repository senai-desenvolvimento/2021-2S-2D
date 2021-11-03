using Microsoft.AspNetCore.Http;
using senai_gufi_webAPI.Context;
using senai_gufi_webAPI.Domains;
using senai_gufi_webAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace senai_gufi_webAPI.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        GufiContext ctx = new GufiContext();

        public string ConsultarPerfilBD(int id_usuario)
        {
            ImagemUsuario imagemUsuario = new ImagemUsuario();          

            imagemUsuario = ctx.ImagemUsuarios.FirstOrDefault(i => i.IdUsuario == id_usuario);

            if(imagemUsuario != null)
            {
                //Converte o valor de uma matriz de inteiros (array de binarios) em string.
                return Convert.ToBase64String(imagemUsuario.Binario);
            }

            return null;
        }

        public string ConsultarPerfilDir(int id_usuario)
        {
            string nome_novo = id_usuario.ToString() + ".png";
            string caminho = Path.Combine("Perfil", nome_novo);

            //analisa se o arquivo existe.
            if (File.Exists(caminho))
            {
               //recupera o array de bytes.
               byte[] bytesArquivo = File.ReadAllBytes(caminho);
                //converte em base 64.
                return Convert.ToBase64String(bytesArquivo);
            }

            return null;

        }

        public Usuario Login(string email, string senha)
        {
            return ctx.Usuarios.FirstOrDefault(u => u.Email == email && u.Senha == senha);
        }

        public void SalvarPerfilBD(IFormFile foto, int id_usuario)
        {
            //instancia do objeto ImagemUsuario para gravar o arquivo no BD.
            ImagemUsuario imagemUsuario = new ImagemUsuario();

            using(var ms = new MemoryStream())
            {
                //copia a imagem enviada para a memoria.
                foto.CopyTo(ms);
                //ToArray = são os bytes da imagem.
                imagemUsuario.Binario = ms.ToArray();
                //nome do arquivo
                imagemUsuario.NomeArquivo = foto.FileName;
                //extensão do arquivo
                imagemUsuario.MimeType = foto.FileName.Split('.').Last();
                //id_usuario
                imagemUsuario.IdUsuario = id_usuario;
            }

            //ANALISAR SE O USUARIO JA POSSUI FOTO DE PERFIL
            ImagemUsuario fotoexistente = new ImagemUsuario();
            fotoexistente = ctx.ImagemUsuarios.FirstOrDefault(i => i.IdUsuario == id_usuario);

            if(fotoexistente != null)
            {
                fotoexistente.Binario = imagemUsuario.Binario;
                fotoexistente.NomeArquivo = imagemUsuario.NomeArquivo;
                fotoexistente.MimeType = imagemUsuario.MimeType;
                fotoexistente.IdUsuario = id_usuario;

                //atualiza a imagem de perfil do usuario.
                ctx.ImagemUsuarios.Update(fotoexistente);
            }
            else
            {
                ctx.ImagemUsuarios.Add(imagemUsuario);
            }

           //salvar as modificações.
            ctx.SaveChanges();
        }

        public void SalvarPerfilDir(IFormFile foto, int id_usuario)
        {

            //Define o nome do arquivo com o ID do Usuario + .png
            string nome_novo = id_usuario.ToString() + ".png";

            //FileStreama fornece uma exibicao para para uma sequencia de bytes.
            //dando suporte para leitura e gravação.

            using (var stream = new FileStream(Path.Combine("perfil", nome_novo), FileMode.Create))
            {
                //copia todos os elementos (array de bytes) para o caminho indicado.
                foto.CopyTo(stream);
            }
        }



        /// <summary>
        /// Atualiza um usuário existente
        /// </summary>
        /// <param name="id">ID do usuário que será atualizado</param>
        /// <param name="usuarioAtualizado">Objeto com as novas informações</param>
        public void Atualizar(int id, Usuario usuarioAtualizado)
        {
            // Busca um usuário através do id
            Usuario usuarioBuscado = ctx.Usuarios.Find(id);

            // Verifica se o nome do usuário foi informado
            if (usuarioAtualizado.NomeUsuario != null)
            {
                // Atribui os novos valores ao campos existentes
                usuarioBuscado.NomeUsuario = usuarioAtualizado.NomeUsuario;
            }

            // Verifica se o e-mail do usuário foi informado
            if (usuarioAtualizado.Email != null)
            {
                // Atribui os novos valores ao campos existentes
                usuarioBuscado.Email = usuarioAtualizado.Email;
            }

            // Verifica se a senha do usuário foi informado
            if (usuarioAtualizado.Senha != null)
            {
                // Atribui os novos valores ao campos existentes
                usuarioBuscado.Senha = usuarioAtualizado.Senha;
            }

            // Atualiza o tipo de usuário que foi buscado
            ctx.Usuarios.Update(usuarioBuscado);

            // Salva as informações para serem gravadas no banco
            ctx.SaveChanges();
        }

        /// <summary>
        /// Busca um usuário através do ID
        /// </summary>
        /// <param name="id">ID do usuário que será buscado</param>
        /// <returns>Um usuário buscado</returns>
        public Usuario BuscarPorId(int id)
        {
            // Retorna o primeiro usuário encontrado para o ID informado, sem exibir sua senha
            return ctx.Usuarios
                .Select(u => new Usuario()
                {
                    IdUsuario = u.IdUsuario,
                    NomeUsuario = u.NomeUsuario,
                    Email = u.Email,
                    IdTipoUsuario = u.IdTipoUsuario,

                    IdTipoUsuarioNavigation = new TipoUsuario()
                    {
                        IdTipoUsuario = u.IdTipoUsuarioNavigation.IdTipoUsuario,
                        TituloTipoUsuario = u.IdTipoUsuarioNavigation.TituloTipoUsuario
                    }
                })
                .FirstOrDefault(u => u.IdUsuario == id);
        }

        /// <summary>
        /// Cadastra um novo usuário
        /// </summary>
        /// <param name="novoUsuario">Objeto novoUsuario que será cadastrado</param>
        public void Cadastrar(Usuario novoUsuario)
        {
            // Adiciona este novoUsuario
            ctx.Usuarios.Add(novoUsuario);

            // Salva as informações para serem gravadas no banco de dados
            ctx.SaveChanges();
        }

        /// <summary>
        /// Deleta um usuário existente
        /// </summary>
        /// <param name="id">ID do usuário que será deletado</param>
        public void Deletar(int id)
        {
            // Remove o tipo de usuário que foi buscado
            ctx.Usuarios.Remove(BuscarPorId(id));

            // Salva as alterações
            ctx.SaveChanges();
        }

        /// <summary>
        /// Lista todos os usuários
        /// </summary>
        /// <returns>Uma lista de usuários</returns>
        public List<Usuario> Listar()
        {
            // Retorna uma lista com todas as informações dos tipos de usuários, exceto as senhas
            return ctx.Usuarios
                .Select(u => new Usuario()
                {
                    IdUsuario = u.IdUsuario,
                    NomeUsuario = u.NomeUsuario,
                    Email = u.Email,
                    IdTipoUsuario = u.IdTipoUsuario,

                    IdTipoUsuarioNavigation = new TipoUsuario()
                    {
                        IdTipoUsuario = u.IdTipoUsuarioNavigation.IdTipoUsuario,
                        TituloTipoUsuario = u.IdTipoUsuarioNavigation.TituloTipoUsuario
                    }
                })
                .ToList();
        }

      
       
    }
}
