namespace de_tai_5
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("");
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbLoai_sach = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbSo_luong = new System.Windows.Forms.TextBox();
            this.cbLoai = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbTac_gia = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_Ten_sach = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbMa_sach = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lvDanh_sach_sach = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btCap_Nhat = new System.Windows.Forms.Button();
            this.btQuan_ly_muon_tra = new System.Windows.Forms.Button();
            this.btQuan_ly_doc_gia = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btLuu = new System.Windows.Forms.Button();
            this.btThem = new System.Windows.Forms.Button();
            this.btXoa = new System.Windows.Forms.Button();
            this.btHuy = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbLoai_sach);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(26, 30);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(158, 207);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Loai sach";
            // 
            // lbLoai_sach
            // 
            this.lbLoai_sach.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLoai_sach.FormattingEnabled = true;
            this.lbLoai_sach.ItemHeight = 20;
            this.lbLoai_sach.Items.AddRange(new object[] {
            "Sach giao khoa",
            "Sach bai tap",
            "Sach kinh te",
            "Sach tin hoc",
            "Sach chinh tri"});
            this.lbLoai_sach.Location = new System.Drawing.Point(6, 25);
            this.lbLoai_sach.Name = "lbLoai_sach";
            this.lbLoai_sach.Size = new System.Drawing.Size(134, 164);
            this.lbLoai_sach.TabIndex = 0;
            this.lbLoai_sach.SelectedIndexChanged += new System.EventHandler(this.lbLoai_sach_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.tbSo_luong);
            this.groupBox2.Controls.Add(this.cbLoai);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.tbTac_gia);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.tb_Ten_sach);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.tbMa_sach);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(212, 30);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(363, 253);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thong tin chi tiet";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 215);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 20);
            this.label5.TabIndex = 10;
            this.label5.Text = "So luong";
            this.label5.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // tbSo_luong
            // 
            this.tbSo_luong.Location = new System.Drawing.Point(81, 212);
            this.tbSo_luong.Name = "tbSo_luong";
            this.tbSo_luong.Size = new System.Drawing.Size(159, 26);
            this.tbSo_luong.TabIndex = 9;
            // 
            // cbLoai
            // 
            this.cbLoai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLoai.FormattingEnabled = true;
            this.cbLoai.Items.AddRange(new object[] {
            "SGK",
            "SBT",
            "kinhte",
            "chinhtri",
            "tinhoc"});
            this.cbLoai.Location = new System.Drawing.Point(81, 128);
            this.cbLoai.Name = "cbLoai";
            this.cbLoai.Size = new System.Drawing.Size(159, 28);
            this.cbLoai.TabIndex = 8;
            this.cbLoai.SelectedIndexChanged += new System.EventHandler(this.cbLoai_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 173);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Tac gia";
            // 
            // tbTac_gia
            // 
            this.tbTac_gia.Location = new System.Drawing.Point(81, 170);
            this.tbTac_gia.Name = "tbTac_gia";
            this.tbTac_gia.Size = new System.Drawing.Size(159, 26);
            this.tbTac_gia.TabIndex = 6;
            this.tbTac_gia.TextChanged += new System.EventHandler(this.tbTac_gia_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Loai";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Ten sach";
            // 
            // tb_Ten_sach
            // 
            this.tb_Ten_sach.Location = new System.Drawing.Point(81, 79);
            this.tb_Ten_sach.Name = "tb_Ten_sach";
            this.tb_Ten_sach.Size = new System.Drawing.Size(276, 26);
            this.tb_Ten_sach.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Ma sach";
            // 
            // tbMa_sach
            // 
            this.tbMa_sach.Enabled = false;
            this.tbMa_sach.Location = new System.Drawing.Point(81, 32);
            this.tbMa_sach.Name = "tbMa_sach";
            this.tbMa_sach.Size = new System.Drawing.Size(159, 26);
            this.tbMa_sach.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lvDanh_sach_sach);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(26, 327);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(749, 190);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Danh sach";
            // 
            // lvDanh_sach_sach
            // 
            this.lvDanh_sach_sach.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.lvDanh_sach_sach.FullRowSelect = true;
            this.lvDanh_sach_sach.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.lvDanh_sach_sach.Location = new System.Drawing.Point(6, 36);
            this.lvDanh_sach_sach.MultiSelect = false;
            this.lvDanh_sach_sach.Name = "lvDanh_sach_sach";
            this.lvDanh_sach_sach.Size = new System.Drawing.Size(737, 148);
            this.lvDanh_sach_sach.TabIndex = 0;
            this.lvDanh_sach_sach.UseCompatibleStateImageBehavior = false;
            this.lvDanh_sach_sach.View = System.Windows.Forms.View.Details;
            this.lvDanh_sach_sach.SelectedIndexChanged += new System.EventHandler(this.lvDanh_sach_sach_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Ma sach";
            this.columnHeader1.Width = 80;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Ten sach";
            this.columnHeader2.Width = 180;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Loai";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Tac gia";
            this.columnHeader4.Width = 180;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "So luong";
            this.columnHeader5.Width = 90;
            // 
            // btCap_Nhat
            // 
            this.btCap_Nhat.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCap_Nhat.Location = new System.Drawing.Point(602, 84);
            this.btCap_Nhat.Name = "btCap_Nhat";
            this.btCap_Nhat.Size = new System.Drawing.Size(143, 30);
            this.btCap_Nhat.TabIndex = 3;
            this.btCap_Nhat.Text = "Cap nhat";
            this.btCap_Nhat.UseVisualStyleBackColor = true;
            this.btCap_Nhat.Click += new System.EventHandler(this.btCap_Nhat_Click);
            // 
            // btQuan_ly_muon_tra
            // 
            this.btQuan_ly_muon_tra.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btQuan_ly_muon_tra.Location = new System.Drawing.Point(602, 230);
            this.btQuan_ly_muon_tra.Name = "btQuan_ly_muon_tra";
            this.btQuan_ly_muon_tra.Size = new System.Drawing.Size(143, 30);
            this.btQuan_ly_muon_tra.TabIndex = 8;
            this.btQuan_ly_muon_tra.Text = "Quan ly muon tra";
            this.btQuan_ly_muon_tra.UseVisualStyleBackColor = true;
            this.btQuan_ly_muon_tra.Click += new System.EventHandler(this.btQuan_ly_muon_tra_Click);
            // 
            // btQuan_ly_doc_gia
            // 
            this.btQuan_ly_doc_gia.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btQuan_ly_doc_gia.Location = new System.Drawing.Point(602, 194);
            this.btQuan_ly_doc_gia.Name = "btQuan_ly_doc_gia";
            this.btQuan_ly_doc_gia.Size = new System.Drawing.Size(143, 30);
            this.btQuan_ly_doc_gia.TabIndex = 10;
            this.btQuan_ly_doc_gia.Text = "Quan ly doc gia";
            this.btQuan_ly_doc_gia.UseVisualStyleBackColor = true;
            this.btQuan_ly_doc_gia.Click += new System.EventHandler(this.button7_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(602, 266);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(141, 30);
            this.button1.TabIndex = 11;
            this.button1.Text = "Ket thuc";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btLuu
            // 
            this.btLuu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btLuu.Location = new System.Drawing.Point(602, 158);
            this.btLuu.Name = "btLuu";
            this.btLuu.Size = new System.Drawing.Size(143, 30);
            this.btLuu.TabIndex = 12;
            this.btLuu.Text = "Luu";
            this.btLuu.UseVisualStyleBackColor = true;
            this.btLuu.Click += new System.EventHandler(this.btLuu_Click);
            // 
            // btThem
            // 
            this.btThem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btThem.Location = new System.Drawing.Point(602, 12);
            this.btThem.Name = "btThem";
            this.btThem.Size = new System.Drawing.Size(143, 30);
            this.btThem.TabIndex = 13;
            this.btThem.Text = "Them";
            this.btThem.UseVisualStyleBackColor = true;
            this.btThem.Click += new System.EventHandler(this.btThem_Click);
            // 
            // btXoa
            // 
            this.btXoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btXoa.Location = new System.Drawing.Point(602, 48);
            this.btXoa.Name = "btXoa";
            this.btXoa.Size = new System.Drawing.Size(143, 30);
            this.btXoa.TabIndex = 14;
            this.btXoa.Text = "Xoa";
            this.btXoa.UseVisualStyleBackColor = true;
            this.btXoa.Click += new System.EventHandler(this.btXoa_Click);
            // 
            // btHuy
            // 
            this.btHuy.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btHuy.Location = new System.Drawing.Point(602, 122);
            this.btHuy.Name = "btHuy";
            this.btHuy.Size = new System.Drawing.Size(143, 30);
            this.btHuy.TabIndex = 15;
            this.btHuy.Text = "Huy";
            this.btHuy.UseVisualStyleBackColor = true;
            this.btHuy.Click += new System.EventHandler(this.btHuy_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider1.ContainerControl = this;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(793, 519);
            this.Controls.Add(this.btHuy);
            this.Controls.Add(this.btXoa);
            this.Controls.Add(this.btThem);
            this.Controls.Add(this.btLuu);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btQuan_ly_doc_gia);
            this.Controls.Add(this.btQuan_ly_muon_tra);
            this.Controls.Add(this.btCap_Nhat);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox lbLoai_sach;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbTac_gia;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_Ten_sach;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbMa_sach;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ListView lvDanh_sach_sach;
        private System.Windows.Forms.Button btCap_Nhat;
        private System.Windows.Forms.Button btQuan_ly_muon_tra;
        private System.Windows.Forms.Button btQuan_ly_doc_gia;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btLuu;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ComboBox cbLoai;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbSo_luong;
        private System.Windows.Forms.Button btThem;
        private System.Windows.Forms.Button btXoa;
        private System.Windows.Forms.Button btHuy;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}

