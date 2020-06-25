using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace OBS_WebForms
{
    public class DataAccess
    {
        

        internal string _connectionString = (@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Tareq\Desktop\New folder\OBS.mdf;Integrated Security=True;Connect Timeout=30;");

        public string InsertAccount(string fname, string lname, string gender, string phone, string email, string dob, decimal balance, string status)
        {
            string msg = string.Empty;
            int rtn = -1;
            balance = decimal.Round(balance, 2);

            string query = string.Format("INSERT INTO account(fname, lname, gender, phone, email, dob, balance, status) VALUES('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', {6}, '{7}')",fname, lname, gender, phone, email, dob, balance, status);
            
            try
            {
                using(SqlConnection connection = new SqlConnection(_connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        rtn = cmd.ExecuteNonQuery();
                    }
                    
                }
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            finally
            {
                msg = msg + "\t" + rtn.ToString();
            }

            return msg;
        }

        public string InsertBook(string bname, string author, string category, string genre, decimal price, int quantity, string seller, string time)
        {
            string msg = string.Empty;
            int rtn = -1;
            price = decimal.Round(price, 2);

            string query = string.Format("INSERT INTO book(bname, author, category, genre, unit_price, quantity, seller, time) VALUES('{0}', '{1}', '{2}', '{3}', {4}, {5}, '{6}', '{7}')", bname, author, category, genre, price, quantity, seller, time);

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        rtn = cmd.ExecuteNonQuery();
                    }

                }
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            finally
            {
                msg = msg + "\t" + rtn.ToString();
            }

            return msg;
        }

        public string InsertUsers(string email, string password, string type)
        {
            string msg = string.Empty;
            int rtn = -1;
            string query = string.Format("INSERT INTO users(email, password, type) VALUES('{0}', '{1}', '{2}')",email, password, type);
            
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        rtn = cmd.ExecuteNonQuery();
                    }

                }
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            finally
            {
                msg = msg + "\t" + rtn.ToString();
            }

            return msg;
        }

        public string InsertOrder(string bookid, string buyer, string seller, string time, int quantity, decimal total, decimal discount, decimal refund, string status)
        {
            string msg = string.Empty;
            int rtn = -1;

            total = decimal.Round(total, 2);
            discount = decimal.Round(discount, 2);
            refund = decimal.Round(refund, 2);

            string query = string.Format("INSERT INTO orders(bookid, buyer, seller, time, quantity, total_price, discount, refund, status) VALUES('{0}', '{1}', '{2}', '{3}', '{4}', {5}, {6}, {7}, '{8}')",  bookid, buyer, seller, time, quantity, total, discount, refund, status);

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        rtn = cmd.ExecuteNonQuery();
                    }

                }
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            finally
            {
                msg = msg + "\t" + rtn.ToString();
            }

            return msg;
        }

        public int LoginCheck(string email,string password)
        {
            string msg = string.Empty;
            int rtn = -1;

            string query = string.Format("select count(*) from users where email = '{0}' and password = '{1}'", email, password);
            try
            {
                using(SqlConnection connection = new SqlConnection(_connectionString))
                {
                    using(SqlCommand cmd = new SqlCommand(query,connection))
                    {
                        connection.Open();
                        rtn = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            finally
            {
                msg = msg + "\t" + rtn;
            }

            return rtn;
        }


        public string LoginTypeCheck(string email, string password)
        {
            string msg = string.Empty;
            string rtn = string.Empty;

            string query = string.Format("select type from users where email = '{0}' and password = '{1}'", email, password);
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        rtn = cmd.ExecuteScalar().ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            finally
            {
                msg = msg + "\t" + rtn;
            }

            return rtn;
        }

        public int GetBookQuantity(int bookid)
        {
            string msg = string.Empty;

            string query = string.Format("select quantity from book where Id ={0}", bookid);
            int quantity = -1;

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        quantity = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }
            }
            catch(Exception ex)
            {
                msg = ex.Message;
            }
            return quantity;
        }

        public int SetBookQuantity(int bookid, int quantity)
        {
            int rtn = -1;
            string msg = string.Empty;

            string query = string.Format("Update book Set quantity = {1} where Id ={0}", bookid, quantity);
            

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        rtn = cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return rtn;
        }

        public DataTable SearchBookByName(string name)
        {
            string msg = string.Empty;
            string query = string.Format("select * from book where bname like '{0}%' or bname like '%{0}%' or bname like '%{0}'", name);

            using (DataTable dt = new DataTable())
            {
                try
                {
                    using(SqlConnection connection = new SqlConnection(_connectionString))
                    {
                        using(SqlCommand cmd = new SqlCommand(query, connection))
                        {
                            connection.Open();
                            using(SqlDataAdapter da = new SqlDataAdapter(cmd))
                            {
                                da.Fill(dt);
                            }
                        }
                    }
                }
                catch(Exception ex)
                {
                    msg = ex.Message;
                }

                return dt;
            }

                
        }

        public DataTable SearchBookByAuthor(string name)
        {
            string msg = string.Empty;
            string query = string.Format("select * from book where author like '{0}%' or author like '%{0}%' or author like '%{0}'", name);

            using (DataTable dt = new DataTable())
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(_connectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand(query, connection))
                        {
                            connection.Open();
                            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                            {
                                da.Fill(dt);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    msg = ex.Message;
                }

                return dt;
            }


        }

        public DataTable SearchBookByID(int id)
        {
            string msg = string.Empty;
            string query = string.Format("select * from book where id = {0}", id);

            using (DataTable dt = new DataTable())
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(_connectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand(query, connection))
                        {
                            connection.Open();
                            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                            {
                                da.Fill(dt);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    msg = ex.Message;
                }

                return dt;
            }
        }

        public DataTable GetTable(string name)
        {
            string msg = string.Empty;
            string query = string.Format("select * from {0}", name);

            using (DataTable dt = new DataTable())
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(_connectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand(query, connection))
                        {
                            connection.Open();
                            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                            {
                                da.Fill(dt);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    msg = ex.Message;
                }

                return dt;
            }
        }

        public DataTable GetSellPosts(string name)
        {
            string msg = string.Empty;
            string query = string.Format("select * from book where seller = '{0}' order by time desc", name);

            using (DataTable dt = new DataTable())
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(_connectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand(query, connection))
                        {
                            connection.Open();
                            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                            {
                                da.Fill(dt);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    msg = ex.Message;
                }

                return dt;
            }


        }

        public DataTable Data_Selection(string query)
        {
            string msg = string.Empty;

            using (DataTable dataTable = new DataTable())
            {
                try
                {
                    using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
                    using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                    using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand))
                    {
                        sqlConnection.Open();
                        sqlDataAdapter.Fill(dataTable);
                    }
                }

                catch (Exception Ex)
                {
                    msg = Ex.Message;
                }


                return dataTable;
            }

        }

        public void Data_Operation(string query)
        {
            string msg = string.Empty;

            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
                using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    sqlConnection.Open();
                    sqlCommand.ExecuteNonQuery();
                }
            }

            catch (Exception Ex)
            {
                msg = Ex.Message;
            }

        }

        
    }
}