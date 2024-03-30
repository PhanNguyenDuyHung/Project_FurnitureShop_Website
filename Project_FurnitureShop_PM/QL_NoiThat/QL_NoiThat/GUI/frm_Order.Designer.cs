namespace QL_NoiThat.GUI
{
    partial class frm_Order
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
            this.data_donhang = new System.Windows.Forms.DataGridView();
            this.cb_tinhtrang = new System.Windows.Forms.ComboBox();
            this.data_chitietdonhang = new System.Windows.Forms.DataGridView();
            this.btn_capnhat = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cb_capnhat = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lb_tinhtrang = new System.Windows.Forms.Label();
            this.lb_mdh = new System.Windows.Forms.Label();
            this.lb_ngaytao = new System.Windows.Forms.Label();
            this.lb_makh = new System.Windows.Forms.Label();
            this.lb_kh = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.data_donhang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.data_chitietdonhang)).BeginInit();
            this.SuspendLayout();
            // 
            // data_donhang
            // 
            this.data_donhang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.data_donhang.Location = new System.Drawing.Point(12, 73);
            this.data_donhang.Name = "data_donhang";
            this.data_donhang.RowHeadersWidth = 51;
            this.data_donhang.RowTemplate.Height = 24;
            this.data_donhang.Size = new System.Drawing.Size(1211, 259);
            this.data_donhang.TabIndex = 0;
            // 
            // cb_tinhtrang
            // 
            this.cb_tinhtrang.FormattingEnabled = true;
            this.cb_tinhtrang.Location = new System.Drawing.Point(102, 346);
            this.cb_tinhtrang.Name = "cb_tinhtrang";
            this.cb_tinhtrang.Size = new System.Drawing.Size(163, 24);
            this.cb_tinhtrang.TabIndex = 1;
            // 
            // data_chitietdonhang
            // 
            this.data_chitietdonhang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.data_chitietdonhang.Location = new System.Drawing.Point(12, 424);
            this.data_chitietdonhang.Name = "data_chitietdonhang";
            this.data_chitietdonhang.RowHeadersWidth = 51;
            this.data_chitietdonhang.RowTemplate.Height = 24;
            this.data_chitietdonhang.Size = new System.Drawing.Size(1211, 299);
            this.data_chitietdonhang.TabIndex = 2;
            // 
            // btn_capnhat
            // 
            this.btn_capnhat.Location = new System.Drawing.Point(601, 338);
            this.btn_capnhat.Name = "btn_capnhat";
            this.btn_capnhat.Size = new System.Drawing.Size(102, 38);
            this.btn_capnhat.TabIndex = 3;
            this.btn_capnhat.Text = "Cập nhật";
            this.btn_capnhat.UseVisualStyleBackColor = true;
            this.btn_capnhat.Click += new System.EventHandler(this.btn_capnhat_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(537, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(280, 34);
            this.label1.TabIndex = 4;
            this.label1.Text = "QUẢN LÝ ĐƠN HÀNG";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 349);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Tình trạng :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(281, 349);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Cập nhật tình trạng";
            // 
            // cb_capnhat
            // 
            this.cb_capnhat.FormattingEnabled = true;
            this.cb_capnhat.Location = new System.Drawing.Point(413, 346);
            this.cb_capnhat.Name = "cb_capnhat";
            this.cb_capnhat.Size = new System.Drawing.Size(163, 24);
            this.cb_capnhat.TabIndex = 7;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.label10.ForeColor = System.Drawing.Color.Firebrick;
            this.label10.Location = new System.Drawing.Point(12, 50);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(88, 20);
            this.label10.TabIndex = 54;
            this.label10.Text = "Đơn hàng";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.Firebrick;
            this.label4.Location = new System.Drawing.Point(12, 401);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(152, 20);
            this.label4.TabIndex = 55;
            this.label4.Text = "Chi tiết đơn hàng";
            // 
            // lb_tinhtrang
            // 
            this.lb_tinhtrang.AutoSize = true;
            this.lb_tinhtrang.Location = new System.Drawing.Point(1336, 208);
            this.lb_tinhtrang.Name = "lb_tinhtrang";
            this.lb_tinhtrang.Size = new System.Drawing.Size(35, 16);
            this.lb_tinhtrang.TabIndex = 56;
            this.lb_tinhtrang.Text = "####";
            // 
            // lb_mdh
            // 
            this.lb_mdh.AutoSize = true;
            this.lb_mdh.Location = new System.Drawing.Point(1336, 118);
            this.lb_mdh.Name = "lb_mdh";
            this.lb_mdh.Size = new System.Drawing.Size(28, 16);
            this.lb_mdh.TabIndex = 57;
            this.lb_mdh.Text = "###";
            // 
            // lb_ngaytao
            // 
            this.lb_ngaytao.AutoSize = true;
            this.lb_ngaytao.Location = new System.Drawing.Point(1339, 159);
            this.lb_ngaytao.Name = "lb_ngaytao";
            this.lb_ngaytao.Size = new System.Drawing.Size(28, 16);
            this.lb_ngaytao.TabIndex = 58;
            this.lb_ngaytao.Text = "###";
            // 
            // lb_makh
            // 
            this.lb_makh.AutoSize = true;
            this.lb_makh.Location = new System.Drawing.Point(1339, 255);
            this.lb_makh.Name = "lb_makh";
            this.lb_makh.Size = new System.Drawing.Size(28, 16);
            this.lb_makh.TabIndex = 59;
            this.lb_makh.Text = "###";
            // 
            // lb_kh
            // 
            this.lb_kh.AutoSize = true;
            this.lb_kh.Location = new System.Drawing.Point(1336, 291);
            this.lb_kh.Name = "lb_kh";
            this.lb_kh.Size = new System.Drawing.Size(35, 16);
            this.lb_kh.TabIndex = 60;
            this.lb_kh.Text = "####";
            // 
            // frm_Order
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1513, 748);
            this.Controls.Add(this.lb_kh);
            this.Controls.Add(this.lb_makh);
            this.Controls.Add(this.lb_ngaytao);
            this.Controls.Add(this.lb_mdh);
            this.Controls.Add(this.lb_tinhtrang);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cb_capnhat);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_capnhat);
            this.Controls.Add(this.data_chitietdonhang);
            this.Controls.Add(this.cb_tinhtrang);
            this.Controls.Add(this.data_donhang);
            this.Name = "frm_Order";
            this.Text = "frm_Order";
            this.Load += new System.EventHandler(this.frm_Order_Load);
            ((System.ComponentModel.ISupportInitialize)(this.data_donhang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.data_chitietdonhang)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView data_donhang;
        private System.Windows.Forms.ComboBox cb_tinhtrang;
        private System.Windows.Forms.DataGridView data_chitietdonhang;
        private System.Windows.Forms.Button btn_capnhat;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cb_capnhat;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lb_tinhtrang;
        private System.Windows.Forms.Label lb_mdh;
        private System.Windows.Forms.Label lb_ngaytao;
        private System.Windows.Forms.Label lb_makh;
        private System.Windows.Forms.Label lb_kh;
    }
}