using Microsoft.Reporting.WinForms;
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

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
            this.reportViewer1.RefreshReport();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Set the path to your report file
            string reportPath = "Report1.rdlc";

            // Check if the report file exists
            if (System.IO.File.Exists(reportPath))
            {
                // Set the ReportPath property
                reportViewer1.LocalReport.ReportPath = reportPath;

                // Define parameters (replace with your actual parameter names and values)
                List<ReportParameter> parameters = new List<ReportParameter>();
                parameters.Add(new ReportParameter("ReportParameter1", "Value1"));
                //parameters.Add(new ReportParameter("ParameterName2", "Value2"));

                // Set parameters to the report
                reportViewer1.LocalReport.SetParameters(parameters);

                // Refresh the report
                reportViewer1.RefreshReport();
            }
            else
            {
                MessageBox.Show("Report file not found!");
            }
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            PrintDocument printDocument = new PrintDocument();
            printDocument.PrintPage += new PrintPageEventHandler(printDocument_PrintPage);
            PrintDialog printDialog = new PrintDialog
            {
                Document = printDocument
            };

            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                printDocument.Print();
            }
        }
        private void printDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            // Exemple de texte à imprimer
            string textToPrint = "Hello, World!";
            Font printFont = new Font("Arial", 12);
            e.Graphics.DrawString(textToPrint, printFont, Brushes.Black, 10, 10);
        }
    }
}
