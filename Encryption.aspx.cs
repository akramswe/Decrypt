using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Security.Cryptography;
using System.Text;

namespace Cryptography3DES
{
    public partial class Encryption : System.Web.UI.Page
    {
        SqlCommand cmd = new SqlCommand();
        SqlConnection con = new SqlConnection();
        DataOperation db = new DataOperation();
        protected void Page_Load(object sender, EventArgs e)
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            con.Open();
            if (Session["Username"] != null)
            {
                string query = @"SELECT [ID]
         ,[Message]
        FROM [dbo].[DES1]";
                GridView1.DataSource = db.GetDatatable(query);
                GridView1.DataBind();
            }
            else
            {
                Response.Redirect("login.aspx");
            }
           

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string key = "@@123";
            MD5CryptoServiceProvider mdHash = new MD5CryptoServiceProvider();
            byte[] keyArr = mdHash.ComputeHash(Encoding.UTF8.GetBytes(key));
            mdHash.Clear();

            byte[] simpleTxt = Encoding.UTF8.GetBytes(TextBox1.Text);

            TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider();
            des.Key = keyArr;
            des.Mode = CipherMode.ECB;
            des.Padding = PaddingMode.PKCS7;

            ICryptoTransform iTransform = des.CreateEncryptor();
            byte[] res = iTransform.TransformFinalBlock(simpleTxt, 0, simpleTxt.Length);
            string cipher = Convert.ToBase64String(res);

            try
            {
                SqlCommand cmd = new SqlCommand("insert into DES1" + "(Message)values(@Message)", con);
                cmd.Parameters.AddWithValue("@Message", cipher);
                // cmd.Parameters.AddWithValue("@Password", PasswordTXT.Text);
                cmd.ExecuteNonQuery();
                // lblmsg.Text = "--- New Account is created with Encrypted Password ---";
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                {
                    //lblmsg.Text = "*** Username alredy exist ***";
                }
                else
                {
                    //  lblmsg.Text = "An Error : " + ex.Message;
                }

            }

            string query = @"SELECT [ID]
         ,[Message]
        FROM [dbo].[DES1]";
            GridView1.DataSource = db.GetDatatable(query);
            GridView1.DataBind();

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string s = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            SqlConnection con = new SqlConnection(s);

            SqlCommand cmd = new SqlCommand("select * from DES1 where ID='" + TextBox4.Text + "'", con);

            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@ID", TextBox4.Text);

            cmd.Connection = con;

            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())

            {

                TextBox1.Text = dr["Message"].ToString();
            }
            dr.Close();
            con.Close();


            string key = "@@123";
            MD5CryptoServiceProvider mdHash = new MD5CryptoServiceProvider();
            byte[] keyArr = mdHash.ComputeHash(Encoding.UTF8.GetBytes(key));
            mdHash.Clear();
            byte[] cipherTxt = Convert.FromBase64String(TextBox1.Text);

            TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider();
            des.Key = keyArr;
            des.Mode = CipherMode.ECB;
            des.Padding = PaddingMode.PKCS7;
            ICryptoTransform iTransform = des.CreateDecryptor();
            byte[] res = iTransform.TransformFinalBlock(cipherTxt, 0, cipherTxt.Length);
            TextBox3.Text = Encoding.UTF8.GetString(res);
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            TextBox1.Text = string.Empty;
            TextBox3.Text = string.Empty;
            TextBox4.Text = string.Empty;

        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("Dashboard.aspx");
        }
    }
}