using Products_CRUD.Data;
using Products_CRUD.Entities;
using Products_CRUD.Presentation.Reports;
using System;
using System.Data;
using System.Windows.Forms;

namespace Products_CRUD.Presentation
{
    public partial class frmProduct : Form
    {
        public frmProduct()
        {
            InitializeComponent();
            dgvProducts.CellFormatting += new DataGridViewCellFormattingEventHandler(dgvProducts_CellFormatting);
        }

        #region "My Variables"
        int stateSave = 0;
        #endregion

        #region "My Methods"
        private void cleanControls()
        {
            txtId.Clear();
            txtName.Clear();
            txtPrice.Clear();
            txtStock.Clear();
            cbCategories.Text = "";
        }

        private void stateControls(bool state)
        {
            txtName.Enabled = state;
            txtPrice.Enabled = state;
            cbCategories.Enabled = state;
            txtStock.Enabled = state;
            txtTitleForm.Visible = state;
        }

        private void stateButtons(bool state)
        {
            btnCancel.Visible = state;
            btnSave.Visible = state;
        }

        private void stateButtonsPrincipal(bool state)
        {
            btnNew.Enabled = state;
            btnUpdate.Enabled = state;
            btnDelete.Enabled = state;
            btnReport.Enabled = state;
            btnExit.Enabled = state;
        }

        private void list_categories()
        {
            Products data = new Products();
            cbCategories.DataSource = data.list_categories();
            cbCategories.ValueMember = "id";
            cbCategories.DisplayMember = "name";
        }

        private void formate_products()
        {
            dgvProducts.Columns[0].Width = 50;
            dgvProducts.Columns[0].HeaderText = "ID";
            dgvProducts.Columns[2].Width = 190;
            dgvProducts.Columns[2].HeaderText = "NOMBRE DEL PRODUCTO";
            dgvProducts.Columns[3].Width = 100;
            dgvProducts.Columns[3].HeaderText = "PRECIO";
            dgvProducts.Columns[4].Width = 100;
            dgvProducts.Columns[4].HeaderText = "STOCK";
            dgvProducts.Columns[5].Width = 150;
            dgvProducts.Columns[5].HeaderText = "ESTADO";
            dgvProducts.Columns[8].Width = 150;
            dgvProducts.Columns[8].HeaderText = "CATEGORÍA";

            dgvProducts.Columns[1].Visible = false;
            dgvProducts.Columns[6].Visible = false;
            dgvProducts.Columns[7].Visible = false;
        }

        private void list_products(string text)
        {
            Products data = new Products();
            DataTable dataTable = data.list_products(text);

            if (dataTable != null)
            {
                dataTable.DefaultView.Sort = "ID ASC";
            }

            dgvProducts.DataSource = dataTable;
            this.formate_products();
        }

        private void select_item()
        {
            if (string.IsNullOrEmpty(dgvProducts.CurrentRow.Cells["id"].Value.ToString()))
            {
                MessageBox.Show("Seleccione un producto",
                    "Aviso del sistema",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }else
            {
                txtId.Text = Convert.ToString(dgvProducts.CurrentRow.Cells["id"].Value);
                txtName.Text = Convert.ToString(dgvProducts.CurrentRow.Cells["name"].Value);
                txtPrice.Text = Convert.ToString(dgvProducts.CurrentRow.Cells["price"].Value);
                txtStock.Text = Convert.ToString(dgvProducts.CurrentRow.Cells["stock"].Value);
            }
        }
        #endregion
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            stateSave = 1;
            this.cleanControls();
            this.stateControls(true);
            this.stateButtons(true);
            this.stateButtonsPrincipal(false);
            txtName.Focus();
            txtTitleForm.Text = "Registrar Producto";
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbCategories_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtStock_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvProducts_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvProducts.Columns[e.ColumnIndex].HeaderText == "ESTADO")
            {
                if (e.Value != null)
                {
                    e.Value = e.Value.ToString() == "1" ? "En stock" : "Sin stock";
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            stateSave = 0;
            this.cleanControls();
            this.stateControls(false);
            this.stateButtons(false);
            this.stateButtonsPrincipal(true);
            btnNew.Focus();
        }

        private void frmProduct_Load(object sender, EventArgs e)
        {
            this.list_categories();
            this.list_products("%");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(txtName.Text == string.Empty || txtPrice.Text == string.Empty ||
                txtStock.Text == string.Empty)
            {
                MessageBox.Show("Debe llenar todos los campos (*)",
                    "Aviso del Sistema",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }else
            {
                Product product = new Product();
                string reply = "";
                if (stateSave == 2 && !string.IsNullOrEmpty(txtId.Text))
                {
                    product.id = Convert.ToInt32(txtId.Text);
                }
                product.name = txtName.Text;
                product.price = Convert.ToDecimal(txtPrice.Text);
                product.stock = Convert.ToInt32(txtStock.Text);
                product.categoryId = Convert.ToInt32(cbCategories.SelectedValue);
                Products data = new Products();
                reply = data.save(stateSave, product);

                if( reply.Equals("OK"))
                {
                    txtId.Text = "";
                    this.cleanControls();
                    this.stateControls(false);
                    this.stateButtons(false);
                    this.stateButtonsPrincipal(true);
                    txtTitleForm.Text = "";
                    this.list_products("%");
                    MessageBox.Show("Producto registrado correctamente", 
                        "Aviso del Sistema",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }else
                {
                    MessageBox.Show(reply, "Aviso del Sistema",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.list_products(txtSearch.Text.Trim());
        }

        private void dgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.select_item();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            stateSave = 2;
            this.stateControls(true);
            this.stateButtons(true);
            this.stateButtonsPrincipal(false);
            txtName.Focus();
            txtTitleForm.Text = "Actualizar Producto";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(dgvProducts.Rows.Count > 0)
            {
                string reply;
                Products data = new Products();
                reply = data.delete(Convert.ToInt32(dgvProducts.CurrentRow.Cells["id"].Value));
                if (reply.Equals("OK"))
                {
                    this.list_products("%");
                    this.cleanControls();
                    MessageBox.Show("Producto eliminado correctamente",
                        "Aviso del Sistema",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                } else
                {
                    MessageBox.Show(reply, "Aviso del Sistema",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            frmRptProducts frmRptProducts = new frmRptProducts();
            frmRptProducts.txtProductOne.Text = txtSearch.Text;
            frmRptProducts.ShowDialog();
        }
    }
}
