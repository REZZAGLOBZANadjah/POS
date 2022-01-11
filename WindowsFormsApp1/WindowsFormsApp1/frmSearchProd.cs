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
    public partial class frmSearchProd : Form
    {
        public frmSearchProd()
        {
            InitializeComponent();
        }

        private void frmSearchProd_Load(object sender, EventArgs e)
        {
            ClsProduct prod = new ClsProduct();
            prod.LoadPublic("LoadVProductItemSP");
            dgvProducts.DataSource = prod.DTPublic;

        }

        private void txtSearchProd_TextChanged(object sender, EventArgs e)
        {
            ClsProduct prod = new ClsProduct();
            prod.SearchProduct(txtSearchProd.Text);
            dgvProducts.DataSource = prod.DTPublic;
        }

        private void txtSearchProd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                var frm = Application.OpenForms["FrmSales"] as FrmSales;
                frm.txtCode.Text = dgvProducts.CurrentRow.Cells[1].Value.ToString();
                SendKeys.Send("{ENTER}");

                this.Close();
            }
        }

        private void dgvProducts_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var frm = Application.OpenForms["FrmSales"] as FrmSales;
                frm.txtCode.Text = dgvProducts.CurrentRow.Cells[1].Value.ToString();
                SendKeys.Send("{ENTER}");
                this.Close();
            }
        }
    }
}
