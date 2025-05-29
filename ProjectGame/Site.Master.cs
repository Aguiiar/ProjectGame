using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectGame
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
          
            if (Session["logado"] == null || !(bool)Session["logado"])
            {
                cadastrarJogoAdm.Visible = false;
                listaJogosAdmin.Visible = false;
            }
            else
            {
                cadastrarJogoAdm.Visible = true;
                listaJogosAdmin.Visible = true;
            }

        }
    }
}