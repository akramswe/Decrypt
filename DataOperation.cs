using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Cryptography3DES
{
    public class DataOperation
    {
        //connection for database
        string connectstring = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        //Method for database for collect data.
        public DataTable GetDatatable(string query)
        {

            //sql connection object
            SqlConnection conn = new SqlConnection(connectstring);
            //check connection on or off
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            //connection to database and carry data.
            SqlDataAdapter adap = new SqlDataAdapter(query, conn);
            //storage 
            DataTable dt = new DataTable();
            //fill data table
            adap.Fill(dt);
            //return data table using dt.
            return dt;

        }

        public int executequery(string query)
        {
            //sql connection object.
            SqlConnection conn = new SqlConnection(connectstring);
            //check database on or off
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }

            //insert data into database
            SqlCommand cmd = new SqlCommand(query, conn);

            try
            {
                //save data into database
                cmd.ExecuteNonQuery();
                return 1;

            }
            catch (SqlException ex)
            {
                return 0;
            }

        }

    }
}