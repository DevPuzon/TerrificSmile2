using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TerrificSmile.modules.Codes
{
    class database_connection
    {
        static string ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\Drive_D\Projects\Github\TerrificSmile\db_TerrificSmile.accdb";
        public static OleDbConnection con = new OleDbConnection();
        public static OleDbCommand cmd = new OleDbCommand();
        public static OleDbDataAdapter da = new OleDbDataAdapter();
        public static DataSet ds = new DataSet();
        public static DataTable dt = new DataTable();

        public static OleDbConnection conn = new OleDbConnection();
        public static OleDbCommand cmdd = new OleDbCommand();
        public static OleDbDataAdapter daa = new OleDbDataAdapter();
        public static DataSet dss = new DataSet();

        public static OleDbConnection conn2 = new OleDbConnection();
        public static OleDbCommand cmdd2 = new OleDbCommand();
        public static OleDbDataAdapter daa2 = new OleDbDataAdapter();
        public static DataSet dss2 = new DataSet();

        public static DataSet Connectionstatic(string query)
        {
            try
            {
                con = new OleDbConnection(ConnectionString);
                cmd = new OleDbCommand(query, con);
                con.Open();

                ds = new DataSet();
                da = new OleDbDataAdapter(cmd);

                da.Fill(ds, "Table1");
                con.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return ds;
        }

        public DataSet Connection2(string query)
        {
            try
            {
                conn = new OleDbConnection(ConnectionString);
                cmdd = new OleDbCommand(query, conn);
                conn.Open();

                dss = new DataSet();
                daa = new OleDbDataAdapter(cmdd);
                daa.Fill(dss, "Table1");
                conn.Close();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);

            }
            return dss;
        }
        public DataSet Connection3(string query)
        {
            try
            {
                conn2 = new OleDbConnection(ConnectionString);
                cmdd2 = new OleDbCommand(query, conn2);
                conn2.Open();

                dss2 = new DataSet();
                daa2 = new OleDbDataAdapter(cmdd2);
                daa2.Fill(dss2, "Table1");
                conn2.Close();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);

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
