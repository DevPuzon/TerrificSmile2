using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TerrificSmile.modules.Codes
{
    public class dentalrecord 
    {
        public dentalrecord()
        {
            teeth_source = new ObservableCollection<teethsource>();
        }
        public ObservableCollection<teethsource> teeth_source;

        public class teethsource
        {
            public string teeth_id { get; set; }
            public string teeth_status { get; set; }
        }
        database_connection dc = new database_connection();
        public async void teethSourceId(string teethid)
        {
            dc = new database_connection();
            DataSet ds;
            DataRow drow;
            string query;
            try
            {
                query = $@"select col_teethid from tbl_teethexam where col_teethid = '{teethid}'";
                ds = await dc.Connection2Async(query);
                int count;
                count = ds.Tables[0].Rows.Count;

                if (count != 0)
                {
                    query = $@"delete from tbl_teethexam where col_teethid = '{teethid}'";
                    dc.Connection2(query);
                }
              else
                {
                    query = $@"insert into tbl_teethexam(col_teethid) values('{teethid}')";
                    dc.Connection2(query);
                }
                teeth_source.Clear();
                query = $@"select col_teethid from tbl_teethexam";
                ds = await dc.Connection2Async(query);
                int ctr, total;
                total = ds.Tables[0].Rows.Count;
                for (ctr = 0; ctr < total; ctr++)
                {
                    drow = ds.Tables[0].Rows[ctr];
                    teeth_source.Add(new teethsource { teeth_id = drow.ItemArray.GetValue(0).ToString() }); 
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            //if (teeth_source.Any(x => x.teeth_id.Contains(teethid)))
            //{
            //    //teeth_source.Remove(new teethsource { teeth_id = teethid });
            //    //int a = teeth_source.IndexOf(new teethsource { teeth_id = teethid });
            //    //MessageBox.Show(a.ToString());
            //    foreach (teethsource item in teeth_source)
            //    {
            //        item.teeth_id.Remove(1, 1);
            //        MessageBox.Show("");
            //    } 
            //}
            //else
            //{
            //    teeth_source.Add(new teethsource { teeth_id = teethid});
            //}
        }
    }
}
