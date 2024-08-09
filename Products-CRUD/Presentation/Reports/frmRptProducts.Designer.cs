namespace Products_CRUD.Presentation.Reports
{
    partial class frmRptProducts
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.listproductsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.txtProductOne = new System.Windows.Forms.TextBox();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.listproductsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // listproductsBindingSource
            // 
            this.listproductsBindingSource.DataMember = "List_products";
            // 
            // txtProductOne
            // 
            this.txtProductOne.Location = new System.Drawing.Point(46, 29);
            this.txtProductOne.Name = "txtProductOne";
            this.txtProductOne.Size = new System.Drawing.Size(100, 20);
            this.txtProductOne.TabIndex = 0;
            this.txtProductOne.Visible = false;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.listproductsBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Products_CRUD.Presentation.Reports.Rpt_products.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(884, 561);
            this.reportViewer1.TabIndex = 1;
            // 
            // frmRptProducts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 561);
            this.Controls.Add(this.txtProductOne);
            this.Controls.Add(this.reportViewer1);
            this.Name = "frmRptProducts";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reporte de Productos";
            this.Load += new System.EventHandler(this.frmRptProducts_Load);
            ((System.ComponentModel.ISupportInitialize)(this.listproductsBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.TextBox txtProductOne;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource listproductsBindingSource;
        private Reports reportes;
    }
}