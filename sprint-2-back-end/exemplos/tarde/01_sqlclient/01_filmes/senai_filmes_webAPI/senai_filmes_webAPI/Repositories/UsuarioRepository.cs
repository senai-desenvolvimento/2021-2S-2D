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
        //private string stringConexao = "Data Source=DESKTOP-U20H53U; initial catalog=catalogo_tarde; user id=sa; pwd=Senai@132";

        private string stringConexao = "Data Source=DESKTOP-U20H53U; initial catalog=catalogo_tarde; user id=sa; pwd=Senai@132";

        public UsuarioDomain BuscarPorEmailSenha(string email, string senha)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {

                string querySelect = @"    SELECT    idUsuario
			                                        ,email
			                                        ,senha
			                                        ,permissao
                                          FROM USUARIOS 
                                          WHERE email = @email
                                          and senha = @senha ";

                using (SqlCommand cmd = new SqlCommand(querySelect, con))
                {
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@senha", senha);

                    con.Open();

                    SqlDataReader rdr = cmd.ExecuteReader();

                    //caso os dados tenham sido obtidos
                    if (rdr.Read())
                    {
                        //cria um objeto do tipo UsuarioDomain
                        UsuarioDomain usuarioBuscado = new UsuarioDomain
                        {
                            //atribui às propriedades os valores das colunas do banco de dados
                            idUsuario = Convert.ToInt32(rdr["idUsuario"]),
                            email = rdr["email"].ToString(),
                            permissao = rdr["permissao"].ToString(),
                            senha = rdr["senha"].ToString()
                        };

                        //jwt.ex=  

                        //retorna o usuario buscado
                        return usuarioBuscado;

                    }

                    //Caso não encontre um email e senha correspondente, retorna null;
                    return null;

                }
            }
        }
    }
}
