using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace POS
{
    class ClsPublic
    {
        //--------------------LoadPublic------------------------------------
        public DataTable DTPublic = new DataTable();
        public void LoadPublic(string SPName)//SPTxt stored procedure  name
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = CLSset.cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = SPName;
            CLSset.cn.Open();
            DTPublic.Load(cmd.ExecuteReader());
            CLSset.cn.Close();
        }
        //---------------------MaxIDPublic-----------------------------------

        public int MaxIDPublic(string SPName)
        {
            int maxId;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = CLSset.cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = SPName;
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
        //-------------------------------delete -----------------------------------------
        public void DeletePublic(string NameSP,int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = CLSset.cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = NameSP;
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
            CLSset.cn.Open();
            cmd.ExecuteNonQuery();
            CLSset.cn.Close();

        }
        //-----------------INSERT --------------------

        public  static string testQuery()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = CLSset.cn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT userName FROM tbUsers where id = 1";
            CLSset.cn.Open();
            string name = Convert.ToString(cmd.ExecuteScalar());
            CLSset.cn.Close();            
            return name;

        }

    }
}
