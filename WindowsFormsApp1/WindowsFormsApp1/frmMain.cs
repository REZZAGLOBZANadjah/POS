using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS
{
    public partial class frmMain : Form
    {

        public frmMain()
        {
            InitializeComponent();
        }

        // show login forme
        private void btnLogin_Click(object sender, EventArgs e)
        {
            frmLogin frm = new frmLogin();
            frm.ShowDialog();
        }
        // lougout forme
        private void btnLogout_Click(object sender, EventArgs e)
        {
            // close sub formes 
            store.Expanded = false;
            sales.Expanded = false;
            buy.Expanded = false;
            ressource.Expanded = false;
            customers.Expanded = false;
            users.Expanded = false;

            btnLogout.Enabled = false;
            store.Enabled = false;
            sales.Enabled = false;
            buy.Enabled = false;
            ressource.Enabled = false;
            ressource.Enabled = false;
            customers.Enabled = false;
            users.Enabled = false;
            btnLogin.Enabled = true;
        }
        //show items forms
        private void btnItem_Click(object sender, EventArgs e)
        {
            frmItem frmItem = new frmItem();


            //pnCont.Controls.Clear();
            //pnCont.Controls.Add(frmItem.pnItem);
            frmItem.ShowDialog();
        }
        // show products forms 
        private void btnProduct_Click(object sender, EventArgs e)
        {
            frmProducts frm = new frmProducts();
            frm.ShowDialog();
        }

        private void btnCustomers_Click(object sender, EventArgs e)
        {
            frmCustomer frmCus = new frmCustomer();
            frmCus.ShowDialog();
        }

        private void pnCont_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnSales_Click(object sender, EventArgs e)
        {
            FrmSales frmSls = new FrmSales();
            frmSls.ShowDialog();
        }

        private void sales_Click(object sender, EventArgs e)
        {

        }

        private void btnSalesOrder_Click(object sender, EventArgs e)
        {
            frmOrderSales frmordS = new frmOrderSales();
            frmordS.ShowDialog();
        }
    }
}
