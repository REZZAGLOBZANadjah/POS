using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.IO;
namespace POS
{
    public partial class frmProducts : Form
    {
        Boolean ADD;
        public void ClearTxt()
        {
            txtID.Clear();
            txtName.Clear();
            txtCode.Clear();
            txtBuy.Clear();
            txtSale.Clear();
            txtEarn.Clear();
            txtQty.Clear();
            pBox.Image=null; 
        }
        public void LoadProd()
        {
            ClsProduct prod = new ClsProduct();
            prod.LoadPublic("LoadVProductItemSP");
            gcProducts.DataSource = prod.DTPublic;
            dgvProd.DataSource = prod.DTPublic;
        }
        public frmProducts()
        {
            InitializeComponent();
            ClsItem item = new ClsItem();
            item.LoadItems();

            cmbItem.DataSource = item.dtItem ;
            cmbItem.DisplayMember = "name";
            cmbItem.ValueMember = "idItem";
            LoadProd();
            

        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            ClearTxt();

            //txtCode.Text = cmbItem.SelectedValue.ToString();
            ClsProduct prod = new ClsProduct();
            int max = prod.MaxIDPublic("MaxIDProductSP")+1;
            txtID.Text = max.ToString();
            ADD = true;
            btnSave.Enabled = true;
            gBox.Enabled = true;
        }

        private void frmProducts_Load(object sender, EventArgs e)
        {

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                ADD = false;
                btnSave.Enabled = true;
                gBox.Enabled = true;
                txtCode.Enabled = false;
                txtID.Text = dgvProd.CurrentRow.Cells[0].Value.ToString();
                txtCode.Text = dgvProd.CurrentRow.Cells[1].Value.ToString();
                txtName.Text = dgvProd.CurrentRow.Cells[2].Value.ToString();
                txtBuy.Text = dgvProd.CurrentRow.Cells[3].Value.ToString();
                txtSale.Text = dgvProd.CurrentRow.Cells[4].Value.ToString();
                txtEarn.Text = dgvProd.CurrentRow.Cells[5].Value.ToString();
                txtQty.Text = dgvProd.CurrentRow.Cells[6].Value.ToString();
                cmbItem.Text = dgvProd.CurrentRow.Cells[7].Value.ToString();
                

            }
            catch (Exception)
            {

                return;
            }

