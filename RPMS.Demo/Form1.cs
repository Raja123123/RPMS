using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rpms.Demo
{
    public partial class Form1 : Form
    {

       

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            PopulateInstalledPrintersCombo();
        }



        private void PopulateInstalledPrintersCombo()
        {
            // Add list of installed printers found to the combo box.
            // The pkInstalledPrinters string will be used to provide the display string.
            String pkInstalledPrinters;
            for (int i = 0; i < PrinterSettings.InstalledPrinters.Count; i++)
            {
                pkInstalledPrinters = PrinterSettings.InstalledPrinters[i];
                comboPrinter.Items.Add(pkInstalledPrinters);
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }

        


        List<string> itemList = new List<string>()
        {
            "201", //fill from somewhere in your code
            "202"
        };

        private void PrintDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics graphics = e.Graphics;

            Font regular = new Font(FontFamily.GenericSansSerif, 10.0f, FontStyle.Regular);
            Font bold = new Font(FontFamily.GenericSansSerif, 10.0f, FontStyle.Bold);

            //print header
            graphics.DrawString("FERREIRA MATERIALS PARA CONSTRUCAO LTDA", bold, Brushes.Black, 20, 10);
            graphics.DrawString("EST ENGENHEIRO MARCILAC, 116, SAO PAOLO - SP", regular, Brushes.Black, 30, 30);
            graphics.DrawString("Telefone: (11)5921-3826", regular, Brushes.Black, 110, 50);
            graphics.DrawLine(Pens.Black, 80, 70, 320, 70);
            graphics.DrawString("CUPOM NAO FISCAL", bold, Brushes.Black, 110, 80);
            graphics.DrawLine(Pens.Black, 80, 100, 320, 100);

            //print items
            graphics.DrawString("COD | DESCRICAO                      | QTY | X | Vir Unit | Vir Total |", bold, Brushes.Black, 10, 120);
            graphics.DrawLine(Pens.Black, 10, 140, 430, 140);

            for (int i = 0; i < itemList.Count; i++)
            {
                graphics.DrawString(itemList[i].ToString(), regular, Brushes.Black, 20, 150 + i * 20);
            }

            //print footer
            //...

            regular.Dispose();
            bold.Dispose();

            // Check to see if more pages are to be printed.
            e.HasMorePages = (itemList.Count > 20);
        }
    }


}
