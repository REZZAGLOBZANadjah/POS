using DevExpress.XtraBars;
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
    public partial class FrmSales : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public int typeCustomer = 1;
        //clear textboxes
        public void clearTextProduct()
        {
            txtCode.Clear();
            txtProdName.Clear();
            txtPrice.Text = Convert.ToDouble(0).ToString();
            txtQte.Text = Convert.ToDouble(1).ToString();
            txtDiscount.Text = Convert.ToDouble(0).ToString();
            txtAmount.Text = Convert.ToDouble(0).ToString();


        }
        DataTable dtSales = new DataTable();
        // void calculate decount  value and the total amount of product
        public void CalculateAmountDescount()
        {
            double amount, descount, totalAmount;
            amount = Convert.ToDouble(txtPrice.Text)*Convert.ToDouble(txtQte.Text);
            descount = Convert.ToDouble(txtDiscount.Text) * amount / 100;
            totalAmount = amount - descount;
            txtAmount.Text = totalAmount.ToString();
        }
        public void CalcTotalAddedValue()
        {
            double totale = 0;
            for (int i = 0; i < dgvSales.Rows.Count; i++)
            {
                totale+=Convert.ToDouble(dgvSales.Rows[i].Cells[5].Value);
            }
            double valueAdded = Convert.ToDouble(txtAddedValue.Text) * totale / 100;
            double totalFinale = totale + valueAdded;
            double stay = Convert.ToDouble(txtPayed.Text) - totalFinale;
            txtStay.Text = stay.ToString();
            txtTotal.Text = totalFinale.ToString();

        }
        public FrmSales()
        {
            InitializeComponent();
            gBCustInfo.Enabled = false;
            txtUser.Text = CLSusers.fullName;
            if (this.Text == "تحديث")
            {
                return;
            }
            ClsOrders ord = new ClsOrders();
            ord.MaxIDPublic("MaxIdOrderSalesSP");
            int ID = ord.MaxIDPublic("MaxIdOrderSalesSP") + 1;
            txtFactId.Text = ID.ToString();       
            txtTestQuer.Text = ClsPublic.testQuery().ToString();
        }


        private void FrmSales_Load(object sender, EventArgs e)
        {
            ClsCustomers cus = new ClsCustomers();
            cus.SelectCustomersByPhone(txtPhoneCus.Text);
            txtNameCus.Text = cus.name;
            txtAdressCus.Text = cus.adress;
            txtEmailCus.Text = cus.email;
            ////
            dtSales.Columns.Add("الباركود");
            dtSales.Columns.Add("اسم المنتج");
            dtSales.Columns.Add("السعر");
            dtSales.Columns.Add("الكمية");
            dtSales.Columns.Add("الخصم");
            dtSales.Columns.Add("الاجمالي");

            dgvSales.DataSource = dtSales;
            ClsOrders clso = new ClsOrders();
            if (this.Text == "تحديث")
            {
                clso.LoadOrderDetails(Convert.ToInt32( txtFactId.Text));
                dtSales = clso.dtOrd.Copy();
                dgvSales.DataSource = dtSales;
                CalcTotalAddedValue();

            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            txtDate.Text = DateTime.Now.ToString();

        }

        private void bTNDeleteAll_Click(object sender, EventArgs e)
        {
            dtSales.Clear();
            CalcTotalAddedValue();

        }



        private void rBCash_CheckedChanged(object sender, EventArgs e)
        {
            if (rBCash.Checked==true) {
                typeCustomer = 1;
                gBCustInfo.Enabled = false;
                //txtUser.Text = typeCustomer.ToString();
            }
            
        }

        private void rBOut_CheckedChanged(object sender, EventArgs e)
        {
            if (rBOut.Checked == true)
            {
                typeCustomer = 2;
                gBCustInfo.Enabled  = true;
                //txtUser.Text = typeCustomer.ToString();
            }
        }

        private void rBIn_CheckedChanged(object sender, EventArgs e)
        {
            if (rBIn.Checked == true)
            {
                typeCustomer = 3;
                gBCustInfo.Enabled = false;
               // txtUser.Text = typeCustomer.ToString();

            }
        }
        // copy text from user controle forme to the customer form
        private void txtPhoneCus_KeyDown(object sender, KeyEventArgs e)
        {
            //
            if (e.KeyCode == Keys.Enter)

            {
                txtPhoneCus.SelectAll();
                txtPhoneCus.Copy();
                ucCustomersAdd.txtPhoneUC.Clear();
                ucCustomersAdd.txtPhoneUC.Paste();
                ucCustomersAdd.txtNameUC.Clear();
                ucCustomersAdd.txtAdressUC.Clear();
                ucCustomersAdd.txtEmailUC.Clear();
                ClsCustomers cus = new ClsCustomers();
                cus.SelectCustomersByPhone(txtPhoneCus.Text);
                txtNameCus.Text = cus.name;
                txtAdressCus.Text = cus.adress;
                txtEmailCus.Text = cus.email;
                if (txtNameCus.Text=="")
                {
                    ucCustomersAdd.Visible = true;
                  
 
                }
                else
                {
                    ucCustomersAdd.Visible = false;
                    txtCode.Focus();
                }

            }
        }


        private void FrmSales_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.Add)
            {
                MessageBox.Show("--------CONTROL + ADD --------");

                txtPhoneCus.Clear();
                txtNameCus.Clear();
                txtAdressCus.Clear();
                txtEmailCus.Clear();
                MessageBox.Show("--------SUCSESS--------");
            }
        }

      

        private void txtPrice_EditValueChanged(object sender, EventArgs e)
        {
            CalculateAmountDescount();
        }

        private void txtQte_EditValueChanged(object sender, EventArgs e)
        {
            CalculateAmountDescount();
        }

        private void txtDiscount_EditValueChanged(object sender, EventArgs e)
        {
            CalculateAmountDescount();
        }

        private void txtDiscount_KeyDown(object sender, KeyEventArgs e)
        {
            for (int i = 0; i < dgvSales.Rows.Count; i++)
            {
                if (txtCode.Text==dgvSales.Rows[i].Cells[0].Value.ToString())
                {
                    CLSset set = new CLSset();
                    set.LoadSetting();
                    if (set.RepeatProduct==true) {
                        txtDiscount.ReadOnly = false;
                    }
                    else
                    {
                        txtDiscount.ReadOnly = true;
                    }

                }
            }
            
            if (e.KeyCode==Keys.Enter)
            {
                CLSset set = new CLSset();
                set.LoadSetting();
                if (set.RepeatProduct == false)
                {
                    for (int i = 0; i < dgvSales.Rows.Count; i++)
                    {
                        if (txtCode.Text == dgvSales.Rows[i].Cells[0].Value.ToString())
                        {
                            dgvSales.Rows[i].Cells[3].Value = Convert.ToDouble(txtQte.Text )
                                + Convert.ToDouble(dgvSales.Rows[i].Cells[3].Value);

                            double amount, descount, totalAmount;
                            amount = Convert.ToDouble(dgvSales.Rows[i].Cells[2].Value)
                                * Convert.ToDouble(dgvSales.Rows[i].Cells[3].Value);

                            descount = Convert.ToDouble(dgvSales.Rows[i].Cells[4].Value) * amount / 100;
                            totalAmount = amount - descount;

                            dgvSales.Rows[i].Cells[5].Value = totalAmount;

                            txtCode.Focus();
                            clearTextProduct();
                            CalcTotalAddedValue();
                            txtPayed.Focus();

                            return;
                        }

                    }
                }


                txtCode.Focus();
                DataRow row = dtSales.NewRow();
                row[0] = txtCode.Text;
                row[1] = txtProdName.Text;
                row[2] = txtPrice.Text;
                row[3] = txtQte.Text;
                row[4] = txtDiscount.Text;
                row[5] = txtAmount.Text;

               
                dtSales.Rows.Add(row);
                clearTextProduct();
                


            }
            CalcTotalAddedValue();

        }

        private void ucCustomersAdd_VisibleChanged(object sender, EventArgs e)
        {
            if (ucCustomersAdd.Visible == false)
            {
                txtPhoneCus.Focus();
            }
        }

        private void txtCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                ClsProduct prod = new ClsProduct();
                prod.SelectProductByCode(txtCode.Text);
                txtProdName.Text = prod.NameProd;
                txtPrice.Text = Convert.ToDouble(prod.priceSale).ToString();
                if (txtProdName.Text!="")
                {
                    txtQte.Select();
                    CLSset sett = new CLSset();
                    if (sett.FastSales==true)
                    {
                        SendKeys.Send("{ENTER}");
                        SendKeys.Send("{ENTER}");
                    }
                }
            }
        }

        private void txtQte_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ClsProduct prod = new ClsProduct();
                if (prod.CheckQty(txtCode.Text,Convert.ToDouble(txtQte.Text)).Rows.Count <1 )
                {
                    MessageBox.Show("كمية غير متاحة");
                    
                    return;

                }
                txtDiscount.Select() ;
                
            }
        }

       
        private void barButtonItem10_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmSetting frmSet = new FrmSetting();
            frmSet.ShowDialog();

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                dgvSales.Rows.RemoveAt(dgvSales.CurrentRow.Index);

            }
            catch (Exception)
            {

                return;
            }
            CalcTotalAddedValue();
            txtPayed.Focus();

        }

        private void btUpdateProd_Click(object sender, EventArgs e)
        {
            try
            {
                txtCode.Text = dgvSales.CurrentRow.Cells[0].Value.ToString();
                txtProdName.Text = dgvSales.CurrentRow.Cells[1].Value.ToString();
                txtPrice.Text = dgvSales.CurrentRow.Cells[2].Value.ToString();
                txtQte.Text = dgvSales.CurrentRow.Cells[3].Value.ToString();
                txtDiscount.Text = dgvSales.CurrentRow.Cells[4].Value.ToString();
                txtAmount.Text = dgvSales.CurrentRow.Cells[5].Value.ToString();
                txtQte.Focus();
                txtDiscount.ReadOnly=false;
                dgvSales.Rows.RemoveAt(dgvSales.CurrentRow.Index);

            }
            catch (Exception)
            {
                MessageBox.Show("ERROR ,Ther is no items to delete them ");
                return;
            }
            CalcTotalAddedValue();
            txtPayed.Focus();

        }

        private void txtAddedValue_EditValueChanged(object sender, EventArgs e)
        {

            if (txtAddedValue.Text=="")
            {
                txtAddedValue.Text = "0";
            }
            CalcTotalAddedValue();
        }
        private void txtPayed_TextChanged(object sender, EventArgs e)
        {
            if (txtPayed.Text == "")
            {
                txtPayed.Text = "0";
            }
            CalcTotalAddedValue();
        }

        private void btnProd_Click(object sender, EventArgs e)
        {
            txtCode.Focus();
            frmSearchProd srcP = new frmSearchProd();
            srcP.ShowDialog();
        }

        private void txtCode_TextChanged(object sender, EventArgs e)
        {
            if (txtCode.Text=="")
            {
                btnProd.Visible = true;
            }
            else
            {
                btnProd.Visible = false;

            }
        }

        private void btnNewOrder_Click(object sender, EventArgs e)
        {
            txtPhoneCus.Clear();
            txtNameCus.Clear();
            txtAdressCus.Clear();
            txtEmailCus.Clear();

            ClsOrders ord = new ClsOrders();
            ord.MaxIDPublic("MaxIdOrderSalesSP");
            int ID = ord.MaxIDPublic("MaxIdOrderSalesSP") + 1;
            txtFactId.Text = ID.ToString();
            txtUser.Text = CLSusers.fullName;
            txtTestQuer.Text = ClsPublic.testQuery().ToString();
            //gBCustInfo.Enabled = false;

            txtAddedValue.Text = Convert.ToDouble(0).ToString();
            txtPayed.Text = Convert.ToDouble(0).ToString();
            dtSales.Clear();
            CalcTotalAddedValue();
            if (rBCash.Checked == true)
            {
                typeCustomer = 1;
                gBCustInfo.Enabled = false;
            }
            if (rBOut.Checked == true)
            {
                typeCustomer = 2;
                gBCustInfo.Enabled = true;
            }
        }

        private void btnSaveOrder_Click(object sender, EventArgs e)
        {
            //save order
             string  TC="0";
            if (rBCash.Checked == true)
            {
                TC = "1";
                typeCustomer = 1;
                txtNameCus.Text = "عميل نقدي";

            }
            if (rBOut.Checked == true)
            {
               // TC = txtPhoneCus.Text;
                TC = "2";

                typeCustomer = 2;

            }
            if (rBIn.Checked == true)
            {
                TC = "3";
                typeCustomer = 3;
                txtNameCus.Text = "عميل داخلي";

            }
            ClsOrders ord = new ClsOrders();
            ClsPublic pub = new ClsPublic();
            int id = pub.MaxIDPublic("MaxIdOrderSalesSP") + 1;

            ord.InsertOrderSale(
                id,
               Convert.ToDateTime( txtDate.Text),

               Convert.ToDouble( txtAddedValue.Text),
               Convert.ToDouble(txtTotal.Text),
               Convert.ToDouble(txtPayed.Text),
               Convert.ToDouble(txtStay.Text),
               txtUser.Text,
               txtNameCus.Text, 
               typeCustomer);

            // save order details 
            for (int i = 0; i < dgvSales.Rows.Count; i++)
            {
                ord.InsertOrdersSalesDetails(
                    id,
                    dgvSales.Rows[i].Cells[0].Value.ToString(),
                    dgvSales.Rows[i].Cells[1].Value.ToString(),
                    Convert.ToDouble( dgvSales.Rows[i].Cells[2].Value.ToString()),
                    Convert.ToDouble( dgvSales.Rows[i].Cells[3].Value.ToString()),
                    Convert.ToDouble( dgvSales.Rows[i].Cells[4].Value.ToString()),
                    Convert.ToDouble( dgvSales.Rows[i].Cells[5].Value.ToString()));
            }
           MessageBox.Show("تم حفظ فاتورة جديدة",txtUser.Text);
            btnNewOrder.PerformClick();
           // btnPrintLast.PerformClick();
        }

   



        private void btnPrintLast_Click(object sender, EventArgs e)
        {
            CrPrintOrderSignal cr = new CrPrintOrderSignal();
            ClsOrders ord = new ClsOrders();
            FrmPrint frmPr = new FrmPrint();
            int id = ord.MaxIDPublic("MaxIdOrderSalesSP");
            ord.GetVOrderAll(id);
            cr.SetDataSource(ord.dtOrd);
            frmPr.crystalReportViewer1.ReportSource = cr;
            cr.PrintOptions.PrinterName = "Canon LBP6030/6040/6018L";
            cr.PrintToPrinter(1,false,0,0);
            cr.Dispose();
            frmPr.Show();
        }

        private void ribbon_Click(object sender, EventArgs e)
        {

        }

        private void btnSaveUpdate_Click(object sender, EventArgs e)
        {
            //save order
            string TC = "0";
            if (rBCash.Checked == true)
            {
                TC = "1";
                typeCustomer = 1;
            }
            if (rBOut.Checked == true)
            {
                // TC = txtPhoneCus.Text;
                TC = "2";

                typeCustomer = 2;

            }
            if (rBIn.Checked == true)
            {
                TC = "3";
                typeCustomer = 3;

            }
            ClsOrders ord = new ClsOrders();
           //int id = pub.MaxIDPublic("MaxIdOrderSalesSP") + 1;
            ord.UpdteOrderSales(
               Convert.ToInt32(txtFactId.Text),
               Convert.ToDateTime(txtDate.Text),
               Convert.ToDouble(txtAddedValue.Text),
               Convert.ToDouble(txtTotal.Text),
               Convert.ToDouble(txtPayed.Text),
               Convert.ToDouble(txtStay.Text),
               txtUser.Text,
               txtPhoneCus.Text,
               typeCustomer);

            ord.DeleteOrederDet(Convert.ToInt32(txtFactId.Text));
            // save order details 
            for (int i = 0; i < dgvSales.Rows.Count; i++)
            {
                ord.InsertOrdersSalesDetails(
                    Convert.ToInt32(txtFactId.Text),
                    dgvSales.Rows[i].Cells[0].Value.ToString(),
                    dgvSales.Rows[i].Cells[1].Value.ToString(),
                    Convert.ToDouble(dgvSales.Rows[i].Cells[2].Value.ToString()),
                    Convert.ToDouble(dgvSales.Rows[i].Cells[3].Value.ToString()),
                    Convert.ToDouble(dgvSales.Rows[i].Cells[4].Value.ToString()),
                    Convert.ToDouble(dgvSales.Rows[i].Cells[5].Value.ToString()));
            }
             MessageBox.Show("update order done   ",txtUser.Text);
            btnNewOrder.PerformClick();
            btnPrintLast.PerformClick();
        }

        private void barButtonItem13_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmOrderSales frmOS = new frmOrderSales();
            frmOS.ShowDialog();
        }
    }
}