using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OBS_WebForms
{
    public partial class Sell : System.Web.UI.Page
    {
        DataAccess dat = new DataAccess();

        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                Session["Flag"] = false;
                Session["ID"] = string.Empty;

                if (Session["token"] == null)
                {
                    Session["token"] = string.Empty;
                }

                

                if (Session["email"] == null)
                {
                    Session["email"] = string.Empty;
                }

                if (string.Equals(Session["token"].ToString(),"Seller"))
                {
                    //Response.Redirect("Login.aspx");
                }

                else if(string.Equals(Session["token"].ToString(),"User"))
                {
                    
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }


                

                
            }
            //GridView1.DataSource = dat.GetSellPosts("place holder");
            //GridView1.DataBind();
            GridLoad();

            //sellerGridLoad();

            gvSell.DataKeyNames = new string[2] { "ID", "Seller ID" };
        }
        private void GridLoad()
        {
            string query = $@"SELECT Id AS ID, bname AS[Book Name],author AS Author, category AS Category,genre AS Genre,unit_price AS Price,quantity AS Quantity,seller AS [Seller ID], time as [Time Posted],status AS Status FROM BOOK WHERE seller ='{Session["email"].ToString()}'";

            gvSell.DataSource = dat.Data_Selection(query);
            gvSell.DataBind();
        }

        //private void sellerGridLoad()
        //{
        //    string query = $@"SELECT Id as ID,bookid as [Book ID], buyer AS Customer,time as Time,quantity as Quantity,discount as Discount,refund as Refund,total_price AS Total FROM Orders";

        //    gvSeller.DataSource = dat.Data_Selection(query);
        //    gvSeller.DataBind();
        //}

        public void LoggedOut()
        {
            Session["email"] = string.Empty;
            Session["password"] = string.Empty;
            Session["token"] = string.Empty;

            Response.Redirect("Login.aspx");
        }

        protected void Logout_Click(object sender, EventArgs e)
        {
            LoggedOut();
        }

        private void FieldLoad()
        {
            try
            {
                string query = $@"SELECT Id AS ID,bname AS [Book Name],author AS Author, category AS Category,genre AS Genre,unit_price AS Price,quantity AS Quantity,seller AS [Seller ID],time as [Time Posted],status AS Status FROM BOOK WHERE ID = {Convert.ToInt32(Session["ID"].ToString())}";

                DataTable dt = dat.Data_Selection(query);

                if (dt.Rows.Count == 1)
                {
                    bname.Text = dt.Rows[0]["Book Name"].ToString();
                    author.Text = dt.Rows[0]["Author"].ToString();
                    category.Text = dt.Rows[0]["Category"].ToString();
                    genre.Text = dt.Rows[0]["Genre"].ToString();
                    price.Text = dt.Rows[0]["Price"].ToString();
                    quantity.Text = dt.Rows[0]["Quantity"].ToString();

                }
            }

            catch (Exception ex)
            {
                msg.Text = ex.Message;
            }
        }
        private void Clear_Fields()
        {
            bname.Text = string.Empty;
            author.Text = string.Empty;
            price.Text = string.Empty;
            quantity.Text = string.Empty;

            confirm.Enabled = true;
        }
        protected void confirm_Click(object sender, EventArgs e)
        {
            decimal p = 0;
            int q = 0;
            int num = 0;
            bool b = int.TryParse(quantity.Text, out num);

            if (b)
            {
                q = Convert.ToInt32(quantity.Text);
            }

            else
            {
                quantity.Text = string.Empty;

                msg.Text = "Please enter a valid number.";
            }

            decimal dnum = 0;
            bool c = decimal.TryParse(price.Text, out dnum);

            if (c)
            {
                p = Convert.ToDecimal(price.Text);
            }

            else
            {
                quantity.Text = string.Empty;

                msg.Text = "Please enter a valid price.";
            }

            dat.InsertBook(bname.Text, author.Text, category.Text, genre.Text, p, q, Session["email"].ToString(), DateTime.Now.ToString());

            Clear_Fields();
            GridLoad();
        }

        protected void back_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Home.aspx");
        }

        

        private void InitilizeSessions()
        {
            if (Session["password"] == null)
            {
                Session["password"] = string.Empty;
            }

            if (Session["email"] == null)
            {
                Session["email"] = string.Empty;
            }
        }

        private bool LogCheck()
        {
            bool b = false;

            if (dat.LoginCheck(Session["email"].ToString(), Session["password"].ToString()) == 1)
            {
                b = true;
            }

            return b;

        }

     

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[0].Text = "View";
            }

            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[1].Text = "Book ID";
            }

            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[2].Text = "Book Name";
            }

            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[3].Text = "Author";
            }

            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[4].Text = "Category";
            }

            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[5].Text = "Genre";
            }

            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[6].Text = "Price";
            }

            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[7].Text = "Available Quantity";
            }

            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[8].Text = "Seller";
            }

            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[9].Text = "Time Posted";
            }
        }

        protected void gvSell_SelectedIndexChanged1(object sender, EventArgs e)
        {
            Session["ID"] = gvSell.SelectedDataKey.Value.ToString();
            confirm.Enabled = false;
            FieldLoad();
        }

        protected void update_Click(object sender, EventArgs e)
        {
            try
            {

                int id = -999;

                bool b = int.TryParse(Session["ID"].ToString(), out id);

                if (id > 0 && b)
                {
                    string query = $@"Update book SET bname = '{bname.Text}' , author = '{author.Text}',category = '{category.Text}', genre = '{genre.Text}',unit_price = {Convert.ToDouble(price.Text)},quantity = {Convert.ToInt16(quantity.Text)} Where id ={Convert.ToInt32(Session["ID"].ToString())};";
                    dat.Data_Operation(query);
                    Clear_Fields();
                    GridLoad();
                }
                else
                {
                    msg.Text = "Please select a item";
                }
                Clear_Fields();
            }

            catch (Exception ex)
            {
                msg.Text = ex.Message;
            }
        }
    }
}