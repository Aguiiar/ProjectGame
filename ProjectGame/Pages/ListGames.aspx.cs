using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using System.Web.UI.WebControls;

using Newtonsoft.Json;
using ProjectGame.Models;

namespace ProjectGame.Pages
{
    public partial class ListGames : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            if (!IsPostBack)
            {
                string nome = Request.QueryString["search"];
                UpdateTable();
                if (!string.IsNullOrEmpty(nome))
                {
                    nome = nome.ToLower();
                    var filteredList = MemoryBank.games.Where(g => g.Name.ToLower().Contains(nome)).Select(g => new
                    {
                        g.Id,
                        g.Name,
                        g.Genre,
                        g.AgeRange,
                        g.Price
                    }).ToList();


                    if (!filteredList.Any())
                    {
                        lblNoFound.Text = "Jogo não encontrado.";
                        lblNoFound.Visible = true;
                        panelSearch.Visible = false;
                        litSearch.Text = "";
                        tableGames.Visible = false;
                        tableAdmin.Visible = false;
                        return;
                    }
                    repeaterGames.DataSource = filteredList;
                    repeaterGames.DataBind();
                    tableGames.Visible = filteredList.Any();


                    if (filteredList.Any())
                    {


                        string path = Server.MapPath("~/Json/contextSearch.json");



                        if (File.Exists(path))
                        {
                            string json = File.ReadAllText(path);
                            var contentSearch = JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(json);


                            foreach (var content in contentSearch.Keys)
                            {
                                if (nome.Contains(content.ToLower()))
                                {
                                    litSearch.Text = contentSearch[content].html;
                                    panelSearch.Visible = true;
                                    break;
                                }
                            }
                        }

                    }

                }
                else
                {

                    lblNoFound.Visible = false;
                    litSearch.Text = "";
                    UpdateTable();
                }
            }



            if (Session["logado"] == null || !(bool)Session["logado"])
            {
                tableAdmin.Visible = false;
            }
            else
            {
                tableAdmin.Visible = true;
            }

        }



        private void UpdateTable()
        {

            var list = MemoryBank.games.Select(g => new
            {
                g.Id,
                g.Name,
                g.Genre,
                g.AgeRange,
                g.Price
            }).ToList();
            repeaterGames.DataSource = list;
            repeaterGames.DataBind();


            bool hasGames = list.Any();

            tableGames.Visible = hasGames;
            lblNoFound.Text = hasGames ? "" : "Não há jogos cadastrados no sistema!";
            lblNoFound.Visible = !hasGames;

        }



        protected void EditDelete(object sender, RepeaterCommandEventArgs e)
        {
            int gameId = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "Delete")
            {
                var gameDelete = MemoryBank.games.FirstOrDefault(g => g.Id == gameId);
                if (gameDelete != null)
                {
                    MemoryBank.games.Remove(gameDelete);
                }


                panelSearch.Visible = false;
                litSearch.Text = "";
                UpdateTable();
                UpdateTable();




                if (!MemoryBank.games.Any())
                {
                    lblNoFound.Text = "Não existe jogos cadastrados no sistema!";
                    lblNoFound.Visible = true;
                    tableGames.Visible = false;
                    tableAdmin.Visible = false;
                }
            }
            else if (e.CommandName == "Edit")
            {

                Response.Redirect($"ControllerGame.aspx?editId={gameId}");

            }
        }



    }
}