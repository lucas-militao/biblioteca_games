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
	}
}
