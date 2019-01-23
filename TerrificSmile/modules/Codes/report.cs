using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace TerrificSmile.modules.Codes
{
    public class report
    {
        public static FlowDocument mcFlowDoc;
        public string receipt_string;
        string date = DateTime.Now.ToString("mm/dd/yyyy");
        string time = DateTime.Now.ToString(" hh: mm: ss");

        public void receipt(string transactionId, string patientId,string patientName,string dateReservedId, string dateReserved,
                            string patientAssist,string payment,string amount,string change,ArrayList teethItem)
        {
            string item;
            mcFlowDoc = new FlowDocument();
            Paragraph para = new Paragraph();
            item = string.Join(Environment.NewLine, teethItem.ToArray());
            receipt_string = $@"Terrific Smile
Dental Clinic
Address
Telephone no. : 123456
Business no.:123456789
Date:  {date}  Time: {time}

Transaction Id : {transactionId}
Patient Id: {patientId}
Patient Name: {patientName}
****************************************
Date Reserved Id: {dateReservedId}
Date Reserved: {dateReserved}
****************************************
Official Receipt
{item}
****************************************
                Total Amount : {amount}
                Payment      : {payment}
                Change       : {change}
****************************************
Patient Assistant : {patientAssist}
****************************************

 ";
            //for (int i = 0; i < teethId.Count; i++)
            //{
            //    teethId[i]
            //}
            para.Inlines.Add(new Run(receipt_string));
            mcFlowDoc.Blocks.Add(para);
        }
    }
}
