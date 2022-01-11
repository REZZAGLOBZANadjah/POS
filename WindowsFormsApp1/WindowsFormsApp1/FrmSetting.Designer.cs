
namespace POS
{
    partial class FrmSetting
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
            this.chFastSales = new System.Windows.Forms.CheckBox();
            this.chRepeat = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.saveSettings = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chFastSales
            // 
            this.chFastSales.AutoSize = true;
            this.chFastSales.Location = new System.Drawing.Point(6, 69);
            this.chFastSales.Name = "chFastSales";
            this.chFastSales.Size = new System.Drawing.Size(137, 27);
            this.chFastSales.TabIndex = 0;
            this.chFastSales.Text = "البيع السريع";
            this.chFastSales.UseVisualStyleBackColor = true;
            // 
            // chRepeat
            // 
            this.chRepeat.AutoSize = true;
            this.chRepeat.Location = new System.Drawing.Point(6, 36);
            this.chRepeat.Name = "chRepeat";
            this.chRepeat.Size = new System.Drawing.Size(154, 27);
            this.chRepeat.TabIndex = 1;
            this.chRepeat.Text = "تكرار المنتجات";
            this.chRepeat.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chFastSales);
            this.groupBox1.Controls.Add(this.chRepeat);
            this.groupBox1.Location = new System.Drawing.Point(17, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(223, 115);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // saveSettings
            // 
            this.saveSettings.Location = new System.Drawing.Point(12, 268);
            this.saveSettings.Name = "saveSettings";
            this.saveSettings.Size = new System.Drawing.Size(223, 37);
            this.saveSettings.TabIndex = 3;
            this.saveSettings.Text = "حفظ الاعدادات";
            this.saveSettings.UseVisualStyleBackColor = true;
            this.saveSettings.Click += new System.EventHandler(this.saveSettings_Click);
            // 
            // FrmSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(260, 351);
            this.Controls.Add(this.saveSettings);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Name = "FrmSetting";
            this.Text = "FrmSetting";
            this.Load += new System.EventHandler(this.FrmSetting_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox chFastSales;
        private System.Windows.Forms.CheckBox chRepeat;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button saveSettings;
    }
}