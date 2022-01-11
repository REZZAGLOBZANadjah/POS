using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace POS
{
    class ClsOrders : ClsPublic
    {
        public DataTable dtOrd = new DataTable();
        SqlCommand cmd;
        public void InsertOrderSale(int id, DateTime orderDate, double valueAdd, double total, double pay,
                                    double stay, string sales, string customers, int typeCustomer)
        {
            cmd = new SqlCommand();
            cmd.Connection = CLSset.cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "InsertOrderSaleSP";
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
            cmd.Parameters.Add("@orderDate", SqlDbType.DateTime).Value = orderDate;
            cmd.Parameters.Add("@valueAdd", SqlDbType.Decimal).Value = valueAdd;
            cmd.Parameters.Add("@total", SqlDbType.Decimal).Value = total;
            cmd.Parameters.Add("@pay", SqlDbType.Decimal).Value = pay;
            cmd.Parameters.Add("@stay", SqlDbType.Decimal).Value = stay;
            cmd.Parameters.Add("@sales", SqlDbType.VarChar, 50).Value = sales;
            cmd.Parameters.Add("@customers", SqlDbType.VarChar, 50).Value = customers;
            cmd.Parameters.Add("@typeCustomer", SqlDbType.Int).Value = typeCustomer;
            CLSset.cn.Open();
            cmd.ExecuteNonQuery();
            CLSset.cn.Close();
        }
        public void InsertOrdersSalesDetails(int idOrder, string code, string productName, double price, double qty, double descount, double total)
        {
            cmd = new SqlCommand();
            cmd.Connection = CLSset.cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "InsertOrdersSalesDetailsSP";
            cmd.Parameters.Add("@idOrder", SqlDbType.Int).Value = idOrder;
            cmd.Parameters.Add("@code", SqlDbType.VarChar, 50).Value = code;
            cmd.Parameters.Add("@productName", SqlDbType.VarChar, 50).Value = productName;
            cmd.Parameters.Add("@price", SqlDbType.Decimal).Value = price;
            cmd.Parameters.Add("@qty", SqlDbType.Decimal).Value = qty;
            cmd.Parameters.Add("@descount", SqlDbType.Decimal).Value = descount;
            cmd.Parameters.Add("@total", SqlDbType.Decimal).Value = total;
            CLSset.cn.Open();
            cmd.ExecuteNonQuery();
            CLSset.cn.Close();
        }
        //load type customers from database 
        public void LoadTypeCustomer()
        {
            cmd = new SqlCommand();
            cmd.Connection = CLSset.cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "LoadTypeCustomerSP";
            CLSset.cn.Open();
            dtOrd.Load(cmd.ExecuteReader());
            CLSset.cn.Close();
        }
        public void LoadVOrderSaleByTypeCus(string typeCustomer)
        {
            cmd = new SqlCommand();
            cmd.Connection = CLSset.cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "LoadVOrderSaleByTypeCusSP";
            cmd.Parameters.Add("@typeCustomer", SqlDbType.VarChar, 50).Value = typeCustomer;
            CLSset.cn.Open();
            dtOrd.Load(cmd.ExecuteReader());
            CLSset.cn.Close();
        }
        public void LoadOrderDetails(int idOrder)
        {
            cmd = new SqlCommand();
            cmd.Connection = CLSset.cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "LoadOrderDetails";
            cmd.Parameters.Add("@idOrder", SqlDbType.Int).Value = idOrder;
            CLSset.cn.Open();
            dtOrd.Load(cmd.ExecuteReader());
            CLSset.cn.Close();
        }

        //print orders information 
        public void OrderInfo()
        {
            cmd = new SqlCommand();
            cmd.Connection = CLSset.cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "OrderInfoSP";
            CLSset.cn.Open();
            dtOrd.Load(cmd.ExecuteReader());
            CLSset.cn.Close();
        }
        //get view orders all
        public void GetVOrderAll(int id)
        {
            cmd = new SqlCommand();
            cmd.Connection = CLSset.cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetVOrderAllSP";
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
            CLSset.cn.Open();
            dtOrd.Load(cmd.ExecuteReader());
            CLSset.cn.Close();

        }
        //update order sales
        public void UpdteOrderSales(int idOrder, DateTime orderDate, double valueAdd, double total, double pay, double stay, string sales, string customers, int typeCustomer)
        {
            cmd = new SqlCommand();
            cmd.Connection = CLSset.cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "UpdteOrderSalesSP";

            cmd.Parameters.Add("@id", SqlDbType.Int).Value = idOrder;
            cmd.Parameters.Add("@orderDate", SqlDbType.DateTime).Value = orderDate;
            cmd.Parameters.Add("@valueAdd", SqlDbType.Decimal).Value = valueAdd;
            cmd.Parameters.Add("@total", SqlDbType.Decimal).Value = total;
            cmd.Parameters.Add("@pay", SqlDbType.Decimal).Value = pay;
            cmd.Parameters.Add("@stay", SqlDbType.Decimal).Value = stay;
            cmd.Parameters.Add("@sales", SqlDbType.VarChar, 50).Value = sales;
            cmd.Parameters.Add("@customers", SqlDbType.VarChar, 50).Value = customers;
            cmd.Parameters.Add("@typeCustomer", SqlDbType.Int).Value = typeCustomer;

            CLSset.cn.Open();
            cmd.ExecuteNonQuery();
            CLSset.cn.Close();
        }
        // delete order sales
        public void DeleteOrederDet(int id)
        {
            cmd = new SqlCommand();
            cmd.Connection = CLSset.cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "DeleteOrederDetSP";
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
            CLSset.cn.Open();
            dtOrd.Load(cmd.ExecuteReader());
            CLSset.cn.Close();

        }
        //get customer 
        public String GetCustomerOrder(int id)
        {
            
            cmd = new SqlCommand();
            cmd.Connection = CLSset.cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetCustomerOrder";
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
            CLSset.cn.Open();
            string phone=cmd.ExecuteScalar().ToString();
            CLSset.cn.Close();
            return phone;
        }
        //DELETE ORDER BY ID
        public void DeleteOreder(int id)
        {
            cmd = new SqlCommand();
            cmd.Connection = CLSset.cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "DeleteOrderSP";
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
            CLSset.cn.Open();
            dtOrd.Load(cmd.ExecuteReader());
            CLSset.cn.Close();

        }
        //Delete ALL Oreders
        public void DeleteALLOreders()
        {
            cmd = new SqlCommand();
            cmd.Connection = CLSset.cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "DeleteALLOrdersSP";
            CLSset.cn.Open();
            dtOrd.Load(cmd.ExecuteReader());
            CLSset.cn.Close();

        }
    }
}