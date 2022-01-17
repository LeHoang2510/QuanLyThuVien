namespace QuanLyThuVien
{
    partial class DoiMatKhau
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DoiMatKhau));
            this.label1 = new System.Windows.Forms.Label();
            this.txtXNMKMOI = new System.Windows.Forms.TextBox();
            this.txtMKMOI = new System.Windows.Forms.TextBox();
            this.txtMKCU = new System.Windows.Forms.TextBox();
            this.txtTK = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ckbMKMOI = new System.Windows.Forms.CheckBox();
            this.ckbXNMKMOI = new System.Windows.Forms.CheckBox();
            this.ckbMKCU = new System.Windows.Forms.CheckBox();
            this.btnDMK = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.errTK = new System.Windows.Forms.ErrorProvider(this.components);
            this.errMKCU = new System.Windows.Forms.ErrorProvider(this.components);
            this.errMKMOI = new System.Windows.Forms.ErrorProvider(this.components);
            this.errXNMKMOI = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errTK)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errMKCU)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errMKMOI)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errXNMKMOI)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(811, 74);
            this.label1.TabIndex = 10;
            this.label1.Text = "Đổi mật khẩu";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtXNMKMOI
            // 
            this.txtXNMKMOI.Location = new System.Drawing.Point(314, 346);
            this.txtXNMKMOI.Name = "txtXNMKMOI";
            this.txtXNMKMOI.Size = new System.Drawing.Size(234, 27);
            this.txtXNMKMOI.TabIndex = 6;
            this.txtXNMKMOI.UseSystemPasswordChar = true;
            // 
            // txtMKMOI
            // 
            this.txtMKMOI.Location = new System.Drawing.Point(314, 273);
            this.txtMKMOI.Name = "txtMKMOI";
            this.txtMKMOI.Size = new System.Drawing.Size(234, 27);
            this.txtMKMOI.TabIndex = 4;
            this.txtMKMOI.UseSystemPasswordChar = true;
            // 
            // txtMKCU
            // 
            this.txtMKCU.Location = new System.Drawing.Point(314, 202);
            this.txtMKCU.Name = "txtMKCU";
            this.txtMKCU.Size = new System.Drawing.Size(234, 27);
            this.txtMKCU.TabIndex = 2;
            this.txtMKCU.UseSystemPasswordChar = true;
            // 
            // txtTK
            // 
            this.txtTK.Location = new System.Drawing.Point(314, 133);
            this.txtTK.Name = "txtTK";
            this.txtTK.Size = new System.Drawing.Size(234, 27);
            this.txtTK.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(116, 349);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(183, 19);
            this.label5.TabIndex = 18;
            this.label5.Text = "Xác nhận mật khẩu mới";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(116, 276);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 19);
            this.label4.TabIndex = 17;
            this.label4.Text = "Mật khẩu mới";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(116, 205);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 19);
            this.label3.TabIndex = 16;
            this.label3.Text = "Mật khẩu cũ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(116, 136);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 19);
            this.label2.TabIndex = 15;
            this.label2.Text = "Tên tài khoản";
            // 
            // ckbMKMOI
            // 
            this.ckbMKMOI.AutoSize = true;
            this.ckbMKMOI.Location = new System.Drawing.Point(584, 275);
            this.ckbMKMOI.Name = "ckbMKMOI";
            this.ckbMKMOI.Size = new System.Drawing.Size(135, 23);
            this.ckbMKMOI.TabIndex = 5;
            this.ckbMKMOI.Text = "Hiện mật khẩu";
            this.ckbMKMOI.UseVisualStyleBackColor = true;
            this.ckbMKMOI.CheckedChanged += new System.EventHandler(this.ckbMKMOI_CheckedChanged);
            // 
            // ckbXNMKMOI
            // 
            this.ckbXNMKMOI.AutoSize = true;
            this.ckbXNMKMOI.Location = new System.Drawing.Point(584, 348);
            this.ckbXNMKMOI.Name = "ckbXNMKMOI";
            this.ckbXNMKMOI.Size = new System.Drawing.Size(135, 23);
            this.ckbXNMKMOI.TabIndex = 7;
            this.ckbXNMKMOI.Text = "Hiện mật khẩu";
            this.ckbXNMKMOI.UseVisualStyleBackColor = true;
            this.ckbXNMKMOI.CheckedChanged += new System.EventHandler(this.ckbXNMKMOI_CheckedChanged);
            // 
            // ckbMKCU
            // 
            this.ckbMKCU.AutoSize = true;
            this.ckbMKCU.Location = new System.Drawing.Point(584, 204);
            this.ckbMKCU.Name = "ckbMKCU";
            this.ckbMKCU.Size = new System.Drawing.Size(135, 23);
            this.ckbMKCU.TabIndex = 3;
            this.ckbMKCU.Text = "Hiện mật khẩu";
            this.ckbMKCU.UseVisualStyleBackColor = true;
            this.ckbMKCU.CheckedChanged += new System.EventHandler(this.ckbMKCU_CheckedChanged);
            // 
            // btnDMK
            // 
            this.btnDMK.Location = new System.Drawing.Point(314, 430);
            this.btnDMK.Name = "btnDMK";
            this.btnDMK.Size = new System.Drawing.Size(163, 39);
            this.btnDMK.TabIndex = 8;
            this.btnDMK.Text = "Đổi mật khẩu";
            this.btnDMK.UseVisualStyleBackColor = true;
            this.btnDMK.Click += new System.EventHandler(this.btnDMK_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(504, 430);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(163, 39);
            this.btnThoat.TabIndex = 9;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // errTK
            // 
            this.errTK.ContainerControl = this;
            // 
            // errMKCU
            // 
            this.errMKCU.ContainerControl = this;
            // 
            // errMKMOI
            // 
            this.errMKMOI.ContainerControl = this;
            // 
            // errXNMKMOI
            // 
            this.errXNMKMOI.ContainerControl = this;
            // 
            // DoiMatKhau
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(835, 654);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnDMK);
            this.Controls.Add(this.ckbMKCU);
            this.Controls.Add(this.ckbXNMKMOI);
            this.Controls.Add(this.ckbMKMOI);
            this.Controls.Add(this.txtXNMKMOI);
            this.Controls.Add(this.txtMKMOI);
            this.Controls.Add(this.txtMKCU);
            this.Controls.Add(this.txtTK);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "DoiMatKhau";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ĐỔI MẬT KHẨU";
            this.Load += new System.EventHandler(this.DoiMatKhau_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errTK)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errMKCU)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errMKMOI)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errXNMKMOI)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtXNMKMOI;
        private System.Windows.Forms.TextBox txtMKMOI;
        private System.Windows.Forms.TextBox txtMKCU;
        private System.Windows.Forms.TextBox txtTK;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox ckbMKMOI;
        private System.Windows.Forms.CheckBox ckbXNMKMOI;
        private System.Windows.Forms.CheckBox ckbMKCU;
        private System.Windows.Forms.Button btnDMK;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.ErrorProvider errTK;
        private System.Windows.Forms.ErrorProvider errMKCU;
        private System.Windows.Forms.ErrorProvider errMKMOI;
        private System.Windows.Forms.ErrorProvider errXNMKMOI;
    }
}