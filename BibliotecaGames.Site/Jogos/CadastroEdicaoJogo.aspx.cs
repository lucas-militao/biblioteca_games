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
		private JogosBo _jogosBo;
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
			_jogosBo = new JogosBo();

			var jogo = new Jogo();

			jogo.Titulo = TxtTitulo.Text;
			jogo.ValorPago = string.IsNullOrWhiteSpace(TxtValorPago.Text) ? (double?) null : Convert.ToDouble(TxtValorPago.Text);
			jogo.DataCompra = string.IsNullOrWhiteSpace(TxtDataCompra.Text) ? (DateTime?) null : Convert.ToDateTime(TxtDataCompra.Text);

			try
			{
				jogo.Imagem = GravarImagemNoDisco();
			}
			catch (Exception)
			{
				LblMensagem.Text = "Ocorreu um erro ao salvar a imagem!";
				throw;
			}
			
			jogo.IdGenero = Convert.ToInt32(DdlGenero.SelectedValue);
			jogo.IdEditor = Convert.ToInt32(DdlEditor.SelectedValue);
			BtnGravar.Enabled = false;

			try
			{
				_jogosBo.InserirNovoJogo(jogo);
				LblMensagem.Text = "Jogo cadastrado com sucesso!";
			}
			catch (Exception)
			{
				LblMensagem.Text = "Ocorreu um erro ao gravar o jogo!";
				throw;
			}
		}

		private string GravarImagemNoDisco()
		{
			if (FileUploadImage.HasFile)
			{
				try
				{
					var caminho = $"{AppDomain.CurrentDomain.BaseDirectory}Content\\ImagensJogos\\";
					var fileName = $"{DateTime.Now.ToString("yyyyMMddhhmmss")}_{FileUploadImage.FileName}";
					FileUploadImage.SaveAs($"{caminho}{fileName}");
					return fileName;
				}
				catch (Exception ex)
				{

					throw ex;
				}
			}
			else
			{
				return null;
			}
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