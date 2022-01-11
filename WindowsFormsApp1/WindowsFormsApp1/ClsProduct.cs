using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace POS
{
    class ClsProduct : ClsPublic 
    {
        public SqlCommand cmd;
         SqlDataReader drProduct;
        public int ID { get; set; }
        public  string NameProd { get; set; }
        public  string Code { get; set; }
        public  double priceBuy { get; set; }
        public  double priceSale { get; set; }
        public  double priceEarn { get; set; }
        public  double Qty { get; set; }
        public  int IdItem { get; set; }

        public void InsertProductNoImage(string code ,string name, double priceBuy,double priceSale,double priceEarn,double qty,int idtItem)
        {
            cmd = new SqlCommand();
            cmd.Connection = CLSset.cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "InsertProductSP";
            //cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
            cmd.Parameters.Add("@code", SqlDbType.VarChar, 50).Value = code;
            cmd.Parameters.Add("@name", SqlDbType.VarChar, 50).Value = name;
            cmd.Parameters.Add("@priceBuy", SqlDbType.Decimal).Value = priceBuy;
            cmd.Parameters.Add("@priceSale", SqlDbType.Decimal).Value = priceSale;
            cmd.Parameters.Add("@priceEarn", SqlDbType.Decimal).Value = priceEarn;
            cmd.Parameters.Add("@qty", SqlDbType.Decimal).Value = qty;
            cmd.Parameters.Add("@itItem", SqlDbType.Int).Value = idtItem;
            CLSset.cn.Open();
            cmd.ExecuteNonQuery();
            CLSset.cn.Close();
        }
        // insert product with image 
        public void InsertProductImage(string code, string name, double priceBuy, double priceSale, double priceEarn, double qty,byte[] imageProduct, int idtItem)
        {
            cmd = new SqlCommand();
            cmd.Connection = CLSset.cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "InsertProductImgSP";
            //cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
            cmd.Parameters.Add("@code", SqlDbType.VarChar, 50).Value = code;
            cmd.Parameters.Add("@name", SqlDbType.VarChar, 50).Value = name;
            cmd.Parameters.Add("@priceBuy", SqlDbType.Decimal).Value = priceBuy;
            cmd.Parameters.Add("@priceSale", SqlDbType.Decimal).Value = priceSale;
            cmd.Parameters.Add("@priceEarn", SqlDbType.Decimal).Value = priceEarn;
            cmd.Parameters.Add("@qty", SqlDbType.Decimal).Value = qty;
            cmd.Parameters.Add("@img", SqlDbType.Image).Value =imageProduct;
            cmd.Parameters.Add("@idItem", SqlDbType.Int).Value = idtItem;
            CLSset.cn.Open();
            cmd.ExecuteNonQuery();
            CLSset.cn.Close();
        }
        public DataTable getImgProd(string code)
        {
            DataTable dt = new DataTable();
            cmd = new SqlCommand();
            cmd.Connection = CLSset.cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "getImgProdSP";
            cmd.Parameters.Add("@code", SqlDbType.VarChar, 50).Value = code;
            CLSset.cn.Open();
            dt.Load(cmd.ExecuteReader());
            CLSset.cn.Close();
            return dt;

        }
        // update product without image 
        public void UpdateProd( string name, double priceBuy, double priceSale, double priceEarn, double qty, int idtItem, string code)
        {
            cmd = new SqlCommand();
            cmd.Connection = CLSset.cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "UpdateProdSP";
            cmd.Parameters.Add("@name", SqlDbType.VarChar, 50).Value = name;
            cmd.Parameters.Add("@priceBuy", SqlDbType.Decimal).Value = priceBuy;
            cmd.Parameters.Add("@priceSale", SqlDbType.Decimal).Value = priceSale;
            cmd.Parameters.Add("@priceEarn", SqlDbType.Decimal).Value = priceEarn;
            cmd.Parameters.Add("@qty", SqlDbType.Decimal).Value = qty;
            cmd.Parameters.Add("@itItem", SqlDbType.Int).Value = idtItem;
            cmd.Parameters.Add("@code", SqlDbType.VarChar, 50).Value = code;

            CLSset.cn.Open();
            cmd.ExecuteNonQuery();
            CLSset.cn.Close();
        }
        // update product wit image 
        public void UpdateProdImg(string name, double priceBuy, double priceSale, double priceEarn, double qty, int idtItem,byte[] img, string code)
        {
            cmd = new SqlCommand();
            cmd.Connection = CLSset.cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "UpdateProdImgSP";
            cmd.Parameters.Add("@name", SqlDbType.VarChar, 50).Value = name;
            cmd.Parameters.Add("@priceBuy", SqlDbType.Decimal).Value = priceBuy;
            cmd.Parameters.Add("@priceSale", SqlDbType.Decimal).Value = priceSale;
            cmd.Parameters.Add("@priceEarn", SqlDbType.Decimal).Value = priceEarn;
            cmd.Parameters.Add("@qty", SqlDbType.Decimal).Value = qty;
            cmd.Parameters.Add("@itItem", SqlDbType.Int).Value = idtItem;
            cmd.Parameters.Add("@img", SqlDbType.Image).Value = img;

            cmd.Parameters.Add("@code", SqlDbType.VarChar, 50).Value = code;

            CLSset.cn.Open();
            cmd.ExecuteNonQuery();
            CLSset.cn.Close();
        }
        //-------------delete product---------------
        public void DeleteProd(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = CLSset.cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "DeleteProductSP";
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
            CLSset.cn.Open();
            cmd.ExecuteNonQuery();
            CLSset.cn.Close();

        }
        // selct product by code
        public void SelectProductByCode(string code)
        {
            //DataTable dtProdName = new DataTable();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = CLSset.cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SelectProductByCodeSP";
            cmd.Parameters.Add("@code", SqlDbType.VarChar,50).Value = code;
            CLSset.cn.Open();
            drProduct=cmd.ExecuteReader();
            drProduct.Read();
            if (drProduct.HasRows)
            {
                NameProd = drProduct[2].ToString();
                priceSale = Convert.ToDouble(drProduct[4]);
            }
            else
            {
                NameProd ="";
                priceSale = 0;
            }
            drProduct.Close();
            CLSset.cn.Close();
        }
        public void SearchProduct(string txt)
        {
            //DataTable dtProdName = new DataTable();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = CLSset.cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SearchProductSP";
            cmd.Parameters.Add("@txt", SqlDbType.VarChar, 50).Value = txt;
            CLSset.cn.Open();

            DTPublic.Load(cmd.ExecuteReader());

            CLSset.cn.Close();
        }
        // check product quantity
        public DataTable CheckQty(string code, double Qty)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = CLSset.cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "CheckQtySP";
            cmd.Parameters.Add("@code", SqlDbType.VarChar, 50).Value = code; 
            cmd.Parameters.Add("@Qty", SqlDbType.Decimal).Value = Qty;
            CLSset.cn.Open();

            dt.Load(cmd.ExecuteReader());

            CLSset.cn.Close();
            return dt;
        }
    }
}
