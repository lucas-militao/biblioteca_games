
using BibliotecaGames.BLL.Exceptions;
using BibliotecaGames.DAL;
using BibliotecaGames.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaGames.BLL.Autenticacao
{
	public class JogosBo
	{
		private JogoDao _jogoDao;

		public List<Jogo> ObterTodosOsJogos()
		{
			_jogoDao = new JogoDao();
			return _jogoDao.ObterTodosOsJogos();
		}

		public void InserirNovoJogo(Jogo jogo)
		{
			_jogoDao = new JogoDao();

			ValidarJogo(jogo);

			var linhasAfetadas = _jogoDao.InserirJogo(jogo);

			if (linhasAfetadas == 0)
			{
				throw new JogoNaoCadastradoException();
			}
		}

		public void ValidarJogo(Jogo jogo)
		{
			if (string.IsNullOrWhiteSpace(jogo.Titulo) || 
				jogo.IdEditor == 0 ||
				jogo.IdGenero == 0)
			{
				throw new JogoInvalidoException();
			}
		}
	}
}
