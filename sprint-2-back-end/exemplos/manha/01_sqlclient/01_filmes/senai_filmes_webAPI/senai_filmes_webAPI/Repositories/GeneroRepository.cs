using senai_filmes_webAPI.Domains;
using senai_filmes_webAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai_filmes_webAPI.Repositories
{
    public class GeneroRepository : IGeneroRepository
    {

        /// <summary>
        /// String de conexão com o banco de dados que recebe os parâmetros.
        /// Data Source = Nome do Servidor
        /// inital catalog = Nome do banco de dados
        /// user id= sa; pwd= Senai@132 = Faz a autenticação com o SQL SERVER, passando Login e Senha.
        /// integrated security = Faz a autenticação com o usuario do sistema (Windows).
        /// </summary>
        //private string stringConexao = "Data Source=DESKTOP-U20H53U; initial catalog=catalogo_manha; user id=sa; pwd=Senai@132";
        private string stringConexao = "Data Source=DESKTOP-30RGV41\\SQLEXPRESS; initial catalog=CATALOGO_M; user id=sa; pwd=senai@132";

        //private string stringConexao = "Data Source=DESKTOP-U20H53U; initial catalog=catalogo_manha; integrated security=true";


        public void AtualizarIdCorpo(GeneroDomain generoAtualizado)
        {
            if (generoAtualizado.nomeGenero != null)
            {
                using (SqlConnection con = new SqlConnection(stringConexao))
                {
                    string queryUpdateBody = "UPDATE GENERO SET nomeGenero = @novoNomeGen WHERE idGenero = @idGenAtualizado";

                    using (SqlCommand cmd = new SqlCommand(queryUpdateBody, con))
                    {
                        cmd.Parameters.AddWithValue("@novoNomeGen", generoAtualizado.nomeGenero);
                        cmd.Parameters.AddWithValue("@idGenAtualizado", generoAtualizado.idGenero);

                        con.Open();

                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        public void AtualizarIdUrl(int idGenero, GeneroDomain generoAtualizado)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryUpdateUrl = "UPDATE GENERO SET nomeGenero = @novoNomeGen WHERE idGenero = @idGenAtualizado";

                using (SqlCommand cmd = new SqlCommand(queryUpdateUrl, con))
                {
                    cmd.Parameters.AddWithValue("@novoNomeGen", generoAtualizado.nomeGenero);
                    cmd.Parameters.AddWithValue("@idGenAtualizado", idGenero);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public GeneroDomain BuscarPorId(int idGenero)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectById = "SELECT nomeGenero, idGenero FROM GENERO WHERE idGenero = @idGenero";

                con.Open();

                SqlDataReader reader;

                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    cmd.Parameters.AddWithValue("@idGenero", idGenero);

                    reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        GeneroDomain generoBuscado = new GeneroDomain
                        {
                            idGenero = Convert.ToInt32(reader["idGenero"]),

                            nomeGenero = reader["nomeGenero"].ToString()
                        };

                        return generoBuscado;
                    }

                    return null;
                }
            }
        }

        /// <summary>
        /// Cadastrar um novo gênero.
        /// </summary>
        /// <param name="novoGenero">Objeto novoGenero com as informações que serão cadastradas.</param>
        public void Cadastrar(GeneroDomain novoGenero)
        {
            // Declara a conexão passando a string de conexão como parâmetro
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Declara a query que será executada
                                     // "INSERT INTO GENERO (nomeGenero) VALUES ('Joana D'Arc')"
                                     // "INSERT INTO Generos (Nome) VALUES ('" + ')DROP TABLE Filmes-- + "')"
                // string queryInsert = "INSERT INTO GENERO (nomeGenero) VALUES ('" + novoGenero.nomeGenero + "')";

                // Não usar dessa forma, pois pode causar o efeito Joana D'Arc
                // Além de permitir SQL Injection 
                // Por exemplo
                // "nomeGenero" : "')DROP TABLE FILME--";

                // Ao tentar cadastrar um gênero com o comando acima, irá deletar a tabela FILME do banco de dados
                // https://www.devmedia.com.br/sql-injection/6102

                string queryInsert = "INSERT INTO GENERO (nomeGenero) VALUES (@nomeGenero)";

                // Declara o SqlCommand cmd passando a query que será executada e a conexão como parâmetros
                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    // Passa o valor do parâmetro @nomeGenero
                    cmd.Parameters.AddWithValue("@nomeGenero", novoGenero.nomeGenero);

                    // Abre a conexão com o banco de dados
                    con.Open();

                    // Executa a query
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Deleta um gênero através do seu id
        /// </summary>
        /// <param name="idGenero">id do gênero que será deletado</param>
        public void Deletar(int idGenero)
        {
            // Declara a SqlConnection con passando a string de conexão como parâmetro
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Declara a query a ser executada passando o valor como parâmetro
                string queryDelete = "DELETE FROM GENERO WHERE idGenero = @id";

                // Declara o SqlCommand cmd passando a query que será executada e a conexão como parâmetros
                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    // Define o valor do id recebido no método como o valor do parâmetro @ID
                    cmd.Parameters.AddWithValue("@id", idGenero);

                    // Abre a conexão com o banco de dados
                    con.Open();

                    // Executa o comando
                    cmd.ExecuteNonQuery();
                }
            }
        }
        
        /// <summary>
        /// Lista todos os gêneros
        /// </summary>
        /// <returns>lista de gêneros</returns>
        public List<GeneroDomain> ListarTodos()
        {
            //Cria uma listaGeneros onde serão armazenados os dados.
            List<GeneroDomain> listaGenero = new List<GeneroDomain>();

            //Declara a SQL connection con passando a string de conexao como parametro.
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                //Declara a instrucao a ser executada
                string querySelectALL = "SELECT idGenero,nomeGenero FROM GENERO;";

                //Abre a conexão com o banco de dados.
                con.Open();

                //Declara o SqlDataReader rar para percorrer a tabela do banco de dados.
                SqlDataReader rdr;

                //Declara o SQLCommand cmd passando a query que sera executada e a conexão com parâmetros.
                using (SqlCommand cmd = new SqlCommand(querySelectALL, con))
                {
                    //executa a query e armaneza os dados no rdr.
                    rdr = cmd.ExecuteReader();

                    //Enquanto houver registros para serem lidos no rdr, o laço se repete.
                    while (rdr.Read())
                    {
                        //Instancia um objeto genero do tipo GeneroDomain
                        GeneroDomain genero = new GeneroDomain()
                        {
                            //atribui a propriedade idGenero o valor da primeira coluna na tabela do banco de dados.
                            idGenero = Convert.ToInt32(rdr[0]),

                            //atribui a propriedade nomeGenero o valor da segunda coluna na tabela do banco de dados.
                            nomeGenero = rdr[1].ToString()
                        };

                        //Adicionar o objeto genero criado a lista listaGeneros.
                        listaGenero.Add(genero);
                    }
                }
            }

            return listaGenero;
        }
    }
}
