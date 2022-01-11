using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1;
namespace POS
{

    public partial class frmOrderSales : Form
    {
        public int ID;
        public frmOrderSales()
        {
            InitializeComponent();
            LoadOrderSales();
            if (CLSusers.admin==true)
            {
                suppFact.Enabled = true;
                suppAll.Enabled = true;
                delFact.Enabled = true;
                modifierFact.Enabled = true;
                modFact.Enabled = true;
            }
        }
        public void LoadOrderSales()
        {
            ClsPublic pub = new ClsPublic();
            pub.LoadPublic("LoadVOrderSaleAllSP");
            dgvOrdSales.DataSource = pub.DTPublic;
        }
       

        private void chShowOrd_CheckedChanged(object sender, EventArgs e)
        {
            
            if (chShowOrd.Checked==true)
            {
                ClsPublic pub = new ClsPublic();
                pub.LoadPublic("LoadVOrderSaleAllSP");
                dgvOrdSales.DataSource = pub.DTPublic;
                cbTypeCus.Enabled = false;

            }
            else
            {
                cbTypeCus.Enabled = true;
                ClsOrders ord = new ClsOrders();
                ord.LoadTypeCustomer();
                cbTypeCus.DataSource = ord.dtOrd;
                cbTypeCus.ValueMember = "id";
                cbTypeCus.DisplayMember = "typeCustomer";
               

            }
        }

 

        private void cbTypeCus_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClsOrders ord = new ClsOrders();
            ord.LoadVOrderSaleByTypeCus(cbTypeCus.Text);
            dgvOrdSales.DataSource = ord.dtOrd;
        }

        private void btnOrdDetails_Click(object sender, EventArgs e)
        {
            try
            {
                int nbr = dgvOrdSales.Rows.Count;
                if (nbr>0)
                {
                    ID = Convert.ToInt32(dgvOrdSales.CurrentRow.Cells[0].Value);
                    ClsOrders ord = new ClsOrders();
                    ord.LoadOrderDetails(ID);
                    frmOrdDetails frm = new frmOrdDetails();
                    frm.dgvOrdDetails.DataSource = ord.dtOrd;
                    frm.lbNo.Text += ID.ToString();
                    frm.ShowDialog();
                }
                else
                {
                    MessageBox.Show("There is no data");
                }

            }
            catch (Exception)
            {

                MessageBox.Show("There is no data");
            }
           
                
        }

        private void btnPrintFact_Click(object sender, EventArgs e)
        {
            int id =Convert.ToInt32( dgvOrdSales.CurrentRow.Cells[0].Value);
            CrPrintOrderSignal cr = new CrPrintOrderSignal();
            ClsOrders ord = new ClsOrders();
            FrmPrint frmPr = new FrmPrint();
            ord.GetVOrderAll(id);

            cr.SetDataSource(ord.dtOrd);
            frmPr.crystalReportViewer1.ReportSource = cr;
            frmPr.Show();
        }

        private void btnPrintAll_Click(object sender, EventArgs e)
        {
            CrPrintOrders cr = new CrPrintOrders();
            ClsOrders ord = new ClsOrders();
            FrmPrint frmPr = new FrmPrint();
            ord.OrderInfo();

           cr.SetDataSource(ord.dtOrd);
            frmPr.crystalReportViewer1.ReportSource = cr;
            frmPr.Show();
        }



         private void btnUpdateOrdSale_Click(object sender, EventArgs e)
         {
             FrmSales frm = new FrmSales();
             frm.Text = "تحديث";
             frm.txtFactId.Text = dgvOrdSales.CurrentRow.Cells[0].Value.ToString();
             frm.btnNewOrder.Visible = false;
             frm.btnPrintLast.Visible = false;
             frm.btnSaveUpdate.Visible = true;
             ClsOrders ord = new ClsOrders();
             string phone = ord.GetCustomerOrder(Convert.ToInt32( dgvOrdSales.CurrentRow.Cells[0].Value.ToString()));
             frm.txtPhoneCus.Text = phone;
             if (phone=="1")
             {
                 frm.rBCash.Checked = true;

             }else if (phone=="3")
             {
                 frm.rBIn.Checked = true;

             }
             else
             {
                 frm.rBOut.Checked = true;

             }
             frm.Show();



         }

