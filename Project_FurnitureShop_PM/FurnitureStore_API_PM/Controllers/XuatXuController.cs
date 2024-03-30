﻿using FurnitureStore_API_PM.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System.Data;

namespace FurnitureStore_API_PM.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class XuatXuController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public XuatXuController(IConfiguration configuration)
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
        public IActionResult GetXuatXu()
        {
            string query = @"SELECT MaXuatXu, TenXuatXu FROM xuatxu";

            List<XuatXu> xuatXus = new List<XuatXu>();

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
                            XuatXu xuatxu = new XuatXu
                            {
                                MaXuatXu = myReader.GetInt32("MaXuatXu"),
                                TenXuatXu = myReader.GetString("TenXuatXu")
                            };
                            xuatXus.Add(xuatxu);
                        }
                    }
                }
            }
            return Ok(xuatXus);
        }



        [HttpGet]
        public IActionResult GetHinh()
        {
            string query = @"SELECT * FROM sanpham";

            List<string> hinhs = new List<string>();

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
                           
                            hinhs.Add(myReader.GetString("Hinh1"));
                        }
                    }
                }
            }
            return Ok(hinhs);
        }




        [HttpGet]
        public IActionResult GetSanPhambyidHinh(string idHinh)
        {
            try
            {
                string connectionString = _configuration.GetConnectionString("DefaultConnection");
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = @"SELECT * FROM sanpham WHERE Hinh1=@id";
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@id", idHinh);
                        using (MySqlDataReader dataReader = cmd.ExecuteReader())
                        {
                            List<SanPham> sanPhams = new List<SanPham>();

                            while (dataReader.Read())
                            {
                                SanPham sanPham = new SanPham
                                {
                                    MaSP = dataReader.GetInt32("MaSP"),
                                    GiaBan = dataReader.GetDecimal("GiaBan"),
                                    TenSanPham = dataReader.GetString("TenSanPham"),
                                    MauSac = dataReader.GetString("MauSac"),
                                    MoTa = dataReader.GetString("MoTa"),
                                    SoLuongTon = dataReader.GetInt32("SoLuongTon"),
                                    Hinh1 = !dataReader.IsDBNull(dataReader.GetOrdinal("Hinh1")) ? dataReader.GetString("Hinh1") : "default_path.jpg",
                                    Hinh2 = !dataReader.IsDBNull(dataReader.GetOrdinal("Hinh2")) ? dataReader.GetString("Hinh2") : "default_path.jpg",
                                    Hinh3 = !dataReader.IsDBNull(dataReader.GetOrdinal("Hinh3")) ? dataReader.GetString("Hinh3") : "default_path.jpg",
                                    KichThuoc = dataReader.GetString("KichThuoc"),
                                    MaLoai = dataReader.GetInt32("MaLoai"),
                                    MaXuatXu = dataReader.GetInt32("MaXuatXu"),
                                    MaChatLieu = dataReader.GetInt32("MaChatLieu")
                                };

                                sanPhams.Add(sanPham);
                            }

                            return Ok(sanPhams);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Lỗi khi truy xuất dữ liệu: " + ex.Message);
            }
        }






        [HttpPost]
        public IActionResult PostXuatXu([FromBody] XuatXu xuatXu)
        {
            if (xuatXu == null)
            {
                return BadRequest("Không có dữ liệu xuất xứ");
            }

            string query = @"INSERT INTO xuatxu (maXuatXu, tenXuatXu) VALUES (@maXuatXu, @tenXuatXu)";

            using (MySqlConnection mycon = new MySqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                mycon.Open();

                using (MySqlCommand myCommand = new MySqlCommand(query, mycon))
                {
                    myCommand.Parameters.AddWithValue("@maXuatXu", xuatXu.MaXuatXu);
                    myCommand.Parameters.AddWithValue("@tenXuatXu", xuatXu.TenXuatXu);

                    using (MySqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        if (myReader.HasRows)
                        {
                            return Ok("Xuất xứ được thêm thành công!");
                        }
                        else
                        {
                            return BadRequest("Không thể thêm xuất xứ.");
                        }
                    }
                }
            }
        }




        
        [HttpDelete]
        public IActionResult DeleteXuatXu(int maXuatXu)
        {
            if (maXuatXu == 0)
            {
                return BadRequest("Mã xuất xứ không hợp lệ.");
            }

            string query = @"DELETE FROM xuatxu WHERE maXuatXu = @maXuatXu";

            using (MySqlConnection mycon = new MySqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                mycon.Open();

                using (MySqlCommand myCommand = new MySqlCommand(query, mycon))
                {
                    myCommand.Parameters.AddWithValue("@maXuatXu", maXuatXu);

                    int result = myCommand.ExecuteNonQuery();

                    if (result == 1)
                    {
                        return Ok("Xuất xứ đã được xóa thành công!");
                    }
                    else
                    {
                        return NotFound("Xuất xứ không tồn tại.");
                    }
                }
            }
        }

        
        [HttpPut]
        public IActionResult PutXuatXu(int maXuatXu, [FromBody] XuatXu xuatXu)
        {
            if (xuatXu == null)
            {
                return BadRequest("Không có dữ liệu xuất xứ");
            }

            string query = @"UPDATE xuatxu SET tenXuatXu = @tenXuatXu WHERE maXuatXu = @maXuatXu";

            using (MySqlConnection mycon = new MySqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                mycon.Open();

                using (MySqlCommand myCommand = new MySqlCommand(query, mycon))
                {
                    myCommand.Parameters.AddWithValue("@maXuatXu", maXuatXu);
                    myCommand.Parameters.AddWithValue("@tenXuatXu", xuatXu.TenXuatXu);

                    int result = myCommand.ExecuteNonQuery();

                    if (result == 1)
                    {
                        return Ok("Xuất xứ được cập nhật thành công!");
                    }
                    else
                    {
                        return BadRequest("Không thể cập nhật xuất xứ.");
                    }
                }
            }
        }
    }
}
