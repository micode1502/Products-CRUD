using Microsoft.Reporting.WinForms;
using Products_CRUD.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Products_CRUD.Presentation.Reports
{
    public partial class frmRptProducts : Form
    {
        public frmRptProducts()
        {
            InitializeComponent();
        }

        #region "My Methods"
        private void list()
        {
            try
            {
                Products data = new Products();
                string text = txtProductOne.Text;
                DataTable dataTable = new DataTable();
                dataTable = data.list_products(text);
                ReportDataSource reportDataSource = new ReportDataSource("DataSet1", dataTable);
                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.DataSources.Add(reportDataSource);
                reportViewer1.LocalReport.ReportEmbeddedResource = "Products_CRUD.Presentation.Reports.Rpt_products.rdlc";
                reportViewer1.LocalReport.Refresh();
                reportViewer1.RefreshReport();
            }catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        private void frmRptProducts_Load(object sender, EventArgs e)
        {

            this.list();
        }
    }
}
