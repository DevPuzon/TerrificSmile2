using System;
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
        public void receipt()
        {
            mcFlowDoc = new FlowDocument();
            // Create a paragraph with text  
            Paragraph para = new Paragraph();
            receipt_string = @"Terrific Smile
Dental Clinic
Address
Telephone no. : 123456
Business no.:123456789
Date:  2008/10/10  Time: 12:00:00

Transaction no. : 
****************************************
Official Receipt
****************************************

 ";

            para.Inlines.Add(new Run(receipt_string));
           // para.Inlines.Add(new Bold(new Run("Go ahead.")));
            // Add the paragraph to blocks of paragraph  
            mcFlowDoc.Blocks.Add(para);
        }
    }
}
