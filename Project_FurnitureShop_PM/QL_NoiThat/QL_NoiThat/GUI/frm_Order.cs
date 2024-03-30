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
    public partial class frm_Order : Form
    {
        DonHang_BUS dh_bus;
        List<Donhang> donhangs;
        public frm_Order()
        {
            InitializeComponent();
            dh_bus = new DonHang_BUS();
            
            //data_donhang.SelectionChanged += data_donhang_SelectionChanged;
            data_donhang.CellClick += data_donhang_CellClick;
            data_donhang.CellClick += dataGridView_CellClick;
        }

        private void frm_Order_Load(object sender, EventArgs e)
        {
           
            // Khởi tạo ComboBox khi Form được tải lên
            InitializeComboBox();
            // Load danh sách đơn hàng ban đầu (có thể là tất cả các đơn hàng)
            lb_kh.Visible = false; 
            lb_mdh.Visible = false; 
            lb_ngaytao.Visible = false;
            lb_tinhtrang.Visible = false;
            lb_makh.Visible = false;
            loadALlDonHang();
            
            LoadDonHangTheoTinhTrang(cb_tinhtrang.SelectedItem.ToString());
            cb_tinhtrang.SelectedIndexChanged += comboBoxTinhTrang_SelectedIndexChanged;
            //loadALlTinhTrang();
            caphattinhtrang();

        }
        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewRow row = data_donhang.Rows[e.RowIndex];
                lb_mdh.Text = row.Cells["MaDonHang"].Value.ToString();
                lb_ngaytao.Text = row.Cells["NgayTao"].Value.ToString();
                lb_tinhtrang.Text = row.Cells["TinhTrang"].Value.ToString();
                lb_makh.Text = row.Cells["MaKH"].Value.ToString();
                cb_capnhat.Text = row.Cells["TinhTrang"].Value.ToString();
            }
        }
        public async void loadALlDonHang()
        {

            donhangs = await dh_bus.getDonHang();

            data_donhang.DataSource = donhangs;
            data_donhang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            data_donhang.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }

        private void data_donhang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra chỉ số dòng và cột hợp lệ
            if (e.RowIndex >= 0 && e.RowIndex < data_donhang.Rows.Count && e.ColumnIndex >= 0)
            {
                // Xử lý sự kiện
                DataGridViewRow selectedRow = data_donhang.Rows[e.RowIndex];
                string maDonHang = selectedRow.Cells["MaDonHang"].Value?.ToString();
                LoadChiTietDonHang(maDonHang);
            }
        }


        private async Task LoadChiTietDonHang(string maDonHang)
        {
            // Gọi API để lấy chi tiết đơn hàng theo mã đơn hàng
            List<CTDH> chiTietDonHang = await dh_bus.getChiTietDonHang(maDonHang);

            // Hiển thị chi tiết đơn hàng
            data_chitietdonhang.DataSource = chiTietDonHang;
        }

        private void InitializeComboBox()
        {
            // Thêm các tình trạng vào ComboBox
            cb_tinhtrang.Items.Add("");
            cb_tinhtrang.Items.Add("Đang vận chuyển");
            cb_tinhtrang.Items.Add("Đang xử lý");
            cb_tinhtrang.Items.Add("Đã hủy");

            // Chọn mặc định là tất cả
            cb_tinhtrang.SelectedIndex = 0;
            
        }
        private void caphattinhtrang()
        {
            cb_capnhat.Items.Clear();
            // Thêm các tình trạng vào ComboBox
            cb_capnhat.Items.Add("Đang vận chuyển");
            cb_capnhat.Items.Add("Đang xử lý");
            cb_capnhat.Items.Add("Đã hủy");

            // Chọn mặc định là tất cả
            cb_capnhat.SelectedIndex = 0;
            //cb_capnhat.SelectedIndexChanged += btn_capnhat_Click;
        }
        private void comboBoxTinhTrang_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Gọi hàm để load danh sách đơn hàng theo tình trạng được chọn
            LoadDonHangTheoTinhTrang(cb_tinhtrang.SelectedItem.ToString());
        }



        private async void LoadDonHangTheoTinhTrang(string tinhTrang)
        {
            // Gọi API hoặc xử lý dữ liệu để lấy danh sách đơn hàng theo tình trạng
            List<Donhang> donhangs = await dh_bus.getDonHangByTT(tinhTrang);

            // Hiển thị danh sách đơn hàng trong DataGridView hoặc nơi bạn muốn
            data_donhang.DataSource = donhangs;
        }

        //public async void loadALlTinhTrang()
        //{
        //    List<Donhang> phieunhaps = await dh_bus.getDonHang();
        //    cb_capnhat.DataSource = phieunhaps;
        //    cb_capnhat.DisplayMember = "TinhTrang"; // Hiển thị tên sản phẩm
        //    cb_capnhat.ValueMember = "TinhTrang"; // Giá trị thực sự của mục được chọn

        //}
       
        private async void btn_capnhat_Click(object sender, EventArgs e)
        {
            int maDH = 0;

            try
            {
                if (data_donhang.SelectedCells.Count > 0)
                {
                    int selectedRowIndex = data_donhang.SelectedCells[0].RowIndex;
                    maDH = Convert.ToInt32(data_donhang.Rows[selectedRowIndex].Cells[0].Value);
                }

                // Lấy giá trị TinhTrang từ ComboBox (đã được cập nhật khi người dùng chọn)
              
                string tinhTrang = cb_capnhat.SelectedItem?.ToString();
                Console.WriteLine($"Selected TinhTrang: {tinhTrang}");
                Donhang update = new Donhang
                {
                    MaDonHang = maDH,
                    NgayTao = lb_ngaytao.Text,
                    TinhTrang = tinhTrang,
                    MaKH = Convert.ToInt32(lb_makh.Text),
                    TenKhachHang=lb_kh.Text
                    
                };

                bool success = await dh_bus.updateTT(maDH, update);

                if (success)
                {
                    MessageBox.Show("Cập nhật tình trạng thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadALlDonHang();
                }
                else
                {
                    MessageBox.Show("Cập nhật tình trạng thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu cần
            }
        }
       
    }
}

