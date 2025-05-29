<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ControllerGame.aspx.cs" Inherits="ProjectGame.Pages.ControllerGame" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
  <div class=" d-flex justify-content-end mt-1">
    <asp:Button runat="server" Text="Logout" OnClick="BtnLogout" CssClass="btn btn-danger btn-sm" />
  </div>
  <div class="col-12">
    <div class="row d-flex justify-content-center">
      <div class="col-md-6 d-flex justify-content-center">
        <div class="px-2 mt-2">
          <div class="mb-2">
            <asp:TextBox CssClass="form-control" placeholder="Nome" ID="txtName" runat="server" />
          </div>
          <div class="mb-2">
            <asp:DropDownList CssClass="form-select" aria-label="Default select example" ID="txtGenre" runat="server">
              <asp:ListItem Selected="True" Value="ADS">ADS</asp:ListItem>
            </asp:DropDownList>
          </div>
          <div class="mb-2">
            <asp:TextBox CssClass="form-control" placeholder="Faixa Etária" ID="txtAgeRange" runat="server" />
          </div>
          <div class="mb-2">
            <asp:TextBox CssClass="form-control" placeholder="Valor" ID="txtPrice" runat="server" />
          </div>
          <div>
            <asp:Button Text="Cadastrar" runat="server" OnClick="GameCommand" CssClass="btn btn-primary px-4 btn-lg" />
          </div>
          <div class="mt-2">
            <asp:Label ID="lblMensagem" runat="server" ForeColor="Green" />
          </div>
        </div>
      </div>
      <div class="col-md-6 d-flex justify-content-center">
        <div> <img src="../Images/imgRegisterAdm.png" width="450" height="450""  /> </div>
      </div>
    </div>
  </div>
</asp:Content>
