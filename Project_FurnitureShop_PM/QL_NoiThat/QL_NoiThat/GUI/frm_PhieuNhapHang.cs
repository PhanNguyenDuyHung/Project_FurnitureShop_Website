using QL_NoiThat.BUS;
using QL_NoiThat.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_NoiThat.GUI
{
    public partial class frm_PhieuNhapHang : Form
    {
		NhapHang_BUS nhaphang_bus;
		public frm_PhieuNhapHang()
        {
            InitializeComponent();
			this.Load += new EventHandler(frm_PhieuNhapHang_Load);
			nhaphang_bus = new NhapHang_BUS();
			loadNCC();
		}

		public async void loadNCC()
		{
			List<NhaCungCap_Model> phieunhaps = await nhaphang_bus.getNCC();

			// Kiểm tra cbNCC có null không trước khi gán giá trị
			if (comboBox1 != null)
			{
				comboBox1.DataSource = phieunhaps;
				comboBox1.DisplayMember = "TenNCC"; // Hiển thị tên sản phẩm
				comboBox1.ValueMember = "MaNCC"; // Giá trị thực sự của mục được chọn
			}
			else
			{
				MessageBox.Show("Lỗi rồi");
			}

		}
		private async void button1_Click(object sender, EventArgs e)
		{
			// Chuỗi ngày tháng từ label
			string dateString = label8.Text; // Chuỗi có định dạng dd/MM/yyyy

			// Định dạng ngày tháng mong muốn
			string format = "dd/MM/yyyy";

			// Khởi tạo đối tượng DateTime từ chuỗi với định dạng cụ thể
			DateTime datet;
			if (DateTime.TryParseExact(dateString, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out datet))
			{
				PhieuNhap pn = new PhieuNhap
				{
					MaNCC = int.Parse(comboBox1.SelectedValue.ToString()),
					NgayNhap = datet,
				};

				int result = await nhaphang_bus.createPhieuNhap(pn);
				if (result == 1)
				{
					MessageBox.Show("Thêm nhập hàng thành công");
				}
				else
				{
					MessageBox.Show("Thêm nhập hàng KHÔNG thành công");
				}
			}
			else
			{
				// Xử lý khi không chuyển đổi được chuỗi sang kiểu DateTime
				// Ví dụ: Hiển thị thông báo lỗi hoặc thực hiện hành động khác tùy thuộc vào trường hợp cụ thể
			}

		}

		private void frm_PhieuNhapHang_Load(object sender, EventArgs e)
		{
			DateTime currentDate = DateTime.Now;
			string formattedDate = currentDate.ToString("dd/MM/yyyy");
			label8.Text = formattedDate;
		}
	}
}
