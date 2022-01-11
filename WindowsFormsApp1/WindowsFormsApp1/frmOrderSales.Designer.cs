
namespace POS
{
    partial class frmOrderSales
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvOrdSales = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.printFact = new System.Windows.Forms.ToolStripMenuItem();
            this.print = new System.Windows.Forms.ToolStripMenuItem();
            this.printAll = new System.Windows.Forms.ToolStripMenuItem();
            this.detailsFact = new System.Windows.Forms.ToolStripMenuItem();
            this.det = new System.Windows.Forms.ToolStripMenuItem();
            this.delFact = new System.Windows.Forms.ToolStripMenuItem();
            this.suppFact = new System.Windows.Forms.ToolStripMenuItem();
            this.suppAll = new System.Windows.Forms.ToolStripMenuItem();
            this.modifierFact = new System.Windows.Forms.ToolStripMenuItem();
            this.modFact = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chShowOrd = new System.Windows.Forms.CheckBox();
            this.cbTypeCus = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrdSales)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvOrdSales
            // 
            this.dgvOrdSales.AllowUserToAddRows = false;
            this.dgvOrdSales.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvOrdSales.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvOrdSales.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvOrdSales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrdSales.Location = new System.Drawing.Point(1, 96);
            this.dgvOrdSales.MultiSelect = false;
            this.dgvOrdSales.Name = "dgvOrdSales";
            this.dgvOrdSales.ReadOnly = true;
            this.dgvOrdSales.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvOrdSales.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvOrdSales.RowTemplate.Height = 30;
            this.dgvOrdSales.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOrdSales.Size = new System.Drawing.Size(1359, 584);
            this.dgvOrdSales.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.printFact,
            this.detailsFact,
            this.delFact,
            this.modifierFact});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.menuStrip1.Size = new System.Drawing.Size(1361, 29);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // printFact
            // 
            this.printFact.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.print,
            this.printAll});
            this.printFact.Name = "printFact";
            this.printFact.Size = new System.Drawing.Size(61, 25);
            this.printFact.Text = "طباعة";
            // 
            // print
            // 
            this.print.Name = "print";
            this.print.Size = new System.Drawing.Size(245, 26);
            this.print.Text = "طباعة الفاتورة (CTR + P)";
            this.print.Click += new System.EventHandler(this.print_Click);
            // 
            // printAll
            // 
            this.printAll.Name = "printAll";
            this.printAll.Size = new System.Drawing.Size(245, 26);
            this.printAll.Text = "طباعة كل الفواتير";
            this.printAll.Click += new System.EventHandler(this.printAll_Click);
            // 
            // detailsFact
            // 
            this.detailsFact.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.det});
            this.detailsFact.Name = "detailsFact";
            this.detailsFact.Size = new System.Drawing.Size(71, 25);
            this.detailsFact.Text = "تفاصيل";
            // 
            // det
            // 
            this.det.Name = "det";
            this.det.Size = new System.Drawing.Size(293, 26);
            this.det.Text = "عرض تفاصيل الفاتورة (CTR+ D)";
            this.det.Click += new System.EventHandler(this.det_Click);
            // 
            // delFact
            // 
            this.delFact.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.suppFact,
            this.suppAll});
            this.delFact.Enabled = false;
            this.delFact.Name = "delFact";
            this.delFact.Size = new System.Drawing.Size(55, 25);
            this.delFact.Text = "حذف";
            // 
            // suppFact
            // 
            this.suppFact.Enabled = false;
            this.suppFact.Name = "suppFact";
            this.suppFact.Size = new System.Drawing.Size(220, 26);
            this.suppFact.Text = "حذف الفاتورة المحددة";
            this.suppFact.Click += new System.EventHandler(this.suppFact_Click);
            // 
            // suppAll
            // 
            this.suppAll.Enabled = false;
            this.suppAll.Name = "suppAll";
            this.suppAll.Size = new System.Drawing.Size(220, 26);
            this.suppAll.Text = "حذف الكل";
            this.suppAll.Click += new System.EventHandler(this.suppAll_Click);
            // 
            // modifierFact
            // 
            this.modifierFact.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.modFact});
            this.modifierFact.Enabled = false;
            this.modifierFact.Name = "modifierFact";
            this.modifierFact.Size = new System.Drawing.Size(60, 25);
            this.modifierFact.Text = "تعديل";
            // 
            // modFact
            // 
            this.modFact.Enabled = false;
            this.modFact.Name = "modFact";
            this.modFact.Size = new System.Drawing.Size(180, 26);
            this.modFact.Text = "تعديل فاتورة";
            this.modFact.Click += new System.EventHandler(this.modFact_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chShowOrd);
            this.groupBox1.Controls.Add(this.cbTypeCus);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 14F);
            this.groupBox1.Location = new System.Drawing.Point(2, 34);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox1.Size = new System.Drawing.Size(1359, 56);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "طلبات البيع";
            // 
            // chShowOrd
            // 
            this.chShowOrd.AutoSize = true;
            this.chShowOrd.Checked = true;
            this.chShowOrd.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chShowOrd.Location = new System.Drawing.Point(1235, 25);
            this.chShowOrd.Name = "chShowOrd";
            this.chShowOrd.Size = new System.Drawing.Size(110, 27);
            this.chShowOrd.TabIndex = 2;
            this.chShowOrd.Text = "عرض الكل";
            this.chShowOrd.UseVisualStyleBackColor = true;
            this.chShowOrd.CheckedChanged += new System.EventHandler(this.chShowOrd_CheckedChanged);
            // 
            // cbTypeCus
            // 
            this.cbTypeCus.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.cbTypeCus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTypeCus.Enabled = false;
            this.cbTypeCus.FormattingEnabled = true;
            this.cbTypeCus.Location = new System.Drawing.Point(965, 23);
            this.cbTypeCus.Name = "cbTypeCus";
            this.cbTypeCus.Size = new System.Drawing.Size(264, 31);
            this.cbTypeCus.TabIndex = 1;
            this.cbTypeCus.SelectedIndexChanged += new System.EventHandler(this.cbTypeCus_SelectedIndexChanged);
            // 
            // frmOrderSales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1361, 681);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvOrdSales);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmOrderSales";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmOrderSales";
            this.Load += new System.EventHandler(this.frmOrderSales_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrdSales)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvOrdSales;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem printFact;
        private System.Windows.Forms.ToolStripMenuItem print;
        private System.Windows.Forms.ToolStripMenuItem printAll;
        private System.Windows.Forms.ToolStripMenuItem detailsFact;
        private System.Windows.Forms.ToolStripMenuItem det;
        private System.Windows.Forms.ToolStripMenuItem delFact;
        private System.Windows.Forms.ToolStripMenuItem suppFact;
        private System.Windows.Forms.ToolStripMenuItem modifierFact;
        private System.Windows.Forms.ToolStripMenuItem suppAll;
        private System.Windows.Forms.ToolStripMenuItem modFact;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chShowOrd;
        private System.Windows.Forms.ComboBox cbTypeCus;
    }
}