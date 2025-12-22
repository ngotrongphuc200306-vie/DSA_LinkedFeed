namespace SingleLinkList
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            txtPostID = new TextBox();
            txtNoiDungBaiDang = new TextBox();
            txtTacGia = new TextBox();
            dtpngayDang = new DateTimePicker();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            dgvbaiDang = new DataGridView();
            btnThem = new Button();
            btnSuaBaiDang = new Button();
            btnXoaBaiDang = new Button();
            label1 = new Label();
            label5 = new Label();
            txtTimKiem = new TextBox();
            btnTimKiem = new Button();
            btnHienThiTatCa = new Button();
            btnSapXepLuotThich = new Button();
            label6 = new Label();
            txtLuotThich = new TextBox();
            pictureBox1 = new PictureBox();
            label7 = new Label();
            btnVeBieuDo = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvbaiDang).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // txtPostID
            // 
            txtPostID.Location = new Point(120, 58);
            txtPostID.Margin = new Padding(3, 2, 3, 2);
            txtPostID.Name = "txtPostID";
            txtPostID.Size = new Size(219, 23);
            txtPostID.TabIndex = 0;
            // 
            // txtNoiDungBaiDang
            // 
            txtNoiDungBaiDang.Location = new Point(120, 83);
            txtNoiDungBaiDang.Margin = new Padding(3, 2, 3, 2);
            txtNoiDungBaiDang.Name = "txtNoiDungBaiDang";
            txtNoiDungBaiDang.Size = new Size(219, 23);
            txtNoiDungBaiDang.TabIndex = 1;
            // 
            // txtTacGia
            // 
            txtTacGia.Location = new Point(120, 108);
            txtTacGia.Margin = new Padding(3, 2, 3, 2);
            txtTacGia.Name = "txtTacGia";
            txtTacGia.Size = new Size(219, 23);
            txtTacGia.TabIndex = 2;
            // 
            // dtpngayDang
            // 
            dtpngayDang.Location = new Point(120, 163);
            dtpngayDang.Margin = new Padding(3, 2, 3, 2);
            dtpngayDang.Name = "dtpngayDang";
            dtpngayDang.Size = new Size(219, 23);
            dtpngayDang.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(25, 85);
            label2.Name = "label2";
            label2.Size = new Size(61, 15);
            label2.TabIndex = 5;
            label2.Text = "Nội Dung:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(25, 110);
            label3.Name = "label3";
            label3.Size = new Size(48, 15);
            label3.TabIndex = 6;
            label3.Text = "Tác Giả:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(25, 167);
            label4.Name = "label4";
            label4.Size = new Size(69, 15);
            label4.TabIndex = 7;
            label4.Text = "Ngày Đăng:";
            // 
            // dgvbaiDang
            // 
            dgvbaiDang.BackgroundColor = SystemColors.ActiveCaption;
            dgvbaiDang.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvbaiDang.Location = new Point(360, 31);
            dgvbaiDang.Margin = new Padding(3, 2, 3, 2);
            dgvbaiDang.Name = "dgvbaiDang";
            dgvbaiDang.RowHeadersWidth = 51;
            dgvbaiDang.Size = new Size(599, 293);
            dgvbaiDang.TabIndex = 8;
            dgvbaiDang.CellContentClick += dgvbaiDang_CellContentClick;
            // 
            // btnThem
            // 
            btnThem.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnThem.Location = new Point(120, 198);
            btnThem.Margin = new Padding(3, 2, 3, 2);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(56, 22);
            btnThem.TabIndex = 9;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // 
            // btnSuaBaiDang
            // 
            btnSuaBaiDang.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSuaBaiDang.Location = new Point(202, 198);
            btnSuaBaiDang.Margin = new Padding(3, 2, 3, 2);
            btnSuaBaiDang.Name = "btnSuaBaiDang";
            btnSuaBaiDang.Size = new Size(56, 22);
            btnSuaBaiDang.TabIndex = 10;
            btnSuaBaiDang.Text = "Sửa";
            btnSuaBaiDang.UseVisualStyleBackColor = true;
            btnSuaBaiDang.Click += btnSuaBaiDang_Click;
            // 
            // btnXoaBaiDang
            // 
            btnXoaBaiDang.BackColor = Color.Red;
            btnXoaBaiDang.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnXoaBaiDang.Location = new Point(282, 198);
            btnXoaBaiDang.Margin = new Padding(3, 2, 3, 2);
            btnXoaBaiDang.Name = "btnXoaBaiDang";
            btnXoaBaiDang.Size = new Size(56, 22);
            btnXoaBaiDang.TabIndex = 11;
            btnXoaBaiDang.Text = "Xóa";
            btnXoaBaiDang.UseVisualStyleBackColor = false;
            btnXoaBaiDang.Click += btnXoaBaiDang_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(25, 60);
            label1.Name = "label1";
            label1.Size = new Size(48, 15);
            label1.TabIndex = 12;
            label1.Text = "Điền ID:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(25, 228);
            label5.Name = "label5";
            label5.Size = new Size(81, 15);
            label5.TabIndex = 13;
            label5.Text = "Tìm Bài Đăng:";
            // 
            // txtTimKiem
            // 
            txtTimKiem.Location = new Point(120, 225);
            txtTimKiem.Margin = new Padding(3, 2, 3, 2);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.Size = new Size(219, 23);
            txtTimKiem.TabIndex = 14;
            // 
            // btnTimKiem
            // 
            btnTimKiem.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnTimKiem.Location = new Point(120, 250);
            btnTimKiem.Margin = new Padding(3, 2, 3, 2);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(82, 22);
            btnTimKiem.TabIndex = 15;
            btnTimKiem.Text = "Tìm Kiếm";
            btnTimKiem.UseVisualStyleBackColor = true;
            btnTimKiem.Click += btnTimKiem_Click;
            // 
            // btnHienThiTatCa
            // 
            btnHienThiTatCa.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnHienThiTatCa.Location = new Point(392, 347);
            btnHienThiTatCa.Margin = new Padding(3, 2, 3, 2);
            btnHienThiTatCa.Name = "btnHienThiTatCa";
            btnHienThiTatCa.Size = new Size(124, 22);
            btnHienThiTatCa.TabIndex = 16;
            btnHienThiTatCa.Text = "Làm mới bảng";
            btnHienThiTatCa.UseVisualStyleBackColor = true;
            btnHienThiTatCa.Click += btnHienThiTatCa_Click;
            // 
            // btnSapXepLuotThich
            // 
            btnSapXepLuotThich.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSapXepLuotThich.Location = new Point(571, 347);
            btnSapXepLuotThich.Margin = new Padding(3, 2, 3, 2);
            btnSapXepLuotThich.Name = "btnSapXepLuotThich";
            btnSapXepLuotThich.Size = new Size(131, 22);
            btnSapXepLuotThich.TabIndex = 19;
            btnSapXepLuotThich.Text = "Top lượt thích";
            btnSapXepLuotThich.UseVisualStyleBackColor = true;
            btnSapXepLuotThich.Click += btnSapXepLuotThich_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(25, 134);
            label6.Name = "label6";
            label6.Size = new Size(64, 15);
            label6.TabIndex = 17;
            label6.Text = "Lượt thích:";
            // 
            // txtLuotThich
            // 
            txtLuotThich.Location = new Point(120, 132);
            txtLuotThich.Margin = new Padding(3, 2, 3, 2);
            txtLuotThich.Name = "txtLuotThich";
            txtLuotThich.Size = new Size(219, 23);
            txtLuotThich.TabIndex = 18;
            txtLuotThich.Text = "0";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(47, 331);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(273, 105);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 20;
            pictureBox1.TabStop = false;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(47, 20);
            label7.Name = "label7";
            label7.Size = new Size(273, 32);
            label7.TabIndex = 21;
            label7.Text = "THÔNG TIN BÀI ĐĂNG";
            // 
            // btnVeBieuDo
            // 
            btnVeBieuDo.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnVeBieuDo.Location = new Point(767, 347);
            btnVeBieuDo.Name = "btnVeBieuDo";
            btnVeBieuDo.Size = new Size(131, 22);
            btnVeBieuDo.TabIndex = 0;
            btnVeBieuDo.Text = "Biểu đồ lượt thích";
            btnVeBieuDo.Click += BtnVeBieuDo_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1100, 791);
            Controls.Add(btnVeBieuDo);
            Controls.Add(label7);
            Controls.Add(pictureBox1);
            Controls.Add(txtLuotThich);
            Controls.Add(label6);
            Controls.Add(btnHienThiTatCa);
            Controls.Add(btnSapXepLuotThich);
            Controls.Add(btnTimKiem);
            Controls.Add(txtTimKiem);
            Controls.Add(label5);
            Controls.Add(label1);
            Controls.Add(btnXoaBaiDang);
            Controls.Add(btnSuaBaiDang);
            Controls.Add(btnThem);
            Controls.Add(dgvbaiDang);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(dtpngayDang);
            Controls.Add(txtTacGia);
            Controls.Add(txtNoiDungBaiDang);
            Controls.Add(txtPostID);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Form1";
            Text = "FaceBle";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dgvbaiDang).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion


        private TextBox txtPostID;
        private TextBox txtNoiDungBaiDang;
        private TextBox txtTacGia;
        private DateTimePicker dtpngayDang;
        private Label label2;
        private Label label3;
        private Label label4;
        private DataGridView dgvbaiDang;
        private Button btnThem;
        private Button btnSuaBaiDang;
        private Button btnXoaBaiDang;
        private Label label1;
        private Label label5;
        private TextBox txtTimKiem;
        private Button btnTimKiem;
        private Button btnHienThiTatCa;
        private Label label6;
        private TextBox txtLuotThich;
        private Button btnSapXepLuotThich;
        private Button btnVeBieuDo;
        private PictureBox pictureBox1;
        private Label label7;
    }
}
