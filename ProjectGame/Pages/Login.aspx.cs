using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectGame.Pages
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnLogin(object sender, EventArgs e)
        {
            string user = txtUser.Text;
            string pass = txtPass.Text;

            if(user == "admin" && pass == "admin")
            {
                Session["logado"] = true;
                Response.Redirect("ControllerGame.aspx");
            }
            else
            {
                lblMensagem.Text = "Usuário ou senha inválidos.";
            }
        }
    }
}