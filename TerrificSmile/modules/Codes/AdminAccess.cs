using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TerrificSmile.modules.Codes
{
    class AdminAccess
    {
        public static Visibility _accessAdmin(string adminUsername, string password)
        {
            Visibility visibility = Visibility.Collapsed;
            string query;
            DataSet ds;
            try
            {
                query = $@"select * from tbl_admin where col_adminUsername = '{adminUsername}' and col_password = '{password}'";
                ds = database_connection.Connectionstatic(query);
                int count;
                count = ds.Tables[0].Rows.Count;
                if(count > 0)
                {
                    visibility = Visibility.Visible;
                }
                else
                {
                    MessageBox.Show("Admin or password doesn't match");
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return visibility;
        }
    }
}
