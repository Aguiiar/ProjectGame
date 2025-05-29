using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjectGame.Models;

namespace ProjectGame
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SearchGames(object sender, EventArgs e)
        {
            string nome = txtSearch.Text.Trim();
            Response.Redirect("~/Pages/listGames.aspx?search=" + nome);

        }
    }
}