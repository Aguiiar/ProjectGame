using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using ProjectGame.Models;

namespace ProjectGame.Pages
{
    public partial class ControllerGame : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            if (Session["logado"] == null || !(bool)Session["logado"])
            {
                Response.Redirect("Login.aspx");
                return;
            }


            if (!IsPostBack)
            {
                LoadGenerousFromApi();
            }



            if (!IsPostBack)
            {
                LoadGenerousFromApi();

                if (Request.QueryString["editId"] != null)
                {
                    int editId = int.Parse(Request.QueryString["editId"]);
                    var game = MemoryBank.games.FirstOrDefault(g => g.Id == editId);

                    if (game != null)
                    {
                        txtName.Text = game.Name;
                        txtGenre.SelectedValue = game.Genre;
                        txtAgeRange.Text = game.AgeRange.ToString();
                        txtPrice.Text = game.Price.ToString();
                        ViewState["editId"] = editId;
                    }
                }

            }
        }


        protected void BtnLogout(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("Login.aspx");
        }



        private void LoadGenerousFromApi()
        {
            using (var client = new WebClient())
            {

                client.Encoding = System.Text.Encoding.UTF8;

                string json = client.DownloadString("https://gist.githubusercontent.com/shackra/46c8c67e7039c3aa52d49dfeff4dad3c/raw/");
                var generous = JsonConvert.DeserializeObject
                <ApiGenre>
                (json);

                txtGenre.Items.Clear();
                txtGenre.Items.Add(new ListItem("Selecione um Gênero", ""));

                foreach (var generou in generous.Genres)
                {
                    txtGenre.Items.Add(new ListItem(generou.Key, generou.Key));
                }
            }
        }

        protected void GameCommand(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtName.Text) ||
                string.IsNullOrWhiteSpace(txtGenre.SelectedValue) || txtGenre.SelectedValue == "" ||
                string.IsNullOrWhiteSpace(txtAgeRange.Text) ||
                string.IsNullOrWhiteSpace(txtPrice.Text))
            {
                lblMensagem.Text = "Campos obrigatórios.";
                lblMensagem.ForeColor = System.Drawing.Color.Red;
                return;
            }
            if (!int.TryParse(txtAgeRange.Text, out int validateAgeRange))
            {
                lblMensagem.Text = "Faixa etária inválida: apenas números são permitidos.";
                lblMensagem.ForeColor = System.Drawing.Color.Red;
                return;
            }

            if (!double.TryParse(txtPrice.Text, out double validatePrice))
            {
                lblMensagem.Text = "Preço inválido. Verifique o valor informado.";
                lblMensagem.ForeColor = System.Drawing.Color.Red;
                return;
            }

            if (ViewState["editId"] != null)
            {
                int editId = (int)ViewState["editId"];
                var gameEdit = MemoryBank.games.FirstOrDefault(g => g.Id == editId);
                if (gameEdit != null)
                {
                    gameEdit.Name = txtName.Text;
                    gameEdit.Genre = txtGenre.SelectedValue;
                    gameEdit.AgeRange = validateAgeRange;
                    gameEdit.Price = validatePrice;



                    lblMensagem.Text = "Jogo atualizado com sucesso!";
                    lblMensagem.ForeColor = System.Drawing.Color.Green;
                    ClearFields();
                    ViewState.Remove("editId");




                    return;
                }
            }
            else
            {
                var g = new Game
                {
                    Id = MemoryBank.games.Count > 0 ? MemoryBank.games.Max(x => x.Id) + 1 : 1,
                    Name = txtName.Text,
                    Genre = txtGenre.SelectedValue,
                    AgeRange = validateAgeRange,
                    Price = validatePrice,
                };
                MemoryBank.games.Add(g);
                lblMensagem.Text = "Game cadastrado!";
                lblMensagem.ForeColor = System.Drawing.Color.Green;
                ClearFields();
            }

        }


        private void ClearFields()
        {
            txtName.Text = "";
            txtGenre.Text = "";
            txtAgeRange.Text = "";
            txtPrice.Text = "";

        }



    }
}