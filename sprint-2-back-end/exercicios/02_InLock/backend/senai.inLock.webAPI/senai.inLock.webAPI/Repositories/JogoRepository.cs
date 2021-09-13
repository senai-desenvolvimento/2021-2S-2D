using senai.inLock.webAPI.Domains;
using senai.inLock.webAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace senai.inLock.webAPI.Repositories
{
    public class JogoRepository : IJogoRepository
    {
        private readonly string stringConexao = "Data Source=DESKTOP-PM35QPG\\SQLEXPRESS; initial catalog=inLockGames; user Id=sa; pwd=senai@132";

        public void Atualizar(int id, Jogo jogoAtualizado)
        {
            throw new NotImplementedException();
        }

        public Jogo BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Jogo novoJogo)
        {
            // Declara a SqlConnection con passando a string de conexão como parâmetro
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Declara a query que será executada
                string queryInsert = "INSERT INTO jogo(nomeJogo, descricao, dataLancamento, valor, idEstudio)" +
                                     "VALUES(@nomeJogo, @descricao, @dataLancamento, @valor, @idEstudio)";

                // Declara o SqlCommand cmd passando a query que será executada e a conexão como parâmetros
                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    // Passa o valor para o parâmetro @nomeJogo
                    cmd.Parameters.AddWithValue("@nomeJogo", novoJogo.NomeJogo);
                    cmd.Parameters.AddWithValue("@descricao", novoJogo.Descricao);
                    cmd.Parameters.AddWithValue("@dataLancamento", novoJogo.DataLancamento);
                    cmd.Parameters.AddWithValue("@valor", novoJogo.Valor);
                    cmd.Parameters.AddWithValue("@idEstudio", novoJogo.IdEstudio);

                    // Abre a conexão com o banco de dados
                    con.Open();

                    // Executa a query
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }

        public List<Jogo> ListarTodos()
        {
            // Cria uma lista listaJogos onde serão armazenados os dados
            List<Jogo> listaJogos = new List<Jogo>();

            // Declara a SqlConnection con passando a string de conexão como parâmetro
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Declara a instrução a ser executada
                string querySelectAll = "SELECT J.idJogo, nomeJogo, descricao, dataLancamento, valor, J.idEstudio, E.nomeEstudio FROM jogo J " +
                                        "INNER JOIN estudio E " +
                                        "ON J.idEstudio = E.idEstudio";

                // Abre a conexão com o banco de dados
                con.Open();

                // Declara o SqlDataReader rdr para percorrer a tabela do banco de dados
                SqlDataReader rdr;

                // Declara o SqlCommand cmd passando a query que será executada e a conexão como parâmetros
                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    // Executa a query e armazena os dados no rdr
                    rdr = cmd.ExecuteReader();

                    // Enquanto houver registros para serem lidos no rdr, o laço se repete
                    while (rdr.Read())
                    {
                        // Instacia um objeto jogo do tipo Jogo
                        Jogo jogo = new Jogo()
                        {
                            // Atribui às propriedades os valores das respectivas colunas da tabela do banco de dados
                            IdJogo = Convert.ToInt32(rdr[0]),

                            NomeJogo = rdr[1].ToString(),

                            Descricao = rdr[2].ToString(),

                            DataLancamento = Convert.ToDateTime(rdr[3]),

                            Valor = Convert.ToDecimal(rdr[4]),

                            IdEstudio = Convert.ToInt32(rdr[5]),

                            Estudio = new Estudio()
                            {
                                NomeEstudio = rdr[6].ToString()
                            }
                        };

                        // Adiciona o objeto jogo à lista listaJogos
                        listaJogos.Add(jogo);
                    }
                }
            }

            // Retorna a lista de jogos
            return listaJogos;
        }
    }
}
