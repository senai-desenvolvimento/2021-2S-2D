using senai_filmes_webAPI.Domains;
using senai_filmes_webAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai_filmes_webAPI.Repositories
{
    /// <summary>
    /// Classe responsável pelo repositório dos gêneros
    /// </summary>
    public class GeneroRepository : IGeneroRepository
    {

        /// <summary>
        /// String de conexão com o banco de dados que recebe os parâmetros.
        /// Data Source= Nome do Servidor
        /// initial catalog = Nome do Banco de Dados
        /// user ID= sa; pwd= Senai@132 = Faz autenticação com o SQL SERVER passando o Login e Senha.
        /// integrated security=true = Faz autenticação com o usuario do sistema (Windows)
        /// 
        /// </summary>
        private string stringConexao = "Data Source=DESKTOP-U20H53U; initial catalog=catalogo_tarde; user Id=sa; pwd=Senai@132";

       
        /// <param name="generoAtualizado"></param>
        //private string stringConexao = "Data Source=DESKTOP-U20H53U; initial catalog=catalogo_tarde; integrated security=true";

        public void AtualizarIdCorpo(GeneroDomain generoAtualizado)
        {
            throw new NotImplementedException();
        }

        public void AtualizarIdUrl(int idGenero, GeneroDomain generoAtualizado)
        {
            throw new NotImplementedException();
        }

        public GeneroDomain BuscarPorId(int idGenero)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Cadastro um novo gênero
        /// </summary>
        /// <param name="novoGenero">Objeto nomeGenero com as informações que serão cadastradas.</param>
        public void Cadastrar(GeneroDomain novoGenero)
        {
            using(SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = "INSERT INTO GENERO (nomeGenero) VALUES ('" + novoGenero.nomeGenero + "')";

                con.Open();

                using(SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    //Executa a query
                    cmd.ExecuteNonQuery();
                }
            }            
        }

        public void Deletar(int idGenero)
        {
            throw new NotImplementedException();
        }

        
        public List<GeneroDomain> ListarTodos()
        {
            List<GeneroDomain> listaGeneros = new List<GeneroDomain>();

            //Declara a SqlConnection con passando a string de conexao como Parametro.
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = "SELECT idGenero, nomeGenero FROM GENERO";

                //Abre a conexão com o banco de dados.
                con.Open();

                //Declarando  SqlDataReader rdr percorrer a tabela do nosso banco de dados.
                SqlDataReader rdr;

                //Declara o SqlCommand passando da query que será executada e a conexão com parametros.
                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    //executa a query e armeza os dados no rdr. 
                    rdr = cmd.ExecuteReader();

                    //Enquanto houver registros para serem lidos no rdr, o laço se repete.
                    while (rdr.Read())
                    {
                        //instancia um objeto genero do tipo GeneroDomain
                        GeneroDomain genero = new GeneroDomain()
                        {
                            //atribui a propriedade idGenero o valor da primeira coluna do bando de dados.
                            idGenero = Convert.ToInt32(rdr[0]),

                            //atribui a propriedade  o valor da segunda coluna da tabela do banco de dados.
                            nomeGenero = rdr[1].ToString()
                        };

                        //adiciona o objeto genero criado a lista listaGeneros
                        listaGeneros.Add(genero);
                    }
                }
            }

            return listaGeneros;
        }
    }
}
