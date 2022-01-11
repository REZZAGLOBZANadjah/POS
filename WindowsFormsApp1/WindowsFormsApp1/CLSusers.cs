using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace POS
{
    public class CLSusers
    {
        public  static string fullName;
        public static Boolean admin;

        public DataTable dtUsers = new DataTable();

        public void Login(string user,string pass)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = CLSset.cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "loginSP";
            cmd.Parameters.Add("@user", SqlDbType.VarChar, 50).Value = user;
            cmd.Parameters.Add("@pass", SqlDbType.VarChar, 50).Value = pass;
            CLSset.cn.Open();
            dtUsers.Load(cmd.ExecuteReader());
            if (dtUsers.Rows.Count>0)
            {
                MessageBox.Show("Hellow "+dtUsers.Rows[0][2]);
                var frm = Application.OpenForms["frmMain"] as frmMain;
                //frmMain frm = new frmMain();
                fullName = dtUsers.Rows[0][2].ToString();
                admin =Convert.ToBoolean( dtUsers.Rows[0][3]);
                frm.btnLogout.Enabled = true;
                frm.store.Enabled = true;
                frm.sales.Enabled = true;
                frm.buy.Enabled = true;
                frm.ressource.Enabled = true;
                frm.ressource.Enabled = true;
                frm.customers.Enabled = true;
                frm.users.Enabled = true;
                frm.btnLogin.Enabled = false;
            }
            else
            {
                MessageBox.Show("Login Erreur");
            }
            CLSset.cn.Close();

        }
    }
}
/*
 
 
 
 */