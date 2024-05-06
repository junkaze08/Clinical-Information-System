namespace EmployeeDatabase
{
    partial class ClinicInformationSystem
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
            this.label5 = new System.Windows.Forms.Label();
            this.empBtn = new System.Windows.Forms.Button();
            this.immBtn = new System.Windows.Forms.Button();
            this.consulBtn = new System.Windows.Forms.Button();
            this.patregBtn = new System.Windows.Forms.Button();
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Britannic Bold", 24.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(394, 37);
            this.label5.TabIndex = 17;
            this.label5.Text = "Clinic Information System";
            // 
            // empBtn
            // 
            this.empBtn.Font = new System.Drawing.Font("Bell MT", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.empBtn.Location = new System.Drawing.Point(18, 19);
            this.empBtn.Name = "empBtn";
            this.empBtn.Size = new System.Drawing.Size(284, 70);
            this.empBtn.TabIndex = 18;
            this.empBtn.Text = "Employee Registration";
            this.empBtn.UseVisualStyleBackColor = true;
            this.empBtn.Click += new System.EventHandler(this.empBtn_Click);
            // 
            // immBtn
            // 
            this.immBtn.Font = new System.Drawing.Font("Bell MT", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.immBtn.Location = new System.Drawing.Point(18, 104);
            this.immBtn.Name = "immBtn";
            this.immBtn.Size = new System.Drawing.Size(284, 70);
            this.immBtn.TabIndex = 19;
            this.immBtn.Text = "Immunization Entry";
            this.immBtn.UseVisualStyleBackColor = true;
            this.immBtn.Click += new System.EventHandler(this.immBtn_Click);
            // 
            // consulBtn
            // 
            this.consulBtn.Font = new System.Drawing.Font("Bell MT", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.consulBtn.Location = new System.Drawing.Point(18, 189);
            this.consulBtn.Name = "consulBtn";
            this.consulBtn.Size = new System.Drawing.Size(284, 70);
            this.consulBtn.TabIndex = 20;
            this.consulBtn.Text = "Consultation Entry";
            this.consulBtn.UseVisualStyleBackColor = true;
            this.consulBtn.Click += new System.EventHandler(this.consulBtn_Click);
            // 
            // patregBtn
            // 
            this.patregBtn.Font = new System.Drawing.Font("Bell MT", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.patregBtn.Location = new System.Drawing.Point(18, 274);
            this.patregBtn.Name = "patregBtn";
            this.patregBtn.Size = new System.Drawing.Size(284, 70);
            this.patregBtn.TabIndex = 21;
            this.patregBtn.Text = "Patient Registration";
            this.patregBtn.UseVisualStyleBackColor = true;
            this.patregBtn.Click += new System.EventHandler(this.patregBtn_Click);
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.empBtn);
            this.groupBox.Controls.Add(this.patregBtn);
            this.groupBox.Controls.Add(this.immBtn);
            this.groupBox.Controls.Add(this.consulBtn);
            this.groupBox.Location = new System.Drawing.Point(52, 68);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(317, 354);
            this.groupBox.TabIndex = 22;
            this.groupBox.TabStop = false;
            this.groupBox.Text = "Menu";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(270, 438);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 13);
            this.label1.TabIndex = 22;
            this.label1.Text = "Junester Ursora II BSIT 2-A";
            // 
            // ClinicInformationSystem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(418, 458);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox);
            this.Controls.Add(this.label5);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "ClinicInformationSystem";
            this.Text = "Clinic Information System";
            this.Load += new System.EventHandler(this.ClinicInformationSystem_Load);
            this.groupBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button empBtn;
        private System.Windows.Forms.Button immBtn;
        private System.Windows.Forms.Button consulBtn;
        private System.Windows.Forms.Button patregBtn;
        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.Label label1;
    }
}