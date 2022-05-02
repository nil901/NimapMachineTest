using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace Nimapcurdopration.Controllers
{
    public class HomeController : Controller
    {
        string instance_name = "DESKTOP-2DO6KSN\\SQLEXPRESS";


        public ActionResult Product_Category()
        {
            return View();
        }

        dataacess da = new dataacess();
        public ActionResult Category()
        {

            string max_id = da.scalar("select isnull(max(Cat_Id),0)+1[max] from  Category").ToString().Trim();
            ViewBag.max_id = max_id;
            return View();
        }

        

        public string Save_data(string Cat_Id, string Cat_Name)
        {
            string ans = "";
            try
            {

            
            //string instance_name = "DESKTOP-2DO6KSN\\SQLEXPRESS";

            string database_name = "Product_Category";

            string strcongbldefault = "Data Source=" + instance_name + ";Database=" + database_name + ";User ID=sai;Password=123;Connection Timeout=300000";

           
            string url = (strcongbldefault);
            SqlConnection con = new SqlConnection(url);
            //con.Open();", adds);
            SqlCommand cmd = new SqlCommand("insert into Category(Cat_Id,Cat_Name) values (@Cat_Id,@Cat_Name)", con);
            cmd.Parameters.AddWithValue("@Cat_Id", Cat_Id);
            cmd.Parameters.AddWithValue("@Cat_Name", Cat_Name);
            con.Open();
            int i = cmd.ExecuteNonQuery();
             con.Close();
                if (i > 0)
            {
                ans = "Data Saved.....";
            }

            }
            catch (Exception ex)
            {

                ans = ex.Message;
            }




            return ans;

        }





        public ActionResult Show_Detials()
        {
            

            string database_name = "Product_Category";

            string strcongbldefault = "Data Source=" + instance_name + ";Database=" + database_name + ";User ID=sai;Password=123;Connection Timeout=300000";
            DataSet ds = new DataSet();
            DataTable dt2 = new DataTable();
            SqlConnection myConnection = new SqlConnection(strcongbldefault);
            SqlCommand cmd = new SqlCommand("select Cat_Id,Cat_Name from Category", myConnection);

            if (myConnection.State==ConnectionState.Open)
            {
                myConnection.Close();
            }

            myConnection.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                dt2.Load(dr);
            }
            myConnection.Close();
            dr.Close();
            dt2.TableName = "Category_list";
            ds.Tables.Add(dt2);



           
            
            
            
            return View(ds);
        }


        public ActionResult Category_update(string user_id)
        {

            DataTable dt = da.data("select Cat_Id,Cat_Name from Category where Cat_Id='" + user_id + "'");
            if (dt.Rows.Count==0)
            {

                return View();
            }
            ViewBag.max_id = dt.Rows[0]["Cat_Id"].ToString().Trim();
            ViewBag.Cat_Name = dt.Rows[0]["Cat_Name"].ToString().Trim();



            return View();

        }

        public string Update_data(string Cat_Id, string Cat_Name)
        {

            

            string database_name = "Product_Category";

            string strcongbldefault = "Data Source=" + instance_name + ";Database=" + database_name + ";User ID=sai;Password=123;Connection Timeout=300000";

            string ans = "";
            string url = (strcongbldefault);
            SqlConnection con = new SqlConnection(url);
            //con.Open();", adds);
            SqlCommand cmd = new SqlCommand("update Category set Cat_Name=@Cat_Name where Cat_Id= @Cat_Id", con);


            cmd.Parameters.AddWithValue("@Cat_Id", Cat_Id);
            cmd.Parameters.AddWithValue("@Cat_Name", Cat_Name);

            con.Open();
            int i = cmd.ExecuteNonQuery();





            if (i > 0)
            {
                ans = "Data Upadted.....";
            }

            return ans;
        }

        public string Delete_data(string Cat_Id)
        {

          

            string database_name = "Product_Category";

            string strcongbldefault = "Data Source=" + instance_name + ";Database=" + database_name + ";User ID=sai;Password=123;Connection Timeout=300000";

            string ans = "";
            string url = (strcongbldefault);
            SqlConnection con = new SqlConnection(url);
            //con.Open();", adds);
            SqlCommand cmd = new SqlCommand("delete from Category where Cat_Id =@Cat_Id", con);
            cmd.Parameters.AddWithValue("@Cat_Id", Cat_Id);
            con.Open();
            //cmd.Parameters.AddWithValue("@LoginID", LoginID);
            int i = cmd.ExecuteNonQuery();
            if (i > 0)
            {
                ans = "Data Deleted.....";
            }

            return ans;
        }




        public ActionResult product_master()
        {
            string max_id = da.scalar("select isnull(max(ProductID),0)+1[max] from  Product").ToString().Trim();
            ViewBag.max_id = max_id;

            string database_name = "Product_Category";

            string strcongbldefault = "Data Source=" + instance_name + ";Database=" + database_name + ";User ID=sai;Password=123;Connection Timeout=300000";
            DataSet ds = new DataSet();
            DataTable dt2 = new DataTable();
            SqlConnection myConnection = new SqlConnection(strcongbldefault);
            SqlCommand cmd = new SqlCommand("select Cat_Id,Cat_Name from Category", myConnection);

            if (myConnection.State == ConnectionState.Open)
            {
                myConnection.Close();
            }

            myConnection.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                dt2.Load(dr);
            }
            myConnection.Close();
            dr.Close();
            dt2.TableName = "Category_list";
            ds.Tables.Add(dt2);



            return View(ds);
        }








        public string Save_data_product(string ProductID, string ProductName, string category_id)
        {

            

            string database_name = "product_category";

            string strcongbldefault = "Data Source=" + instance_name + ";Database=" + database_name + ";User ID=sai;Password=123;Connection Timeout=300000";

            string ans = "";
            string url = (strcongbldefault);
            SqlConnection con = new SqlConnection(url);
            //con.Open();", adds);
            SqlCommand cmd = new SqlCommand("insert into Product(ProductID,ProductName,Cat_id) values (@ProductID,@ProductName,@category)", con);



            cmd.Parameters.AddWithValue("@ProductID", ProductID);
            cmd.Parameters.AddWithValue("@ProductName", ProductName);
            cmd.Parameters.AddWithValue("@category", category_id);




            con.Open();
            int i = cmd.ExecuteNonQuery();


            if (i > 0)
            {
                ans = "Data Saved.....";
            }

            return ans;
        }



        public ActionResult Show_Detials_product()
        {
        

            string database_name = "product_category";

            string strcongbldefault = "Data Source=" + instance_name + ";Database=" + database_name + ";User ID=sai;Password=123;Connection Timeout=300000";
            DataSet ds = new DataSet();
            DataTable dt2 = new DataTable();
            SqlConnection myConnection = new SqlConnection(strcongbldefault);
            SqlCommand cmd = new SqlCommand("select ProductID,ProductName, Cat_Name category from Product,Category where  Product.Cat_id = Category.Cat_id ", myConnection);
            myConnection.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                dt2.Load(dr);
            }
            myConnection.Close();
            dr.Close();
            dt2.TableName = "category_list";
            ds.Tables.Add(dt2);



            return View(ds);


        }


        public ActionResult product_master_update(string ProductID)
        {
            

            DataTable dt = da.data("select ProductID, ProductName, Cat_Name category,Product.Cat_id from Product,Category  where  Product.Cat_id = Category.Cat_id and ProductID='" + ProductID + "'");
            if (dt.Rows.Count==0)
            {
                return View();
            }
            ViewBag.max_id = dt.Rows[0]["ProductID"].ToString().Trim();
            ViewBag.ProductName = dt.Rows[0]["ProductName"].ToString().Trim();
            ViewBag.category = dt.Rows[0]["category"].ToString().Trim();
            ViewBag.Cat_id = dt.Rows[0]["Cat_id"].ToString().Trim();



            string database_name = "Product_Category";

            string strcongbldefault = "Data Source=" + instance_name + ";Database=" + database_name + ";User ID=sai;Password=123;Connection Timeout=300000";
            DataSet ds = new DataSet();
            DataTable dt2 = new DataTable();
            SqlConnection myConnection = new SqlConnection(strcongbldefault);
            SqlCommand cmd = new SqlCommand("select Cat_Id,Cat_Name from Category", myConnection);

            if (myConnection.State == ConnectionState.Open)
            {
                myConnection.Close();
            }

            myConnection.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                dt2.Load(dr);
            }
            myConnection.Close();
            dr.Close();
            dt2.TableName = "Category_list";
            ds.Tables.Add(dt2);



            return View(ds);


        }

        public string Update_data_product(string ProductID, string ProductName, string category_id)
        {

          

            string database_name = "product_category";

            string strcongbldefault = "Data Source=" + instance_name + ";Database=" + database_name + ";User ID=sai;Password=123;Connection Timeout=300000";

            string ans = "";
            string url = (strcongbldefault);
            SqlConnection con = new SqlConnection(url);
            //con.Open();", adds);
            SqlCommand cmd = new SqlCommand("update Product set ProductName=@ProductName,Cat_id=@category where ProductID= @ProductID", con);


            cmd.Parameters.AddWithValue("@ProductID", ProductID);
            cmd.Parameters.AddWithValue("@ProductName", ProductName);
            cmd.Parameters.AddWithValue("@category", category_id);





            con.Open();
            int i = cmd.ExecuteNonQuery();





            if (i > 0)
            {
                ans = "Data Upadted.....";
            }

            return ans;
        }




        public string Delete_data_product(string ProductID)
        {



            string database_name = "product_category";
            string strcongbldefault = "Data Source=" + instance_name + ";Database=" + database_name + ";User ID=sai;Password=123;Connection Timeout=300000";
            string ans = "";
            string url = (strcongbldefault);
            SqlConnection con = new SqlConnection(url);
            //con.Open();", adds);
            SqlCommand cmd = new SqlCommand("delete from  Product  where ProductID= @ProductID", con);

            cmd.Parameters.AddWithValue("@ProductID", ProductID);
           





            con.Open();
            int i = cmd.ExecuteNonQuery();





            if (i > 0)
            {
                ans = "Data Deleted.....";
            }

            return ans;
        }


        //public ActionResult Show_Detials_product()
        //{


        //    string database_name = "product_category";

        //    string strcongbldefault = "Data Source=" + instance_name + ";Database=" + database_name + ";User ID=sai;Password=123;Connection Timeout=300000";
        //    DataSet ds = new DataSet();
        //    DataTable dt2 = new DataTable();
        //    SqlConnection myConnection = new SqlConnection(strcongbldefault);
        //    SqlCommand cmd = new SqlCommand("select ProductID,ProductName, Cat_Name category from Product,Category where  Product.Cat_id = Category.Cat_id ", myConnection);
        //    myConnection.Open();
        //    SqlDataReader dr = cmd.ExecuteReader();
        //    if (dr.HasRows)
        //    {
        //        dt2.Load(dr);
        //    }
        //    myConnection.Close();
        //    dr.Close();
        //    dt2.TableName = "category_list";
        //    ds.Tables.Add(dt2);



        //    return View(ds);


        //}
        public ActionResult Show_final_view()
        {


            string database_name = "product_category";

            string strcongbldefault = "Data Source=" + instance_name + ";Database=" + database_name + ";User ID=sai;Password=123;Connection Timeout=300000";
            DataSet ds = new DataSet();
            DataTable dt2 = new DataTable();
            SqlConnection myConnection = new SqlConnection(strcongbldefault);
            SqlCommand cmd = new SqlCommand("select ProductID,ProductName, Cat_Name [category name], Category.Cat_id [categ id] from Product,Category where  Product.Cat_id = Category.Cat_id ", myConnection);
            myConnection.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                dt2.Load(dr);
            }
            myConnection.Close();
            dr.Close();
            dt2.TableName = "category_list";
            ds.Tables.Add(dt2);



            return View(ds);


        }





    }
}