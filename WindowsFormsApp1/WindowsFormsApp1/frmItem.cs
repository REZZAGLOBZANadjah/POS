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
    public partial class frmItem : Form
    {
        int add = 0;

        public frmItem()
        {
            InitializeComponent();
            ClsItem item = new ClsItem();
            item.LoadItems();
            dgvItems.DataSource = item.dtItem;
            dgvItems.Columns[0].HeaderText = "رقم الصنف";
            dgvItems.Columns[1].HeaderText = "اسم الصنف";
        
        }

        private void frmItem_Load(object sender, EventArgs e)
        {

        }

       

        private void btnSave_Click(object sender, EventArgs e)
        {
           



        }

        private void btnEditItem_Click(object sender, EventArgs e)
        {
            add = 1;
            txtID.Text = dgvItems.CurrentRow.Cells[0].Value.ToString();
            txtName.Text = dgvItems.CurrentRow.Cells[1].Value.ToString();
            txtName.Enabled = true;

        }

        private void btnDeleteItem_Click(object sender, EventArgs e)
        {
           
        }

        private void pnItem_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnAddItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            add = 0;
            ClsItem item = new ClsItem();
            txtName.Enabled = true;
            txtName.Clear();
            txtName.Select();
            int maxId = item.MaxIdItem() + 1;
            txtID.Text = maxId.ToString();
        }



        private void DeleteItem_Click(object sender, EventArgs e)
        {
            ClsItem item = new ClsItem();
            int id = Convert.ToInt32(dgvItems.CurrentRow.Cells[0].Value.ToString());

            if (MessageBox.Show("هل تريد حذف الصنف المحدد ؟", "عملية حذف" + dgvItems.CurrentRow.Cells[1].Value, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                item.DeleteItem(id);
                MessageBox.Show("تمت عملية الحذف ينجاح", "عملية حذف", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show("تم الغاء عملية الحذف ", "عملية حذف", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;


            }
            item.LoadItems();
            dgvItems.DataSource = item.dtItem;
        }

        private void EditItem_Click(object sender, EventArgs e)
        {
            add = 1;
            txtID.Text = dgvItems.CurrentRow.Cells[0].Value.ToString();
            txtName.Text = dgvItems.CurrentRow.Cells[1].Value.ToString();
            txtName.Enabled = true;
        }

        private void saveItem_Click(object sender, EventArgs e)
        {
            if (add == 0)
            {
                //add item
                ClsItem item = new ClsItem();
                if (txtName.Text != "")
                {
                    item.InsertItem(Convert.ToInt32(txtID.Text), txtName.Text);
                    item.LoadItems();
                    dgvItems.DataSource = item.dtItem;
                    MessageBox.Show("تمت الاضافة بنجاح");
                    txtID.Clear();
                    txtName.Clear();
                    txtName.Enabled = false;
                }
                else
                {
                    MessageBox.Show("اسم صنف مطلوب");
                }
            }
            else
            {
                //edit item
                ClsItem item = new ClsItem();
                if (txtName.Text != "")
                {
                    item.UpdateItem(Convert.ToInt32(txtID.Text), txtName.Text);
                    item.LoadItems();
                    dgvItems.DataSource = item.dtItem;
                    MessageBox.Show("تمت التعديل بنجاح");
                    txtID.Clear();
                    txtName.Clear();
                    txtName.Enabled = false;
                }
                else
                {
                    MessageBox.Show("اسم صنف مطلوب");
                }
            }

        }
    }
}
