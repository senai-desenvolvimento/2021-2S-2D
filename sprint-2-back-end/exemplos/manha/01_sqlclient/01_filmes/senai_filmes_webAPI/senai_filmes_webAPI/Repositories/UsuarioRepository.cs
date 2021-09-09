using senai_filmes_webAPI.Domains;
using senai_filmes_webAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai_filmes_webAPI.Repositories
{

    public class UsuarioRepository : IUsuarioRepository
    {
        //private string stringConexao = "Data source=DESKTOP-U20H53U; initial catalog=catalogo_manha; user Id=sa; pwd=Senai@132";

        private string stringConexao = "Data Source=DESKTOP-U20H53U; initial catalog=catalogo_manha; user id=sa; pwd=Senai@132";

        public UsuarioDomain BuscarPorEmailSenha(string email, string senha)
        {
            //Define a conexao con passando a string de conexão
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                //define o comando a ser executado no banco de dados.
                string querySelect = @"select  idUsuario,email, senha, permissao
	                                   from usuario
	                                   where email  = @email
	                                   and senha = @senha";

                //Define o comando cmd passando a query e a conexão
                using (SqlCommand cmd = new SqlCommand(querySelect, con))
                {
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@senha", senha);

                    //Abre conexão com o banco de dados.
                    con.Open();

                    //Executa o comando e armazena os dados no objeto rdr.
                    SqlDataReader rdr = cmd.ExecuteReader();

                    //Caso dados tenham sido obtidos.
                    if (rdr.Read())
                    {
                        //Cria um objeto do tipo UsuarioDomain
                        UsuarioDomain usuarioBuscado = new UsuarioDomain
                        {
                            //Atribui às propriedades os valores das colunas do banco de dados.
                            idUsuario = Convert.ToInt32(rdr["idUsuario"]),
                            email = rdr["email"].ToString(),
                            senha = rdr["senha"].ToString(),
                            permissao = rdr["permissao"].ToString()
                        };
                        //Retorna o usuário buscado
                        return usuarioBuscado;
                    }
                    //Caso não encontre um email e senha correspondente, retorna null.
                    return null;
                }
            }
        }
    }
}
