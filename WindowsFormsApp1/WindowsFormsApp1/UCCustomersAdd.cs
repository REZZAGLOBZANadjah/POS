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
    public partial class UCCustomersAdd : UserControl
    {
        public UCCustomersAdd()
        {
            InitializeComponent();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ClsCustomers cus = new ClsCustomers();

            cus.InsertCustomers(txtPhoneUC.Text,txtNameUC.Text,txtAdressUC.Text,txtEmailUC.Text);
            this.Visible = false;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void UCCustomersAdd_Load(object sender, EventArgs e)
        {
           // txtPhoneUC.Clear();
           // txtPhoneUC.Paste();
            txtNameUC.Focus();
        }

        private void UCCustomersAdd_VisibleChanged(object sender, EventArgs e)
        {

        }

        private void txtNameUC_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                txtAdressUC.Focus();
            }
        }

        private void txtAdressUC_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtEmailUC.Focus();
            }
        }

        private void txtEmailUC_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSaveExite.Focus();
            }
        }
    }
}
