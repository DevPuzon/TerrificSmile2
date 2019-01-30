using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;

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
            public string otherDescription { get; set; }
            public string otherFee { get; set; }
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
        public void _clear()
        {
            inventory_source.Clear();
            expenses_source.Clear();
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
                query = $@"select * from tbl_dailyInventory
where col_month = '{month}' and
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
                        otherDescription = drow.ItemArray.GetValue(4).ToString(),
                        otherFee = drow.ItemArray.GetValue(5).ToString(),
                        day = drow.ItemArray.GetValue(6).ToString(),
                        month = drow.ItemArray.GetValue(7).ToString(),
                        year = drow.ItemArray.GetValue(8).ToString(),
                    });
                }
                //expenses
                query = $@"select * from tbl_expenses 
where col_month = '{month}' and
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
        public void _updateDailyInventory(string gross, string commission, string perday,string otherdescription,string otherfee,string day,string month,string year,
                                          string id)
        {
            if (gross == "") { gross = "0"; }
            if (commission == "") { commission = "0"; }
            if (perday == "") { perday = "0"; }
            if (otherdescription == "") { otherdescription = "none"; }
            if (otherfee == "") { otherfee = "0"; }
            dc = new database_connection();
            string query;
            try
            {
                query = $@"update tbl_dailyInventory
set col_gross = '{gross}',
col_commission = '{commission}',
col_perday = '{perday}',
col_otherDescription = '{otherdescription}',
col_otherFee = '{otherfee}',
col_day = '{day}',
col_month = '{month}',
col_year = '{year}'
where col_id = {id}";
                dc.Connection2(query);
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void _updateExpenses(string description, string fee,string month,string year,string id)
        {
            if (description == "") { description = "none"; }
            if (fee == "") { fee = "0"; }
            dc = new database_connection();
            string query;
            try
            {
                query = $@"update tbl_expenses 
set col_description = '{description}',
col_fee = '{fee}',
col_month = '{month}',
col_year = '{year}'
where col_id = {id}";
                dc.Connection2(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void _insertDailyInventory(string gross, string commission, string perday,string otherdescription, string otherfee, string day,string month,string year)
        {
            if (gross == "") { gross = "0"; }
            if (commission == "") { commission = "0"; }
            if (perday == "") { perday = "0"; }
            if (otherdescription == "") { otherdescription = "none"; }
            if (otherfee == "") { otherfee = "0"; }
            dc = new database_connection();
            string query;
            try
            {
                query = $@"insert into
tbl_dailyInventory(col_gross,col_commission,col_perday,col_otherDescription,col_otherFee,col_day,col_month,col_year)
values('{gross}','{commission}','{perday}','{otherdescription}','{otherfee}','{day}','{month}','{year}')";
                dc.Connection2(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void _insertExpenses(string description, string fee, string month,string year)
        {
            if (description == "") { description = "none"; }
            if (fee == "") { fee = "0"; }
            dc = new database_connection();
            string query;
            try
            {
                query = $@"insert into
tbl_expenses(col_description,col_fee,col_month,col_year)
values('{description}','{fee}','{month}','{year}')";
                dc.Connection2(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void _deleteDailyInventory(string id)
        {
            dc = new database_connection();
            string query;
            try
            {
                query = $@"delete from tbl_dailyInventory where col_id = {id}";
                dc.Connection2(query);
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void _deleteExpenses(string id)
        {
            dc = new database_connection();
            string query;
            try
            {
                query = $@"delete from tbl_expenses where col_id = {id}";
                dc.Connection2(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        public FlowDocument _computation(string month, string year)
        {
            FlowDocument flowDocument = new FlowDocument();
            Paragraph para = new Paragraph();
            string receipt_string;
            int total_expenses = 0;
            int total_gross = 0;
            int total_commission = 0;
            int total_perday = 0;
            int total_other = 0;
            int total_average = 0;
            int sum_ecp = 0;
            int diff_grossEcp = 0;
            dc = new database_connection();
            DataSet ds;
            DataRow row;
            string query;
            try
            {
                query = $@"select sum(col_fee) from tbl_expenses where col_month = '{month}' and col_year = '{year}'";
                ds = dc.Connection2(query);
                row = ds.Tables[0].Rows[0];
                total_expenses = int.Parse(row.ItemArray.GetValue(0).ToString());//total expenses
                query = $@"select sum(col_gross),sum(col_commission),sum(col_perday),sum(col_otherFee) from tbl_dailyInventory
                            where col_month = '{month}' and col_year = '{year}'";
                ds = dc.Connection2(query);
                row = ds.Tables[0].Rows[0];
                total_gross = int.Parse(row.ItemArray.GetValue(0).ToString()); // total gross
                total_commission = int.Parse(row.ItemArray.GetValue(1).ToString()); //total commission
                total_perday = int.Parse(row.ItemArray.GetValue(2).ToString()); // total perday
                total_other = int.Parse(row.ItemArray.GetValue(3).ToString());// total other
                sum_ecp = total_expenses + total_commission + total_perday;
                diff_grossEcp = total_gross - sum_ecp;
                total_average = diff_grossEcp + total_other;
                receipt_string = $@"
Total Expenses :                {total_expenses}
Total Commission :              {total_commission}
Total Per Day :                 {total_perday}
Sum of ECP :                    {sum_ecp}

Total Gross :                   {total_gross}
Sum of ECP :                    {sum_ecp}
Difference of Gross and ECP :   {diff_grossEcp}

Difference of Gross and ECP :   {diff_grossEcp}
Total Other :                   {total_other}


Total Average :                 {total_average}
 ";
                para.Inlines.Add(new Run(receipt_string));
                flowDocument.Blocks.Add(para);
            }
            catch(Exception ex)
            {

            }
            return flowDocument;
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
