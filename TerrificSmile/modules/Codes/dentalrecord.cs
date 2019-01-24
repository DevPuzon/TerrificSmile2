using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

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
            public string teeth_amount { get; set; }
        }
        database_connection dc = new database_connection();
        public void teethSourceIds(MahApps.Metro.IconPacks.PackIconEntypo icon)
        {
            ucontrol_dentalchart1.iconList.Add(icon);
        }
        public MahApps.Metro.IconPacks.PackIconEntypoKind teethSourceId(string teethid)
        {
            //ucontrol_dentalchart1.iconList.Add(icon);
            MahApps.Metro.IconPacks.PackIconEntypoKind packIcon = MahApps.Metro.IconPacks.PackIconEntypoKind.CircleWithCross;
            dc = new database_connection();
            DataSet ds;
            DataRow drow;
            string query;
            try
            {
                query = $@"select col_teethid from tbl_teethexam where col_teethid = '{teethid}'";
                ds = dc.Connection2(query);
                int count;
                count = ds.Tables[0].Rows.Count;

                if (count != 0)
                {
                    packIcon = MahApps.Metro.IconPacks.PackIconEntypoKind.Circle;
                    query = $@"delete from tbl_teethexam where col_teethid = '{teethid}'";
                    dc.Connection2(query);
                }
              else
                {
                    packIcon = MahApps.Metro.IconPacks.PackIconEntypoKind.CircleWithCross;
                    query = $@"insert into tbl_teethexam(col_teethid) values('{teethid}')";
                    dc.Connection2(query);
                }
                teeth_source.Clear();
                query = $@"select col_teethid from tbl_teethexam";
                ds = dc.Connection2(query);
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
            return packIcon;
        }
        public void ClearTeeth()
        {
            dc = new database_connection();
            string query;
            query = $@"delete from tbl_teethexam";
            dc.Connection2(query);
            teeth_source.Clear();
        }
        public ArrayList teethList()
        {
            ArrayList arr = new ArrayList();
            teethsource currentItem;
            for(int i= 0; i < teeth_source.Count; i++)
            {
                currentItem = teeth_source[i];
                if (currentItem.teeth_status != null)
                {
                    arr.Add("1 - " + currentItem.teeth_id + "  " + currentItem.teeth_status);
                }
            }
            return arr;
        }
        public int TotalAmount()
        {
            int amount = 0;
            teethsource currentitem;
            int count;
            count = teeth_source.Count;
            for (int i = 0; i < count; i++)
            {
                currentitem = teeth_source[i];
                if (currentitem.teeth_amount != null)
                {
                    if (currentitem.teeth_amount != "")
                    amount = amount + int.Parse(currentitem.teeth_amount);
                    ucontrol_dentalchart1.amount2valid = true;
                }
                else
                {
                    ucontrol_dentalchart1.amount2valid = false;
                }
            }
            return amount;
        }
    }
}