            try
            {
                // get image product from table prod 
                ClsProduct prod = new ClsProduct();
                byte[] img = (byte[])prod.getImgProd(dgvProd.CurrentRow.Cells[1].Value.ToString()).Rows[0][0];
                MemoryStream ms = new MemoryStream(img);
                pBox.Image = Image.FromStream(ms);
            }
            catch (Exception)
            {

                pBox.Image=null;
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ADD==true)
            {
                //INSERT
                if (pBox.Image==null)
                {
                    // insert product without  Image inserted
                    ClsProduct prod = new ClsProduct();
                    prod.InsertProductNoImage(
                        //Convert.ToInt32(txtID.Text),
                        txtCode.Text,
                        txtName.Text,
                        Convert.ToDouble(txtBuy.Text),
                        Convert.ToDouble(txtSale.Text),
                        Convert.ToDouble(txtEarn.Text),
                        Convert.ToDouble(txtQty.Text),
                        Convert.ToInt32(cmbItem.SelectedValue));
                    MessageBox.Show("****تمت اضافة منتج بنجاح****");
                }
                else
                {
                    MemoryStream ms = new MemoryStream();
                    pBox.Image.Save(ms,pBox.Image.RawFormat);
                    byte[] img = ms.ToArray();
                    //insert  product with image 
                    ClsProduct prod = new ClsProduct();
                    prod.InsertProductImage(
                        //Convert.ToInt32(txtID.Text),
                        txtCode.Text,
                        txtName.Text,
                        Convert.ToDouble(txtBuy.Text),
                        Convert.ToDouble(txtSale.Text),
                        Convert.ToDouble(txtEarn.Text),
                        Convert.ToDouble(txtQty.Text),
                        img,
                        Convert.ToInt32(cmbItem.SelectedValue)) ;
                    MessageBox.Show("****تمت اضافة منتج بنجاح**بصورة**");
                }

            }
            else
            {
                // UPDATE 
                if (pBox.Image == null)
                {
                    //Update without image 
                    ClsProduct prod = new ClsProduct();
                    
                    prod.UpdateProd(
                        //Convert.ToInt32(txtID.Text),
                        txtName.Text,
                        Convert.ToDouble(txtBuy.Text),
                        Convert.ToDouble(txtSale.Text),
                        Convert.ToDouble(txtEarn.Text),
                        Convert.ToDouble(txtQty.Text),
                        Convert.ToInt32(cmbItem.SelectedValue),
                        txtCode.Text);
                    MessageBox.Show("****تمت تحديث منتج بنجاح***بدون صورة*");
                }
                else
                {
                    MemoryStream ms = new MemoryStream();
                    pBox.Image.Save(ms, pBox.Image.RawFormat);
                    byte[] img = ms.ToArray();
                    //insert  product with image 
                    // update image 
                    //UpdateProdImgSP

                    //Update without image 
                    ClsProduct prod = new ClsProduct();
                    prod.UpdateProdImg(
                        //Convert.ToInt32(txtID.Text),
                        txtName.Text,
                        Convert.ToDouble(txtBuy.Text),
                        Convert.ToDouble(txtSale.Text),
                        Convert.ToDouble(txtEarn.Text),
                        Convert.ToDouble(txtQty.Text),
                        Convert.ToInt32(cmbItem.SelectedValue),
                        img,
                        txtCode.Text);
                    MessageBox.Show("****تمت تحديث منتج بنجاح***بصورة*");
                }




            }
            // clear text boxes
            ClearTxt();
            btnSave.Enabled = false;
            gBox.Enabled = false;
            LoadProd();
        }

        private void txtSale_TextChanged(object sender, EventArgs e)
        {
           /* try
            {
                txtEarn.Text = (Convert.ToDouble(txtSale.Text) - Convert.ToDouble(txtBuy.Text)).ToString();

            }
            catch (Exception)
            {

                return;
            }
       
            */
        }

        private void txtEarn_TextChanged(object sender, EventArgs e)
        {
           // 
            try
            {
                txtEarn.Text = (Convert.ToDouble(txtSale.Text) - Convert.ToDouble(txtBuy.Text)).ToString();

                if (Convert.ToDouble(txtEarn.Text) <= 0)
                {
                    txtEarn.BackColor = Color.Red;
                }
                else
                {
                    txtEarn.BackColor = Color.Green;
                }
            }
            catch (Exception)
            {
                txtEarn.Text = "0";
                return;
            }         
        }

 

        private void btnSelectImage_Click(object sender, EventArgs e)
        {
            //open file dialogue
            ofd.Filter = "Image | *.jpeg; *.jpg; *.png;";
            if (ofd.ShowDialog()==DialogResult.OK)
            {
                pBox.Image = Image.FromFile(ofd.FileName);

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pBox.Image = null;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(dgvProd.CurrentRow.Cells[0].Value.ToString());
                if (id > 0)
                {
                    ClsProduct prod = new ClsProduct();

                    if (MessageBox.Show("هل تريد حذف المنتج المحدد ؟", "عملية حذف" + dgvProd.CurrentRow.Cells[1].Value, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        //prod.DeleteProd(id);
                        prod.DeletePublic("DeleteProductSP", id);
                        MessageBox.Show("تمت عملية الحذف بنجاح", "عملية حذف", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else
                    {
                        MessageBox.Show("تم الغاء عملية الحذف ", "عملية حذف", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;


                    }
                    prod.LoadPublic("LoadVProductItemSP");
                    dgvProd.DataSource = prod.DTPublic;
                }
                else
                {
                    MessageBox.Show("لا يوجد منتج لحذفه", "عملية حذف", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception)
            {

                MessageBox.Show("لا يوجد منتج لحذفه", "عملية حذف", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); 
            }
            LoadProd();
            
           
        }


    }
}
