using BibliotecaGames.BLL;
using System;
using System.Web.Security;
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
				Deslogar();
			}
		}

		private void carregarJogosNoRepeater()
		{
			_jogosBo = new JogosBo();
			RepeaterJogos.DataSource = _jogosBo.ObterTodosOsJogos();
			RepeaterJogos.DataBind();
		}

		private void Deslogar()
		{
			if (!string.IsNullOrEmpty(Page.Request.QueryString["logout"]))
			{
				FormsAuthentication.SignOut();
				Session.Abandon();
				//FormsAuthentication.RedirectToLoginPage();
				Response.Redirect("/Autenticacao/Login.aspx");
			}
		}
	}
}