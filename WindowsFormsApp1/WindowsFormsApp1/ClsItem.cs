using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace POS
{
    class ClsItem
    {
        public DataTable dtItem = new DataTable();
        
        // execute stored procedure with no parameter
        public void ExecutPS(string SPName)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = CLSset.cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = SPName;
            CLSset.cn.Open();
            dtItem.Load(cmd.ExecuteReader());
            CLSset.cn.Close();
        }
        
        public void LoadItems()
        {
            ExecutPS("loadItemSP");
            /*
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = CLSset.cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "loadItemSP";
            CLSset.cn.Open();
            dtItem.Load(cmd.ExecuteReader());
            CLSset.cn.Close();
            */

        }

       private int maxId;
        // get max id in table items to insert a new value 
        public int MaxIdItem()
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = CLSset.cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "MaxIDItemSP";
                CLSset.cn.Open();
                maxId = Convert.ToInt32(cmd.ExecuteScalar());

            }
            catch
            {
                maxId = 0;
            }
           
            CLSset.cn.Close();
            return maxId;
        }
        // insert item function 
        public void InsertItem(int id, string name)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = CLSset.cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "InsertItemSP";
            //cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
            cmd.Parameters.Add("@name", SqlDbType.VarChar, 50).Value = name;
            CLSset.cn.Open();
            cmd.ExecuteNonQuery();
            CLSset.cn.Close();

        }
        // Update item function 
        public void UpdateItem(int id, string name)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = CLSset.cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "UpdateItemSP";
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
            cmd.Parameters.Add("@name", SqlDbType.VarChar, 50).Value = name;
            CLSset.cn.Open();
            cmd.ExecuteNonQuery();
            CLSset.cn.Close();

        }
        // delete Items 
        public void DeleteItem(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = CLSset.cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "DeleteItemSP";
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
            CLSset.cn.Open();
            cmd.ExecuteNonQuery();
            CLSset.cn.Close();

        }
    }
    
}
