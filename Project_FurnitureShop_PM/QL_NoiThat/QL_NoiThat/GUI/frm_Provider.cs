using QL_NoiThat.BUS;
using QL_NoiThat.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_NoiThat.GUI
{
    public partial class frm_Provider : Form
    {
        NhaCungCap_BUS ncc_bus;
        public frm_Provider()
        {
            InitializeComponent();
            txtMaNCC.Enabled = false;
            ncc_bus = new NhaCungCap_BUS();
            LoadData();
            dataGridView1.CellClick += dataGridViewNhaCungCap_CellClick;
        }
        private async void LoadData()
        {
           
            List<NhaCungCap_M> ncc = await ncc_bus.getNhaCungCap();
            dataGridView1.DataSource=ncc;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

        }
       
        private void dataGridViewNhaCungCap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                    txtMaNCC.Text = row.Cells["MaNCC"].Value.ToString();
                    txtTenNCC.Text = row.Cells["TenNCC"].Value.ToString();
                    txtSDTNCC.Text = row.Cells["SDTNCC"].Value.ToString();
                    txtDiaChiNCC.Text = row.Cells["DiaChiNCC"].Value.ToString();   
            }
        }
        private async void btn_Them_Click(object sender, EventArgs e)
        {
            try {
                NhaCungCap_M nhaCungCap = new NhaCungCap_M
                {
                    //MaNCC = maNCC,
                    TenNCC = txtTenNCC.Text,
                    SDTNCC = txtSDTNCC.Text,
                    DiaChiNCC = txtDiaChiNCC.Text
                };
                List<NhaCungCap_M> updatedList = await ncc_bus.AddNhaCungCap(nhaCungCap);
                MessageBox.Show($"Thêm thành công nhà cung cấp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                clear();
                LoadData();
            }
               catch(Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm nhà cung cấp: {ex.Message}");
            }   
        }
        private  async void btn_Xoa_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                string maNCCToDelete = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                DialogResult result = MessageBox.Show($"Bạn có chắc muốn xóa nhà cung cấp có mã {maNCCToDelete} không?", "Xác nhận Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    bool deleteSuccess = await ncc_bus.DeleteNhaCungCap(maNCCToDelete);
                    if (deleteSuccess)
                    {
                        LoadData();
                        MessageBox.Show("Xóa nhà cung cấp thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        clear();
                    }
                    else
                    {
                        MessageBox.Show("Không thể xóa nhà cung cấp. Vui lòng thử lại.");
                    }
                }

            }
            else
            {
                MessageBox.Show("Vui lòng chọn một nhà cung cấp để xóa.");
            }
        }

        private async void btn_Sua_Click(object sender, EventArgs e)
        {
            try
            {
                int maNCC = 0;
                if (dataGridView1.SelectedCells.Count > 0)
                {
                    int rowIndex = dataGridView1.SelectedCells[0].RowIndex;
                    maNCC = Convert.ToInt32(dataGridView1.Rows[rowIndex].Cells[0].Value);

                    NhaCungCap_M nhaCungCap = new NhaCungCap_M
                    {
                        MaNCC = maNCC,
                        TenNCC = txtTenNCC.Text,
                        SDTNCC = txtSDTNCC.Text,
                        DiaChiNCC = txtDiaChiNCC.Text
                    };

                    // Gọi hàm sửa
                    bool updatedList = await ncc_bus.UpdateNhaCungCapAsync(maNCC, nhaCungCap);

                    if (updatedList)
                    {
                        // Cập nhật lại danh sách sản phẩm (gọi hàm hiển thị danh sách sản phẩm mới)
                        MessageBox.Show("Cập nhật nhà cung cấp thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData();
                        clear();
                    }
                    else
                    {
                        // Xử lý lỗi nếu cần
                    }
                }
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu cần
            }
            clear();
        }
        private void clear()
        {
            txtMaNCC.Text = "";
            txtTenNCC.Text = "";
            txtSDTNCC.Text = "";
            txtDiaChiNCC.Text = "";
        }
    }
}
