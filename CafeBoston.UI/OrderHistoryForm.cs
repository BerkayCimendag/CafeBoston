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
    public partial class OrderHistoryForm : Form
    {
        private readonly CafeData _db;
        public OrderHistoryForm(CafeData db)
        {
            _db = db;
            InitializeComponent();
            dgvOrders.DataSource = db.PastOrders;
        }

        private void dgvOrders_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvOrders.SelectedRows.Count ==1)
            {
                Order order = (Order)dgvOrders.SelectedRows[0].DataBoundItem;
                dgvOrderDetails.DataSource = order.OrderDetails;
            }
            else
            {
                dgvOrderDetails.DataSource = null;
            }
        }
    }
}
