using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OBS_WebForms
{
    public partial class Moderator : System.Web.UI.Page
    {
        DataAccess dat = new DataAccess();
        //DataTable dt = new DataTable();
        //DataTable search = new DataTable();
        DataTable dtSearch = new DataTable();
        
    protected void Page_Load(object sender, EventArgs e)
        {
            //comboBoxLoad();

            if (!IsPostBack)
            {
                Session["Flag"] = false;
                Session["ID"] = string.Empty;

                if (Session["token"] == null)
                {
                    Session["token"] = string.Empty;
                }
                if (!string.Equals(Session["token"].ToString(), "Moderator"))
                {
                    Response.Redirect("Login.aspx");
                }

            }
            
            if (dtSearch.Rows.Count > 0)
            {
                gvModerator.DataSource = dtSearch;
                gvModerator.DataBind();
            }

            
            else if ((bool)Session["Flag"] == false)
            {
                gridLoad();
            }



            gvModerator.DataKeyNames = new string[3] { "ID", "Book Name", "Seller ID" };


        }

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

        private void gridLoad()
        {
            string query = $@"SELECT Id AS ID,bname AS [Book Name],author AS Author, category AS Category,genre AS Genre,unit_price AS Price,quantity AS Quantity,seller AS [Seller ID],time as [Time Posted],status AS Status FROM BOOK";

            gvModerator.DataSource = dat.Data_Selection(query);
            gvModerator.DataBind();
        }

        private void Clear_Fields()
        {
            txtBookName.Text = string.Empty;
            txtAuthor.Text = string.Empty;
            txtPrice.Text = string.Empty;
            txtQuantity.Text = string.Empty;
            txtSeller.Text = string.Empty;
            txtSearch.Text = string.Empty;
        }
        private void comboBoxLoad()
        {
            string[] searchList = new string[2] { "Active", "Inactive" };
            cboSearchList.DataSource = searchList;
            cboSearchList.DataBind();

            string[] category = new string[3] { "New", "Used", "Rare" };
            cboCategory.DataSource = category;
            cboCategory.DataBind();

            string[] genre = new string[5] { "Science", "Technology", "Programming", "Business", "Novel" };
            cboGenre.DataSource = genre;
            cboGenre.DataBind();

            cboStatus.DataSource = searchList;
            cboStatus.DataBind();

        }

        private void fieldLoad()
        {
            try
            {
                string query = $@"SELECT Id AS ID,bname AS [Book Name],author AS Author, category AS Category,genre AS Genre,unit_price AS Price,quantity AS Quantity,seller AS [Seller ID],time as [Time Posted],status AS Status FROM BOOK WHERE ID = {Convert.ToInt32(Session["ID"].ToString())}";

                DataTable dt = dat.Data_Selection(query);

                if (dt.Rows.Count == 1)
                {
                    txtBookName.Text = dt.Rows[0]["Book Name"].ToString();
                    txtAuthor.Text = dt.Rows[0]["Author"].ToString();
                    cboCategory.SelectedValue = dt.Rows[0]["Category"].ToString();
                    cboGenre.SelectedValue = dt.Rows[0]["Genre"].ToString();
                    txtPrice.Text = dt.Rows[0]["Price"].ToString();
                    txtPrice.ReadOnly = true;
                    txtQuantity.Text = dt.Rows[0]["Quantity"].ToString();
                    txtQuantity.ReadOnly = true;
                    txtSeller.Text = dt.Rows[0]["Seller ID"].ToString();
                    txtSeller.ReadOnly = true;
                    cboStatus.SelectedValue = dt.Rows[0]["Status"].ToString();
                }
            }

            catch(Exception ex)
            {
                msg.Text = ex.Message;
            }
        }
        protected void gvModerator_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                //string id = gvModerator.DataKeys[gvModerator.SelectedIndex].Values["ID"].ToString();
                Session["ID"] = gvModerator.SelectedDataKey.Value.ToString();

                fieldLoad();
                //msg.Text = Session["ID"].ToString();

                
            }
            catch(Exception ex)
            {
                msg.Text = ex.Message;
            }




        }

        protected void SearchButton_Click(object sender, EventArgs e)
        {
            Session["Flag"] = true;

            //string subQuery = $@"(SELECT * FROM BOOK Where bname  like '{txtSearch.Text}%' or bname like '%{txtSearch.Text}%' or bname like '%{txtSearch.Text}';)";
            //string subQuery1 = $@"(SELECT * FROM BOOK Where Status = 'Inactive')";


            if (string.Equals(cboSearchList.Text, "All") && string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                gridLoad();
            }

            //else if (string.Equals(cboSearchList.Text, "Active"))
            //{
                
            //    string query = $@"SELECT Id AS ID,bname AS [Book Name],author AS Author, category AS Category,genre AS Genre,unit_price AS Price,quantity AS Quantity,seller AS [Seller ID],time as [Time Posted],status AS Status FROM BOOK WHERE  bname  like '{txtSearch.Text}%' or bname like '%{txtSearch.Text}%' or bname like '%{txtSearch.Text}' AND Status like 'Active' ";
            //    gvModerator.DataSource = dat.Data_Selection(query);
            //    gvModerator.DataBind();
            //}

            //else if (string.Equals(cboSearchList.Text, "Inactive"))
            //{

            //    string query = $@"SELECT * FROM BOOK Where bname  like '{txtSearch.Text}%' or bname like '%{txtSearch.Text}%' or bname like '%{txtSearch.Text}'  IN '{subQuery1}' ";
            //    gvModerator.DataSource = dat.Data_Selection(query);
            //    gvModerator.DataBind();
            //}

            else if (string.Equals(cboSearchList.Text, "Seller") && !string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                string email = txtSearch.Text;

                string query = $@"SELECT Id AS ID, bname AS[Book Name], author AS Author, category AS Category, genre AS Genre, unit_price AS Price, quantity AS Quantity, seller AS [Seller ID], time as [Time Posted], status AS Status FROM BOOK WHERE seller like '{email}%' or seller like '%{email}%' or seller like '%{email}'";

                dtSearch = dat.Data_Selection(query);

                if (dtSearch.Rows.Count > 0)
                {
                    gvModerator.DataSource = dtSearch;
                    gvModerator.DataBind();
                }
                else
                {
                    msg.Text = "Item not found";
                }
            }

            else
            {
                string bname = txtSearch.Text;

                string query = $@"SELECT Id AS ID, bname AS[Book Name], author AS Author, category AS Category, genre AS Genre, unit_price AS Price, quantity AS Quantity, seller AS [Seller ID], time as [Time Posted], status AS Status FROM BOOK WHERE bname like '{bname}%' or bname like '%{bname}%' or bname like '%{bname}'";

                dtSearch = dat.Data_Selection(query);

                if (dtSearch.Rows.Count > 0)
                {
                    gvModerator.DataSource = dtSearch;
                    gvModerator.DataBind();
                }
                else
                {
                    msg.Text = "Item not found";
                }
            }
            
        }

        protected void Approve_Click(object sender, EventArgs e)
        {
            try
            {
                int id = -999;

                bool b = int.TryParse(Session["ID"].ToString(), out id);

                if (id > 0 && b)
                {
                    string query = $@"Update book SET status ='Active' Where id = {id};";
                    dat.Data_Operation(query);
                    gridLoad();
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

        protected void Update_Click(object sender, EventArgs e)
        {
            //msg.Text = Session["ID"].ToString();
            //msg.ForeColor = System.Drawing.Color.Red;
            try
            {

                int id = -999;

                bool b = int.TryParse(Session["ID"].ToString(), out id);

                if (id > 0 && b)
                {
                    string query = $@"Update book SET bname = '{txtBookName.Text}' , author = '{txtAuthor.Text}',category = '{cboCategory.SelectedValue}', genre = '{cboGenre.SelectedValue}',status ='{cboStatus.SelectedValue}' Where id ={Convert.ToInt32(Session["ID"].ToString())};";
                    dat.Data_Operation(query);
                    gridLoad();
                }
                else
                {
                    msg.Text = "Please select a item";
                }
                Clear_Fields();
            }

            catch(Exception ex)
            {
                msg.Text = ex.Message;
            }
        }

        protected void Delete_Click(object sender, EventArgs e)
        {
            try
            {
                int id = -999;

                bool b = int.TryParse(Session["ID"].ToString(), out id);

                if (id > 0 && b)
                {
                    string query = $@"Delete from book  Where id = {id};";
                    dat.Data_Operation(query);
                    gridLoad();
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