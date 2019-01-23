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
    public class EditAdminAssistant
    {
        public EditAdminAssistant()
        {
            adminSource = new ObservableCollection<admin_source>();
            patientAssistantSource = new ObservableCollection<patientassistant_source>();
        }
        public ObservableCollection<admin_source> adminSource;
        public ObservableCollection<patientassistant_source> patientAssistantSource;
        database_connection dc = new database_connection();
        public class admin_source
        {
            public string id { get; set; }
            public string adminUserName { get; set; }
            public string password { get; set; }
        }

        public class patientassistant_source
        {
            public string id { get; set; }
            public string patientAssistant { get; set; }
        }
        public void _clearSelect()
        {
            adminSource.Clear();
            patientAssistantSource.Clear();
            _select();
        }
        public void _select()
        {
            dc = new database_connection();
            string query;
            DataSet ds;
            DataRow drow;
            try
            {
                query = $@"select * from tbl_admin";
                ds = dc.Connection2(query);
                int ctr, total;
                total = ds.Tables[0].Rows.Count;
                for (ctr = 0; ctr < total; ctr++)
                {
                    drow = ds.Tables[0].Rows[ctr];
                    adminSource.Add(new admin_source
                    {
                        id = drow.ItemArray.GetValue(0).ToString(),
                        adminUserName = drow.ItemArray.GetValue(1).ToString(),
                        password = drow.ItemArray.GetValue(2).ToString(),
                    });
                }

                query = $@"select * from tbl_patientAssistant";
                ds = dc.Connection2(query);
                total = ds.Tables[0].Rows.Count;
                for (ctr = 0; ctr < total; ctr++)
                {
                    drow = ds.Tables[0].Rows[ctr];
                    patientAssistantSource.Add(new patientassistant_source
                    {
                        id = drow.ItemArray.GetValue(0).ToString(),
                        patientAssistant = drow.ItemArray.GetValue(1).ToString(),
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void _deleteAdmin(string idDelete)
        {
            dc = new database_connection();
            string query;
            try
            {
                query = $@"delete from tbl_admin where col_id = {idDelete}";
                dc.Connection2(query);
                MessageBox.Show("Deleted");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void _saveAdmin(string id,string adminUsername,string password)
        {
            dc = new database_connection();
            string query;
            DataSet ds;
            try
            {
                query = $@"select * from tbl_admin  where col_id = {id}";
                ds = dc.Connection2(query);
                int count;
                count = ds.Tables[0].Rows.Count;
                if(count > 0)
                {
                    //update
                    query = $@"update tbl_admin
set col_adminUsername = '{adminUsername}',
col_password = '{password}' where col_id = {id}";
                    dc.Connection2(query);
                    MessageBox.Show("Updated");
                }
                else
                {
                    //save
                    query = $@"insert into 
tbl_admin(col_adminUsername,col_password)
values('{adminUsername}','{password}')";
                    dc.Connection2(query);
                    MessageBox.Show("Saved");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void _deletePatientAssistant(string idDelete)
        {
            dc = new database_connection();
            string query;
            try
            {
                query = $@"delete from tbl_patientAssistant where col_id = {idDelete}";
                dc.Connection2(query);
                MessageBox.Show("Deleted");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void _saveAssistant(string id, string assistant)
        {
            dc = new database_connection();
            string query;
            DataSet ds;
            try
            {
                query = $@"select * from tbl_patientAssistant where col_id = {id}";
                ds = dc.Connection2(query);
                int count;
                count = ds.Tables[0].Rows.Count;
                if (count > 0)
                {
                    //update
                    query = $@"update tbl_patientAssistant
set col_patientAssistant = '{assistant}'
where col_id = {id}";
                    dc.Connection2(query);
                    MessageBox.Show("Updated");
                }
                else
                {
                    //save
                    query = $@"insert into 
tbl_patientAssistant(col_patientAssistant)
values('{assistant}')";
                    dc.Connection2(query);
                    MessageBox.Show("Saved");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
