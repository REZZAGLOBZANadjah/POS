
namespace POS
{
    partial class frmOrdDetails
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbNo = new DevExpress.XtraEditors.LabelControl();
            this.dgvOrdDetails = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrdDetails)).BeginInit();
            this.SuspendLayout();
            // 
            // lbNo
            // 
            this.lbNo.Appearance.Font = new System.Drawing.Font("Tahoma", 14F);
            this.lbNo.Appearance.Options.UseFont = true;
            this.lbNo.Location = new System.Drawing.Point(375, 13);
            this.lbNo.Margin = new System.Windows.Forms.Padding(4);
            this.lbNo.Name = "lbNo";
            this.lbNo.Size = new System.Drawing.Size(90, 23);
            this.lbNo.TabIndex = 0;
            this.lbNo.Text = "فاتورة رقم :";
            // 
            // dgvOrdDetails
            // 
            this.dgvOrdDetails.AllowUserToAddRows = false;
            this.dgvOrdDetails.AllowUserToDeleteRows = false;
            this.dgvOrdDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrdDetails.Location = new System.Drawing.Point(3, 44);
            this.dgvOrdDetails.Margin = new System.Windows.Forms.Padding(4);
            this.dgvOrdDetails.Name = "dgvOrdDetails";
            this.dgvOrdDetails.ReadOnly = true;
            this.dgvOrdDetails.Size = new System.Drawing.Size(781, 307);
            this.dgvOrdDetails.TabIndex = 1;
            // 
            // frmOrdDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(786, 353);
            this.Controls.Add(this.dgvOrdDetails);
            this.Controls.Add(this.lbNo);
            this.Font = new System.Drawing.Font("Tahoma", 12F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmOrdDetails";
            this.Text = "frmOrdDetails";
            this.Load += new System.EventHandler(this.frmOrdDetails_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrdDetails)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public DevExpress.XtraEditors.LabelControl lbNo;
        public System.Windows.Forms.DataGridView dgvOrdDetails;
    }
}