using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OBS_WebForms
{
    public partial class Login : System.Web.UI.Page
    {
        DataAccess dat = new DataAccess();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if(Session["email"] == null)
                {
                    Session["email"] = string.Empty;
                }

                if (Session["password"] == null)
                {
                    Session["password"] = string.Empty;
                }

                if (Session["token"] == null)
                {
                    Session["token"] = string.Empty;
                }

                
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Registration.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (dat.LoginCheck(email.Text, pass.Text) == 1)
            {
                Session["password"] = pass.Text;
                Session["email"] = email.Text;
                Session["token"] = dat.LoginTypeCheck(email.Text, pass.Text);
                //Label1.Text = Session["token"].ToString();
                //Label1.Text = 
                //Session["token"] = dat.LoginCheck(email.Text, pass.Text);
                //int count = Convert.ToInt16(Session["v"].ToString());
                //if(count == 1)
                //{
                //    Response.Redirect("Admin.aspx");
                //}
                //else
                //{
                //    Response.Redirect("Login.aspx");
                //}
                //Label2.Text = dat.LoginCheck(email.Text, pass.Text).ToString();

                if (string.Equals(Session["token"].ToString(), "Admin"))
                {
                    Response.Redirect("Admin.aspx");
                }
                else if (string.Equals(Session["token"].ToString(), "Moderator"))
                {
                    Response.Redirect("Moderator.aspx");
                }

                else if (string.Equals(Session["token"].ToString(), "User"))
                {
                    Response.Redirect("Home.aspx");
                }

                else if (string.Equals(Session["token"].ToString(), "Seller"))
                {
                    Response.Redirect("Sell.aspx");
                }

                else
                {
                    Response.Redirect("Login.aspx");
                }
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }
    }
}