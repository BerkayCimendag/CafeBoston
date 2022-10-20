using CafeBoston.DATA;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CafeBoston.UI
{
    public partial class MainForm : Form
    {
        CafeData db = new CafeData();

        
        public MainForm()
        {
            InitializeComponent();
            LoadSavedData();
            SeedSampleProucts();
            LoadTables();

        }

        private void LoadSavedData()
        {
            try
            {
                string json = File.ReadAllText("data.json");
                db = JsonSerializer.Deserialize<CafeData>(json);
            }
            catch (Exception)
            {
            }
        }

        private void SeedSampleProucts()
        {
            if (db.Products.Any())
            {
                return;
            }
            db.Products.Add(new Product() { ProductName = "Cola", UnitPrice = 14.50M });
            db.Products.Add(new Product() { ProductName = "Tea", UnitPrice = 9M });
            
        }

        private void LoadTables()
        {
            for (int i = 1; i <= db.TableCount ; i++)
            {
                var lvi = new ListViewItem($"Table {i}");
                lvi.Tag = i;
                lvi.ImageKey = db.ActiveOrders.Any(x=>x.TableNo==i)? "full" : "empty";
                lvwTables.Items.Add(lvi);
            }
        }

        private void lvwTables_DoubleClick(object sender, EventArgs e)
        {
            var selectedLvi = lvwTables.SelectedItems[0];
            int tableNo = (int)selectedLvi.Tag;

            var order = db.ActiveOrders.FirstOrDefault(x => x.TableNo == tableNo);

            if (order == null)
            {
                order = new Order() { TableNo = tableNo };
                db.ActiveOrders.Add(order);
                selectedLvi.ImageKey = "full";
            }

            var frmOrder = new OrderForm(db , order);
            frmOrder.TableMoving += FrmOrder_TableMoving;
            var dr =frmOrder.ShowDialog();

            if (dr == DialogResult.OK)
            {
                selectedLvi.ImageKey = "empty";
            }
        }

        private void FrmOrder_TableMoving(int oldTableNo, int newTableNo)
        {
            foreach (ListViewItem lvi in lvwTables.Items)
            {
                int tableNo = (int)lvi.Tag;

                if (tableNo == oldTableNo)
                {
                    lvi.ImageKey = "empty";
                }
                else if (tableNo == newTableNo)
                {
                    lvi.ImageKey = "full";
                }
            }
        }

        private void tsmiOrderHistory_Click(object sender, EventArgs e)
        {
            new OrderHistoryForm(db).ShowDialog();
        }

        private void tsmiProducts_Click(object sender, EventArgs e)
        {
            new ProductForm(db).ShowDialog();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
           string json =  JsonSerializer.Serialize(db);
            File.WriteAllText("data.json", json);
        }
    }
}
