using CafeBoston.DATA;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CafeBoston.UI
{
    public partial class ProductForm : Form
    {
        private CafeData _db;
        BindingList<Product> _products;
        Product _edited;
        public ProductForm(CafeData db)
        {
            _products = new BindingList<Product>(db.Products);
            InitializeComponent();
            _db = db;
            dgvProducts.DataSource = _products;

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string productName = txtProductName.Text.Trim();
            if (productName == "")
            {
                MessageBox.Show("Ürün adı girmediniz a product name!");
                return;
            }

            if (_edited == null)
            {
                _products.Add(new Product()
                {
                    ProductName = productName,
                    UnitPrice = nudUnitPrice.Value

                });
            }
            else
            {
                _edited.ProductName = productName;
                _edited.UnitPrice = nudUnitPrice.Value;
                _products.ResetBindings();
            }
            SwitchToAddMode();

        }

        private void dgvProducts_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            var dr = MessageBox.Show("Are you sure that you want to delete this product?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

            if (dr == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvProducts.SelectedRows.Count != 1)
            {
                return;
            }

            SwitchToEditMode();
        }

        private void SwitchToEditMode()
        {
            dgvProducts.Enabled = false;
            btnCancel.Show();
            btnEdit.Text = "SAVE";
            _edited = (Product)dgvProducts.SelectedRows[0].DataBoundItem;
            txtProductName.Text = _edited.ProductName;
            nudUnitPrice.Value = _edited.UnitPrice;
            btnEdit.Enabled = false;
        }
        private void SwitchToAddMode()
        {
            dgvProducts.Enabled = true;
            btnCancel.Hide();
            btnEdit.Text = "ADD";
            _edited = null;
            txtProductName.Text = "";
            nudUnitPrice.Value = 0;
            btnEdit.Enabled = true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            SwitchToAddMode();
        }
    }
}
