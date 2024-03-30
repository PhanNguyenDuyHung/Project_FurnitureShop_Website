using QL_NoiThat.BUS;
using QL_NoiThat.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_NoiThat.GUI
{
	public partial class frm_AddEntry : Form
	{
		NhapHang_BUS nhaphang_bus1;
		public frm_AddEntry()
		{
			InitializeComponent();
			DateTime currentDate = DateTime.Now;
			string formattedDate = currentDate.ToString("dd/MM/yyyy");
			label3.Text = formattedDate;
			loadNCC();

		}

		private void label3_Click(object sender, EventArgs e)
		{

		}
		public async void loadNCC()
		{
			List<NhaCungCap> phieunhaps = await nhaphang_bus1.GetNCC();
			comboBox1.DataSource = phieunhaps;
			comboBox1.DisplayMember = "TenNCC"; // Hiển thị tên sản phẩm
			comboBox1.ValueMember = "MaNCC"; 
			
		}

		private async void btn_add_Click(object sender, EventArgs e)
		{
			//PhieuNhap pn = new PhieuNhap
			//{
			//	MaNCC = int.Parse(comboBox1.SelectedValue.ToString()),
			//	NgayNhap = label3.Text,
			//};

			//int result = await nhaphang_bus1.createPhieuNhap(pn);
			//if (result == 1)
			//{
			//	MessageBox.Show("Thêm nhập hàng thành công");

			//}
			//else
			//{

			//	MessageBox.Show("Thêm nhập hàng KHÔNG thành công");

			//}
		}
	}
}
