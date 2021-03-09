namespace LinqTOSql
{
    partial class Form1
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
            this.btinsert = new System.Windows.Forms.Button();
            this.btupdate = new System.Windows.Forms.Button();
            this.btDelete = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtEmpNo = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtBasic = new System.Windows.Forms.TextBox();
            this.txtDeptNo = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btshow = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btinsert
            // 
            this.btinsert.Location = new System.Drawing.Point(53, 106);
            this.btinsert.Name = "btinsert";
            this.btinsert.Size = new System.Drawing.Size(75, 23);
            this.btinsert.TabIndex = 0;
            this.btinsert.Text = "insert";
            this.btinsert.UseVisualStyleBackColor = true;
            this.btinsert.Click += new System.EventHandler(this.insert_Click);
            // 
            // btupdate
            // 
            this.btupdate.Location = new System.Drawing.Point(154, 106);
            this.btupdate.Name = "btupdate";
            this.btupdate.Size = new System.Drawing.Size(75, 23);
            this.btupdate.TabIndex = 1;
            this.btupdate.Text = "update";
            this.btupdate.UseVisualStyleBackColor = true;
            this.btupdate.Click += new System.EventHandler(this.update_Click);
            // 
            // btDelete
            // 
            this.btDelete.Location = new System.Drawing.Point(249, 106);
            this.btDelete.Name = "btDelete";
            this.btDelete.Size = new System.Drawing.Size(75, 23);
            this.btDelete.TabIndex = 2;
            this.btDelete.Text = "Delete";
            this.btDelete.UseVisualStyleBackColor = true;
            this.btDelete.Click += new System.EventHandler(this.btDelete_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "EmpNo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(140, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(277, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Basic";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(402, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "DeptNo";
            // 
            // txtEmpNo
            // 
            this.txtEmpNo.Location = new System.Drawing.Point(53, 37);
            this.txtEmpNo.Name = "txtEmpNo";
            this.txtEmpNo.Size = new System.Drawing.Size(81, 20);
            this.txtEmpNo.TabIndex = 8;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(181, 37);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(81, 20);
            this.txtName.TabIndex = 9;
            // 
            // txtBasic
            // 
            this.txtBasic.Location = new System.Drawing.Point(318, 36);
            this.txtBasic.Name = "txtBasic";
            this.txtBasic.Size = new System.Drawing.Size(81, 20);
            this.txtBasic.TabIndex = 10;
            // 
            // txtDeptNo
            // 
            this.txtDeptNo.Location = new System.Drawing.Point(443, 40);
            this.txtDeptNo.Name = "txtDeptNo";
            this.txtDeptNo.Size = new System.Drawing.Size(81, 20);
            this.txtDeptNo.TabIndex = 11;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(53, 193);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(471, 259);
            this.dataGridView1.TabIndex = 12;
            // 
            // btshow
            // 
            this.btshow.Location = new System.Drawing.Point(368, 105);
            this.btshow.Name = "btshow";
            this.btshow.Size = new System.Drawing.Size(75, 23);
            this.btshow.TabIndex = 13;
            this.btshow.Text = "show";
            this.btshow.UseVisualStyleBackColor = true;
            this.btshow.Click += new System.EventHandler(this.btshow_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(536, 464);
            this.Controls.Add(this.btshow);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.txtDeptNo);
            this.Controls.Add(this.txtBasic);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtEmpNo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btDelete);
            this.Controls.Add(this.btupdate);
            this.Controls.Add(this.btinsert);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btinsert;
        private System.Windows.Forms.Button btupdate;
        private System.Windows.Forms.Button btDelete;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtEmpNo;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtBasic;
        private System.Windows.Forms.TextBox txtDeptNo;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btshow;
    }
}

