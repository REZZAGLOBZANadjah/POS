using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace POS
{
    class CLSset
    {
     public static    SqlConnection cn = new SqlConnection("Data Source=NAJAH;Initial Catalog=POSFullDB;Integrated Security=True");

        SqlCommand cmd;
        DataTable dtSettings = new DataTable();
        public bool RepeatProduct { get; set; }
        public bool FastSales { get; set; }
        public void LoadSetting()
        {
            cmd = new SqlCommand();
            cmd.Connection = CLSset.cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "LoadSettingSP";
            CLSset.cn.Open();
            dtSettings.Load(cmd.ExecuteReader());
            RepeatProduct = Convert.ToBoolean(dtSettings.Rows[0][2]);
            FastSales = Convert.ToBoolean(dtSettings.Rows[1][2]);
            CLSset.cn.Close();
            
        }
        public void UpdateSetting(bool stateProperty, int id)
        {
            cmd = new SqlCommand();
            cmd.Connection = CLSset.cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "UpdateSettingSP";
            cmd.Parameters.Add("@StateProperty", SqlDbType.Bit).Value=stateProperty;
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
            CLSset.cn.Open();
            cmd.ExecuteNonQuery();
            CLSset.cn.Close();
            //UpdateSettingSP
        }
    }
}