        private void det_Click(object sender, EventArgs e)
        {
            try
            {
                int nbr = dgvOrdSales.Rows.Count;
                if (nbr > 0)
                {
                    ID = Convert.ToInt32(dgvOrdSales.CurrentRow.Cells[0].Value);
                    ClsOrders ord = new ClsOrders();
                    ord.LoadOrderDetails(ID);
                    frmOrdDetails frm = new frmOrdDetails();
                    frm.dgvOrdDetails.DataSource = ord.dtOrd;
                    frm.lbNo.Text += ID.ToString();
                    frm.ShowDialog();
                }
                else
                {
                    MessageBox.Show("There is no data");
                }

            }
            catch (Exception)
            {

                MessageBox.Show("There is no data");
            }
        }

        private void print_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dgvOrdSales.CurrentRow.Cells[0].Value);
            CrPrintOrderSignal cr = new CrPrintOrderSignal();
            ClsOrders ord = new ClsOrders();
            FrmPrint frmPr = new FrmPrint();
            ord.GetVOrderAll(id);

            cr.SetDataSource(ord.dtOrd);
            frmPr.crystalReportViewer1.ReportSource = cr;
            frmPr.Show();
        }

        private void printAll_Click(object sender, EventArgs e)
        {
            CrPrintOrders cr = new CrPrintOrders();
            ClsOrders ord = new ClsOrders();
            FrmPrint frmPr = new FrmPrint();
            ord.OrderInfo();

            cr.SetDataSource(ord.dtOrd);
            frmPr.crystalReportViewer1.ReportSource = cr;
            frmPr.Show();
        }

        private void modFact_Click(object sender, EventArgs e)
        {
            FrmSales frm = new FrmSales();
            frm.Text = "تحديث";
            frm.txtFactId.Text = dgvOrdSales.CurrentRow.Cells[0].Value.ToString();
            frm.btnNewOrder.Visible = false;
            frm.btnPrintLast.Visible = false;
            frm.btnSaveUpdate.Visible = true;
            ClsOrders ord = new ClsOrders();
            string phone = ord.GetCustomerOrder(Convert.ToInt32(dgvOrdSales.CurrentRow.Cells[0].Value.ToString()));
            frm.txtPhoneCus.Text = phone;
            if (phone == "1")
            {
                frm.rBCash.Checked = true;

            }
            else if (phone == "3")
            {
                frm.rBIn.Checked = true;

            }
            else
            {
                frm.rBOut.Checked = true;

            }
            frm.Show();
        }

        private void suppFact_Click(object sender, EventArgs e)
        {
            try
            {
                ClsOrders ord = new ClsOrders();
                ID = Convert.ToInt32(dgvOrdSales.CurrentRow.Cells[0].Value);
                if (MessageBox.Show("هل تريد حذف الفاتورة المحددة؟", "عملية حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    ord.DeleteOreder(ID);
                    MessageBox.Show("تم الحذف بنجاح", "عملية حذف", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadOrderSales();
                }
                else
                {
                    MessageBox.Show("تم الغاء عملية الحذف", "عملية حذف", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

            }
            catch (Exception)
            {

                return;
            }
           
        }

        private void suppAll_Click(object sender, EventArgs e)
        {
            try
            {
                ClsOrders ord = new ClsOrders();
                ID = Convert.ToInt32(dgvOrdSales.CurrentRow.Cells[0].Value);
                if (MessageBox.Show("احذر سوف يتم   حذف كل الفواتير؟", "عملية حذف الكل", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    ord.DeleteALLOreders();
                    MessageBox.Show("تم الحذف بنجاح", "عملية حذف", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadOrderSales();
                }
                else
                {
                    MessageBox.Show("تم الغاء عملية الحذف", "عملية حذف", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception)
            {

                return;
            }
            
        }

        private void frmOrderSales_Load(object sender, EventArgs e)
        {

        }
    }
}
