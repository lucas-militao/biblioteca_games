using BibliotecaGames.BLL;
using System;
using System.Web.UI;

namespace BibliotecaGames.Site.Jogos
{
	public partial class Catalogo : System.Web.UI.Page
	{
		private JogosBo _jogosBo;
		protected void Page_Load(object sender, EventArgs e)
		{ 
			if (!Page.IsPostBack)
			{
				carregarJogosNoRepeater();
			}
		}

		private void carregarJogosNoRepeater()
		{
			_jogosBo = new JogosBo();
			RepeaterJogos.DataSource = _jogosBo.ObterTodosOsJogos();
			RepeaterJogos.DataBind();
		}
	}
}