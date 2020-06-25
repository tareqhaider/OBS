using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OBS_WebForms
{
    public partial class Registration : System.Web.UI.Page
    {
        DataAccess dat = new DataAccess();

        protected void Page_Load(object sender, EventArgs e)
        {
            InitilizeSessions();
            
            //if (!IsPostBack)
            //{
            //    if (Session["token"] == null)
            //    {
            //        Session["token"] = string.Empty;
            //    }

            //}

            if (string.Equals(Session["token"].ToString(), "Admin"))
            {
                typeList_Load();
            }
        }

        private void typeList_Load()
        {
            List<string> adminControl = new List<string>();
            adminControl.Add("Admin");
            adminControl.Add("Moderator");


            typeList.DataSource = adminControl;
            typeList.DataBind();
        }
        protected void register_Click(object sender, EventArgs e)
        {
            char partition = '@';
            string session = string.Empty;
            string temp = string.Empty;
            string password = string.Empty;
            string cp = string.Empty;
            bool b = false;

            List<bool> dict = new List<bool>();

            b = ValidateNames(fname.Text, out temp);
            dict.Add(b);
            var v = (b == true) ? session += partition + temp : fname.Text = string.Empty;


            b = ValidateNames(lname.Text, out temp);
            dict.Add(b);
            session += partition + temp;

            b = ValidatePasswords(pass.Text, out password);
            dict.Add(b);

            b = ValidatePasswords(cpass.Text, out cp);
            dict.Add(b);

            //v = (password == cp) ? session += partition + password : null;
            //v = "abc";

            if (string.Equals(pass.Text, cpass.Text) && !string.IsNullOrWhiteSpace(pass.Text) && !string.IsNullOrWhiteSpace(cpass.Text))
            {
                b = true;
                dict.Add(b);
            }
            else
            {
                b = false;
                dict.Add(b);
            }

            b = ValidatePhone(phone.Text);
            dict.Add(b);

            if (b)
            {
                Session["phone"] = phone.Text;
            }

            b = ValidateEmail(email.Text);
            dict.Add(b);

            if (b)
            {
                Session["email"] = email.Text;
            }

            b = !string.IsNullOrWhiteSpace(genderList.Text);
            dict.Add(b);

            if (b)
            {
                Session["gender"] = genderList.Text;
            }


            if (ValidateAll(dict))
            {
                msg.Text = dat.InsertAccount(fname.Text, lname.Text, genderList.Text, phone.Text, email.Text, dob.Text, 00.00m, "Inactive");
                msg.Text = dat.InsertUsers(email.Text, pass.Text, typeList.Text);

                msg.Text = "Registration Successful";
                lbl.Text = string.Empty;
            }

            else
            {
                msg.Text = "One or Many Invalid Fields";
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
        protected void back_Click(object sender, EventArgs e)
        {
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

        private void LogCheck()
        {
            int i = dat.LoginCheck(Session["email"].ToString(), Session["password"].ToString());

            if (i == 1)
            {
                Response.Redirect(Request.RawUrl);
            }

            else
            {
                Response.Redirect("Login.aspx");
            }
        }

        private bool ValidateNames(string input, out string output)
        {
            output = string.Empty;

            if (!string.IsNullOrWhiteSpace(input))
            {
                var text = input;

                text = Regex.Replace(text, @"[\s+]", string.Empty);
                text = Regex.Replace(text, @"[\d-]", string.Empty);
                text = Regex.Replace(text, @"[~`!@#$%^&*()+=|\\{}':;.,<>/?[\]""_-]", string.Empty);

                output = text.ToString();

                return true;

            }
            else
            {
                return false;
            }
        }

        private bool ValidatePasswords(string input, out string output)
        {
            output = string.Empty;

            if (!string.IsNullOrWhiteSpace(input))
            {
                var text = input;

                text = Regex.Replace(text, @"[\s+]", string.Empty);


                output = text.ToString();

                return true;

            }
            else
            {
                return false;
            }
        }

        private bool ValidatePhone(string input)
        {
            if (string.IsNullOrWhiteSpace(input) == false)
            {
                int parse;
                bool result = int.TryParse(input, out parse);

                if (input.Length == 11 & result == true)
                {
                    if (input.StartsWith("013") || input.StartsWith("014") || input.StartsWith("015") || input.StartsWith("016") || input.StartsWith("017") || input.StartsWith("018") || input.StartsWith("019"))
                    {

                        return true;
                    }
                    else
                    {

                        return false;
                    }
                }
                else
                {

                    return false;
                }
            }
            else
            {

                return false;
            }
        }

        private bool ValidateEmail(string e)
        {
            if (string.IsNullOrEmpty(e) == false)
            {
                if (e.EndsWith("@gmail.com") || e.EndsWith("@yahoo.com") || e.EndsWith("@hotmail.com"))
                {


                    string query = $@"SELECT * From Users Where email = '{email.Text}'";
                    DataTable dt = dat.Data_Selection(query);
                    if (dt.Rows.Count > 0)
                    {
                        lbl.Text = "Email Already Exists";
                        return false;
                    }

                    else
                    {
                        return true;
                    }
                    //return true;
                }
                else
                {

                    return false;
                }
            }
            else
            {

                return false;
            }

        }

        private bool ValidateAll(List<bool> lst)
        {
            bool b = true;
            foreach (var items in lst)
            {
                if (items == false)
                {
                    b = false;
                    break;
                }
            }
            return b;
        }

        //private bool VerifyPasswords(string pass, string cpass)
        //{
        //    if(pass == cpass)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}
    }
}