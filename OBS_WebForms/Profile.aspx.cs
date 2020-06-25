using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OBS_WebForms
{
    public partial class Profile : System.Web.UI.Page
    {
        DataAccess dat = new DataAccess();

        DataTable dt = new DataTable();
        //WHERE u.email = '{Session["Email"].ToString()}'
        protected void Page_Load(object sender, EventArgs e)
        {
            //changePersonal.Visible = false;

            //Session["Email"] = "tareq.haider@yahoo.com";

            if (!IsPostBack)
            {
                InitilizeSessions();

                if (string.Equals(Session["token"].ToString(), "Seller"))
                {
                    //Response.Redirect("Login.aspx");
                    DetailsLoad();
                }

                else if (string.Equals(Session["token"].ToString(), "User"))
                {
                    DetailsLoad();
                }

                else if (string.Equals(Session["token"].ToString(), "Admin"))
                {
                    DetailsLoad();
                }

                else if (string.Equals(Session["token"].ToString(), "Moderator"))
                {
                    DetailsLoad();
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }
            }

            



        }

        public void DetailsLoad()
        {
            Login.Visible = false;
            profileD.Visible = true;


            string queryProfile = $@"SELECT CONCAT(a.fname ,' ',a.lname) AS Name, u.email AS Email,a.phone AS Phone,a.dob as [Birth Date],a.balance AS Balance,u.type as [User Type]
                            FROM Account AS a
                            INNER JOIN Users AS u
                            ON a.email = u.email 
                            WHERE u.email = '{Session["Email"].ToString()}'";

            dt = dat.Data_Selection(queryProfile);
            dvProfile.DataSource = dt;
            dvProfile.DataBind();

            string queryOrder = $@"SELECT b.bname AS [Book Name], o.seller AS Seller,o.time AS Time,o.quantity as Quantity,total_price as [Total Price],o.discount as Discount,o.status as Status
                            FROM orders AS o
                            INNER JOIN book AS b
                            ON o.bookid = b.id
                            WHERE o.buyer = '{Session["Email"].ToString()}'";

            gvOrder.DataSource = dat.Data_Selection(queryOrder);
            gvOrder.DataBind();
        }

        public void LoggedOut()
        {
            Session["email"] = string.Empty;
            Session["password"] = string.Empty;
            Session["token"] = string.Empty;
            Login.Visible = true;
            profileD.Visible = false;
            Response.Redirect("Login.aspx");
        }

        private void InitilizeSessions()
        {
            if (!IsPostBack)
            {

                if (Session["password"] == null)
                {
                    Session["password"] = string.Empty;
                }

                if (Session["email"] == null)
                {
                    Session["email"] = string.Empty;
                }

                if (Session["token"] == null)
                {
                    Session["token"] = string.Empty;
                }



            }
        }

        protected void btnProfileInfo_Click(object sender, EventArgs e)
        {
            //if (dt.Rows.Count == 1)
            //{

            //    txtFname.Text = dt.Rows[0]["First Name"].ToString();

            //    txtLname.Text = dt.Rows[0]["Last Name"].ToString();

            //    changePersonal.Visible = true;
            //}
        }

        protected void btnChangePassword_Click(object sender, EventArgs e)
        {
            msg.Text = "cpass Infor Pressed";
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {

        }

        protected void Logout_Click(object sender, EventArgs e)
        {
            LoggedOut();
        }
    }
}