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

            //se existe imagem de perfil para o usuario.
            if(imagemUsuario != null)
            {
                //Converte o valor de uma matriz de inteiros (byte) em string.
                return Convert.ToBase64String(imagemUsuario.Binario);
            }

            return null;
        }

        public string ConsultarPerfilDir(int id_usuario)
        {
            //Definimos o nome do arquivo com o ID_USUARIO + a extensão.
            string nome_arquivo = id_usuario.ToString() + ".png";

            string caminho = Path.Combine("perfil", nome_arquivo);

            //analise se o arquivo existe.
            if (File.Exists(caminho))
            {
                //recupera o array de bytes do arquivo.
                byte[] bytes_arquivo = File.ReadAllBytes(caminho);

                       //converte o array de byte em base64.
                return Convert.ToBase64String(bytes_arquivo);
            }

            return null;
        }

        public Usuario Login(string email, string senha)
        {
            return ctx.Usuarios.FirstOrDefault(u => u.Email == email && u.Senha == senha);
        }

        public void SalvarPerfilBD(IFormFile foto, int id_usuario)
        {
            //instancia do objeto ImagemUsuario
            ImagemUsuario imagemUsuario = new ImagemUsuario();

            using(var ms = new MemoryStream())
            {
                //copia a imagem enviada para memoria. (ms)
                foto.CopyTo(ms);
                //ToArray = byte de um elemento matriz.
                imagemUsuario.Binario = ms.ToArray();
                //nome do arquivo
                imagemUsuario.NomeArquivo = foto.FileName;
                //extensao do arquivo
                imagemUsuario.MimeType = foto.FileName.Split('.').Last();
                //id_usuario
                imagemUsuario.IdUsuario = id_usuario;
            }

            //Analisar se usuario ja possui foto de perfil.
            ImagemUsuario imagemExistente = new ImagemUsuario();
            imagemExistente = ctx.ImagemUsuarios.FirstOrDefault(i => i.IdUsuario == id_usuario);

            if(imagemExistente != null)
            {
                //atualizar imagem de perfil atual pelo novo objeto enviado.
                imagemExistente.Binario = imagemUsuario.Binario;
                imagemExistente.NomeArquivo = imagemUsuario.NomeArquivo;
                imagemExistente.MimeType = imagemUsuario.MimeType;
                imagemExistente.IdUsuario = id_usuario;

                ctx.ImagemUsuarios.Update(imagemExistente);
            }
            else
            {
                ctx.ImagemUsuarios.Add(imagemUsuario);
            }
          
            //salva as modificações.
            ctx.SaveChanges();

        }

        public void SalvarPerfilDir(IFormFile foto, int id_usuario)
        {
            //Definimos o nome do arquivo com o ID_USUARIO + a extensão.
            string nome_arquivo = id_usuario.ToString() + ".png";

            //FileStream fornece uma exbicicao para uma sequecia de bytes.
            // e tambem da suporte para leitura e gravação.
            using(var stream = new FileStream(Path.Combine("perfil", nome_arquivo), FileMode.Create))
            {
                //copia o arquivo foto para o caminho indicado.
                foto.CopyTo(stream);
            }
        }
    }
}
