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
    }
}
