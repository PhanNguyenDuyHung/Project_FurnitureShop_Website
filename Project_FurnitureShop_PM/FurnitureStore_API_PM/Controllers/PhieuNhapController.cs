using FurnitureStore_API_PM.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System.Data;
using System.Reflection.PortableExecutable;
using System.Text.RegularExpressions;

namespace FurnitureStore_API_PM.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class PhieuNhapController : ControllerBase
    {
        public readonly IConfiguration _configuration;
        public PhieuNhapController(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        [HttpGet]
        public IActionResult GetNhaCungCap()
        {
            try
            {
                string connectionString = _configuration.GetConnectionString("DefaultConnection");
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = @"SELECT * FROM  nhacungcap  ";
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataReader dataReader = cmd.ExecuteReader())
                        {
                            List<NhaCungCap> phieunhaps = new List<NhaCungCap>();
                            while (dataReader.Read())
                            {
                                NhaCungCap phieunhap = new NhaCungCap
                                {
                                    MaNCC = dataReader.GetInt32("MaNCC"),
                                    TenNCC = dataReader.GetString("TenNCC"),
                                    SDTNCC = dataReader.GetString("SDTNCC"),
                                    DiaChiNCC = dataReader.GetString("DiaChiNCC")
                                };
                                phieunhaps.Add(phieunhap);
                            }

                            return Ok(phieunhaps);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Lỗi khi truy xuất dữ liệu :" + ex.Message);
            }
        }

        [HttpGet]
        public IActionResult GetNhaCC()
        {
            try
            {
                string connectionString = _configuration.GetConnectionString("DefaultConnection");
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = @"SELECT MaNCC, TenNCC FROM  nhacungcap  ";
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataReader dataReader = cmd.ExecuteReader())
                        {
                            List<NhaCC> phieunhaps = new List<NhaCC>();
                            while (dataReader.Read())
                            {
                                NhaCC phieunhap = new NhaCC
                                {
                                    MaNCC = dataReader.GetInt32("MaNCC"),
                                    TenNCC = dataReader.GetString("TenNCC"),
                                };
                                phieunhaps.Add(phieunhap);
                            }

                            return Ok(phieunhaps);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Lỗi khi truy xuất dữ liệu :" + ex.Message);
            }
        }

        [HttpGet]
        public IActionResult GetSanPhambyNCC(int maNCC)
        {
            try
            {
                string connectionString = _configuration.GetConnectionString("DefaultConnection");

                // Chuỗi truy vấn SQL
                string query = @"
                    SELECT DISTINCT
                        SP.MaSP,
                        SP.TenSanPham,
                        SP.SoLuongTon
                    FROM
                        sanpham SP
                    JOIN
                        ghinhannhaphang CTH ON SP.MaSP = CTH.MaSP
                    JOIN
                        nhaphang NH ON CTH.MaNhapHang = NH.MaNhapHang
                    WHERE
                        NH.MaNCC = @MaNCC;
                ";

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        // Thêm tham số MaNCC vào truy vấn
                        cmd.Parameters.AddWithValue("@MaNCC", maNCC);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            List<SanPhamm> results = new List<SanPhamm>();

                            while (reader.Read())
                            {
                                SanPhamm phieunhap = new SanPhamm
                                {
                                    MaSP = reader.GetInt32("MaSP"),
                                    TenSanPham = reader.GetString("TenSanPham"),
                                    SoLuongTon = reader.GetInt32("SoLuongTon")

                                };
                                results.Add(phieunhap);
                            }

                            return Ok(results);

                        }



                        // Trả về kết quả


                    }
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Lỗi khi truy xuất dữ liệu: " + ex.Message);
            }
        }


        [HttpGet]
        public IActionResult GetNCC_PhieuNhapbyIDNCC(int maNCC)
        {
            try
            {
                string connectionString = _configuration.GetConnectionString("DefaultConnection");
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = @"SELECT * FROM nhaphang n, nhacungcap c WHERE n.MaNCC = c.MaNCC and c.MaNCC=@MaNCC ";
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@MaNCC", maNCC);
                        using (MySqlDataReader dataReader = cmd.ExecuteReader())
                        {
                            List<PhieuNhapHT> phieunhaps = new List<PhieuNhapHT>();
                            while (dataReader.Read())
                            {
                                PhieuNhapHT phieunhap = new PhieuNhapHT
                                {
                                    MaNhapHang = dataReader.GetInt32("MaNhapHang"),
                                    NgayNhap = dataReader.GetString("NgayNhap"),
                                    TenNCC = dataReader.GetString("TenNCC"),
                                    SDT = dataReader.GetString("SDTNCC"),
                                    TongTien = dataReader.GetDecimal("TongTien")
                                };
                                phieunhaps.Add(phieunhap);
                            }

                            return Ok(phieunhaps);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Lỗi khi truy xuất dữ liệu :" + ex.Message);
            }
        }

        [HttpGet]
        public IActionResult Get_ChiTietPhieuNhapbyIDMaNhapHang(int maNhapHang)
        {
            try
            {
                string connectionString = _configuration.GetConnectionString("DefaultConnection");
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = @"SELECT * FROM nhaphang n, ghinhannhaphang ct, sanpham s WHERE s.MaSP = ct.MaSP and n.MaNhapHang = ct.MaNhapHang and ct.MaNhapHang=@MaNhapHang";
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@MaNhapHang", maNhapHang);
                        using (MySqlDataReader dataReader = cmd.ExecuteReader())
                        {
                            List<ChiTietPN> phieunhaps = new List<ChiTietPN>();
                            while (dataReader.Read())
                            {
                                ChiTietPN phieunhap = new ChiTietPN
                                {
                                    MaThongKeNhap = dataReader.GetInt32("MaThongKeNhap"),
                                    MaSP = dataReader.GetInt32("MaSP"),
                                    TenSanPham = dataReader.GetString("TenSanPham"),
                                    SoLuong = dataReader.GetInt32("SoLuong"),
                                    DonGiaNhap = dataReader.GetInt32("DonGiaNhap"),
                                    MaNhapHang = dataReader.GetInt32("MaNhapHang")

                                };
                                phieunhaps.Add(phieunhap);
                            }

                            return Ok(phieunhaps);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Lỗi khi truy xuất dữ liệu :" + ex.Message);
            }
        }

        [HttpPost]
        public IActionResult CreateCTPN([FromBody] CreateChiTietPN sanPham)
        {
            try
            {
                string connectionString = _configuration.GetConnectionString("DefaultConnection");
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = @"INSERT INTO ghinhannhaphang (MaSP, SoLuong, DonGiaNhap, GhiChu, MaNhapHang )
                             VALUES (@masp, @soluong, @dongianhap, @ghichu, @manhaphang)";

                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@masp", sanPham.MaSP);
                        cmd.Parameters.AddWithValue("@soluong", sanPham.SoLuong);
                        cmd.Parameters.AddWithValue("@dongianhap", sanPham.DonGiaNhap);
                        cmd.Parameters.AddWithValue("@ghichu", "");
                        cmd.Parameters.AddWithValue("@manhaphang", sanPham.MaNhapHang);


                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            return Ok("Sản phẩm đã được tạo thành công.");
                        }
                        else
                        {
                            return StatusCode(StatusCodes.Status500InternalServerError, "Lỗi khi tạo sản phẩm.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Lỗi khi thêm sản phẩm: " + ex.Message);
            }
        }

        [HttpPost]
        public IActionResult UpdateCTPN([FromBody] UpdateChiTietPN updateCTPN)
        {
            try
            {
                string connectionString = _configuration.GetConnectionString("DefaultConnection");
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = @"UPDATE ghinhannhaphang SET DonGiaNhap=@DonGiaNhap, SoLuong=@SoLuong WHERE MaThongKeNhap=@MaThongKeNhap and MaSP=@MaSP";

                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@DonGiaNhap", updateCTPN.DonGiaNhap);
                        cmd.Parameters.AddWithValue("@SoLuong", updateCTPN.SoLuong);
                        cmd.Parameters.AddWithValue("@MaThongKeNhap", updateCTPN.MaThongKeNhap);
                        cmd.Parameters.AddWithValue("@MaSP", updateCTPN.MaSP);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            return Ok("Chi tiết nhập hàng đã được cập nhật thành công");
                        }
                        else
                        {
                            return StatusCode(StatusCodes.Status500InternalServerError, "Lỗi khi cập nhật chi tiết nhập hàng");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Lỗi khi thêm sản phẩm: " + ex.Message);
            }

        }


        [HttpDelete]
        public IActionResult DeleteCTPN(int idphieunhap, int idchitietphieunhap)
        {
            try
            {
                string connectionString = _configuration.GetConnectionString("DefaultConnection");
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "DELETE FROM ghinhannhaphang WHERE MaThongKeNhap  = @Idctpn AND MaNhapHang=@idpn ";

                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@Idctpn", idchitietphieunhap);
                        cmd.Parameters.AddWithValue("idpn", idphieunhap);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            return Ok("Sản phẩm đã được xóa thành công.");
                        }
                        else
                        {
                            return StatusCode(StatusCodes.Status500InternalServerError, "Lỗi khi xóa sản phẩm.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Lỗi khi xóa sản phẩm: " + ex.Message);
            }
        }

        [HttpPost]
        public IActionResult CreatePN([FromBody] PhieuNhap_date phieunhap)
        {
            try
            {
                string connectionString = _configuration.GetConnectionString("DefaultConnection");
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = @"INSERT INTO nhaphang (NgayNhap, MaNCC)
                             VALUES (@ngaynhap, @mancc)";

                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@ngaynhap", phieunhap.NgayNhap);
                        cmd.Parameters.AddWithValue("@mancc", phieunhap.MaNCC);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            return Ok("Phiếu nhập đã được tạo thành công.");
                        }
                        else
                        {
                            return StatusCode(StatusCodes.Status500InternalServerError, "Lỗi khi tạo phiếu nhập.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Lỗi khi thêm phiếu: " + ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetMaxMaNCC()
        {
            try
            {
                string connectionString = _configuration.GetConnectionString("DefaultConnection");
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT MAX(MaSP) AS Max FROM sanpham";

                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        object result = cmd.ExecuteScalar();

                        if (result != null && result != DBNull.Value)
                        {
                            int maxMaNhapHang = Convert.ToInt32(result);
                            maxMaNhapHang++;
                            return Ok(maxMaNhapHang);
                        }
                        else
                        {
                            return StatusCode(StatusCodes.Status500InternalServerError, "Lỗi khi truy vấn");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Lỗi khi: " + ex.Message);
            }
        }

        [HttpGet]
        public IActionResult get_Sanpham_SoLuong()
        {
            try
            {
                string connectionString = _configuration.GetConnectionString("DefaultConnection");
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = @" SELECT DISTINCT TenSanPham, SoluongTon FROM sanpham ";
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataReader dataReader = cmd.ExecuteReader())
                        {
                            List<SanPham_Sl> phieunhaps = new List<SanPham_Sl>();
                            while (dataReader.Read())
                            {
                                SanPham_Sl phieunhap = new SanPham_Sl
                                {
                                    TenSanPham = dataReader.GetString("TenSanPham"),
                                    SoLuongTon = dataReader.GetInt32("SoLuongTon")
                                };
                                phieunhaps.Add(phieunhap);
                            }

                            return Ok(phieunhaps);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Lỗi khi truy xuất dữ liệu :" + ex.Message);
            }


        }

        [HttpGet]
        public IActionResult get_Sanpham_SoLuong_max()
        {
            try
            {
                string connectionString = _configuration.GetConnectionString("DefaultConnection");
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = @" SELECT DISTINCT TenSanPham, SoluongTon FROM sanpham ORDER BY SoluongTon DESC ";
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataReader dataReader = cmd.ExecuteReader())
                        {
                            List<SanPham_Sl> phieunhaps = new List<SanPham_Sl>();
                            while (dataReader.Read())
                            {
                                SanPham_Sl phieunhap = new SanPham_Sl
                                {
                                    TenSanPham = dataReader.GetString("TenSanPham"),
                                    SoLuongTon = dataReader.GetInt32("SoLuongTon")
                                };
                                phieunhaps.Add(phieunhap);
                            }

                            return Ok(phieunhaps);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Lỗi khi truy xuất dữ liệu :" + ex.Message);
            }
        }

        [HttpGet]
        public IActionResult get_Sanpham_SoLuong_min()
        {
            try
            {
                string connectionString = _configuration.GetConnectionString("DefaultConnection");
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = @" SELECT DISTINCT TenSanPham, SoluongTon FROM sanpham ORDER BY SoluongTon ASC ";
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataReader dataReader = cmd.ExecuteReader())
                        {
                            List<SanPham_Sl> phieunhaps = new List<SanPham_Sl>();
                            while (dataReader.Read())
                            {
                                SanPham_Sl phieunhap = new SanPham_Sl
                                {
                                    TenSanPham = dataReader.GetString("TenSanPham"),
                                    SoLuongTon = dataReader.GetInt32("SoLuongTon")
                                };
                                phieunhaps.Add(phieunhap);
                            }

                            return Ok(phieunhaps);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Lỗi khi truy xuất dữ liệu :" + ex.Message);
            }
        }


        [HttpGet]
        public IActionResult get_spBanchay()
        {
            try
            {
                string connectionString = _configuration.GetConnectionString("DefaultConnection");

                // Chuỗi truy vấn SQL
                string query = @"
                   SELECT DISTINCT MaSP, SoLuong
                        FROM chitietdonhang
                        ORDER BY SoLuong DESC
                ";

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            List<SanPham_banchay> results = new List<SanPham_banchay>();

                            while (reader.Read())
                            {
                                SanPham_banchay phieunhap = new SanPham_banchay
                                {
                                    MaSP = reader.GetInt32("MaSP"),
                                    SoLuongTon = reader.GetInt32("SoLuong")
                                };
                                results.Add(phieunhap);
                            }

                            return Ok(results);

                        }



                        // Trả về kết quả


                    }
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Lỗi khi truy xuất dữ liệu: " + ex.Message);
            }

        }

        [HttpGet]
        public IActionResult GetGiaBanbyYear(int nam)
        {
            try
            {

                string connectionString = _configuration.GetConnectionString("DefaultConnection");

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();


                    // Chuỗi truy vấn SQL
                    string query = @"
                        SELECT SUM(chitietdonhang.DonGia) AS doanhso
                        FROM chitietdonhang
                        INNER JOIN donhang ON chitietdonhang.maCTHD = donhang.MaDonHang
                        WHERE YEAR(donhang.NgayTao) = @nam";

                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@nam", nam);

                        object result = cmd.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            int ds = Convert.ToInt32(result);
                            ds++; // Bạn có thể xử lý giá trị ở đây nếu cần thiết
                            return Ok(ds);
                        }
                        else
                        {
                            return StatusCode(StatusCodes.Status500InternalServerError, "Lỗi khi truy vấn");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Lỗi khi: " + ex.Message);
            }
        }


        [HttpGet]
        public IActionResult GetGiaBanbyMonth(int nam)
        {
            try
            {

                string connectionString = _configuration.GetConnectionString("DefaultConnection");

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();


                    // Chuỗi truy vấn SQL
                    string query = @"
                               SELECT MONTH(donhang.NgayTao) AS Thang, SUM(chitietdonhang.DonGia) AS TongDonGia
                                        FROM chitietdonhang
                                        JOIN donhang ON chitietdonhang.MaDH = donhang.MaDonHang
                                        WHERE YEAR(donhang.NgayTao) = @nam
                                        GROUP BY MONTH(donhang.NgayTao)";


                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@nam", nam);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            List<doanhso> results = new List<doanhso>();

                            while (reader.Read())
                            {
                                doanhso ds = new doanhso
                                {
                                    Thang = reader.GetInt32("Thang"),
                                    DonGia = reader.GetInt32("TongDonGia")

                                };
                                results.Add(ds);
                            }

                            return Ok(results);

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Lỗi khi: " + ex.Message);
            }
        }

        [HttpGet]
        public IActionResult GetGiaBanbyQuarter(int nam)
        {
            try
            {
                string connectionString = _configuration.GetConnectionString("DefaultConnection");

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = @"
                SELECT 
                    (CASE 
                        WHEN MONTH(donhang.NgayTao) BETWEEN 1 AND 3 THEN 'Quý 1'
                        WHEN MONTH(donhang.NgayTao) BETWEEN 4 AND 6 THEN 'Quý 2'
                        WHEN MONTH(donhang.NgayTao) BETWEEN 7 AND 9 THEN 'Quý 3'
                        ELSE 'Quý 4'
                     END) AS Quy,
                    SUM(chitietdonhang.DonGia) AS TongDonGia
                    FROM chitietdonhang
                    JOIN donhang ON chitietdonhang.MaDH = donhang.MaDonHang
                    WHERE YEAR(donhang.NgayTao) = @nam
                    GROUP BY 
                    (CASE 
                        WHEN MONTH(donhang.NgayTao) BETWEEN 1 AND 3 THEN 'Quý 1'
                        WHEN MONTH(donhang.NgayTao) BETWEEN 4 AND 6 THEN 'Quý 2'
                        WHEN MONTH(donhang.NgayTao) BETWEEN 7 AND 9 THEN 'Quý 3'
                        ELSE 'Quý 4'
                     END)";

                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@nam", nam);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            List<doanhsoquy> results = new List<doanhsoquy>();

                            while (reader.Read())
                            {
                                doanhsoquy ds = new doanhsoquy
                                {
                                    Quy = reader.GetString("Quy"),
                                    DonGia = reader.GetInt32("TongDonGia")
                                };
                                results.Add(ds);
                            }

                            return Ok(results);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Lỗi khi: " + ex.Message);
            }
        }

        [HttpPost]
        public IActionResult checkLogin([FromBody] user userLogin)
        {
            try
            {
                string connectionString = _configuration.GetConnectionString("DefaultConnection");

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT COUNT(*) FROM taikhoan WHERE name = @Name AND password = @Password";

                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@Name", userLogin.name);
                        cmd.Parameters.AddWithValue("@Password", userLogin.pass);

                        int count = Convert.ToInt32(cmd.ExecuteScalar());

                        if (count > 0)
                        {
                            return Ok("Đăng nhập thành công");
                        }
                        else
                        {
                            return BadRequest("Đăng nhập không hợp lệ");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Lỗi khi: " + ex.Message);
            }
        }


    }
}

