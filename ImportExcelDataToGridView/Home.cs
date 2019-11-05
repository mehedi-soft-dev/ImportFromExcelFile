using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;

namespace ImportExcelDataToGridView
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Do You Want to Exit ?", "Exit Application",
                MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if(dialogResult == DialogResult.Yes)
                this.Dispose();
        }

        OpenFileDialog _openFileDialog = new OpenFileDialog();
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            showDataGridView.Rows.Clear();

            Microsoft.Office.Interop.Excel.Application xlApplication;
            Microsoft.Office.Interop.Excel.Workbook xlWorkbook;
            Microsoft.Office.Interop.Excel.Worksheet xlWorksheet;
            Microsoft.Office.Interop.Excel.Range xlRange;

            int xlRow;
            string fileName;

            _openFileDialog.Filter = "Excel Office | *.xl; *.xlsx";
            _openFileDialog.ShowDialog();
            fileName = _openFileDialog.FileName;

            if (fileName != string.Empty)
            {
                xlApplication = new Microsoft.Office.Interop.Excel.Application();
                xlWorkbook = xlApplication.Workbooks.Open(fileName);
                xlWorksheet = xlWorkbook.Worksheets["Sheet1"];
                xlRange = xlWorksheet.UsedRange;

                int i = 0;

                for (xlRow = 2; xlRow <= xlRange.Rows.Count; xlRow++)
                {
                    if (xlRange.Cells[xlRow, 1].Text != "")
                    {
                        i++;
                        showDataGridView.Rows.Add(i, xlRange.Cells[xlRow, 1].Text, xlRange.Cells[xlRow, 2].Text,
                            xlRange.Cells[xlRow, 3].Text, xlRange.Cells[xlRow, 4].Text);
                    }
                }
                xlWorkbook.Close();
                xlApplication.Quit();
            }
        }
    }
}
