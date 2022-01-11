using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS
{
    public partial class FrmSetting : Form
    {
        public FrmSetting()
        {
            InitializeComponent();
        }

        private void FrmSetting_Load(object sender, EventArgs e)
        {
            CLSset set = new CLSset();
            set.LoadSetting();
            chRepeat.Checked = set.RepeatProduct;
            chFastSales.Checked = set.FastSales;
        }

        private void saveSettings_Click(object sender, EventArgs e)
        {
            CLSset set = new CLSset();
            set.UpdateSetting(chRepeat.Checked,1);

            set.UpdateSetting(chFastSales.Checked,2);
            
        }
    }
}
