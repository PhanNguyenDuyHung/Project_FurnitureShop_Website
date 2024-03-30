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

namespace QL_NoiThat.GUI
{
	public partial class frm_Entry : Form
	{
		NhapHang_BUS nhaphang_bus;
		public frm_Entry()
		{
			InitializeComponent();
			nhaphang_bus = new NhapHang_BUS();
			loadALlNCC();
		}

		private async void btnThem_Click(object sender, EventArgs e)
		{

			CreateChiTietPN ctpn = new CreateChiTietPN
			{
				MaSP = int.Parse(txtIDSPN.Text),
				SoLuong = int.Parse(txtSLN.Text),
				DonGiaNhap = int.Parse(txtDonGiaNhap.Text),
				MaNhapHang = int.Parse(lbID.Text)
			};

			update_sl sl= new update_sl
			{
				id = int.Parse(txtIDSPN.Text),
				sl = int.Parse(txtSLN.Text),
			};

			int result = await nhaphang_bus.createCTPhieuNhap(ctpn);
			if (result == 1)
			{
				MessageBox.Show("Thêm chi tiết nhập hàng thành công");
				int rs = await nhaphang_bus.updateSLSP(sl);
				if(rs == 0)
				{
					MessageBox.Show("Thêm chi tiết nhập hàng KHÔNG thành công vì không điều chỉnh được số lượng");
					
				}
                else
                {
					loadAsync_CTNH(lbID.Text);
					string maNCC = cbNCC.SelectedValue.ToString();
					loadAsync(maNCC);
				}
			}
			else
			{

				MessageBox.Show("Thêm chi tiết nhập hàng KHÔNG thành công");

			}
		}
		public async void loadALlNCC()
		{
			List<NhaCungCap_Model> phieunhaps = await nhaphang_bus.getNCC();
			cbNCC.DataSource = phieunhaps;
			cbNCC.DisplayMember = "TenNCC"; // Hiển thị tên sản phẩm
			cbNCC.ValueMember = "MaNCC"; // Giá trị thực sự của mục được chọn

		}

		public async Task loadAsync_CTNH(string id)
		{
			List<ChiTietPN> khohangs = await nhaphang_bus.getChiTietPhieuNhap(id);
			dtgvChiTietPhieu.Refresh();
			dtgvChiTietPhieu.DataSource = khohangs;
		}

		private void dtgvPhieuNhap_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			DataGridViewRow row = new DataGridViewRow();
			row = dtgvPhieuNhap.Rows[e.RowIndex];

			lbID.Text = Convert.ToString(row.Cells["MaNhapHang"].Value);
			lbNCC.Text = Convert.ToString(row.Cells["TenNCC"].Value);
			lbNgay.Text = Convert.ToString(row.Cells["NgayNhap"].Value);
			lbDonGia.Text = Convert.ToString(row.Cells["TongTien"].Value);

			loadAsync_CTNH(lbID.Text);
			
			loadAsync(maNCC);

		}

		public async void loadALlPhieuNhap(int id)
		{

			List<PhieuNhapHT_Model> phieunhaps = await nhaphang_bus.getPhieuNhap(id);

			dtgvPhieuNhap.DataSource = phieunhaps;
		}

		string maNCC = "";
		 async Task loadAsync(string id)
		{
			maNCC = id;
			List<SanPhamm> khohangs = await nhaphang_bus.getTonKho(id);
			dtgvKhoHang.DataSource = khohangs;
		}

		private void cbNCC_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cbNCC.SelectedValue.ToString() != null && cbNCC.SelectedValue.ToString() != "QL_NoiThat.Model.NhaCungCap_Model")
			{
				string maNCC = cbNCC.SelectedValue.ToString();
				loadAsync(maNCC);
				loadALlPhieuNhap(int.Parse(maNCC));
			}
		}

		private async void btnXoa_Click(object sender, EventArgs e)
		{
			if (dtgvChiTietPhieu.SelectedRows.Count > 0)
			{
				DataGridViewRow selectedRow = dtgvChiTietPhieu.SelectedRows[0];

				// Kiểm tra giá trị null trước khi chuyển đổi kiểu dữ liệu
				if (selectedRow.Cells[0].Value != null && selectedRow.Cells[5].Value != null)
				{
					int idchitietphieunhap = Convert.ToInt32(selectedRow.Cells[0].Value);
					int idphieunhap = Convert.ToInt32(selectedRow.Cells[5].Value);

					int result = await nhaphang_bus.DeleteCTPN(idphieunhap, idchitietphieunhap);
					if (result == 1)
					{
						MessageBox.Show("Xóa chi tiết nhập hàng thành công");
						string id = Convert.ToString(idphieunhap);
						loadAsync_CTNH(id);
					}
					else
					{
						MessageBox.Show("Xóa chi tiết nhập hàng KHÔNG thành công");
					}
				}
				else
				{
					MessageBox.Show("Dữ liệu không hợp lệ"); // Có thể giá trị của cell là null
				}
			}
			else
			{
				MessageBox.Show("Chưa chọn chi tiết phiếu");
			}
		}

		private async void btn_SuaCTPN_Click(object sender, EventArgs e)
		{
			UpdateChiTietPN ctpn = new UpdateChiTietPN
			{
				MaThongKeNhap = int.Parse(lbIDCTNH.Text),
				MaSP = int.Parse(txtIDSPN.Text),
				SoLuong = int.Parse(txtSLN.Text),
				DonGiaNhap = int.Parse(txtDonGiaNhap.Text),
			};

			int result = await nhaphang_bus.updateCTPhieuNhap(ctpn);
			if (result == 1)
			{
				MessageBox.Show("Sửa chi tiết nhập hàng thành công");

			}
			else
			{
				MessageBox.Show("Sửa chi tiết nhập hàng KHÔNG thành công");
			}
		}

		private void btnClear_Click(object sender, EventArgs e)
		{
			lbIDCTNH.Text = "";
			txtIDSPN.Text = "";
			txtSLN.Text = "";
			txtDonGiaNhap.Text = "";
		}

		private void dtgvChiTietPhieu_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			DataGridViewRow row = new DataGridViewRow();

			row = dtgvChiTietPhieu.Rows[e.RowIndex];

			lbIDCTNH.Text = Convert.ToString(row.Cells["MaThongKeNhap"].Value);
			txtIDSPN.Text = Convert.ToString(row.Cells["MaSP"].Value);
			txtDonGiaNhap.Text = Convert.ToString(row.Cells["DonGiaNhap"].Value);
			txtSLN.Text = Convert.ToString(row.Cells["SoLuong"].Value);

			txtTong.Text = (int.Parse(txtSLN.Text) * int.Parse(txtDonGiaNhap.Text)).ToString();
		}

		private void btn_taoPN_Click(object sender, EventArgs e)
		{
			frm_PhieuNhapHang f = new frm_PhieuNhapHang();
			f.ShowDialog();
			this.Hide();
		}
	}
}
