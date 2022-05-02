using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using System.IO;
using System.Web.Script.Serialization;
using System.Text;
using Newtonsoft.Json;


namespace Nimapcurdopration
{





    public class dataacess
    {



        public static string instance_name = "DESKTOP-2DO6KSN\\SQLEXPRESS";

        public static string database_name = "Product_Category";



        public Boolean exist(string str)
        {
            Boolean val;
            string strcon = "Data Source=" + instance_name + ";Database=" + database_name + ";User ID=sai;Password=123;Connection Timeout=300000";
            SqlConnection myConnection = new SqlConnection(strcon);
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = str;
            sqlCmd.Connection = myConnection;
            if (myConnection.State == ConnectionState.Closed)
            {
                myConnection.Open();
            }
            SqlDataReader sdr = sqlCmd.ExecuteReader();
            if (sdr.HasRows)
            {
                val = true;
                myConnection.Close();
            }
            else
            {
                val = false;
                myConnection.Close();
            }
            sdr.Close();
            return val;

        }
        public string scalar(string str)
        {
            string dt = "";
            string strcon = "Data Source=" + instance_name + ";Database=" + database_name + ";User ID=sai;Password=123;Connection Timeout=300000";
            SqlConnection myConnection = new SqlConnection(strcon);
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = str;
            sqlCmd.Connection = myConnection;
            if (myConnection.State == ConnectionState.Closed)
            {
                myConnection.Open();
            }



            dt = sqlCmd.ExecuteScalar().ToString();
            myConnection.Close();
            return dt;

        }

        public DataTable data(string str)
        {
            string strcon = "Data Source=" + instance_name + ";Database=" + database_name + ";User ID=sai;Password=123;Connection Timeout=300000";
            SqlConnection myConnection = new SqlConnection(strcon);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(str, myConnection);
            if (myConnection.State == ConnectionState.Closed)
            {
                myConnection.Open();
            }

            da.Fill(dt);
            myConnection.Close();
            return dt;
        }

        public int exeqry(string qry)
        {
            string strcon = "Data Source=" + instance_name + ";Database=" + database_name + ";User ID=sai;Password=123;;Connection Timeout=300000";
            SqlConnection myConnection = new SqlConnection(strcon);
            if (myConnection.State == ConnectionState.Closed)
            {
                myConnection.Open();
            }
            SqlCommand cmd = new SqlCommand(qry, myConnection);
            int var = cmd.ExecuteNonQuery();
            myConnection.Close();
            return var;
        }


    }
}