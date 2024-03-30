namespace QL_NoiThat.GUI
{
	partial class frm_Entry
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
			this.btn_SuaCTPN = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.txtTong = new System.Windows.Forms.TextBox();
			this.btnClear = new System.Windows.Forms.Button();
			this.lbIDCTNH = new System.Windows.Forms.Label();
			this.cbNCC = new System.Windows.Forms.ComboBox();
			this.btnXoa = new System.Windows.Forms.Button();
			this.btnThem = new System.Windows.Forms.Button();
			this.label15 = new System.Windows.Forms.Label();
			this.txtSLN = new System.Windows.Forms.TextBox();
			this.txtDonGiaNhap = new System.Windows.Forms.TextBox();
			this.txtIDSPN = new System.Windows.Forms.TextBox();
			this.label13 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.lbNgay = new System.Windows.Forms.Label();
			this.lbID = new System.Windows.Forms.Label();
			this.lbNCC = new System.Windows.Forms.Label();
			this.lbDonGia = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.label10 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.dtgvChiTietPhieu = new System.Windows.Forms.DataGridView();
			this.dtgvPhieuNhap = new System.Windows.Forms.DataGridView();
			this.btn_taoPN = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.dtgvKhoHang = new System.Windows.Forms.DataGridView();
			((System.ComponentModel.ISupportInitialize)(this.dtgvChiTietPhieu)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dtgvPhieuNhap)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dtgvKhoHang)).BeginInit();
			this.SuspendLayout();
			// 
			// btn_SuaCTPN
			// 
			this.btn_SuaCTPN.Location = new System.Drawing.Point(958, 365);
			this.btn_SuaCTPN.Name = "btn_SuaCTPN";
			this.btn_SuaCTPN.Size = new System.Drawing.Size(64, 23);
			this.btn_SuaCTPN.TabIndex = 80;
			this.btn_SuaCTPN.Text = "Sửa";
			this.btn_SuaCTPN.UseVisualStyleBackColor = true;
			this.btn_SuaCTPN.Click += new System.EventHandler(this.btn_SuaCTPN_Click);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(201, 363);
			this.button1.Margin = new System.Windows.Forms.Padding(2);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(123, 24);
			this.button1.TabIndex = 79;
			this.button1.Text = "Nhập sản phẩm mới";
			this.button1.UseVisualStyleBackColor = true;
			// 
			// txtTong
			// 
			this.txtTong.Enabled = false;
			this.txtTong.Location = new System.Drawing.Point(958, 333);
			this.txtTong.Margin = new System.Windows.Forms.Padding(2);
			this.txtTong.Name = "txtTong";
			this.txtTong.Size = new System.Drawing.Size(117, 20);
			this.txtTong.TabIndex = 78;
			this.txtTong.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// btnClear
			// 
			this.btnClear.Location = new System.Drawing.Point(1037, 365);
			this.btnClear.Margin = new System.Windows.Forms.Padding(2);
			this.btnClear.Name = "btnClear";
			this.btnClear.Size = new System.Drawing.Size(55, 24);
			this.btnClear.TabIndex = 77;
			this.btnClear.Text = "Clear";
			this.btnClear.UseVisualStyleBackColor = true;
			this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
			// 
			// lbIDCTNH
			// 
			this.lbIDCTNH.AutoSize = true;
			this.lbIDCTNH.Location = new System.Drawing.Point(886, 214);
			this.lbIDCTNH.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lbIDCTNH.Name = "lbIDCTNH";
			this.lbIDCTNH.Size = new System.Drawing.Size(35, 13);
			this.lbIDCTNH.TabIndex = 76;
			this.lbIDCTNH.Text = "####";
			// 
			// cbNCC
			// 
			this.cbNCC.FormattingEnabled = true;
			this.cbNCC.Location = new System.Drawing.Point(167, 42);
			this.cbNCC.Margin = new System.Windows.Forms.Padding(2);
			this.cbNCC.Name = "cbNCC";
			this.cbNCC.Size = new System.Drawing.Size(164, 21);
			this.cbNCC.TabIndex = 75;
			this.cbNCC.SelectedIndexChanged += new System.EventHandler(this.cbNCC_SelectedIndexChanged);
			// 
			// btnXoa
			// 
			this.btnXoa.Location = new System.Drawing.Point(889, 364);
			this.btnXoa.Margin = new System.Windows.Forms.Padding(2);
			this.btnXoa.Name = "btnXoa";
			this.btnXoa.Size = new System.Drawing.Size(58, 24);
			this.btnXoa.TabIndex = 74;
			this.btnXoa.Text = "Xóa";
			this.btnXoa.UseVisualStyleBackColor = true;
			this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
			// 
			// btnThem
			// 
			this.btnThem.Location = new System.Drawing.Point(795, 363);
			this.btnThem.Margin = new System.Windows.Forms.Padding(2);
			this.btnThem.Name = "btnThem";
			this.btnThem.Size = new System.Drawing.Size(81, 24);
			this.btnThem.TabIndex = 73;
			this.btnThem.Text = "Nhập hàng";
			this.btnThem.UseVisualStyleBackColor = true;
			this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
			// 
			// label15
			// 
			this.label15.AutoSize = true;
			this.label15.Location = new System.Drawing.Point(902, 309);
			this.label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(172, 13);
			this.label15.TabIndex = 72;
			this.label15.Text = "-------------------------------------------------------";
			// 
			// txtSLN
			// 
			this.txtSLN.Location = new System.Drawing.Point(1009, 287);
			this.txtSLN.Margin = new System.Windows.Forms.Padding(2);
			this.txtSLN.Name = "txtSLN";
			this.txtSLN.Size = new System.Drawing.Size(65, 20);
			this.txtSLN.TabIndex = 71;
			this.txtSLN.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txtDonGiaNhap
			// 
			this.txtDonGiaNhap.Location = new System.Drawing.Point(889, 262);
			this.txtDonGiaNhap.Margin = new System.Windows.Forms.Padding(2);
			this.txtDonGiaNhap.Name = "txtDonGiaNhap";
			this.txtDonGiaNhap.Size = new System.Drawing.Size(186, 20);
			this.txtDonGiaNhap.TabIndex = 70;
			this.txtDonGiaNhap.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txtIDSPN
			// 
			this.txtIDSPN.Location = new System.Drawing.Point(889, 235);
			this.txtIDSPN.Margin = new System.Windows.Forms.Padding(2);
			this.txtIDSPN.Name = "txtIDSPN";
			this.txtIDSPN.Size = new System.Drawing.Size(186, 20);
			this.txtIDSPN.TabIndex = 69;
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Location = new System.Drawing.Point(795, 287);
			this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(52, 13);
			this.label13.TabIndex = 68;
			this.label13.Text = "Số lượng:";
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(795, 262);
			this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(74, 13);
			this.label12.TabIndex = 67;
			this.label12.Text = "Đơn giá nhập:";
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(795, 238);
			this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(73, 13);
			this.label11.TabIndex = 66;
			this.label11.Text = "ID Sản Phẩm:";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(795, 214);
			this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(21, 13);
			this.label8.TabIndex = 65;
			this.label8.Text = "ID:";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
			this.label7.ForeColor = System.Drawing.Color.Firebrick;
			this.label7.Location = new System.Drawing.Point(842, 196);
			this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(217, 17);
			this.label7.TabIndex = 64;
			this.label7.Text = "Thông tin chi tiết phiếu nhập";
			// 
			// lbNgay
			// 
			this.lbNgay.AutoSize = true;
			this.lbNgay.Location = new System.Drawing.Point(977, 54);
			this.lbNgay.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lbNgay.Name = "lbNgay";
			this.lbNgay.Size = new System.Drawing.Size(35, 13);
			this.lbNgay.TabIndex = 63;
			this.lbNgay.Text = "####";
			// 
			// lbID
			// 
			this.lbID.AutoSize = true;
			this.lbID.Location = new System.Drawing.Point(880, 54);
			this.lbID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lbID.Name = "lbID";
			this.lbID.Size = new System.Drawing.Size(35, 13);
			this.lbID.TabIndex = 62;
			this.lbID.Text = "####";
			// 
			// lbNCC
			// 
			this.lbNCC.AutoSize = true;
			this.lbNCC.Location = new System.Drawing.Point(880, 79);
			this.lbNCC.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lbNCC.Name = "lbNCC";
			this.lbNCC.Size = new System.Drawing.Size(35, 13);
			this.lbNCC.TabIndex = 61;
			this.lbNCC.Text = "####";
			// 
			// lbDonGia
			// 
			this.lbDonGia.AutoSize = true;
			this.lbDonGia.Location = new System.Drawing.Point(880, 104);
			this.lbDonGia.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lbDonGia.Name = "lbDonGia";
			this.lbDonGia.Size = new System.Drawing.Size(35, 13);
			this.lbDonGia.TabIndex = 60;
			this.lbDonGia.Text = "####";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(841, 104);
			this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(35, 13);
			this.label6.TabIndex = 59;
			this.label6.Text = "Tổng:";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(940, 54);
			this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(35, 13);
			this.label5.TabIndex = 58;
			this.label5.Text = "Ngày:";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(802, 79);
			this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(78, 13);
			this.label4.TabIndex = 57;
			this.label4.Text = "Nhà cung cấp:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(857, 54);
			this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(21, 13);
			this.label3.TabIndex = 56;
			this.label3.Text = "ID:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
			this.label2.ForeColor = System.Drawing.Color.Firebrick;
			this.label2.Location = new System.Drawing.Point(854, 19);
			this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(163, 17);
			this.label2.TabIndex = 55;
			this.label2.Text = "Thông tin phiếu nhập";
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
			this.panel1.Location = new System.Drawing.Point(346, 23);
			this.panel1.Margin = new System.Windows.Forms.Padding(2);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(7, 551);
			this.panel1.TabIndex = 54;
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
			this.label10.ForeColor = System.Drawing.Color.Firebrick;
			this.label10.Location = new System.Drawing.Point(545, 19);
			this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(90, 17);
			this.label10.TabIndex = 53;
			this.label10.Text = "Phiếu nhập";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
			this.label9.ForeColor = System.Drawing.Color.Firebrick;
			this.label9.Location = new System.Drawing.Point(519, 196);
			this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(145, 17);
			this.label9.TabIndex = 52;
			this.label9.Text = "Chi tiết phiếu nhập";
			// 
			// dtgvChiTietPhieu
			// 
			this.dtgvChiTietPhieu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dtgvChiTietPhieu.Location = new System.Drawing.Point(360, 214);
			this.dtgvChiTietPhieu.Margin = new System.Windows.Forms.Padding(2);
			this.dtgvChiTietPhieu.Name = "dtgvChiTietPhieu";
			this.dtgvChiTietPhieu.RowHeadersWidth = 62;
			this.dtgvChiTietPhieu.RowTemplate.Height = 28;
			this.dtgvChiTietPhieu.Size = new System.Drawing.Size(411, 328);
			this.dtgvChiTietPhieu.TabIndex = 51;
			this.dtgvChiTietPhieu.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvChiTietPhieu_CellClick);
			// 
			// dtgvPhieuNhap
			// 
			this.dtgvPhieuNhap.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dtgvPhieuNhap.Location = new System.Drawing.Point(365, 42);
			this.dtgvPhieuNhap.Margin = new System.Windows.Forms.Padding(2);
			this.dtgvPhieuNhap.Name = "dtgvPhieuNhap";
			this.dtgvPhieuNhap.RowHeadersWidth = 62;
			this.dtgvPhieuNhap.RowTemplate.Height = 28;
			this.dtgvPhieuNhap.Size = new System.Drawing.Size(406, 115);
			this.dtgvPhieuNhap.TabIndex = 50;
			this.dtgvPhieuNhap.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvPhieuNhap_CellClick);
			// 
			// btn_taoPN
			// 
			this.btn_taoPN.Location = new System.Drawing.Point(638, 161);
			this.btn_taoPN.Margin = new System.Windows.Forms.Padding(2);
			this.btn_taoPN.Name = "btn_taoPN";
			this.btn_taoPN.Size = new System.Drawing.Size(133, 24);
			this.btn_taoPN.TabIndex = 49;
			this.btn_taoPN.Text = "Tạo phiếu nhập";
			this.btn_taoPN.UseVisualStyleBackColor = true;
			this.btn_taoPN.Click += new System.EventHandler(this.btn_taoPN_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.Firebrick;
			this.label1.Location = new System.Drawing.Point(147, 15);
			this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(79, 17);
			this.label1.TabIndex = 48;
			this.label1.Text = "Kho Hàng";
			// 
			// dtgvKhoHang
			// 
			this.dtgvKhoHang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dtgvKhoHang.Location = new System.Drawing.Point(14, 64);
			this.dtgvKhoHang.Margin = new System.Windows.Forms.Padding(2);
			this.dtgvKhoHang.Name = "dtgvKhoHang";
			this.dtgvKhoHang.RowHeadersWidth = 62;
			this.dtgvKhoHang.RowTemplate.Height = 28;
			this.dtgvKhoHang.Size = new System.Drawing.Size(316, 289);
			this.dtgvKhoHang.TabIndex = 47;
			// 
			// frm_Entry
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1159, 599);
			this.Controls.Add(this.btn_SuaCTPN);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.txtTong);
			this.Controls.Add(this.btnClear);
			this.Controls.Add(this.lbIDCTNH);
			this.Controls.Add(this.cbNCC);
			this.Controls.Add(this.btnXoa);
			this.Controls.Add(this.btnThem);
			this.Controls.Add(this.label15);
			this.Controls.Add(this.txtSLN);
			this.Controls.Add(this.txtDonGiaNhap);
			this.Controls.Add(this.txtIDSPN);
			this.Controls.Add(this.label13);
			this.Controls.Add(this.label12);
			this.Controls.Add(this.label11);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.lbNgay);
			this.Controls.Add(this.lbID);
			this.Controls.Add(this.lbNCC);
			this.Controls.Add(this.lbDonGia);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.dtgvChiTietPhieu);
			this.Controls.Add(this.dtgvPhieuNhap);
			this.Controls.Add(this.btn_taoPN);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.dtgvKhoHang);
			this.Name = "frm_Entry";
			this.Text = "frm_Entry";
			((System.ComponentModel.ISupportInitialize)(this.dtgvChiTietPhieu)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dtgvPhieuNhap)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dtgvKhoHang)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btn_SuaCTPN;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.TextBox txtTong;
		private System.Windows.Forms.Button btnClear;
		private System.Windows.Forms.Label lbIDCTNH;
		private System.Windows.Forms.ComboBox cbNCC;
		private System.Windows.Forms.Button btnXoa;
		private System.Windows.Forms.Button btnThem;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.TextBox txtSLN;
		private System.Windows.Forms.TextBox txtDonGiaNhap;
		private System.Windows.Forms.TextBox txtIDSPN;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label lbNgay;
		private System.Windows.Forms.Label lbID;
		private System.Windows.Forms.Label lbNCC;
		private System.Windows.Forms.Label lbDonGia;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.DataGridView dtgvChiTietPhieu;
		private System.Windows.Forms.DataGridView dtgvPhieuNhap;
		private System.Windows.Forms.Button btn_taoPN;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.DataGridView dtgvKhoHang;
	}
}