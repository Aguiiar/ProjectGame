<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ProjectGame._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>
        <section>
        

                <div class="row">

                    <div class="col col-sm-12 col-md-6 col-lg-8">
                        <p class="fs-5 mb-0">Bem vindo ao <span class="fs-4 fst-italic fw-bold">GameVerse</span></p>
                        <p class="fs-2 lh-1 mt-0 fw-bold">O melhor do mundo dos games está aqui!</p>
                        <p class="lh-lg mt-5">Prepare-se para entrar no universo onde os jogos ganham vida: GameVerse! Aqui você encontra os melhores preços, lançamentos imperdíveis e tudo o que precisa saber sobre o mundo gamer. Promoções bombásticas e informações atualizadas te esperam a cada clique!</p>



                        <asp:TextBox CssClass="form-control mt-5" ID="txtSearch" placeholder="Busque seu game!" runat="server" />
                       
                        <ajaxToolkit:AutoCompleteExtender ID="autoCompleteSearch" CompletionListCssClass="form-control list-unstyled  mt-1 me-2" runat="server" TargetControlID="txtSearch" ServicePath="~/Services/AutoCompleteServices.asmx" ServiceMethod="GetGameName" MinimumPrefixLength="1" CompletionSetCount="5" EnableCaching="true" CompletionInterval="100" />
                         
                        <asp:Button ID="btnSearch" runat="server" OnClick="SearchGames" Text="Buscar" CssClass="btn btn-primary mt-5 px-4  mb-3 sm-mb-0 btn-lg" />
                    
                    </div>
                    <div class="col col-sm-12 col-md-6 col-lg-4 mt-2">
                        <img src="Images/imageIndex.png" width="350" class="rounded" />

                    </div>

                </div>
        

        </section>
    </main>

</asp:Content>
