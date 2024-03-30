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
using System.Xml.Linq;

namespace QL_NoiThat.GUI
{
    public partial class frm_Product : Form
    {
        SanPham_BUS sp_bus;
        public frm_Product()
        {
            InitializeComponent();
            sp_bus = new SanPham_BUS();
            txt_masp.Enabled = false;
            LoadData();
            loadChatLieu();
            loadLoaiHang();
            loadXuatXu(); 
            data_SP.CellClick += dataGridView_CellClick;
        }
        private async void LoadData()
        {
           
                List<SanPham_Model> spData = await sp_bus.getSanPham();
                data_SP.DataSource = spData;
                data_SP.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                data_SP.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }
        public async void loadChatLieu()
        {
            List<ChatLieu_Model> chatLieu = await sp_bus.getChatLieu();
            cb_chatlieu.DataSource = chatLieu;
            cb_chatlieu.DisplayMember = "TenChatLieu"; // Hiển thị tên chất liệu
            cb_chatlieu.ValueMember = "MaChatLieu"; // Giá trị thực sự của mục được chọn

        }
        public async void loadXuatXu()
        {
            List<XuatXu_Model> xuatXus = await sp_bus.getXuatXu();
            cb_xuatxu.DataSource = xuatXus;
            cb_xuatxu.DisplayMember = "TenXuatXu"; // Hiển thị tên xuất xứ 
            cb_xuatxu.ValueMember = "MaXuatXu"; // Giá trị thực sự của mục được chọn

        }
        public async void loadLoaiHang()
        {
            List<Loai_Model> loaiHangs = await sp_bus.getLoai();
            cb_loai.DataSource = loaiHangs;
            cb_loai.DisplayMember = "TenLoai"; // Hiển thị tên loại
            cb_loai.ValueMember = "MaLoai"; // Giá trị thực sự của mục được chọn

        }
       
        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewRow row = data_SP.Rows[e.RowIndex];

                    txt_masp.Text = row.Cells["MaSP"].Value.ToString();
                    txt_tensp.Text = row.Cells["TenSanPham"].Value.ToString();
                    txt_gia.Text = row.Cells["GiaBan"].Value.ToString();
                    txt_mota.Text = row.Cells["MoTa"].Value.ToString();
                    txt_hinh.Text = row.Cells["Hinh1"].Value.ToString();
                    txt_mausac.Text = row.Cells["MauSac"].Value.ToString();
                    txt_soluong.Text = row.Cells["SoLuongTon"].Value.ToString();
                    txt_kichthuoc.Text = row.Cells["KichThuoc"].Value.ToString();
                    cb_loai.Text= row.Cells["MaLoai"].Value.ToString();  //txt_loai.Text
                    cb_chatlieu.Text= row.Cells["MaChatLieu"].Value.ToString(); //txt_chatlieu.Text
                    cb_xuatxu.Text= row.Cells["MaXuatXu"].Value.ToString(); //txt_xuatxu.Text


            }
        }
        private async void btn_them_Click(object sender, EventArgs e)
        {
            try
            {
                // Tạo đối tượng SanPham_Model từ các trường nhập liệu
                SanPham_Model sanPham = new SanPham_Model
                {
                    //MaSP = Convert.ToInt32(txt_masp.Text),
                    TenSanPham = txt_tensp.Text,
                    GiaBan = Convert.ToDecimal(txt_gia.Text),
                    MoTa = txt_mota.Text,
                    Hinh1 = txt_hinh.Text,
                    MauSac = txt_mausac.Text,
                    SoLuongTon = Convert.ToInt32(txt_soluong.Text),
                    KichThuoc = txt_mota.Text,
                    MaLoai = Convert.ToInt32(cb_loai.SelectedValue),
                    MaChatLieu = Convert.ToInt32(cb_chatlieu.SelectedValue),
                    MaXuatXu = Convert.ToInt32(cb_xuatxu.SelectedValue)
                    // Thêm các trường khác tương ứng
                };
                // Gọi phương thức thêm từ lớp BUS
                List<SanPham_Model> updatedList = await sp_bus.AddSanPham(sanPham);
                MessageBox.Show($"Thêm thành công sản phẩm","Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                clear();
                 LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm sản phẩm: {ex.Message}");
            }
        }
       

        private async void btn_xoa_Click(object sender, EventArgs e)
        {
            if (data_SP.SelectedRows.Count > 0)
            {
                string maSPToDelete = data_SP.SelectedRows[0].Cells[0].Value.ToString();

                DialogResult result = MessageBox.Show($"Bạn có chắc muốn xóa sản phẩm có mã {maSPToDelete} không?", "Xác nhận Xóa", MessageBoxButtons.YesNo,MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Thực hiện xóa thông qua Business Layer
                    bool deleteSuccess = await sp_bus.DeleteProductAsync(maSPToDelete);

                    if (deleteSuccess)
                    {
                       LoadData();
                        MessageBox.Show("Xóa sản phẩm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        clear();
                    }
                    else
                    {
                        MessageBox.Show("Không thể xóa sản phẩm. Vui lòng thử lại.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một sản phẩm để xóa.");
            }

        }

        private async void btn_sua_Click(object sender, EventArgs e)
        {
            int maSP = 0;
           
            try
            {
                if (data_SP.SelectedCells.Count > 0)
                { int selectedRowIndex = data_SP.SelectedCells[0].RowIndex;
                    maSP = Convert.ToInt32(data_SP.Rows[selectedRowIndex].Cells[0].Value);
                }

                SanPham_Model updatedProduct = new SanPham_Model
                {
                    MaSP = maSP,
                    TenSanPham = txt_tensp.Text,
                    GiaBan = decimal.Parse(txt_gia.Text),
                    MauSac = txt_mausac.Text,
                    MoTa = txt_mota.Text,
                    SoLuongTon = int.Parse(txt_soluong.Text),
                    Hinh1 = txt_hinh.Text,
                    KichThuoc = txt_kichthuoc.Text,
                    //MaLoai = int.Parse(txt_loai.Text),
                    //MaXuatXu = int.Parse(txt_xuatxu.Text),
                    //MaChatLieu = int.Parse(txt_chatlieu.Text)
                    MaLoai = Convert.ToInt32(cb_loai.SelectedValue), // Lấy giá trị từ ComboBox Loai
                    MaChatLieu = Convert.ToInt32(cb_chatlieu.SelectedValue), // Lấy giá trị từ ComboBox ChatLieu
                    MaXuatXu = Convert.ToInt32(cb_xuatxu.SelectedValue) // Lấy giá trị từ ComboBox XuatXu
                };

                bool success = await sp_bus.UpdateProductAsync(maSP.ToString(), updatedProduct);

                if (success)
                {
                    // Cập nhật lại danh sách sản phẩm (gọi hàm hiển thị danh sách sản phẩm mới)
                    MessageBox.Show("Cập nhật sản phẩm thành công","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    LoadData();
                    clear();
                }
                else
                {
                    // Xử lý lỗi nếu cần
                }
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu cần
            }
            clear();
        }

        private void frm_Product_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        public void clear()
        {
            txt_masp.Text = "";
            txt_tensp.Text = "";
            txt_gia.Text = "";
            txt_mota.Text = "";
            txt_soluong.Text = "";
            txt_hinh.Text="";
            txt_mausac.Text = "";
            txt_kichthuoc.Text="";
            cb_loai.Text="";
            cb_xuatxu.Text="";
            cb_chatlieu.Text = "";

        }
    }
}
