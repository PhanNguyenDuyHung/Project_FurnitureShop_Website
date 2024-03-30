using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_NoiThat.GUI
{
    public partial class frm_Main : Form
    {
        public frm_Main()
        {
            InitializeComponent();
            OpemChildForm(new frm_Customer());
            lb_TenQL.Text = "QUẢN LÝ ĐƠN HÀNG";
        }

        private Form currentformChild;
        private void OpemChildForm(Form childform)
        {
			if (currentformChild != null)
			{
				currentformChild.Close();
			}
			currentformChild = childform;
			childform.TopLevel = false;
			childform.FormBorderStyle = FormBorderStyle.None;
			childform.Dock = DockStyle.Fill;
			pn_body.Controls.Add(childform);
			pn_body.Tag = childform;
			childform.BringToFront();
			childform.Show();
		}

        private void frm_Main_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpemChildForm(new frm_Order());
            lb_TenQL.Text = "QUẢN LÝ ĐƠN HÀNG";

        }

        private void btn_QLNhapHang_Click(object sender, EventArgs e)
        {
            OpemChildForm(new frm_Entry());
            lb_TenQL.Text = "QUẢN LÝ NHẬP HÀNG";
        }

        private void btn_QLSanPham_Click(object sender, EventArgs e)
        {
            OpemChildForm(new frm_Product());
            lb_TenQL.Text = "QUẢN LÝ SẢN PHẨM";
        }

        private void btn_QLNhaCungCap_Click(object sender, EventArgs e)
        {
            OpemChildForm(new frm_Provider());
            lb_TenQL.Text = "QUẢN LÝ NHÀ CUNG CẤP";
        }

        private void btn_QuanLyThongKe_Click(object sender, EventArgs e)
        {
            
            OpemChildForm(new frm_Statistical());
            lb_TenQL.Text = "QUẢN LÝ THỐNG KÊ";
        }

        private void pn_body_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
