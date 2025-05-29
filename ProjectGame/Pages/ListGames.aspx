<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListGames.aspx.cs" Inherits="ProjectGame.Pages.ListGames" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server"> 
  <asp:Panel ID="panelSearch" runat="server" Visible="false">
    <asp:Literal ID="litSearch" runat="server" />
  </asp:Panel>
  <div>
    <asp:Label ID="lblNoFound" runat="server" CssClass="text-danger font-bold h3 fw-bolder fst-italic" Visible="false" />
  </div>
  <div id="tableAdmin" runat="server" class="px-2">
    <asp:Panel ID="tableGames" runat="server" Visible="false">
      <table class="table table-striped">
        <thead>
          <tr>
            <th>Id</th>
            <th>Nome</th>
            <th>Gêneros</th>
            <th>Faixa Etária</th>
            <th>Valor</th>
          </tr>
        </thead>
        <tbody>
          <asp:Repeater ID="repeaterGames" runat="server" OnItemCommand="EditDelete">
            <ItemTemplate>
              <tr>
                <td class="fw-normal"><%# Eval("Id") %></td>
                <td class="fw-normal"><%# Eval("Name") %></td>
                <td class="fw-normal"><%# Eval("Genre") %></td>
                <td class="fw-normal"><%# Eval("AgeRange") %></td>
                <td class="fw-normal"><%# Eval("Price") %></td>
                <td><asp:Button ID="btnDelete"
                                        runat="server"
                                        Text="Deletar"
                                        CommandName="Delete"
                                        CommandArgument='<%# Eval("Id") %>'
                                        CssClass="btn btn-danger btn-sm" /></td>
                <td><asp:Button ID="btnEdit" runat="server" Text="Editar" CommandName="Edit" CommandArgument='<%# Eval("Id") %>' CssClass="btn btn-warning btn-sm" /></td>
              </tr>
            </ItemTemplate>
          </asp:Repeater>
        </tbody>
      </table>
    </asp:Panel>
  </div>

</asp:Content>
