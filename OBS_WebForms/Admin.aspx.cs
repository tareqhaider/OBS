using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OBS_WebForms
{
    public partial class Admin : System.Web.UI.Page
    {
        DataAccess dat = new DataAccess();
        
        DataTable dtSearch = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                Session["Flag"] = false;
                Session["ID"] = string.Empty;
                
                if(Session["token"] == null)
                {
                    Session["token"] = string.Empty;
                }
                if (!string.Equals(Session["token"].ToString(),"Admin"))
                {
                    Response.Redirect("Login.aspx");
                }
               
            }

            





            if (dtSearch.Rows.Count > 0)
            {
                gvAdmin.DataSource = dtSearch;
                gvAdmin.DataBind();
            }


            else if ((bool)Session["Flag"] == false)
            {
                gridLoad();
            }

            //gridLoad();

            gvAdmin.DataKeyNames = new string[2] { "ID", "Email" };

            //Login.Visible = false;
            //Login.Text = "Admin";


            //if(Login.Text == "Admin")
            //{
            //    Response.Redirect("Profile.aspx");
            //}

            
        }

        

        private void gridLoad()
        {
            string query = $@"SELECT a.Id as ID,a.fname as [First Name],a.lname as [Last Name],a.email as Email,u.password as [Password],a.phone as [Phone Number],a.balance as Balance,a.gender AS Gender,
                                a.dob as [Birth Date],a.status as [Status],u.type as [User Type]
                            FROM Account AS a
                            INNER JOIN Users AS u
                            ON a.email = u.email;";

            gvAdmin.DataSource = dat.Data_Selection(query);
            gvAdmin.DataBind();
        }

        private void fieldLoad()
        {
            try
            {
                string query = $@"SELECT a.Id as ID,a.fname as [First Name],a.lname as [Last Name],a.email as Email,u.password as [Password],a.phone as [Phone Number],a.balance as Balance,a.gender AS Gender,
                                a.dob as [Birth Date],a.status as [Status],u.type as [User Type]
                            FROM Account AS a
                            INNER JOIN Users AS u
                            ON a.email = u.email WHERE a.Email = '{Session["ID"].ToString()}'"; //Convert.ToInt32(Session["ID"].ToString())

                DataTable dt = dat.Data_Selection(query);

                //msg.Text = dt.Rows.Count.ToString();
                if (dt.Rows.Count == 1)
                {
                    
                    txtFname.Text = dt.Rows[0]["First Name"].ToString();

                    txtLname.Text = dt.Rows[0]["Last Name"].ToString();

                    txtEmail.Text = dt.Rows[0]["Email"].ToString();

                    txtPassword.Text = dt.Rows[0]["Password"].ToString();

                    txtPhone.Text = dt.Rows[0]["Phone Number"].ToString();
                   
                    txtBalance.Text = dt.Rows[0]["Balance"].ToString();
                    
                    cboGender.SelectedValue = dt.Rows[0]["Gender"].ToString();
                    
                    cboStatus.SelectedValue = dt.Rows[0]["Status"].ToString();

                    cboType.Text = dt.Rows[0]["User Type"].ToString();

                    txtDob.Text = dt.Rows[0]["Birth Date"].ToString();
                }
            }

            catch (Exception ex)
            {
                msg.Text = ex.Message;
            }
        }

        private void Clear_Fields()
        {
            txtFname.Text = string.Empty;
            txtLname.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtPassword.Text = string.Empty;
            txtPhone.Text = string.Empty;
            txtBalance.Text = string.Empty;
            txtDob.Text = string.Empty;
        }
        protected void gvAdmin_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtEmail.ReadOnly = true;

            try
            {
                //string id = gvModerator.DataKeys[gvModerator.SelectedIndex].Values["ID"].ToString();
                Session["ID"] = gvAdmin.SelectedDataKey.Values["Email"].ToString();

                fieldLoad();
                //msg.Text = Session["ID"].ToString();


            }
            catch (Exception ex)
            {
                msg.Text = ex.Message;
            }
        }

        protected void Delete_Click(object sender, EventArgs e)
        {
            try
            {
                string email = Session["ID"].ToString();

                

                if (!string.IsNullOrWhiteSpace(email))
                {
                    string query1 = $@"Delete from Account  Where email = '{email}';";
                    dat.Data_Operation(query1);

                    string query2 = $@"Delete from users  Where email = '{email}';";
                    dat.Data_Operation(query2);
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

        protected void Approve_Click(object sender, EventArgs e)
        {
            try
            {


                string email = Session["ID"].ToString();

                if (!string.IsNullOrWhiteSpace(email))
                {
                    string query = $@"Update account SET status ='Active' Where email = '{email}';";
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

        protected void Create_Click(object sender, EventArgs e)
        {
            Session["access"] = "Admin";
            Response.Redirect("Registration.aspx");
        }

        protected void SearchButton_Click(object sender, EventArgs e)
        {
            Session["Flag"] = true;
            string email = txtSearch.Text;

            string query = $@"SELECT a.Id as ID,a.fname as [First Name],a.lname as [Last Name],a.email as Email,u.password as [Password],a.phone as [Phone Number],a.balance as Balance,a.gender AS Gender,
                                a.dob as [Birth Date],a.status as [Status],u.type as [User Type]
                            FROM Account AS a
                            INNER JOIN Users AS u
                            ON a.email = u.email WHERE a.Email like '{email}%' or a.Email like '%{email}%' or a.Email like '%{email}'";

            dtSearch = dat.Data_Selection(query);

            if (dtSearch.Rows.Count > 0)
            {
                gvAdmin.DataSource = dtSearch;
                gvAdmin.DataBind();
            }
            else
            {
                msg.Text = "Item not found";
            }
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

        protected void Update_Click(object sender, EventArgs e)
        {
            try
            {

                //int id = -999;

                //bool b = int.TryParse(Session["ID"].ToString(), out id);

                if (!string.IsNullOrWhiteSpace(Session["ID"].ToString()))
                {
                    string query = $@"Update Account SET fname = '{txtFname.Text}' , lname = '{txtLname.Text}',gender = '{cboGender.SelectedValue}', phone = '{txtPhone.Text}',dob ='{txtDob.Text}', balance = '{txtBalance.Text}', status = '{cboStatus.SelectedValue}' Where email ='{Session["ID"].ToString()}'";
                    dat.Data_Operation(query);

                    string queryUser = $@"Update Users SET password = '{txtPassword.Text}' , type = '{cboType.SelectedValue}' Where email ='{Session["ID"].ToString()}'";
                    dat.Data_Operation(queryUser);

                    gridLoad();
                }
                else
                {
                    msg.Text = "Please select a item";
                }
                //Clear_Fields();
            }

            catch (Exception ex)
            {
                msg.Text = ex.Message;
            }
        }
    }
}