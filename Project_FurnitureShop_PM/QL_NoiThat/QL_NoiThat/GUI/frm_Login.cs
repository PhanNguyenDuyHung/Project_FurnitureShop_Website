using QL_NoiThat.BUS;
using QL_NoiThat.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace QL_NoiThat.GUI
{
    public partial class frm_Login : Form
    {
        NhapHang_BUS nhaphang_bus;
        public frm_Login()
        {
            InitializeComponent();
            nhaphang_bus = new NhapHang_BUS(); 
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private async void btn_Dangnhap_Click(object sender, EventArgs e)
        {
           user u = new user()
           {
				name = txt_username.Text,
			    pass = txt_userpass.Text
		    };

			if ( await nhaphang_bus.checklogin(u) ==1)
			{
				DialogResult result = MessageBox.Show("Đăng nhập thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

				if (result == DialogResult.OK)
				{
					frm_Main fm = new frm_Main();
					fm.Show();
					this.Hide();
				}
			}
			else
			{
				MessageBox.Show("Đăng nhập không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
				// Xử lý khi đăng nhập không thành công (nếu cần).
			}

		}
	}
}
