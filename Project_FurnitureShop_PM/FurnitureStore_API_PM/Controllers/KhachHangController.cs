using FurnitureStore_API_PM.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data.Common;
using System;
using System.ComponentModel;

namespace FurnitureStore_API_PM.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class KhachHangController : ControllerBase
    {
        public readonly IConfiguration _configuration;
        public KhachHangController(IConfiguration configuration)
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
                    return Ok("Kết nối đến MySQL thành công !");
                }
                catch (Exception ex)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Lỗi khi kết nối đến MySQL:" + ex.Message);
                }
            }
        }
        //Get
        [HttpGet]
        public IActionResult GetKhachHang()
        {
            try
            {
                string connectionString = _configuration.GetConnectionString("DefaultConnection");
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = @"SELECT *FROM khachhang";
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataReader dataReader = cmd.ExecuteReader())
                        {
                            List<KhachHang> khachHangs = new List<KhachHang>();
                            while (dataReader.Read())
                            {
                                KhachHang khachHang = new KhachHang
                                {
                                    MaKH = dataReader.GetInt32("MaKH"),
                                    TenKH = dataReader.GetString("TenKH"),
                                    SDT = dataReader.GetString("SDT"),
                                    DiaChi = dataReader.GetString("DiaChi"),
                                    TaiKhoan = dataReader.GetString("TaiKhoan"),
                                    MatKhau = dataReader.GetString("MatKhau")
                                };
                                khachHangs.Add(khachHang);
                            }

                            return Ok(khachHangs);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Lỗi khi truy xuất dữ liệu :" + ex.Message);
            }
        }
        //Post
        [HttpPost]
        public IActionResult CreateKhachHang([FromBody] KhachHang khachHang)
        {
            try
            {
                string connectionString = _configuration.GetConnectionString("DefaultConnection");
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = @"INSERT INTO khachhang(TenKH,SDT,DiaChi,TaiKhoan,MatKhau) VALUES(@TenKH,@SDT,@DiaChi,@TaiKhoan,@MatKhau)";

                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@TenKH", khachHang.TenKH);
                        cmd.Parameters.AddWithValue("@SDT", khachHang.SDT);
                        cmd.Parameters.AddWithValue("@DiaChi", khachHang.TenKH);
                        cmd.Parameters.AddWithValue("@TenKH", khachHang.TenKH);
                        cmd.Parameters.AddWithValue("@TenKH", khachHang.TenKH);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            return Ok("Thêm khách hàng thành công");

                        }
                        else
                        {
                            return StatusCode(StatusCodes.Status500InternalServerError, "Lỗi khi thêm khách hàng ");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Lỗi khi thêm khách hàng: " + ex.Message);
            }

        }
        //Put
        [HttpPost]
        public IActionResult UpdateKhachHang([FromBody] KhachHang khachHang)
        {
            try
            {
                string connectionString = _configuration.GetConnectionString("DefaultConnection");
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = @"UPDATE khachhang SET TenKH=@TenKH, SDT=@SDT, DiaChi=@DiaChi,TaiKhoan=@TaiKhoan, MatKhau=@MatKhau WHERE MaKH=@Id";

                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@TenKH", khachHang.TenKH);
                        cmd.Parameters.AddWithValue("@SDT", khachHang.SDT);
                        cmd.Parameters.AddWithValue("@DiaChi", khachHang.DiaChi);
                        cmd.Parameters.AddWithValue("@TaiKhoan", khachHang.TaiKhoan);
                        cmd.Parameters.AddWithValue("@MatKhau", khachHang.MatKhau);
                        cmd.Parameters.AddWithValue("@Id", khachHang.MaKH);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            return Ok("Khách hàng đã được cập nhật thành công");
                        }
                        else
                        {
                            return StatusCode(StatusCodes.Status500InternalServerError, "Lỗi khi cập nhật khách hàng");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Lỗi khi cập nhật khách hàng : " + ex.Message);
            }
        }
        //Delete
        [HttpDelete]
        public IActionResult DeleteKhachHang(int id)
        {
            try
            {
                string connectionString = _configuration.GetConnectionString("DefaultConnection");
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "DELETE FROM khachhang WHERE MaKH = @Id ";

                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@Id", id);

                        int rowAffected = cmd.ExecuteNonQuery();

                        if (rowAffected > 0)
                        {
                            return Ok("Đã thành công xóa khách hàng");
                        }
                        else
                        {
                            return StatusCode(StatusCodes.Status500InternalServerError, "Lỗi không thể xóa khách hàng");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Lỗi khi xóa khách hàng" + ex.Message);
            }
        }


        [HttpGet]
        public IActionResult GetLoginKhachHang(string account, string password)
        {
            try
            {
                string connectionString = _configuration.GetConnectionString("DefaultConnection");
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = @"SELECT * FROM khachhang WHERE TaiKhoan = @account AND MatKhau = @password";

                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@account", account);
                        cmd.Parameters.AddWithValue("@password", password);

                        using (MySqlDataReader dataReader = cmd.ExecuteReader())
                        {
                            List<KhachHang> khachHangs = new List<KhachHang>();
                            while (dataReader.Read())
                            {
                                KhachHang khachHang = new KhachHang
                                {
                                    MaKH = dataReader.GetInt32("MaKH"),
                                    TenKH = dataReader.GetString("TenKH"),
                                    SDT = dataReader.GetString("SDT"),
                                    DiaChi = dataReader.GetString("DiaChi"),
                                    TaiKhoan = dataReader.GetString("TaiKhoan"),
                                    MatKhau = dataReader.GetString("MatKhau")
                                };
                                khachHangs.Add(khachHang);
                            }

                            return Ok(khachHangs);
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
        public IActionResult ChangePassword(int id, string MatKhau)
        {
            try
            {
                string connectionstring = _configuration.GetConnectionString("DefaultConnection");
                using (MySqlConnection connection = new MySqlConnection(connectionstring))
                {
                    connection.Open();

                    string query = @"UPDATE khachhang SET MatKhau=@MatKhau WHERE MaKH=@Id";

                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {

                        cmd.Parameters.AddWithValue("@MatKhau", MatKhau);
                        cmd.Parameters.AddWithValue("@Id", id);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            return Ok("Mật khẩu đã được cập nhật thành công đã được cập nhật thành công");
                        }
                        else
                        {
                            return StatusCode(StatusCodes.Status500InternalServerError, "Lỗi khi cập nhật khách hàng");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Lỗi khi thay đổi mật khẩu: " + ex.Message);
            }
        }





        [HttpGet]
        public IActionResult GetKhachHangById(int id)
        {
            try
            {
                string connectionString = _configuration.GetConnectionString("DefaultConnection");
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = @"SELECT * FROM khachhang WHERE MaKH = @id";
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        using (MySqlDataReader dataReader = cmd.ExecuteReader())
                        {
                            KhachHang khachHang = new KhachHang();
                            while (dataReader.Read())
                            {
                                khachHang = new KhachHang
                                {
                                    MaKH = dataReader.GetInt32("MaKH"),
                                    TenKH = dataReader.GetString("TenKH"),
                                    SDT = dataReader.GetString("SDT"),
                                    DiaChi = dataReader.GetString("DiaChi"),
                                    TaiKhoan = dataReader.GetString("TaiKhoan"),
                                    MatKhau = dataReader.GetString("MatKhau")
                                };

                            }

                            return Ok(khachHang);
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
        public IActionResult GetOrderByKhachHang(int id)
        {
            try
            {
                string connectionString = _configuration.GetConnectionString("DefaultConnection");
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = @"
                                SELECT d.MaDonHang, d.NgayTao, d.TinhTrang, s.TenSanPham, c.SoLuong, c.DonGia, c.ThanhTien, c.KichCo, c.MauSac
                                FROM donhang d, chitietdonhang c, sanpham s
                                WHERE d.MaKH = @id AND d.MaDonHang = c.MaDH AND s.MaSP = c.MaSP
                                ORDER BY d.MaDonHang DESC"; // Sử dụng DESC để xếp giảm dần

                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        using (MySqlDataReader dataReader = cmd.ExecuteReader())
                        {
                            List<DonHangg> donHangs = new List<DonHangg>();

                            while (dataReader.Read())
                            {
                                DonHangg donHang = new DonHangg
                                {
                                    MaDH = dataReader.GetInt32("MaDonHang"),
                                    NgayTao = dataReader.GetString("NgayTao"),
                                    TinhTrang = dataReader.GetString("TinhTrang"),
                                    TenSanPham=dataReader.GetString("TenSanPham"),
                                    DonGia=dataReader.GetInt32("DonGia"),
                                    SoLuong = dataReader.GetInt32("SoLuong"),
                                    KichCo = dataReader.GetString("KichCo"),
                                    MauSac = dataReader.GetString("MauSac"),
                                    ThanhTien= dataReader.GetInt32("ThanhTien")
                                };

                                donHangs.Add(donHang);
                            }

                            return Ok(donHangs);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Lỗi khi truy xuất dữ liệu: " + ex.Message);
            }
        }



    }

    // các phương thức khác ..........
}



