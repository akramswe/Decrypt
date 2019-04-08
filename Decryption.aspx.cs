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
    public partial class Decryption : System.Web.UI.Page
    {
        SqlCommand cmd = new SqlCommand();
        SqlConnection con = new SqlConnection();
        DataOperation db = new DataOperation();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["Username1"] != null)
            {

                lblmsg.Text = "Welcome " + Session["Username1"].ToString() + " you have loged-in successfully";
                //  lblmsg.Text = "Welcome " + (string)(Session["Username"]) + " you have loged-in successfully";
                con.ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                con.Open();

                string query = @"SELECT [ID]
                      ,[Message]
                      FROM [dbo].[DES1]";
                GridView1.DataSource = db.GetDatatable(query);
                GridView1.DataBind();

            }
            else
            {
                Response.Redirect("Portal Login.aspx");
            }
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

                TextBox2.Text = dr["Message"].ToString();
            }
            dr.Close();
            con.Close();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {

            string key = "@@123";
            MD5CryptoServiceProvider mdHash = new MD5CryptoServiceProvider();
            byte[] keyArr = mdHash.ComputeHash(Encoding.UTF8.GetBytes(key));
            mdHash.Clear();
            byte[] cipherTxt = Convert.FromBase64String(TextBox2.Text);

            TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider();
            des.Key = keyArr;
            des.Mode = CipherMode.ECB;
            des.Padding = PaddingMode.PKCS7;
            ICryptoTransform iTransform = des.CreateDecryptor();
            byte[] res = iTransform.TransformFinalBlock(cipherTxt, 0, cipherTxt.Length);
            TextBox3.Text = Encoding.UTF8.GetString(res);
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            TextBox2.Text = string.Empty;
            TextBox3.Text = string.Empty;
            TextBox4.Text = string.Empty;
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            Session.Remove("Username1");
            //Session.RemoveAll();
            Response.Redirect("~/Portal Login.aspx");
        }
    }
}