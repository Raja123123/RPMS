using Rpms.Models;
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


            printPreviewControl1.Document = printDocument1;
            printPreviewControl1.Zoom = 1;
            //printPreviewDialog1.Document = printDocument1;
            //printPreviewDialog1.ShowDialog();
            //printDocument1.Print();
        }

        private InvoicePrint  GetInvoicePrint()
        {
            var fakeInvoice = new InvoicePrint
            {
                InvoiceSetting = new InvoiceSetting(),
                Orgnization = new Orgnization
                {
                    Name = "Raj Cola Pvt Ltd",
                    Address = "Shop no f-14, Gayatri complex, street no 3, Samastiput Bajar, Bihar, 110091",
                    ID = Guid.NewGuid(),
                    MobileNumber = "8800282570",
                    Status = "Active",
                    Email = "raj@gmail.com",
                    GST = "GSTNUMBER12121210",
                },
                Customer = new Customer
                {
                    Address = Faker.Address.StreetAddress(),
                    ID = Guid.NewGuid(),
                    MobileNo = Faker.Phone.Number(),
                    Name = Faker.Name.FullName(),
                    Status = "Active"
                },
                Invoice = new Invoice
                {
                    CustomerID = Guid.NewGuid(),
                    DiscountCode = Guid.NewGuid(),
                    DiscountCodeAmount = 20,
                    ID = Guid.NewGuid(),
                    Number = "INVORDERNO1",
                    PaidAmount = 5000,
                    TotalAmount = 5000,
                    TotalDiscount = 20,
                    Date = DateTime.Now
                },
                User = new User
                {
                    Address = Faker.Address.StreetAddress(),
                    ID = Guid.NewGuid(),
                    MobileNo = Faker.Phone.Number(),
                    Name = Faker.Name.FullName(),
                    Status = "Active"
                },
                InvoiceProducts = new List<InvoiceProduct> {
                   new InvoiceProduct{
                       Discount = 0,
                       ProductID =Guid.NewGuid(),
                       ProductName = "ProductName - aa" ,
                       ProductCode = "Code -" + Faker.RandomNumber.Next(),
                       Mrp = 200.523m,
                       Quantity = 5
                   }
                },
            };

            for (int i = 0; i < 4; i++)
            {
                fakeInvoice.InvoiceProducts.Add(new InvoiceProduct{
                       Discount = 5 + i,
                       ProductID =Guid.NewGuid(),
                       ProductName = "ProductName - " + i,
                        ProductCode = "Code -" + i,
                        Mrp = 200,
                       Quantity = 5
                   }
                );
            }
            return fakeInvoice;

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
         
        }

        


         

        private void PrintDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {

            var data = GetInvoicePrint();

            Graphics graphics = e.Graphics;

            Font regular = new Font(FontFamily.GenericSansSerif, 8.0f, FontStyle.Regular);
            Font bold = new Font(FontFamily.GenericSansSerif, 8.0f, FontStyle.Bold);
            int top = 5;
            int topIncrement = 15;
            int left = 5;
            int width = 280;
            var rightAlign = new StringFormat();
            rightAlign.Alignment = StringAlignment.Far;

            var centerAlign = new StringFormat();
            centerAlign.Alignment = StringAlignment.Center;

            //---------------------------print header
            //Shop information


            var orgNameBox = new Rectangle(left, top = top + 30, width , topIncrement);
            graphics.DrawString(data.Orgnization.Name, bold, Brushes.Black, orgNameBox, centerAlign);

            if (data.InvoiceSetting.DisplayOrgnizationAddress)
            {
                var orgAddressBox = new Rectangle(left, top = top + topIncrement, width, top = top + topIncrement);
                graphics.DrawString(data.Orgnization.Address, regular, Brushes.Black, orgAddressBox, centerAlign);
            }

            

            if (data.InvoiceSetting.DisplayContactNo)
                graphics.DrawString("Contact No: " + data.Orgnization.MobileNumber, regular, Brushes.Black, left, top = top + topIncrement);

            if (data.InvoiceSetting.DisplayGST)
                graphics.DrawString("GST: " + data.Orgnization.GST, regular, Brushes.Black, left, top = top + topIncrement);

            if (data.InvoiceSetting.DisplaySalesPersonName)
                graphics.DrawString("Sales Person: " + data.User.Name, regular, Brushes.Black, left, top = top + topIncrement);


            graphics.DrawLine(Pens.Black, left, top = top + topIncrement, width, top );


            graphics.DrawString("Customer" , bold, Brushes.Black, left, top = top +( topIncrement/2));

            graphics.DrawString("Name: " + data.Customer.Name, regular, Brushes.Black, left, top = top + topIncrement);
            graphics.DrawString("Contact No: " + data.Customer.MobileNo, regular, Brushes.Black, left, top = top + topIncrement);

            graphics.DrawLine(Pens.Black, left, top = top + topIncrement, width, top);


            ////left align
            graphics.DrawString("Invoice No: " + data.Invoice.Number, regular, Brushes.Black, left, top = top + (topIncrement/2));
            //right align
            graphics.DrawString("Date: " + data.Invoice.Date.ToString("MM/dd/yyyy"), regular, Brushes.Black, new Rectangle(150,top, width-150, top), rightAlign);



            int productWidth = Convert.ToInt32(width * 37.93 / 100);
            int quantityWidth = Convert.ToInt32(width * 10.34 / 100);
            int mrpWidth = Convert.ToInt32(width * 17.24 / 100);
            int priceWidth = Convert.ToInt32(width * 17.24 / 100);
            int netWidth = Convert.ToInt32(width * 17.24 / 100);



            //Product Code      Qty     Price,Tax,Discount      Net
            var productBox = new Rectangle(left, top = top +30, productWidth, topIncrement *3);
            //e.Graphics.FillRectangle(new SolidBrush(Color.PaleVioletRed), productBox);

            var quantityBox = new Rectangle(left + productWidth,  top , quantityWidth, topIncrement * 3);
            //e.Graphics.FillRectangle(new SolidBrush(Color.PapayaWhip), quantityBox);

            var mrpBox = new Rectangle(left + productWidth + quantityWidth, top, mrpWidth, topIncrement * 3);
            //e.Graphics.FillRectangle(new SolidBrush(Color.PapayaWhip), quantityBox);


            var priceBox = new Rectangle(left + productWidth + quantityWidth + mrpWidth, top , priceWidth, topIncrement * 3);
            //e.Graphics.FillRectangle(new SolidBrush(Color.PaleGoldenrod), priceBox);

            var netAmountBox = new Rectangle(left + productWidth + quantityWidth + mrpWidth + priceWidth, top, netWidth, topIncrement * 3);
            //e.Graphics.FillRectangle(new SolidBrush(Color.Gainsboro), netAmountBox);


            graphics.DrawString("Product\nCode" , bold, Brushes.Black, productBox);
            graphics.DrawString("Qty", bold, Brushes.Black, quantityBox, rightAlign);
            graphics.DrawString("MRP", bold, Brushes.Black, mrpBox, rightAlign);
            graphics.DrawString("Price\nTax\nDisc", bold, Brushes.Black, priceBox, rightAlign);
            graphics.DrawString("Net", bold, Brushes.Black, netAmountBox, rightAlign);

            graphics.DrawLine(Pens.Black, left, top = top + (topIncrement*3), width, top);

            top = top + 2;
            foreach (var item in data.InvoiceProducts)
            {


                productBox = new Rectangle(left, top, productWidth, topIncrement * 3);
                //e.Graphics.FillRectangle(new SolidBrush(Color.PaleVioletRed), productBox);

                quantityBox = new Rectangle(left + productWidth, top, quantityWidth, topIncrement * 3);
                //e.Graphics.FillRectangle(new SolidBrush(Color.PapayaWhip), quantityBox);

                mrpBox = new Rectangle(left + productWidth + quantityWidth, top, mrpWidth, topIncrement * 3);
                //e.Graphics.FillRectangle(new SolidBrush(Color.PapayaWhip), quantityBox);


                priceBox = new Rectangle(left + productWidth + quantityWidth + mrpWidth, top, priceWidth, topIncrement * 3);
                //e.Graphics.FillRectangle(new SolidBrush(Color.PaleGoldenrod), priceBox);

                netAmountBox = new Rectangle(left + productWidth + quantityWidth + mrpWidth + priceWidth, top, netWidth, topIncrement * 3);
                //e.Graphics.FillRectangle(new SolidBrush(Color.Gainsboro), netAmountBox);


                //graphics.DrawLine(Pens.Black, 20, top, width, top);
                //graphics.DrawString("Product\nCode", regular, Brushes.Black, productBox);
                graphics.DrawString($"{item.ProductName}\n{item.ProductCode}", regular, Brushes.Black, productBox);

                //graphics.DrawString("Qty", regular, Brushes.Black, quantityBox, rightAlign);
                graphics.DrawString($"{item.Quantity.ToString("0.##")}", regular, Brushes.Black, quantityBox, rightAlign);

                //graphics.DrawString("Price\nTax\nDisc", regular, Brushes.Black, priceBox, rightAlign);
                graphics.DrawString($"{item.Mrp.ToString("0.##")}\n{item.Tax.ToString("0.##")}\n-{item.Discount.ToString("0.##")}", regular, Brushes.Black, priceBox, rightAlign);

                //graphics.DrawString("Net", regular, Brushes.Black, netAmountBox, rightAlign);
                graphics.DrawString($"{((item.Mrp + item.Tax) - item.Discount).ToString("0.##")}", regular, Brushes.Black, netAmountBox, rightAlign);

                top = top + topIncrement * 3;

            }

            graphics.DrawLine(Pens.Black, left, top, width, top);

            //left align
            graphics.DrawString($"Total Item{(data.InvoiceProducts.Count > 0 ? "s" : "")} : " + data.InvoiceProducts.Count, regular, Brushes.Black, left, top = top + 5);
            //right align
            graphics.DrawString("Total Amt: " + data.Invoice.TotalAmount.ToString("0.##"), regular, Brushes.Black, new Rectangle(150, top, width - 150, top), rightAlign);

            graphics.DrawString("Total Saving: " + data.Invoice.TotalDiscount.ToString("0.##"), regular, Brushes.Black, new Rectangle(150, top = top + 20, width - 150, top), rightAlign);










            regular.Dispose();
            bold.Dispose();

            // Check to see if more pages are to be printed.
            e.HasMorePages = (data.InvoiceProducts.Count > 20);
        }
    }


}
