using FurnitureStore_API_PM.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System.Text.RegularExpressions;
using System.Data;
using System;

namespace FurnitureStore_API_PM.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class NhaCungCapController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public NhaCungCapController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet("checkconnection")]
        public IActionResult CheckConnection()
        {
            string connectionString = _configuration.GetConnectionString("DefaultConnection");
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    return Ok("Kết nối đến MySQL thành công!");
                }
                catch (Exception ex)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Lỗi khi kết nối đến MySQL: " + ex.Message);
                }
            }
        }
        [HttpGet]
        public IActionResult GetNhaCungCap()
        {
            string query = @"SELECT MaNCC, TenNCC, SDTNCC,DiaChiNCC FROM nhacungcap";

            List<NhaCungCap> nhaCungs = new List<NhaCungCap>();

            string sqlDataSource = _configuration.GetConnectionString("DefaultConnection");

            using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
            {
                mycon.Open();

                using (MySqlCommand myCommand = new MySqlCommand(query, mycon))
                {
                    using (MySqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        while (myReader.Read())
                        {
                            NhaCungCap nhaCungCap = new NhaCungCap
                            {
                                MaNCC = myReader.GetInt32("MaNCC"),
                                TenNCC = myReader.GetString("TenNCC"),
                                SDTNCC = myReader.GetString("SDTNCC"),
                                DiaChiNCC = myReader.GetString("DiaChiNCC"),
                            };
                            nhaCungs.Add(nhaCungCap);
                        }
                    }
                }
            }
            return Ok(nhaCungs);
        }



        [HttpPost]
        public IActionResult PostNhaCungCap([FromBody] NhaCungCap nhaCungCap)
        {
            if (nhaCungCap == null)
            {
                return BadRequest("Không có dữ liệu ");
            }
            try {
                using (MySqlConnection mycon = new MySqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    mycon.Open();

                    string query = @"INSERT INTO nhacungcap (MaNCC, TenNCC, SDTNCC, DiaChiNCC) VALUES (@MaNCC, @TenNCC, @SDTNCC, @DiaChiNCC)";

                    using (MySqlCommand myCommand = new MySqlCommand(query, mycon))
                    {
                        myCommand.Parameters.AddWithValue("@MaNCC", nhaCungCap.MaNCC);
                        myCommand.Parameters.AddWithValue("@TenNCC", nhaCungCap.TenNCC);
                        myCommand.Parameters.AddWithValue("@SDTNCC", nhaCungCap.SDTNCC);
                        myCommand.Parameters.AddWithValue("@DiaChiNCC", nhaCungCap.DiaChiNCC);

                        int rowsAffected = myCommand.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            return Ok("Nhà cung cấp được thêm thành công!");
                        }
                        else
                        {
                            return StatusCode(StatusCodes.Status500InternalServerError, "Không thể thêm Nhà cung cấp.");
                        }
                    }
                }
            }catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Lỗi khi thêm nhà cung cấp: " + ex.Message);
            }
          }



       
        [HttpDelete("{maNCC}")]
        public IActionResult DeleteNhaCungCap(int maNCC)
        {
            try
            {
                string connectionString = _configuration.GetConnectionString("DefaultConnection");
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    using (MySqlConnection mycon = new MySqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                    {
                        mycon.Open();
                        string query = @"DELETE FROM nhacungcap WHERE MaNCC = @MaNCC";

                        using (MySqlCommand myCommand = new MySqlCommand(query, mycon))
                        {
                            myCommand.Parameters.AddWithValue("@MaNCC", maNCC);

                            int result = myCommand.ExecuteNonQuery();

                            if (result > 0)
                            {
                                return Ok("Nhà cung cấp đã được xóa thành công!");
                            }
                            else
                            {
                                return StatusCode(StatusCodes.Status500InternalServerError, "Lỗi khi xóa nhà cung cấp.");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Lỗi khi xóa nhà cung cấp: " + ex.Message);
            }
        }
        [HttpPut]
        public IActionResult PutNhaCungCap(int maNCC, [FromBody] NhaCungCap nhaCungCap)
        {
            if (nhaCungCap == null)
            {
                return BadRequest("Không có dữ liệu Nhà cung cấp");
            }

            string query = @"UPDATE nhacungcap SET TenNCC = @TenNCC,SDTNCC=@SDTNCC,DiaChiNCC=@DiaChiNCC WHERE MaNCC = @MaNCC";

            using (MySqlConnection mycon = new MySqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                mycon.Open();

                using (MySqlCommand myCommand = new MySqlCommand(query, mycon))
                {
                    myCommand.Parameters.AddWithValue("@MaNCC", maNCC);
                    myCommand.Parameters.AddWithValue("@TenNCC", nhaCungCap.TenNCC);
                    myCommand.Parameters.AddWithValue("@SDTNCC", nhaCungCap.SDTNCC);
                    myCommand.Parameters.AddWithValue("@DiaChiNCC", nhaCungCap.DiaChiNCC);

                    int result = myCommand.ExecuteNonQuery();

                    if (result == 1)
                    {
                        return Ok("Nhà cung cấp được cập nhật thành công!");
                    }
                    else
                    {
                        return BadRequest("Không thể cập nhật Nhà cung cấp.");
                    }
                }
            }
        }

        /*Donhang*/
        [HttpGet]
        public IActionResult GetDonHang()
        {
            string query = @"SELECT d.MaDonHang , d.NgayTao, d.TinhTrang, d.MaKH, k.TenKH FROM donhang d, khachhang k WHERE d.MaKH = k.MaKH";

            List<Donhangg> nhaCungs = new List<Donhangg>();

            string sqlDataSource = _configuration.GetConnectionString("DefaultConnection");

            using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
            {
                mycon.Open();

                using (MySqlCommand myCommand = new MySqlCommand(query, mycon))
                {
                    using (MySqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        while (myReader.Read())
                        {
                            Donhangg nhaCungCap = new Donhangg
                            {   MaDonHang = myReader.GetInt32("MaDonHang"),
                                NgayTao= myReader.GetString("NgayTao"),
                                TinhTrang = myReader.GetString("TinhTrang"),
                                MaKH = myReader.GetInt32("MaKH"),
                                TenKhachHang = myReader.GetString("TenKH"),

                               
                            };
                            nhaCungs.Add(nhaCungCap);
                        }
                    }
                }
            }
            return Ok(nhaCungs);
        }
        [HttpGet]
        public IActionResult GetDonHangByTinhTrang(string tinhTrang)
        {
            string query = @"SELECT
                                    dh.MaDonHang,
                                    dh.NgayTao,
                                    dh.TinhTrang,
                                    dh.MaKH,
                                    kh.TenKH
                                FROM
                                    donhang dh, khachhang kh
                                WHERE
                                    dh.MaKH = kh.MaKH AND dh.TinhTrang = @TinhTrang;";

            List<Donhangg> nhaCungs = new List<Donhangg>();

            string sqlDataSource = _configuration.GetConnectionString("DefaultConnection");

            using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
            {
                mycon.Open();

                using (MySqlCommand myCommand = new MySqlCommand(query, mycon))
                {
                    myCommand.Parameters.AddWithValue("@TinhTrang", tinhTrang);
                    using (MySqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        while (myReader.Read())
                        {
                            Donhangg nhaCungCap = new Donhangg
                            {
                                MaDonHang = myReader.GetInt32("MaDonHang"),
                                NgayTao = myReader.GetString("NgayTao"),
                                TinhTrang = myReader.GetString("TinhTrang"),
                                MaKH = myReader.GetInt32("MaKH"),
                                TenKhachHang = myReader.GetString("TenKH"),
                            };
                            nhaCungs.Add(nhaCungCap);
                        }
                    }
                }
            }
            return Ok(nhaCungs);
        }

        [HttpGet]
        public IActionResult GetDonHangByMaDH(string maDonHang)
        {
            string query = @"SELECT
                                        dh.MaDonHang,
                                        dh.NgayTao,
                                        dh.TinhTrang,
                                        dh.MaKH,
                                        kh.TenKH
                                    FROM
                                        donhang dh, khachhang kh
                                    WHERE
                                        dh.MaKH = kh.MaKH AND dh.MaDonHang = @Madonhang;";

            List<Donhangg> nhaCungs = new List<Donhangg>();

            string sqlDataSource = _configuration.GetConnectionString("DefaultConnection");

            using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
            {
                mycon.Open();

                using (MySqlCommand myCommand = new MySqlCommand(query, mycon))
                {
                    myCommand.Parameters.AddWithValue("@Madonhang", maDonHang);
                    using (MySqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        while (myReader.Read())
                        {
                            Donhangg nhaCungCap = new Donhangg
                            {
                                MaDonHang = myReader.GetInt32("MaDonHang"),
                                NgayTao = myReader.GetString("NgayTao"),
                                TinhTrang = myReader.GetString("TinhTrang"),
                                MaKH = myReader.GetInt32("MaKH"),
                                TenKhachHang = myReader.GetString("TenKH"),
                            };
                            nhaCungs.Add(nhaCungCap);
                        }
                    }
                }
            }
            return Ok(nhaCungs);
        }
        /**/

        [HttpGet]
        public IActionResult GetChiTietDonHang(int maDonHang)
        {
            string query = @"SELECT 
                                    c.MaCTHD,
                                    c.SoLuong,
                                    c.DonGia,
                                    c.ThanhTien,
                                    c.KichCo,
                                    c.MauSac,
                                    c.MaDH,
                                    c.MaSP,
                                    s.TenSanPham
                                FROM 
                                    chitietdonhang c
                                JOIN 
                                    sanpham s ON c.MaSP = s.MaSP
                                JOIN 
                                    donhang d ON c.MaDH = d.MaDonHang
                                WHERE
                                    d.MaDonHang = @MaDonHang;";
                              

            List<ChiTietDonHangg> ctdh = new List<ChiTietDonHangg>();

            string sqlDataSource = _configuration.GetConnectionString("DefaultConnection");

            using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
            {
                mycon.Open();
               
                using (MySqlCommand myCommand = new MySqlCommand(query, mycon))
                {
                    myCommand.Parameters.AddWithValue("@MaDonHang", maDonHang);
                    using (MySqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        while (myReader.Read())
                        {
                            ChiTietDonHangg nhaCungCap = new ChiTietDonHangg
                            {
                                MaCTHD = myReader.GetInt32("MaCTHD"),
                                SoLuong = myReader.GetInt32("SoLuong"),
                                DonGia =myReader.GetInt32("DonGia"),
                                ThanhTien=myReader.GetInt32("ThanhTien"),
                                KichCo=myReader.GetString("KichCo"),
                                MauSac=myReader.GetString("MauSac"),
                                MaDH=myReader.GetInt32("MaDH"),
                                MaSP=myReader.GetInt32("MaSP"),
                                TenSanPham=myReader.GetString("TenSanPham")
                                
                            };
                            ctdh.Add(nhaCungCap);
                        }
                    }
                }
            }
            return Ok(ctdh);
        }
        [HttpPut]
        public IActionResult UpdateTinhTrang(int MaDH,[FromBody] Donhangg request)
        {
            try
            {
                string connectionString = _configuration.GetConnectionString("DefaultConnection");
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = @"UPDATE donhang SET TinhTrang=@NewTinhTrang WHERE MaDonHang=@MaDonHang";

                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@MaDonHang", MaDH);
                        cmd.Parameters.AddWithValue("@NewTinhTrang", request.TinhTrang);
   
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            return Ok("Cập nhật tình trạng đơn hàng thành công");
                        }
                        else
                        {
                            return NotFound($"Không tìm thấy đơn hàng với mã {MaDH}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Lỗi khi cập nhật tình trạng đơn hàng: {ex.Message}");
            }
        }
    
    }
}
