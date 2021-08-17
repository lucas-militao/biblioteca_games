using BibliotecaGames.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BibliotecaGames.Site.Jogos
{
	public partial class CadastroEdicaoJogo : System.Web.UI.Page
	{
		private GeneroBo _generoBo;
		private EditorBo _editorBo;
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				CarregarGenerosNaCombo();
				CarregarEditoresNaCombo();
			}
		}

		protected void BtnGravar_Click(object sender, EventArgs e)
		{

		}

		private void CarregarEditoresNaCombo()
		{
			_editorBo = new EditorBo();
			var editores = _editorBo.ObterTodosOsEditores();

			DdlEditor.DataSource = editores;
			DdlEditor.DataBind();
		}

		private void CarregarGenerosNaCombo()
		{
			_generoBo = new GeneroBo();
			var generos = _generoBo.ObterTodosOsGeneros();

			DdlGenero.DataSource = generos;
			DdlGenero.DataBind();
		}
	}
}