<%@ Page Title="" Language="C#" MasterPageFile="~/Jogos/SiteMasterPage.Master" AutoEventWireup="true" CodeBehind="CadastroEdicaoJogo.aspx.cs" Inherits="BibliotecaGames.Site.Jogos.CadastroEdicaoJogo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<div>

		<div class="form-group">
			<label for="TxtTitulo">Título</label>
			<asp:TextBox runat="server" ID="TxtTitulo" CssClass="form-control"></asp:TextBox>
			<asp:RequiredFieldValidator ID="RfvTitulo" runat="server" ControlToValidate="TxtTitulo" ErrorMessage="É necessário preencher o campo Título" Text="*"></asp:RequiredFieldValidator>
		</div>

		<div class="form-group">
			<label for="TxtValorPago">Valor pago</label>
			<asp:TextBox runat="server" ID="TxtValorPago" CssClass="form-control"></asp:TextBox>
		</div>

		<div class="form-group">
			<label for="TxtDataCompra">Data Compra</label>
			<asp:TextBox runat="server" ID="TxtDataCompra" CssClass="form-control" TextMode="Date"></asp:TextBox>
		</div>

		<div class="form-group">
			<label for="FileUploadImage">Imagem</label>
			<asp:FileUpload ID="FileUploadImage" runat="server" CssClass="form-control"/>
		</div>

		<div class="form-group">
			<label for="DdlGenero">Gênero</label>
			<asp:DropDownList runat="server" ID="DdlGenero" CssClass="form-control" DataValueField="Id" DataTextField="Descricao"></asp:DropDownList>
			<asp:RequiredFieldValidator ID="RfvGenero" runat="server" ControlToValidate="DdlGenero" ErrorMessage="É necessário preencher o campo Genero" Text="*"></asp:RequiredFieldValidator>
		</div>

		<div class="form-group">
			<label for="DdlEditor">Editor</label>
			<asp:DropDownList ID="DdlEditor" runat="server" CssClass="form-control" DataValueField="Id" DataTextField="Nome"></asp:DropDownList>
			<asp:RequiredFieldValidator ID="RfvEditor" runat="server" ControlToValidate="DdlEditor" ErrorMessage="É necessário preencher o campo Editor" Text="*"></asp:RequiredFieldValidator>
		</div>
		<br />
		<asp:Label ID="LblMensagem" runat="server" />
		<br />
		<asp:Button ID="BtnGravar" Text="Gravar" runat="server" CssClass="btn btn-primary" runat="server" OnClick="BtnGravar_Click"/>
		<br />
		<asp:ValidationSummary 
			runat="server" 
			DisplayMode="BulletList"
			id="valSum"
			ForeColor="Red"
			EnableClientScript="true"
			HeaderText="Você precisa corrigir os seguintes campos: "
		/>
		<br />
		<a href="Catalogo.aspx">Voltar ao catálogo de jogos</a>
	</div>
</asp:Content>
