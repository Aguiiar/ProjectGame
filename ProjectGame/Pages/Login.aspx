<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ProjectGame.Pages.Login" %>



<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <div class="BoxImgBanner mt-3 h-75"></div>
    <div class="d-flex justify-content-center mt-3">


        <div class="boxForm card bg-transparent d-flex justify-content-center  rounded" style="width: 18rem;">
            <div class="card-body">
                <asp:TextBox ID="txtUser" runat="server" Placeholder="Usuário" CssClass="form-control mb-4" />
                <asp:TextBox ID="txtPass" runat="server" Placeholder="Senha" TextMode="Password" CssClass="form-control mb-4" />
                <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="BtnLogin" CssClass="btn btn-primary px-5" />
                <div class="mt-3">
                    <asp:Label ID="lblMensagem" runat="server" ForeColor="Red" />
                </div>

            </div>
        </div>
    </div>
</asp:Content>
