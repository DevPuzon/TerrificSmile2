using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TerrificSmile.modules.Codes;
namespace TerrificSmile.modules
{
    /// <summary>
    /// Interaction logic for ucontrol_report.xaml
    /// </summary>
    public partial class ucontrol_report : UserControl
    {
        public ucontrol_report()
        {
            InitializeComponent();
            r.receipt();
            _datagrid_report();
        }
        report r = new report();
        dentalInformation di = new dentalInformation();
        private void _datagrid_report()
        {
            datagrid_report.ItemsSource = di.information_source;
            di._select();
        }
        void a()
        {
             // r = new report();
    //        FlowDocument mcFlowDoc = new FlowDocument();
    //        // Create a paragraph with text  
    //        Paragraph para = new Paragraph();
    //        string a = @" FlowDocument mcFlowDoc = newFlowDocument();  
    //// Create a paragraph with text  
    //Paragraph para = newParagraph();  
    //para.Inlines.Add(newRun(I am a flow document.Would you like to edit me? ));  
    //para.Inlines.Add(newBold(newRun(Go ahead.)));
    //        // Add the paragraph to blocks of paragraph  
    //        mcFlowDoc.Blocks.Add(para);
    //        // Create RichTextBox, set its hegith and width  
    //        RichTextBox mcRTB = newRichTextBox();
    //        mcRTB.Width = 560;
    //        mcRTB.Height = 280;
    //        // Set contents  
    //        mcRTB.Document = mcFlowDoc;
    //        // Add RichTextbox to the container  
    //        ContainerPanel.Children.Add(mcRTB); ";

    //        para.Inlines.Add(new Run(a));
    //        para.Inlines.Add(new Bold(new Run("Go ahead.")));
    //        // Add the paragraph to blocks of paragraph  
    //        mcFlowDoc.Blocks.Add(para);
    //        // Create RichTextBox, set its hegith and width  
    //        //RichTextBox mcRTB = new RichTextBox();
    //        //mcRTB.Width = 560;
    //        //mcRTB.Height = 280;
    //        //// Set contents  
    //        //mcRTB.Document = mcFlowDoc;
    //        // Add RichTextbox to the container  
    //        //container.Children.Add(mcRTB);
            richbox_receipt.Document = report.mcFlowDoc;
        }

        private void txtbox_search_TextChanged(object sender, TextChangedEventArgs e)
        {
            di._clear();
            di._search(txtbox_search.Text);
        }
    }
}
