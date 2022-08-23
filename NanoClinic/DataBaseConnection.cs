using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Microsoft.Win32;
using System.IO;




namespace NanoClinic
{
    class DataBaseConnection
    {
        private SqlConnection con;
        private SqlCommand cmd;
        private DataSet ds;
        private SqlDataAdapter da;

        public DataBaseConnection()
        {

            
                con = new SqlConnection("Data Source=DESKTOP-CJUIRT8;Initial Catalog=Testing_1;Integrated Security=True");
            
           
        }

        public void openConnection()
        {
            con.Open();
        }

        public void closeConnection()
        {
            con.Close();
        }
        
        public int Insert_Update_Delete(string q) 
        {
            int i=0;
                openConnection();
                cmd = new SqlCommand(q, con);
            try
            {

                 i = cmd.ExecuteNonQuery();

            }
            catch (SqlException)
            {
            }
            catch (Exception)
            {

            }
            closeConnection();
                return i;
  
        }

        public DataTable display(string q)
        {
            openConnection();
            da = new SqlDataAdapter(q, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            closeConnection();

            return dt;
        }
        public DataTable passprofile(string q)
        {
            openConnection();
            da = new SqlDataAdapter(q, con);
            ds = new DataSet("myDataSet");
            DataTable dataTable = new DataTable();
            da.Fill(dataTable);


            return dataTable;
        }
        
        
       


        public int CheckLogin(string q)
        {
            
                openConnection();
                da = new SqlDataAdapter(q, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                closeConnection();
                if (dt.Rows[0][0].ToString() == "1")
                    return 1;
                else
                    return 0;
            
            
           

        }


    }
}
