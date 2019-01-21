using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using System.Windows;

namespace TerrificSmile.modules.Codes
{
    public class getId
    {
        database_connection dc = new database_connection();

        public async Task<String> _patientId()
        {
            dc = new database_connection();
            DataSet ds;
            DataRow drow;
            string query;
            query = $@"select id_patient from tbl_allId";
            ds = await dc.Connection2Async(query);

            drow = ds.Tables[0].Rows[0];
            string patientId = drow.ItemArray.GetValue(0).ToString();
            patientId = string.Format((int.Parse(patientId) + 1).ToString("D5"));

            //query = $@"Update tbl_allId set id_patient = '{patientId}'";
            //dc.Connection2(query);
            return patientId;
        }

        public async Task<String> _dateReservedId()
        {
            dc = new database_connection();
            DataSet ds;
            DataRow drow;
            string query;
            query = $@"select id_dateReserved from tbl_allId";
            ds = await dc.Connection2Async(query);

            drow = ds.Tables[0].Rows[0];
            string dateReservedId = drow.ItemArray.GetValue(0).ToString();
            dateReservedId = string.Format((int.Parse(dateReservedId) + 1).ToString("D5"));

            //query = $@"Update tbl_allId set id_dateReserved = '{dateReservedId2}'";
            //dc.Connection2(query);
            return dateReservedId;
        }

        public async Task<String> _transactionId()
        {
            dc = new database_connection();
            DataSet ds;
            DataRow drow;
            string query;
            query = $@"select id_transaction from tbl_allId";
            ds = await dc.Connection2Async(query);

            drow = ds.Tables[0].Rows[0];
            string transactionId = drow.ItemArray.GetValue(0).ToString();
            transactionId = string.Format((int.Parse(transactionId) + 1).ToString("D9"));

            //query = $@"Update tbl_allId set id_transaction = '{transactionId}'";
            //dc.Connection2(query);
            return transactionId;
        }
        
        public async void updatePatientId()
        {
            string patientId = await _patientId();
            string reservedId = await _dateReservedId();
            string transactionId = await _transactionId();
            string query;
            query = $@"Update tbl_allId set id_patient = '{patientId}'";
            database_connection.Connectionstatic(query);

            query = $@"Update tbl_allId set id_dateReserved = '{reservedId}'";
            database_connection.Connectionstatic(query);

            query = $@"Update tbl_allId set id_transaction = '{transactionId}'";
            database_connection.Connectionstatic(query);
        }
    }
}
