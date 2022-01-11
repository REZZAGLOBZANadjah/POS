using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace POS

{
    class ClsCustomers :ClsPublic
    {
        public DataTable dtcustomers = new DataTable();
        public SqlDataReader dRCustomer;
        public string phone { get; set; }
        public string name { get; set; }
        public string adress { get; set; }
        public string email { get; set; }
        public void InsertCustomers(string phone, string name,string adress,string email)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = CLSset.cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "insertCustomersSP";
            cmd.Parameters.Add("@phone", SqlDbType.VarChar,15).Value = phone;
            cmd.Parameters.Add("@name", SqlDbType.VarChar, 50).Value = name;
            cmd.Parameters.Add("@adress", SqlDbType.VarChar,50).Value = adress;
            cmd.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = email;
            CLSset.cn.Open();
            cmd.ExecuteNonQuery();
            CLSset.cn.Close();

        }
        public void SearchCustomers(string txt)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = CLSset.cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SearchCustomerSP";
            cmd.Parameters.Add("@txt", SqlDbType.VarChar, 50).Value = txt;
            CLSset.cn.Open();
            dtcustomers.Load(cmd.ExecuteReader());
            CLSset.cn.Close();
        }
        public void UpdateCustomer(string phone,string name,string adress,string email)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = CLSset.cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "UpdateCustomerSP";
           // cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
            cmd.Parameters.Add("@phone", SqlDbType.VarChar, 15).Value = phone;
            cmd.Parameters.Add("@name", SqlDbType.VarChar, 50).Value = name;
            cmd.Parameters.Add("@adress", SqlDbType.VarChar, 50).Value = adress;
            cmd.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = email;
            CLSset.cn.Open();
            cmd.ExecuteNonQuery();
            CLSset.cn.Close();

        }
        
        public void DeleteCustomer(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = CLSset.cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "DeleteCustomerSP";
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
            CLSset.cn.Open();
            cmd.ExecuteNonQuery();
            CLSset.cn.Close();

        }
        public void DeleteAllCustomer()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = CLSset.cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "DeleteAllCustomerSP";
            CLSset.cn.Open();
            cmd.ExecuteNonQuery();
            CLSset.cn.Close();

        }
        public void RES()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = CLSset.cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "RES";
            CLSset.cn.Open();
            cmd.ExecuteNonQuery();
            CLSset.cn.Close();

        }

        public DataTable CheckPhone(string phone)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = CLSset.cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "CheckPhoneSP";
            cmd.Parameters.Add("@phone", SqlDbType.VarChar,15).Value = phone;
            CLSset.cn.Open();
            dtcustomers.Load(cmd.ExecuteReader());            
            CLSset.cn.Close();
            return dtcustomers;
        }
        public void SelectCustomersByPhone(string phone)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = CLSset.cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SelectCustomersByPhoneSP";
            cmd.Parameters.Add("@phone", SqlDbType.VarChar, 15).Value = phone;
            CLSset.cn.Open();
            dRCustomer = cmd.ExecuteReader();
            dRCustomer.Read();
            if (dRCustomer.HasRows)
            {
                name = dRCustomer[2].ToString();
                adress = dRCustomer[3].ToString();
                email = dRCustomer[4].ToString();
            }
            else
            {
                name ="";
                adress ="";
                email = "";
            }
            dRCustomer.Close();
            //dtcustomers.Load(cmd.ExecuteReader());
            CLSset.cn.Close();
        }
    }
}
