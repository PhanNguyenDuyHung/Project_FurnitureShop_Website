using FurnitureStore_API_PM.DTO;
using FurnitureStore_API_PM.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System.Text.RegularExpressions;

namespace FurnitureStore_API_PM.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class GiohangController : ControllerBase
    {

        private readonly IConfiguration _configuration;
        private readonly string _sqlDataSource;

        public GiohangController(IConfiguration configuration)
        {
            _configuration = configuration;
            _sqlDataSource = _configuration.GetConnectionString("DefaultConnection");
        }
        //Get
        [HttpGet]
        public IActionResult Index(int idKH)
        {
            try
            {
                string connectionString = _configuration.GetConnectionString("DefaultConnection");
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = @"SELECT  sanpham.soluongton as soluongton, chitietgiohang.MaSP as masp, giohang.MaGH as magh,chitietgiohang.kichthuoc as kichthuoc, giohang.makh as makh, chitietgiohang.mactgh as mactgh ,chitietgiohang.Soluong as soluong, sanpham.TenSanPham as tensp, sanpham.GiaBan as giaban, chitietgiohang.Mausac as mausac, sanpham.Hinh1 as hinh1 FROM  giohang inner join chitietgiohang on giohang.MaGH = chitietgiohang.MaGH
inner join sanpham on sanpham.MaSP = chitietgiohang.MaSP
 Where giohang.MaKH = @idKH"; //
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@idKH", idKH);
                        using (MySqlDataReader dataReader = cmd.ExecuteReader())
                        {
                            List<GioHang> giohangs = new List<GioHang>();
                            List<ChiTietGH> chitietGHs = new List<ChiTietGH>();
                            while (dataReader.Read())
                            {
                                
                                ChiTietGH chitietGH = new ChiTietGH
                                {
                                    MACTGH = dataReader.GetInt32("mactgh"),
                                    MaGH = dataReader.GetInt32("magh"),
                                    TenSP = dataReader.GetString("tensp"),
                                    Soluong = dataReader.GetInt32("soluong"),
                                    Mausac = dataReader.GetString("mausac"),
                                    Dongia = dataReader.GetDouble("giaban"),
                                    Hinh1 = dataReader.GetString("hinh1"),
                                    Kichthuoc = dataReader.GetString("kichthuoc"),
                                    MaSP = dataReader.GetInt32("masp"),
                                    Soluongton = dataReader.GetInt32("soluongton")
                                };

                                chitietGHs.Add(chitietGH);
                            }

                            return Ok(chitietGHs);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Lỗi khi truy xuất dữ liệu: " + ex.Message);
            }
        }

        
        [HttpPut]
        public IActionResult Update([FromBody] object updateCTGH){
            try
            {
                string connectionString = _configuration.GetConnectionString("DefaultConnection");
                UpdateCTGHDTO u = new UpdateCTGHDTO();
				var up = JsonConvert.DeserializeAnonymousType(updateCTGH.ToString(), u);
				using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = @"Update chitietgiohang set soluong=@soluong Where chitietgiohang.mactgh = @mactgh"; //
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@soluong", up.Soluong);
                        cmd.Parameters.AddWithValue("@mactgh", up.Mactgh);
                        
                        using (MySqlDataReader dataReader = cmd.ExecuteReader())
                        {
                            return Ok();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Lỗi khi truy xuất dữ liệu: " + ex.Message);
            }
        }

		
        [HttpDelete]
		public IActionResult Delete(int mactgh, int idKH)
		{
			try
			{
				string connectionString = _configuration.GetConnectionString("DefaultConnection");
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = @"delete from chitietgiohang Where chitietgiohang.mactgh = @mactgh"; //
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@mactgh", mactgh);

                        using (MySqlDataReader dataReader = cmd.ExecuteReader())
                        {
                            return Index(idKH);
                        }
                    }
                }

            }
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, "Lỗi khi truy xuất dữ liệu: " + ex.Message);
			}
		}


        //Get
        [HttpPost]
        public IActionResult Checkout([FromBody] object checkout)
        {
            try
            {
                Donhang dhobj = new Donhang();
                var donhang = JsonConvert.DeserializeAnonymousType(checkout.ToString(), dhobj);

                long madh = 0;
                string connectionString = _configuration.GetConnectionString("DefaultConnection");


                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = @"INSERT INTO donhang (NgayTao, TinhTrang, MaKH) VALUES
                    ( @ngaytao, @tinhtrang, @makh)";
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                       
                        cmd.Parameters.AddWithValue("@ngaytao", donhang.NgayTao);
                        cmd.Parameters.AddWithValue("@tinhtrang", donhang.TinhTrang);
                        cmd.Parameters.AddWithValue("@makh", donhang.MaKH);
                        cmd.ExecuteNonQuery();
                        madh = cmd.LastInsertedId;
                    }
                    //chi tiet don hang
                    query = @"INSERT INTO chitietdonhang (MaCTHD, SoLuong, DonGia, ThanhTien, KichCo, MauSac, MaDH, MaSP) VALUES ";
                    for (int i = 0; i < donhang.chiTietDonHang.Count - 1; i++)
                    {
                        query += $"(@MaCTHD{i}, @SoLuong{i}, @DonGia{i}, @ThanhTien{i}, @KichCo{i}, @MauSac{i}, @MaDH{i}, @MaSP{i}),";
                    }
                    query += $"(@MaCTHD{donhang.chiTietDonHang.Count - 1}, @SoLuong{donhang.chiTietDonHang.Count - 1}, @DonGia{donhang.chiTietDonHang.Count - 1}, @ThanhTien{donhang.chiTietDonHang.Count - 1}, @KichCo{donhang.chiTietDonHang.Count - 1}, @MauSac{donhang.chiTietDonHang.Count - 1}, @MaDH{donhang.chiTietDonHang.Count - 1}, @MaSP{donhang.chiTietDonHang.Count - 1})";

                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        for (int i = 0; i < donhang.chiTietDonHang.Count; i++)
                        {
                            cmd.Parameters.AddWithValue($"@MaCTHD{i}", donhang.chiTietDonHang[i].MaCTHD);
                            cmd.Parameters.AddWithValue($"@SoLuong{i}", donhang.chiTietDonHang[i].SoLuong);
                            cmd.Parameters.AddWithValue($"@DonGia{i}", donhang.chiTietDonHang[i].DonGia);
                            cmd.Parameters.AddWithValue($"@ThanhTien{i}", donhang.chiTietDonHang[i].ThanhTien);
                            cmd.Parameters.AddWithValue($"@KichCo{i}", donhang.chiTietDonHang[i].KichCo);
                            cmd.Parameters.AddWithValue($"@MauSac{i}", donhang.chiTietDonHang[i].MauSac);
                            cmd.Parameters.AddWithValue($"@MaDH{i}", madh);
                            cmd.Parameters.AddWithValue($"@MaSP{i}", donhang.chiTietDonHang[i].MaSP);
                        }
                        cmd.ExecuteNonQuery();
                        
                    }
                    //xoa gio hang
                    query = @"delete from chitietgiohang where mactgh in (@mactghs)";
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        List<int> mactghs = new List<int>();
                        for (int i = 0; i < donhang.chiTietDonHang.Count; i++)
                        {
                            mactghs.Add(donhang.chiTietDonHang[i].MaCTGH);

                        }
                        
                        cmd.Parameters.AddWithValue($"@mactghs",string.Join(", ", mactghs));
                        cmd.ExecuteNonQuery();

                    }
                    return Ok();
                }

                }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Lỗi khi truy xuất dữ liệu: " + ex.Message);
            }
        }



        [HttpGet]
        public IActionResult GetGioHang()
        {
            string query = "SELECT * FROM giohang";
            List<GioHang> listGH = new List<GioHang>();
            using (MySqlConnection mycon = new MySqlConnection(_sqlDataSource))
            {
                mycon.Open();

                using (MySqlCommand myCommand = new MySqlCommand(query, mycon))
                {
                    using (MySqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        while (myReader.Read())
                        {
                            GioHang gioHang = new GioHang
                            {
                                MaGH = myReader.GetInt32("MaKH"),
                                MaKH = myReader.GetInt32("MaKH")

                            };
                            listGH.Add(gioHang);
                        }
                    }
                }
            }
            return Ok(listGH);
        }

        [HttpGet]
        public IActionResult GetGioHangById(int magh)
        {
            string query = @"SELECT * FROM giohang WHERE giohang.MaGH = @magh";
            List<GioHang> listGH = new List<GioHang>();
            using (MySqlConnection mycon = new MySqlConnection(_sqlDataSource))
            {
                mycon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, mycon))
                {
                    myCommand.Parameters.AddWithValue("@magh", magh);
                    using (MySqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        while (myReader.Read())
                        {
                            GioHang gioHang = new GioHang
                            {
                                MaGH = myReader.GetInt32("MaKH"),
                                MaKH = myReader.GetInt32("MaKH")
                            };
                            listGH.Add(gioHang);
                        }
                    }
                }
            }
            return Ok(listGH);
        }
        [HttpGet]
        public IActionResult GetGioHangByMaKH(int makh)
        {
            string query = @"SELECT * FROM giohang WHERE giohang.MaKH = @makh";
            List<GioHang> listGH = new List<GioHang>();
            using (MySqlConnection mycon = new MySqlConnection(_sqlDataSource))
            {
                mycon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, mycon))
                {
                    myCommand.Parameters.AddWithValue("@makh", makh);
                    using (MySqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        while (myReader.Read())
                        {
                            GioHang gioHang = new GioHang
                            {
                                MaGH = myReader.GetInt32("MaGH"),
                                MaKH = myReader.GetInt32("MaKH")
                            };
                            listGH.Add(gioHang);
                        }
                    }
                }
            }
            return Ok(listGH);
        }
        [HttpGet]
        public IActionResult GetChiTietGioHangByIdGioHang(int magh)
        {
            string query = @"SELECT * FROM chitietgiohang WHERE MaGH = @magh";
            using (MySqlConnection mycon = new MySqlConnection(_sqlDataSource))
            {
                mycon.Open();

                using (MySqlCommand myCommand = new MySqlCommand(query, mycon))
                {
                    myCommand.Parameters.AddWithValue("@magh", magh);
                    using (MySqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        List<ChiTietGioHang> listCTGH = new List<ChiTietGioHang>();
                        while (myReader.Read())
                        {
                            if (myReader.GetInt32("MaGH") == magh)
                            {
                                ChiTietGioHang ctgh = new ChiTietGioHang
                                {
                                    MaCTGH = myReader.GetInt32("MaCTGH"),
                                    ThanhTien = !myReader.IsDBNull(myReader.GetOrdinal("Thanhtien")) ? myReader.GetDecimal("Thanhtien") : 0,
                                    SoLuong = myReader.GetInt32("Soluong"),
                                    Dongia = myReader.GetDecimal("Dongia"),
                                    MauSac = myReader.GetString("Mausac"),
                                    MaGH = myReader.GetInt32("MaGH"),
                                    MaSP = myReader.GetInt32("MaSP")
                                };
                                listCTGH.Add(ctgh);
                            }

                        }
                        return Ok(listCTGH);
                    }
                }
            }

        }
        [HttpGet]
        public IActionResult GetChiTietGioHang()
        {
            string query = @"SELECT * FROM chitietgiohang ";
            using (MySqlConnection mycon = new MySqlConnection(_sqlDataSource))
            {
                mycon.Open();

                using (MySqlCommand myCommand = new MySqlCommand(query, mycon))
                {
                    using (MySqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        List<ChiTietGioHang> listCTGH = new List<ChiTietGioHang>();
                        while (myReader.Read())
                        {
                            ChiTietGioHang ctgh = new ChiTietGioHang
                            {
                                MaCTGH = myReader.GetInt32("MaCTGH"),
                                ThanhTien = !myReader.IsDBNull(myReader.GetOrdinal("Thanhtien")) ? myReader.GetDecimal("Thanhtien") : 0,
                                SoLuong = myReader.GetInt32("Soluong"),
                                Dongia = myReader.GetDecimal("Dongia"),
                                MauSac = myReader.GetString("Mausac"),
                                KichThuoc = myReader.GetString("KichThuoc"),
                                MaGH = myReader.GetInt32("MaGH"),
                                MaSP = myReader.GetInt32("MaSP")
                            };
                            listCTGH.Add(ctgh);
                        }
                        return Ok(listCTGH);
                    }
                }
            }

        }

        [HttpPost]
        public IActionResult CreateCTGH1(ChiTietGioHang ctgioHang)
        {
            string query = @"INSERT INTO chitietgiohang(Thanhtien, Soluong, Dongia, Mausac, KichThuoc, MaGH, MaSP) VALUES (@thanhtien, @soluong, @dongia, @mausac, @kichthuoc, @magh, @masp)";
            string connectionString = _configuration.GetConnectionString("DefaultConnection");
            using (MySqlConnection mycon = new MySqlConnection(connectionString))
            {
                mycon.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, mycon))
                {
                    cmd.Parameters.AddWithValue("@thanhtien", ctgioHang.ThanhTien);
                    cmd.Parameters.AddWithValue("@soluong", ctgioHang.SoLuong);
                    cmd.Parameters.AddWithValue("@dongia", ctgioHang.Dongia);
                    cmd.Parameters.AddWithValue("@mausac", ctgioHang.MauSac);
                    cmd.Parameters.AddWithValue("@magh", ctgioHang.MaGH);
                    cmd.Parameters.AddWithValue("@masp", ctgioHang.MaSP);
                    cmd.Parameters.AddWithValue("@kichthuoc", ctgioHang.KichThuoc);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        return Ok("Chi tiết giỏ hàng mới đã được tạo thành công.");
                    }
                    else
                    {
                        return StatusCode(StatusCodes.Status500InternalServerError, "Lỗi khi thêm sản phẩm vào giỏ hàng.");
                    }
                }
            }
        }
        [HttpPost]
        public IActionResult CreateCTGH(decimal Dongia, string MauSac, int MaGH, int MaSP)
        {
            string query = @"INSERT INTO chitietgiohang(Thanhtien, Soluong, Dongia, Mausac, MaGH, MaSP) VALUES (@thanhtien, @soluong, @dongia, @mausac, @magh, @masp)";
            string connectionString = _configuration.GetConnectionString("DefaultConnection");
            using (MySqlConnection mycon = new MySqlConnection(connectionString))
            {
                mycon.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, mycon))
                {
                    cmd.Parameters.AddWithValue("@thanhtien", Dongia);
                    cmd.Parameters.AddWithValue("@soluong", 1);
                    cmd.Parameters.AddWithValue("@dongia", Dongia);
                    cmd.Parameters.AddWithValue("@mausac", MauSac);
                    cmd.Parameters.AddWithValue("@magh", MaGH);
                    cmd.Parameters.AddWithValue("@masp", MaSP);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        return Ok("Chi tiết giỏ hàng mới đã được tạo thành công.");
                    }
                    else
                    {
                        return StatusCode(StatusCodes.Status500InternalServerError, "Lỗi khi thêm sản phẩm vào giỏ hàng.");
                    }
                }
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteGioHang(int id)
        {
            string query = @"DELETE FROM giohang WHERE MaGH = @MaGH";


            using (MySqlConnection mycon = new MySqlConnection(_sqlDataSource))
            {
                mycon.Open();

                using (MySqlCommand myCommand = new MySqlCommand(query, mycon))
                {
                    myCommand.Parameters.AddWithValue("@MaGH", id);

                    int rowsAffected = myCommand.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        return Ok();
                    }
                    else
                    {
                        return NotFound();
                    }
                }
            }
        }
    }
}
