
namespace POS
{
    partial class UCCustomersAdd
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.label21 = new System.Windows.Forms.Label();
            this.txtAdressUC = new System.Windows.Forms.TextBox();
            this.txtNameUC = new System.Windows.Forms.TextBox();
            this.txtPhoneUC = new System.Windows.Forms.TextBox();
            this.button8 = new System.Windows.Forms.Button();
            this.btnSaveExite = new System.Windows.Forms.Button();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.txtEmailUC = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label21
            // 
            this.label21.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label21.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(265, 109);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(130, 27);
            this.label21.TabIndex = 33;
            this.label21.Text = "البريد الالكتروني";
            // 
            // txtAdressUC
            // 
            this.txtAdressUC.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAdressUC.Location = new System.Drawing.Point(6, 73);
            this.txtAdressUC.Name = "txtAdressUC";
            this.txtAdressUC.Size = new System.Drawing.Size(252, 30);
            this.txtAdressUC.TabIndex = 72;
            this.txtAdressUC.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAdressUC_KeyDown);
            // 
            // txtNameUC
            // 
            this.txtNameUC.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNameUC.Location = new System.Drawing.Point(6, 39);
            this.txtNameUC.Name = "txtNameUC";
            this.txtNameUC.Size = new System.Drawing.Size(252, 30);
            this.txtNameUC.TabIndex = 71;
            this.txtNameUC.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNameUC_KeyDown);
            // 
            // txtPhoneUC
            // 
            this.txtPhoneUC.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPhoneUC.Location = new System.Drawing.Point(6, 5);
            this.txtPhoneUC.Name = "txtPhoneUC";
            this.txtPhoneUC.Size = new System.Drawing.Size(252, 30);
            this.txtPhoneUC.TabIndex = 65;
            // 
            // button8
            // 
            this.button8.BackColor = System.Drawing.Color.Red;
            this.button8.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button8.Location = new System.Drawing.Point(5, 141);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(102, 36);
            this.button8.TabIndex = 70;
            this.button8.Text = "خروج";
            this.button8.UseVisualStyleBackColor = false;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // btnSaveExite
            // 
            this.btnSaveExite.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnSaveExite.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveExite.Location = new System.Drawing.Point(134, 141);
            this.btnSaveExite.Name = "btnSaveExite";
            this.btnSaveExite.Size = new System.Drawing.Size(124, 36);
            this.btnSaveExite.TabIndex = 69;
            this.btnSaveExite.Text = "حفظ و خروج";
            this.btnSaveExite.UseVisualStyleBackColor = false;
            this.btnSaveExite.Click += new System.EventHandler(this.button7_Click);
            // 
            // label18
            // 
            this.label18.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label18.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(264, 75);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(130, 27);
            this.label18.TabIndex = 68;
            this.label18.Text = "العنوان :";
            // 
            // label19
            // 
            this.label19.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label19.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(265, 9);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(130, 30);
            this.label19.TabIndex = 67;
            this.label19.Text = "الهاتف :";
            // 
            // label20
            // 
            this.label20.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label20.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(265, 41);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(130, 27);
            this.label20.TabIndex = 66;
            this.label20.Text = "الاسم :";
            // 
            // txtEmailUC
            // 
            this.txtEmailUC.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmailUC.Location = new System.Drawing.Point(6, 107);
            this.txtEmailUC.Name = "txtEmailUC";
            this.txtEmailUC.Size = new System.Drawing.Size(253, 30);
            this.txtEmailUC.TabIndex = 73;
            this.txtEmailUC.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtEmailUC_KeyDown);
            // 
            // UCCustomersAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtEmailUC);
            this.Controls.Add(this.txtAdressUC);
            this.Controls.Add(this.txtNameUC);
            this.Controls.Add(this.txtPhoneUC);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.btnSaveExite);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label21);
            this.Font = new System.Drawing.Font("Tahoma", 12F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "UCCustomersAdd";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(403, 177);
            this.Load += new System.EventHandler(this.UCCustomersAdd_Load);
            this.VisibleChanged += new System.EventHandler(this.UCCustomersAdd_VisibleChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button btnSaveExite;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        public System.Windows.Forms.TextBox txtPhoneUC;
        public System.Windows.Forms.TextBox txtAdressUC;
        public System.Windows.Forms.TextBox txtNameUC;
        public System.Windows.Forms.TextBox txtEmailUC;
    }
}
