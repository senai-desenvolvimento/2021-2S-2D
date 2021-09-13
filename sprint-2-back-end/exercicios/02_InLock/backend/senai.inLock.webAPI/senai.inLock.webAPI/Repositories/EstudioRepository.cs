using senai.inLock.webAPI.Domains;
using senai.inLock.webAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace senai.inLock.webAPI.Repositories
{
    public class EstudioRepository : IEstudioRepository
    {
        private readonly string stringConexao = "Data Source=DESKTOP-PM35QPG\\SQLEXPRESS; initial catalog=inLockGames; user Id=sa; pwd=senai@132";

        public List<Estudio> ListarComJogos()
        {
            // Cria uma lista onde serão armazenados os dados
            List<Estudio> listaEstudios = new List<Estudio>();

            // Declara a SqlConnection con passando a string de conexão como parâmetro
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Declara a instrução a ser executada
                string querySelectAllStudio = "SELECT idEstudio, nomeEstudio FROM Estudio";

                // Abre a conexão com o banco de dados
                con.Open();

                // Declara o SqlDataReader para percorrer a tabela do banco de dados
                SqlDataReader readerEstudios;

                // Declara o SqlCommand cmd passando a query que será executada e a conexão como parâmetros
                using (SqlCommand cmd = new SqlCommand(querySelectAllStudio, con))
                {
                    // Executa a query e armazena os dados no rdr
                    readerEstudios = cmd.ExecuteReader();

                    // Enquanto houver registros para serem lidos no rdr, o laço se repete
                    while (readerEstudios.Read())
                    {
                        List<Jogo> listaJogos = new List<Jogo>();

                        Estudio estudio = new Estudio()
                        {
                            IdEstudio = Convert.ToInt32(readerEstudios[0]),
                            NomeEstudio = readerEstudios[1].ToString()
                        };

                        using (SqlConnection conGames = new SqlConnection(stringConexao))
                        {
                            string querySelectAllGames = "SELECT idJogo, nomeJogo, descricao, dataLancamento, valor FROM jogo WHERE idEstudio = @idEstudio";

                            conGames.Open();

                            SqlDataReader readerGames;

                            using (SqlCommand cmdGames = new SqlCommand(querySelectAllGames, conGames))
                            {
                                cmdGames.Parameters.AddWithValue("@idEstudio", estudio.IdEstudio);
                                readerGames = cmdGames.ExecuteReader();

                                while (readerGames.Read())
                                {
                                    Jogo jogo = new Jogo()
                                    {
                                        IdJogo = Convert.ToInt32(readerGames[0]),

                                        NomeJogo = readerGames[1].ToString(),

                                        Descricao = readerGames[2].ToString(),

                                        DataLancamento = Convert.ToDateTime(readerGames[3]),

                                        Valor = Convert.ToDecimal(readerGames[4])
                                    };

                                    listaJogos.Add(jogo);
                                }
                            }
                            estudio.ListaJogos = listaJogos;

                            listaEstudios.Add(estudio);
                        }
                    }
                }
            }

            // Retorna a lista de estúdios
            return listaEstudios;
        }
    }
}
