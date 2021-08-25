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

				if (EstaEmModoEdicao())
				{
					CarregarDadosParaEdicao();
				}
				
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

				LblMensagem.ForeColor = System.Drawing.Color.Green;
				LblMensagem.Text = "Jogo cadastrado com sucesso!";
			}
			catch (Exception)
			{
				LblMensagem.ForeColor = System.Drawing.Color.Red;
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

		public void CarregarDadosParaEdicao()
		{
			_jogosBo = new JogosBo();

			var id = ObterIdDoJogo();

			var jogo = _jogosBo.ObterJogoPeloId(id);

			TxtTitulo.Text = jogo.Titulo;
			TxtValorPago.Text = jogo.ValorPago.ToString();
			TxtDataCompra.Text = jogo.DataCompra.ToString();
			DdlEditor.Text = jogo.IdEditor.ToString();
			DdlGenero.Text = jogo.IdGenero.ToString();
		}

		private int ObterIdDoJogo()
		{
			var id = 0;
			var idQueryString = Request.QueryString["id"];
			if (int.TryParse(idQueryString, out id))
			{
				if (id <= 0)
				{
					throw new Exception("ID inválido");
				}
				return id;
			}
			else
			{
				throw new Exception("ID inválido");
			}
		}

		private Boolean EstaEmModoEdicao()
		{
			return Request.QueryString.AllKeys.Contains("id");
		}
	}
}