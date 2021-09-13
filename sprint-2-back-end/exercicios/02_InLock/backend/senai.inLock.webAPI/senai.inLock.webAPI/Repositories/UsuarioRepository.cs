using senai.inLock.webAPI.Domains;
using senai.inLock.webAPI.Interfaces;
using System;
using System.Data.SqlClient;

namespace senai.inLock.webAPI.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly string stringConexao = "Data Source=DESKTOP-PM35QPG\\SQLEXPRESS; initial catalog=inLockGames; user Id=sa; pwd=senai@132";

        public Usuario Login(string email, string senha)
        {
            // Define a conexão con passando a string de conexão
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Define o comando a ser executado no banco de dados
                string querySelect = "SELECT idUsuario, email, U.idTipoUsuario, TU.titulo " +
                                     "FROM usuario U INNER JOIN tipoUsuario TU ON U.idTipoUsuario = TU.idTipoUsuario " +
                                     "WHERE email = @email AND senha = @senha";

                // Define o comando cmd passando a query e a conexão
                using (SqlCommand cmd = new SqlCommand(querySelect, con))
                {
                    // Define os valores dos parâmetros
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@senha", senha);

                    // Abre a conexão com o banco de dados
                    con.Open();

                    // Executa o comando e armazena os dados no objeto rdr
                    SqlDataReader rdr = cmd.ExecuteReader();

                    // Caso dados tenham sido obtidos
                    if (rdr.Read())
                    {
                        // Cria um objeto do tipo UsuarioDomain
                        Usuario usuarioBuscado = new Usuario
                        {
                            // Atribui às propriedades os valores das colunas do banco de dados
                            IdUsuario = Convert.ToInt32(rdr["idUsuario"]),
                            Email = rdr["email"].ToString(),
                            IdTipoUsuario = Convert.ToInt32(rdr["idTipoUsuario"]),
                            TipoUsuario = new TipoUsuario()
                            {
                                Titulo = rdr["titulo"].ToString()
                            }
                        };

                        // Retorna o usuário buscado
                        return usuarioBuscado;
                    }

                    // Caso não encontre um email e senha correspondente, retorna null
                    return null;
                }
            }
        }
    }
}
