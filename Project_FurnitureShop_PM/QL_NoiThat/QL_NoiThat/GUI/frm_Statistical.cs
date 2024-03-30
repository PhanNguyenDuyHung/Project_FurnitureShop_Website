using Newtonsoft.Json;
using QL_NoiThat.BUS;
using QL_NoiThat.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace QL_NoiThat.GUI
{
    public partial class frm_Statistical : Form
    {
		NhapHang_BUS nhaphang_bus;
		private System.Windows.Forms.ToolTip tooltip = new System.Windows.Forms.ToolTip();
		private Timer hideTimer = new Timer();

        public frm_Statistical()
        {
			nhaphang_bus = new NhapHang_BUS();
            InitializeComponent();
			loadchart();
        }

        public async void loadchart()
        {
			List<SanPham_Sl> phieunhaps = await nhaphang_bus.getSP_SL();

			// Gán dữ liệu cho biểu đồ
			chart1.Series.Clear();
			chart1.Series.Add("Số lượng tồn kho");
			chart1.Series["Số lượng tồn kho"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;

			// Thêm dữ liệu vào biểu đồ
			foreach (var phieunhap in phieunhaps)
			{
				// Thêm dữ liệu vào biểu đồ với tên sản phẩm làm nhãn
				chart1.Series["Số lượng tồn kho"].Points.AddXY(phieunhap.TenSanPham, phieunhap.SoLuongTon);
			}

			// Đảm bảo các nhãn trên trục x hiển thị đầy đủ
			chart1.ChartAreas[0].AxisX.Interval = 1;
			chart1.ChartAreas[0].AxisX.LabelStyle.Angle = -45;

		}


		private async void frm_Statistical_Load(object sender, EventArgs e)
		{
			dateTimePicker1.Format = DateTimePickerFormat.Custom;
			dateTimePicker1.CustomFormat = "dd/mm/yyyy";
		}
		private void chart1_MouseClick(object sender, MouseEventArgs e)
		{
			var pos = e.Location;
			var results = chart1.HitTest(pos.X, pos.Y, false,
										 System.Windows.Forms.DataVisualization.Charting.ChartElementType.DataPoint);

			foreach (var result in results)
			{
				if (result.ChartElementType == System.Windows.Forms.DataVisualization.Charting.ChartElementType.DataPoint)
				{
					var prop = result.Object as System.Windows.Forms.DataVisualization.Charting.DataPoint;
					if (prop != null)
					{
						int columnIndex = (int)prop.XValue;

						// Hiển thị số lượng tồn khi click vào cột
						tooltip.Show("" + prop.YValues[0], chart1, pos.X, pos.Y - 15);

						// Ẩn tooltip sau 5 giây
						hideTimer.Interval = 5000;
						hideTimer.Tick += (s, args) =>
						{
							tooltip.Hide(chart1);
							hideTimer.Stop();
						};
						hideTimer.Start();
					}
				}
			}
		}

		private async void btn_max_Click(object sender, EventArgs e)
		{
			List<SanPham_Sl> phieunhaps = await nhaphang_bus.getSP_SL_max();


			// Gán dữ liệu cho biểu đồ
			chart1.Series.Clear();
			chart1.Series.Add("Số lượng tồn kho");
			chart1.Series["Số lượng tồn kho"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;


			// Thêm dữ liệu vào biểu đồ
			foreach (var phieunhap in phieunhaps)
			{
				chart1.Series["Số lượng tồn kho"].Points.AddXY(phieunhap.TenSanPham, phieunhap.SoLuongTon);
			}
			// Đảm bảo các nhãn trên trục x hiển thị đầy đủ
			chart1.ChartAreas[0].AxisX.Interval = 1;
			chart1.ChartAreas[0].AxisX.LabelStyle.Angle = -45;
			label1.Text = "THỐNG KÊ SẢN PHẨM TỒN KHO GIẢM DẦN";
			dataGridView1.DataSource = null;
		}


		
		private void chart1_MouseMove(object sender, MouseEventArgs e)
		{
			
		}

		

		private async void btn_min_Click(object sender, EventArgs e)
		{
			List<SanPham_Sl> phieunhaps = await nhaphang_bus.getSP_SL_min();


			// Gán dữ liệu cho biểu đồ
			chart1.Series.Clear();
			chart1.Series.Add("Số lượng tồn kho");
			chart1.Series["Số lượng tồn kho"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;


			// Thêm dữ liệu vào biểu đồ
			foreach (var phieunhap in phieunhaps)
			{
				chart1.Series["Số lượng tồn kho"].Points.AddXY(phieunhap.TenSanPham, phieunhap.SoLuongTon);
			}
			// Đảm bảo các nhãn trên trục x hiển thị đầy đủ
			chart1.ChartAreas[0].AxisX.Interval = 1;
			chart1.ChartAreas[0].AxisX.LabelStyle.Angle = -45;
			label1.Text = "THỐNG KÊ SẢN PHẨM TỒN KHO TĂNG DẦN";
			dataGridView1.DataSource = null;
		}

		private async void button1_Click(object sender, EventArgs e)
		{
			List<SanPham_banchay> phieunhaps = await nhaphang_bus.spbanchay();


			// Gán dữ liệu cho biểu đồ
			chart1.Series.Clear();
			chart1.Series.Add("Số lượng bán");
			chart1.Series["Số lượng bán"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;

			// Thêm dữ liệu vào biểu đồ
			foreach (var phieunhap in phieunhaps)
			{
				if(phieunhap.SoLuongTon >0)
				{ 
				chart1.Series["Số lượng bán"].Points.AddXY(phieunhap.MaSP, phieunhap.SoLuongTon);
				}
			}
			// Đảm bảo các nhãn trên trục x hiển thị đầy đủ
			chart1.ChartAreas[0].AxisX.Interval = 1;
			chart1.ChartAreas[0].AxisX.LabelStyle.Angle = 45;
			label1.Text = "THỐNG KÊ SẢN PHẨM BÁN RA";

			List<SanPham> sp = await nhaphang_bus.getsp();
			dataGridView1.DataSource = sp;


		}

		private async void btn_ds_Click(object sender, EventArgs e)
		{
			// Lấy giá trị từ DateTimePicker
			DateTime selectedDate = dateTimePicker1.Value;

			// Lấy năm từ giá trị đã chọn
			int year = selectedDate.Year;


			List<doanhso> phieunhaps = await nhaphang_bus.doanhso(year);


			// Gán dữ liệu cho biểu đồ
			chart1.Series.Clear();
			chart1.Series.Add("Doanh số theo tháng");
			chart1.Series["Doanh số theo tháng"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;


			// Thêm dữ liệu vào biểu đồ
			foreach (var phieunhap in phieunhaps)
			{
				chart1.Series["Doanh số theo tháng"].Points.AddXY("Tháng "+phieunhap.Thang, phieunhap.DonGia);
			}
			// Đảm bảo các nhãn trên trục x hiển thị đầy đủ
			chart1.ChartAreas[0].AxisX.Interval = 1;
			chart1.ChartAreas[0].AxisX.LabelStyle.Angle = -45;
			label1.Text = "THỐNG KÊ DOANH SỐ THÁNG THEO CÁC THÁNG TRONG NĂM";
			dataGridView1.DataSource = null;

		}

		private async void btn_dsQuy_Click(object sender, EventArgs e)
		{
			// Lấy giá trị từ DateTimePicker
			DateTime selectedDate = dateTimePicker1.Value;

			// Lấy năm từ giá trị đã chọn
			int year = selectedDate.Year;


			List<doanhsoquy> phieunhaps = await nhaphang_bus.doanhsoquy(year);


			// Gán dữ liệu cho biểu đồ
			chart1.Series.Clear();
			chart1.Series.Add("Doanh số theo quý");
			chart1.Series["Doanh số theo quý"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;


			// Thêm dữ liệu vào biểu đồ
			foreach (var phieunhap in phieunhaps)
			{
				chart1.Series["Doanh số theo quý"].Points.AddXY(phieunhap.Quy, phieunhap.DonGia);
			}
			// Đảm bảo các nhãn trên trục x hiển thị đầy đủ
			chart1.ChartAreas[0].AxisX.Interval = 1;
			chart1.ChartAreas[0].AxisX.LabelStyle.Angle = -45;
			label1.Text = "THỐNG KÊ DOANH SỐ THÁNG THEO CÁC QÚY TRONG NĂM";
			dataGridView1.DataSource = null;

		}
	}
}
