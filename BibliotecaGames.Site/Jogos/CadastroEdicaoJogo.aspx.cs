using BibliotecaGames.BLL;
using BibliotecaGames.Entities;
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
			var jogo = new Jogo();

			jogo.IdEditor = Convert.ToInt32(DdlEditor.SelectedValue);
			jogo.IdGenero = Convert.ToInt32(DdlGenero.SelectedValue);
			jogo.Titulo = TxtTitulo.Text;
			jogo.Imagem = FileUploadImage.FileName;
			jogo.ValorPago = string.IsNullOrWhiteSpace(TxtValorPago.Text) ? (double?) null : Convert.ToDouble(TxtValorPago.Text);
			jogo.DataCompra = string.IsNullOrWhiteSpace(TxtDataCompra.Text) ? (DateTime?) null : Convert.ToDateTime(TxtDataCompra.Text);
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