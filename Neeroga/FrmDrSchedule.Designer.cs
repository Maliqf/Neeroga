namespace Neeroga
{
    partial class FrmDrSchedule
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
            this.TxtUID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.CmbHospital = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.CmbSpecial = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.CmbDay = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.CmbStTime = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.CmbEndTime = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnUpdt = new System.Windows.Forms.Button();
            this.btnInsert = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // TxtUID
            // 
            this.TxtUID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtUID.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtUID.Location = new System.Drawing.Point(102, 12);
            this.TxtUID.Name = "TxtUID";
            this.TxtUID.ReadOnly = true;
            this.TxtUID.Size = new System.Drawing.Size(376, 23);
            this.TxtUID.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "User ID:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(8, 321);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(480, 263);
            this.dataGridView1.TabIndex = 18;
            // 
            // CmbHospital
            // 
            this.CmbHospital.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbHospital.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbHospital.FormattingEnabled = true;
            this.CmbHospital.Location = new System.Drawing.Point(102, 54);
            this.CmbHospital.Name = "CmbHospital";
            this.CmbHospital.Size = new System.Drawing.Size(376, 23);
            this.CmbHospital.TabIndex = 19;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 15);
            this.label3.TabIndex = 20;
            this.label3.Text = "Hospital:";
            // 
            // CmbSpecial
            // 
            this.CmbSpecial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbSpecial.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbSpecial.FormattingEnabled = true;
            this.CmbSpecial.Location = new System.Drawing.Point(102, 98);
            this.CmbSpecial.Name = "CmbSpecial";
            this.CmbSpecial.Size = new System.Drawing.Size(376, 23);
            this.CmbSpecial.TabIndex = 21;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 15);
            this.label2.TabIndex = 22;
            this.label2.Text = "Specialization:";
            // 
            // CmbDay
            // 
            this.CmbDay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbDay.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbDay.FormattingEnabled = true;
            this.CmbDay.Items.AddRange(new object[] {
            "Monday",
            "Tuesday",
            "Wednesday",
            "Thursday",
            "Friday",
            "Saturday",
            "Sunday"});
            this.CmbDay.Location = new System.Drawing.Point(102, 141);
            this.CmbDay.Name = "CmbDay";
            this.CmbDay.Size = new System.Drawing.Size(376, 23);
            this.CmbDay.TabIndex = 23;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 145);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 15);
            this.label4.TabIndex = 24;
            this.label4.Text = "Day:";
            // 
            // CmbStTime
            // 
            this.CmbStTime.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbStTime.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbStTime.FormattingEnabled = true;
            this.CmbStTime.Items.AddRange(new object[] {
            "08:00:00",
            "09:00:00",
            "10:00:00",
            "11:00:00",
            "12:00:00",
            "14:00:00",
            "16:00:00",
            "18:00:00",
            "20:00:00",
            "21:00:00"});
            this.CmbStTime.Location = new System.Drawing.Point(102, 185);
            this.CmbStTime.Name = "CmbStTime";
            this.CmbStTime.Size = new System.Drawing.Size(376, 23);
            this.CmbStTime.TabIndex = 25;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 189);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 15);
            this.label5.TabIndex = 26;
            this.label5.Text = "Start Time:";
            // 
            // CmbEndTime
            // 
            this.CmbEndTime.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbEndTime.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbEndTime.FormattingEnabled = true;
            this.CmbEndTime.Items.AddRange(new object[] {
            "08:00:00",
            "09:00:00",
            "10:00:00",
            "11:00:00",
            "12:00:00",
            "14:00:00",
            "16:00:00",
            "18:00:00",
            "20:00:00",
            "21:00:00"});
            this.CmbEndTime.Location = new System.Drawing.Point(102, 232);
            this.CmbEndTime.Name = "CmbEndTime";
            this.CmbEndTime.Size = new System.Drawing.Size(376, 23);
            this.CmbEndTime.TabIndex = 27;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(12, 236);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 15);
            this.label6.TabIndex = 28;
            this.label6.Text = "End Time:";
            // 
            // btnUpdt
            // 
            this.btnUpdt.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdt.Location = new System.Drawing.Point(330, 274);
            this.btnUpdt.Name = "btnUpdt";
            this.btnUpdt.Size = new System.Drawing.Size(111, 27);
            this.btnUpdt.TabIndex = 30;
            this.btnUpdt.Text = "Update";
            this.btnUpdt.UseVisualStyleBackColor = true;
            // 
            // btnInsert
            // 
            this.btnInsert.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInsert.Location = new System.Drawing.Point(75, 273);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(111, 27);
            this.btnInsert.TabIndex = 29;
            this.btnInsert.Text = "Insert";
            this.btnInsert.UseVisualStyleBackColor = true;
            // 
            // FrmDrSchedule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 590);
            this.Controls.Add(this.btnUpdt);
            this.Controls.Add(this.btnInsert);
            this.Controls.Add(this.CmbEndTime);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.CmbStTime);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.CmbDay);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.CmbSpecial);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CmbHospital);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.TxtUID);
            this.Controls.Add(this.label1);
            this.Name = "FrmDrSchedule";
            this.Text = "Manage Schedule";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TxtUID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox CmbHospital;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox CmbSpecial;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox CmbDay;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox CmbStTime;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox CmbEndTime;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnUpdt;
        private System.Windows.Forms.Button btnInsert;
    }
}