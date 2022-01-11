using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace POS
{
    public partial class frmCustomer : Form
    {
        int ADD = 0;
        public void txtClear()
        {
            txtPhone.Clear();
            txtName.Clear();
            txtAdress.Clear();
            txtEmail.Clear();
            txtPhone.Select();
        }
        public void txtOn()
        {
            txtPhone.Enabled = true;
            txtName.Enabled = true;
            txtAdress.Enabled = true;
            txtEmail.Enabled = true;
        }
        public void txtOff()
        {
            txtPhone.Enabled = false;
            txtName.Enabled = false;
            txtAdress.Enabled = false;
            txtEmail.Enabled = false;
        }
        public void LoadCustomers()
        {
            ClsCustomers cus = new ClsCustomers();
            cus.LoadPublic("LoadCustomers");
            dgvCustomers.DataSource = cus.DTPublic;


        }
        public frmCustomer()
        {
            InitializeComponent();
            LoadCustomers();
        }

        private void frmCustomer_Load(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ADD = 1;
            txtOn();
            txtClear();
            txtPhone.ReadOnly = false;
            LoadCustomers();
            if (dgvCustomers.Rows.Count<1)
            {
                ClsCustomers cus = new ClsCustomers();
                cus.RES();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            ADD = 2;
            txtOn();
            txtClear();
            txtPhone.Text = dgvCustomers.CurrentRow.Cells[1].Value.ToString();
            txtName.Text = dgvCustomers.CurrentRow.Cells[2].Value.ToString();
            txtAdress.Text = dgvCustomers.CurrentRow.Cells[3].Value.ToString();
            txtEmail.Text = dgvCustomers.CurrentRow.Cells[4].Value.ToString();
            txtPhone.ReadOnly = true;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtPhone.Text==""||txtName.Text==""|| txtEmail.Text=="")
            {
                MessageBox.Show("لا يمكن ادخال قيم فارغة");
                return;
            }
            if (ADD == 0)
            {
                MessageBox.Show("لم يتم تنفيذ أي شيء");
            }
            else if (ADD == 1)
            {
                ClsCustomers cus = new ClsCustomers();
                cus.InsertCustomers(txtPhone.Text, txtName.Text, txtAdress.Text, txtEmail.Text);
                MessageBox.Show("تمت الاضافة بنجاح");
                //LoadCustomers();

            }
            else if (ADD == 2)
            {
                ClsCustomers cus = new ClsCustomers();
                cus.UpdateCustomer(txtPhone.Text, txtName.Text, txtAdress.Text, txtEmail.Text);
                MessageBox.Show("تم التعديل ينجاح");
                //LoadCustomers();

            }
            txtClear();
            txtOff();
            ADD = 0;
            LoadCustomers();
            txtPhone.ReadOnly = false;

        }

        private void txtPhoneKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtName.Select();
            }
        }

        private void txtNameKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtAdress.Select();
            }
        }

        private void txtAdressKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtEmail.Select();
            }
        }

        private void txtEmailKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSave.PerformClick();
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            ClsCustomers cus = new ClsCustomers();
            cus.SearchCustomers(txtSearch.Text);
            dgvCustomers.DataSource = cus.dtcustomers;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            LoadCustomers();

            if (dgvCustomers.Rows.Count > 0)
            {
                DialogResult result = MessageBox.Show(" سوف يتم حذف العميل", "عملية حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        int id = Convert.ToInt32(dgvCustomers.CurrentRow.Cells[0].Value);
                        ClsCustomers cus = new ClsCustomers();
                        cus.DeleteCustomer(id);
                    }
                    catch (Exception)
                    {

                        return;
                    }


                    
                    MessageBox.Show("تمت عملية الحذف بنجاح", "عملية حذف", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    return;
                }
           }
            else
            {
                //MessageBox.Show("لا يوجد عميل لحذفه", "عملية حذف", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;

            }
            LoadCustomers();
                
        }

        private void btnDeleteAll_Click(object sender, EventArgs e)
        {
            LoadCustomers();

            if (dgvCustomers.Rows.Count < 1)
            {
                return;
            }
            DialogResult result = MessageBox.Show("احذر سوف يتم حذف كل العملاء", "عملية حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                ClsCustomers cus = new ClsCustomers();
                cus.DeleteAllCustomer();
                MessageBox.Show("تمت عملية الحذف بنجاح", "عملية حذف", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cus.RES();
            }
            else
            {
                MessageBox.Show("تم الغاء عملية الحذف ", "عملية حذف", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            LoadCustomers();

        }

        private void txtPhone_Validating(object sender, CancelEventArgs e)
        {
            ClsCustomers cus = new ClsCustomers();
            DataTable dt = new DataTable();
            dt = cus.CheckPhone(txtPhone.Text);
            if (dt.Rows.Count>0)
            {
                MessageBox.Show( "  رقم هاتف موجود من قبل   "+ txtPhone.Text);
                txtPhone.Clear();
                txtPhone.Focus();
            }
        }

        private void pboxSearch_Click(object sender, EventArgs e)
        {

        }
    }

}

