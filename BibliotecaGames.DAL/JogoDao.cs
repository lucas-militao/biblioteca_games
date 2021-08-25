using BibliotecaGames.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaGames.DAL
{
	public class JogoDao
	{
		public List<Jogo> ObterTodosOsJogos()
		{
			try
			{
				var command = new SqlCommand();
				command.Connection = Conexao.connection;
				command.CommandText = "SELECT * FROM jogos";

				Conexao.Conectar();

				var reader = command.ExecuteReader();

				var jogos = new List<Jogo>();

				while (reader.Read())
				{
					var jogo = new Jogo();

					jogo.Id = Convert.ToInt32(reader["id"]);
					jogo.Imagem = reader["imagem"].ToString();
					jogo.DataCompra = reader["data_compra"] == DBNull.Value ? (DateTime?) null : Convert.ToDateTime(reader["data_compra"]);
					jogo.Titulo = reader["titulo"].ToString();
					jogo.ValorPago = reader["valor_pago"] == DBNull.Value ? (double?) null : Convert.ToDouble(reader["valor_pago"]);

					jogos.Add(jogo);
				}

				return jogos;
			}
			catch (Exception)
			{
				throw;
			}
			finally
			{
				Conexao.Desconectar();
			}

		}

		public int InserirJogo(Jogo jogo)
		{
			try
			{
				var command = new SqlCommand();
				command.Connection = Conexao.connection;

				command.CommandText = @"INSERT INTO [dbo].[jogos]
												   ([titulo]
												   ,[valor_pago]
												   ,[data_compra]
												   ,[id_genero]
												   ,[id_editor]
												   ,[imagem])
											 VALUES
												   (@TITULO
												   ,@VALOR_PAGO
												   ,@DATA_COMPRA
												   ,@ID_GENERO
												   ,@ID_EDITOR
												   ,@IMAGE)";


				command.Parameters.AddWithValue("@TITULO", jogo.Titulo);
				command.Parameters.AddWithValue("@VALOR_PAGO", jogo.ValorPago);
				command.Parameters.AddWithValue("@DATA_COMPRA", jogo.DataCompra);
				command.Parameters.AddWithValue("@ID_GENERO", jogo.IdGenero);
				command.Parameters.AddWithValue("@ID_EDITOR", jogo.IdEditor);
				command.Parameters.AddWithValue("@IMAGE", jogo.Imagem);

				Conexao.Conectar();

				return command.ExecuteNonQuery();
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				Conexao.Desconectar();
			}

		}
	}
}
