using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OBS_WebForms
{
    public partial class Home : System.Web.UI.Page
    {
        DataAccess dat = new DataAccess();

        DataTable dt = new DataTable();
        DataTable dtSearch = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            //{
            //    Session["Flag"] = false;
            //    Session["ID"] = string.Empty;

                
            //}

            //if (dtSearch.Rows.Count > 0)
            //{
            //    GridView1.DataSource = dtSearch;
            //    GridView1.DataBind();
            //}


            //else if ((bool)Session["Flag"] == false)
            //{
            //    //gridLoad();
            //    GridView1.DataSource = dat.GetTable("book");
            //    GridView1.DataBind();
            //}



            GridView1.DataKeyNames = new string[3] { "Id", "bname", "seller" };


            if (!IsPostBack)
            {
                InitilizeSessions();
                if(LogCheck() == true)
                {
                    Response.Write(Session["email"].ToString() + "\t" + Session["password"].ToString());
                    //Response.Redirect("Login.aspx");
                }

                if (ViewState["q"] == null)
                {
                    ViewState["q"] = 1;
                }

                GridView1.DataSource = dat.GetTable("book");
                GridView1.DataBind();

                TextBox1.Text = ViewState["q"].ToString();

               

            }

        }

        private void DetailsLoad()
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(Session["ID"].ToString()))
                {
                    string query = $@"SELECT Id AS ID,bname AS [Book Name],author AS Author, category AS Category,genre AS Genre,unit_price AS Price,quantity AS Quantity,seller AS [Seller ID],time as [Time Posted],status AS Status FROM BOOK WHERE Id ={Convert.ToInt32(Session["ID"].ToString())}";

                    dvHome.DataSource = dat.Data_Selection(query);
                    dvHome.DataBind();
                }
            }
            catch(Exception ex)
            {
                msg.Text = ex.Message;
            }
        }
        public void LoggedOut()
        {
            Session["email"] = string.Empty;
            Session["password"] = string.Empty;
            Session["token"] = string.Empty;

            Response.Redirect("Login.aspx");
        }

        private void UserCheck()
        {
            if (string.Equals(Session["token"].ToString(), "Seller"))
            {
                //Response.Redirect("Login.aspx");
                //DetailsLoad();
            }

            else if (string.Equals(Session["token"].ToString(), "User"))
            {
                //DetailsLoad();
            }

            else if (string.Equals(Session["token"].ToString(), "Admin"))
            {
               // DetailsLoad();
            }

            else if (string.Equals(Session["token"].ToString(), "Moderator"))
            {
                //DetailsLoad();
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }


        protected void Logout_Click(object sender, EventArgs e)
        {
            LoggedOut();
        }


        protected void order_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Session["email"].ToString()))
            {
                Response.Redirect("Login.aspx");
            }
            
            int temp = Convert.ToInt32(ViewState["q"]);

            if (temp <= 0)
            {
                temp = 1;
                TextBox1.Text = temp.ToString();
                ViewState["q"] = temp;
            }

            try
            {
                //GridView1.SelectedDataKey.Value
                if (!string.IsNullOrWhiteSpace(Session["ID"].ToString()))
                {
                    DataTable dt = dat.SearchBookByID(Convert.ToInt32(Session["ID"].ToString()));
                    if (dt.Rows.Count == 1)
                    {
                        int quantity = Convert.ToInt32(ViewState["q"].ToString());
                        DataRow dr = dt.Rows[dt.Rows.Count - 1];
                        int bookid = Convert.ToInt32(dr["Id"]);
                        string seller = dr["seller"].ToString();
                        decimal price = Convert.ToDecimal(dr["unit_price"]);
                        int db_quantity = Convert.ToInt32(dr["quantity"]);
                        decimal total = price * quantity;
                        string status = "Added";
                        string buyer = Session["email"].ToString();
                        int nq = dat.GetBookQuantity(bookid);

                        if (nq > 0 && nq > Convert.ToInt32(TextBox1.Text))
                        {
                            dat.InsertOrder(bookid.ToString(), buyer, seller, DateTime.Now.ToString(), quantity, total, 0, 0, status);
                            
                            dat.SetBookQuantity(bookid, nq - quantity);
                        }
                        else
                        {
                            msg.Text = "Not enough quantity";
                            ViewState["q"] = 1;
                            TextBox1.Text = ViewState["q"].ToString();

                        }
                        

                        GridView1.DataSource = dat.GetTable("book");
                        GridView1.DataBind();

                        DetailsLoad();

                        msg.Text = "Order on Processing.";
                        //msg.Text = db_quantity.ToString();
                    }
                    else
                    {
                        msg.Text = "Select a Product First.";
                    }

                   

                }
            }
            catch
            {
                msg.Text = "Select a Product First.";
            }
 
        }

        protected void SearchButton_Click(object sender, EventArgs e)
        {
            if(SearchList.SelectedValue == "1")
            {
                int num = 0;
                bool b = int.TryParse(search.Text, out num);

                if (b)
                {
                    GridView1.DataSource = dat.SearchBookByID(Convert.ToInt32(search.Text));
                    GridView1.DataBind();
                }

                else
                {
                    GridView1.DataSource = dat.GetTable("book");
                    GridView1.DataBind();
                }
            }

            else if(SearchList.SelectedValue == "2")
            {
                GridView1.DataSource = dat.SearchBookByName(search.Text);
                GridView1.DataBind();
            }

            else if (SearchList.SelectedValue == "3")
            {
                GridView1.DataSource = dat.SearchBookByAuthor(search.Text);
                GridView1.DataBind();
            }
        }


        protected void add_Click(object sender, EventArgs e)
        {
            int temp = Convert.ToInt32(ViewState["q"]);

            if (temp == 0)
            {
                temp = 0;
            }

            temp += 1;
            ViewState["q"] = temp;
            TextBox1.Text = ViewState["q"].ToString();
        }

        protected void sub_Click(object sender, EventArgs e)
        {
            int temp = Convert.ToInt32(ViewState["q"]);

            if (temp == 0)
            {
                temp = 1;
            }
            temp -= 1;
            ViewState["q"] = temp;
            TextBox1.Text = ViewState["q"].ToString();
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

            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[10].Text = "Status";
            }
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

            if (Session["ID"] == null)
            {
                Session["ID"] = string.Empty;
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

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //string id = gvModerator.DataKeys[gvModerator.SelectedIndex].Values["ID"].ToString();
                Session["ID"] = GridView1.SelectedDataKey.Value.ToString();

                DetailsLoad();

                //dvHome.DataSource = dat.SearchBookByID(Convert.ToInt32(Session["ID"].ToString()));
                //dvHome.DataBind();
                //msg.Text = Session["ID"].ToString();


            }
            catch (Exception ex)
            {
                msg.Text = ex.Message;
            }
        }
    }
}