using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TerrificSmile.modules.Codes
{
    public class Income
    {
        public Income()
        {
            inventory_source = new ObservableCollection<inventorysource>();
            expenses_source = new ObservableCollection<expensessource>();
        }
        public ObservableCollection<inventorysource> inventory_source;
        public ObservableCollection<expensessource> expenses_source;
        database_connection dc = new database_connection();
        public class inventorysource
        {
            public string id { get; set; }
            public string gross { get; set; }
            public string commission { get; set; }
            public string perday { get; set; }
            public string other { get; set; }
            public string day { get; set; }
            public string month { get; set; }
            public string year { get; set; }
        }

        public class expensessource
        {
            public string id { get; set; }
            public string description { get; set; }
            public string fee { get; set; }
            public string month { get; set; }
            public string year { get; set; }
        }

        public async void _search(string month, string year)
        {
            dc = new database_connection();
            string query;
            DataSet ds;
            DataRow drow;
            try
            {
                //daily inventory
                query = $@"select * from tbl_monthlyIncome 
where col_month = '{month}' or
col_year = '{year}'";
                ds = await dc.Connection2Async(query);
                int count;
                count = ds.Tables[0].Rows.Count;
                for (int i = 0; i < count; i++)
                {
                    drow = ds.Tables[0].Rows[i];
                    inventory_source.Add(new inventorysource {
                        id = drow.ItemArray.GetValue(0).ToString(),
                        gross = drow.ItemArray.GetValue(1).ToString(),
                        commission = drow.ItemArray.GetValue(2).ToString(),
                        perday = drow.ItemArray.GetValue(3).ToString(),
                        other = drow.ItemArray.GetValue(4).ToString(),
                        day = drow.ItemArray.GetValue(5).ToString(),
                        month = drow.ItemArray.GetValue(6).ToString(),
                        year = drow.ItemArray.GetValue(7).ToString(),
                    });
                }
                //expenses
                query = $@"select * from tbl_expenses 
where col_month = '{month}' or
col_year = '{year}'";
                ds = await dc.Connection2Async(query);
                count = ds.Tables[0].Rows.Count;
                for (int i = 0; i < count; i++)
                {
                    drow = ds.Tables[0].Rows[i];
                    expenses_source.Add(new expensessource
                    {
                        id = drow.ItemArray.GetValue(0).ToString(),
                        description = drow.ItemArray.GetValue(1).ToString(),
                        fee = drow.ItemArray.GetValue(2).ToString(),
                        month = drow.ItemArray.GetValue(3).ToString(),
                        year = drow.ItemArray.GetValue(4).ToString(),
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public List<string> _day()
        {
            List<string> a = new List<string>();
            for(int i =1; i <= 31; i++)
            {
                a.Add(i.ToString());
            }
            return a;
        }
        public List<string> _month()
        {
            List<string> a = new List<string>();
            for (int i = 1; i <= 12; i++)
            {
                a.Add(i.ToString());
            }
            return a;
        }
        public List<string> _year()
        {
            List<string> a = new List<string>();
            for (int i = 2019; i <= 2025; i++)
            {
                a.Add(i.ToString());
            }
            return a;
        }
    }
}
