using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerrificSmile.modules.Codes
{
    class database_connection
    {
        static string ConnectionString = @"Data Source=MICHAEL-PC\SQLEXPRESS;Initial Catalog=db_TerrificSmile;Integrated Security=True";
        public static SqlConnection con = new SqlConnection();
        public static SqlCommand cmd = new SqlCommand();
        public static SqlDataAdapter da = new SqlDataAdapter();
        public static DataSet ds = new DataSet();
        public static DataTable dt = new DataTable();


        string ConnectionString1 = @"Data Source=MICHAEL-PC\SQLEXPRESS;Initial Catalog=db_TerrificSmile;Integrated Security=True";
        public static SqlConnection conn = new SqlConnection();
        public static SqlCommand cmdd = new SqlCommand();
        public static SqlDataAdapter daa = new SqlDataAdapter();
        public static DataSet dss = new DataSet();

        string ConnectionString2 = @"Data Source=MICHAEL-PC\SQLEXPRESS;Initial Catalog=db_TerrificSmile;Integrated Security=True";
        public static SqlConnection conn2 = new SqlConnection();
        public static SqlCommand cmdd2 = new SqlCommand();
        public static SqlDataAdapter daa2 = new SqlDataAdapter();
        public static DataSet dss2 = new DataSet();

        public static DataSet Connectionstatic(string query)
        {
            try
            {
                con = new SqlConnection(ConnectionString);
                cmd = new SqlCommand(query, con);
                con.Open();

                ds = new DataSet();
                da = new SqlDataAdapter(cmd);

                da.Fill(ds, "Table1");
                con.Close();
            }
            catch (Exception e)
            {


            }
            return ds;
        }
        public DataSet Connection2(string query)
        {
            try
            {
                conn = new SqlConnection(ConnectionString1);
                cmdd = new SqlCommand(query, conn);
                conn.Open();

                dss = new DataSet();
                daa = new SqlDataAdapter(cmdd);
                daa.Fill(dss, "Table1");
                conn.Close();

            }
            catch (Exception e)
            {


            }
            return dss;
        }
        public DataSet Connection3(string query)
        {
            try
            {
                conn2 = new SqlConnection(ConnectionString2);
                cmdd2 = new SqlCommand(query, conn2);
                conn2.Open();

                dss2 = new DataSet();
                daa2 = new SqlDataAdapter(cmdd2);
                daa2.Fill(dss2, "Table1");
                conn2.Close();

            }
            catch (Exception e)
            {


            }
            return dss2;
        }
        public async Task<DataSet> Connection1Async(string query)
        {
            await Task.Run(() =>
            {
                Connection2(query);
            });
            return dss;
        }
        public async Task<DataSet> Connection2Async(string query)
        {
            await Task.Run(() =>
            {
                Connection3(query);
            });
            return dss2;
        }
    }
}
