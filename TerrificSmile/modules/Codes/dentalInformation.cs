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
    public class dentalInformation
    {
        public dentalInformation()
        {
            information_source = new ObservableCollection<informationSource>();
        }

        public ObservableCollection<informationSource> information_source;

        public class informationSource
        {
            public string transactionId { get; set; }
            public string patientId { get; set; }
            public string name { get; set; }
            public string age { get; set; }
            public string address { get; set; }
            public string phoneNumber { get; set; }
            public string gender { get; set; }
            public string patientAssistant { get; set; }
            public string reservationId { get; set; }
            public string dateReserved { get; set; }
            public string dateCurrent { get; set; }
            public string payment { get; set; }
            public string amount { get; set; }
            public string change { get; set; }
        }

        database_connection dc = new database_connection();
        public void _clear()
        {
            information_source.Clear();
        }
        public void _save(string transactionId,string patientId,string name,string age
                         ,string address,string phoneNumber,string gender,string patientAssistant
                         ,string reservationId,string dateReserved,string payment,string amount, string change)
        {
            dc = new database_connection();
            string query;
            try
            {
                query = $@"insert into 
tbl_main(col_transactionId,col_patientId,col_name,col_age,col_address
	    ,col_phoneNumber,col_gender,col_patientAssitant,col_reservationId,col_dateReserved
	    ,col_dateCurrent,col_payment,col_amount,col_change)
values('{transactionId}','{patientId}','{name}',{age},'{address}',{phoneNumber},'{gender}','{patientAssistant}'
        ,'{reservationId}','{dateReserved}','{MainWindow.date + MainWindow.time}',{payment},{amount},{change})";
                dc.Connection2(query);
                MessageBox.Show("Save");
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public async void _select()
        {
            dc = new database_connection();
            string query;
            DataSet ds;
            DataRow drow;
            try
            {
                query = $@"select * from tbl_main";
                ds =await dc.Connection2Async(query);
                int ctr, total;
                total = ds.Tables[0].Rows.Count;
                for (ctr = 0; ctr < total; ctr++)
                {
                    drow = ds.Tables[0].Rows[ctr];
                    information_source.Add(new informationSource {
                        transactionId = drow.ItemArray.GetValue(0).ToString(),
                        patientId = drow.ItemArray.GetValue(1).ToString(),
                        name = drow.ItemArray.GetValue(2).ToString(),
                        age = drow.ItemArray.GetValue(3).ToString(),
                        address = drow.ItemArray.GetValue(4).ToString(),
                        phoneNumber = drow.ItemArray.GetValue(5).ToString(),
                        gender = drow.ItemArray.GetValue(6).ToString(),
                        patientAssistant = drow.ItemArray.GetValue(7).ToString(),
                        reservationId = drow.ItemArray.GetValue(8).ToString(),
                        dateReserved = drow.ItemArray.GetValue(9).ToString(),
                        dateCurrent = drow.ItemArray.GetValue(10).ToString(),
                        payment = drow.ItemArray.GetValue(11).ToString(),
                        amount = drow.ItemArray.GetValue(12).ToString(),
                        change = drow.ItemArray.GetValue(13).ToString(),
                    });
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public async void _search(string search)
        {
            dc = new database_connection();
            DataSet ds;
            DataRow drow;
            string query;
            try
            {
                query = $@"select * from tbl_main 
where col_transactionId like '%{search}%' or 
col_patientId like '%{search}%' or 
col_name like '%{search}%' or col_reservationId like '%{search}%'";
                ds = await dc.Connection2Async(query);
                int ctr, total;
                total = ds.Tables[0].Rows.Count;
                for(ctr = 0; ctr < total; ctr++)
                {
                    drow = ds.Tables[0].Rows[ctr];
                    information_source.Add(new informationSource
                    {
                        transactionId = drow.ItemArray.GetValue(0).ToString(),
                        patientId = drow.ItemArray.GetValue(1).ToString(),
                        name = drow.ItemArray.GetValue(2).ToString(),
                        age = drow.ItemArray.GetValue(3).ToString(),
                        address = drow.ItemArray.GetValue(4).ToString(),
                        phoneNumber = drow.ItemArray.GetValue(5).ToString(),
                        gender = drow.ItemArray.GetValue(6).ToString(),
                        patientAssistant = drow.ItemArray.GetValue(7).ToString(),
                        reservationId = drow.ItemArray.GetValue(8).ToString(),
                        dateReserved = drow.ItemArray.GetValue(9).ToString(),
                        dateCurrent = drow.ItemArray.GetValue(10).ToString(),
                        payment = drow.ItemArray.GetValue(11).ToString(),
                        amount = drow.ItemArray.GetValue(12).ToString(),
                        change = drow.ItemArray.GetValue(13).ToString(),
                    });
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public List<string> _assistantList()
        {
            List<string> vs = new List<string>();
            dc = new database_connection();
            DataSet ds;
            DataRow drow;
            string query;
            try
            {
                query = $@"select col_patientAssistant from tbl_patientAssistant";
                ds = dc.Connection2(query);
                int count;
                count = ds.Tables[0].Rows.Count;
                for(int i = 0; i< count; i++)
                {
                    drow = ds.Tables[0].Rows[i];
                    vs.Add(drow.ItemArray.GetValue(0).ToString());
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return vs;
        }
    }
}
