using System.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using WebsiteNoiThat.Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Text;

namespace WebsiteNoiThat.Controllers
{
    public class AccountController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:7053/api");
        private readonly HttpClient _client;
        public AccountController()
        {
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;

        }


        public async Task<ActionResult> logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("index", "home");
        }


        public async Task<ActionResult> Login(string currentUrl)
        {
            HttpContext.Session.SetString("returnCurrentUrl", currentUrl);
            
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Login(string account1, string pass1)
        {
            HttpResponseMessage response = await _client.GetAsync(_client.BaseAddress + $"/KhachHang/GetLoginKhachHang?account={account1}&password={pass1}");

            if (response.IsSuccessStatusCode)
            {
                List<KhachHang> listKH = new List<KhachHang>(); 
                string data = await response.Content.ReadAsStringAsync();
                if(data != "[]")
                {
                    listKH = JsonConvert.DeserializeObject<List<KhachHang>>(data);
                    HttpContext.Session.SetString("IDCustomer", listKH[0].MaKH.ToString());

                    string url = HttpContext.Session.GetString("returnCurrentUrl");

                    return Redirect(url);
                }
                else
                {
                    ViewBag.UserName = "Tài khoản hoặc mật khẩu sai";
                    return View();
                }
                
            }
           

            return View();
        }



        [HttpGet]
        public async Task<ActionResult> AccountDetails(int id)
        {
            HttpResponseMessage response = await _client.GetAsync(_client.BaseAddress + $"/KhachHang/GetKhachHangById?id={id}");
            KhachHang khach = new KhachHang();
            if (response.IsSuccessStatusCode)
            {
                string data = await response.Content.ReadAsStringAsync();
                khach = JsonConvert.DeserializeObject<KhachHang>(data);
            }
            return View(khach);
        }

        [HttpPost]
        public async Task<ActionResult> UpdateAccount(string TenKH, int MaKH, string Sdt, string TaiKhoan, string MatKhau, string DiaChi)
        {
            KhachHang khach = new KhachHang
            {
                MaKH = MaKH,
                TenKH = TenKH,
                DiaChi = DiaChi,
                SDT = Sdt,
                TaiKhoan = TaiKhoan,
                MatKhau = MatKhau,
            };
            var content = new StringContent(JsonConvert.SerializeObject(khach), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _client.PostAsync(_client.BaseAddress + "/KhachHang/UpdateKhachHang", content);
            if (response.IsSuccessStatusCode)
            {
                // Cập nhật thành công
                var result = await response.Content.ReadAsStringAsync();
                // result chứa thông báo thành công từ API
                SetAlert("Cập nhật thông tin cá nhân thành công", "success");
                return RedirectToAction("AccountDetails", "Account", new { id = khach.MaKH });
            }
            else
            {
                // Xử lý lỗi
                SetAlert("Cập nhật thông tin cá nhân thất bại", "error");
                return RedirectToAction("AccountDetails", "Account", new { id = khach.MaKH });
            }
        }
        [HttpPost]
        public async Task<ActionResult> UpdatePassword(int MaKH, string MatKhauMoi)
        {
            HttpResponseMessage response = await _client.GetAsync(_client.BaseAddress + $"/KhachHang/ChangePassword?id={MaKH}&MatKhau={MatKhauMoi}");

            if (response.IsSuccessStatusCode)
            {
                string data = await response.Content.ReadAsStringAsync();
                if (data != "[]")
                {
                    SetAlert("Thay đổi mật khẩu thành công", "success");
                    return RedirectToAction("AccountDetails", "Account", new { id = MaKH });
                }
                else
                {
                    SetAlert("Thay đổi mật khẩu thất bại", "error");
                    return RedirectToAction("AccountDetails", "Account", new { id = MaKH });
                }
            }
            else
            {
                SetAlert("Thay đổi mật khẩu thất bại", "error");
                return RedirectToAction("AccountDetails", "Account", new { id = MaKH });
            }
        }
        [HttpGet]
        public async Task<ActionResult> GetOrderByKhachHang(int MaKH)
        {
            HttpResponseMessage response = await _client.GetAsync(_client.BaseAddress + $"/khachhang/GetOrderByKhachHang?id={MaKH}");
            List<DonHangg> donHangs = new List<DonHangg>();
            if (response.IsSuccessStatusCode)
            {

                string data = await response.Content.ReadAsStringAsync();
                if (data != "[]")
                {
                    donHangs = JsonConvert.DeserializeObject<List<DonHangg>>(data);
                }
                else
                {
                    ViewBag.ThongBao = "BẠN KHÔNG CÓ ĐƠN HÀNG";
                    return View();
                }
            }
            return View(donHangs);
        }

        public void SetAlert(string message, string type)
        {
            TempData["AlertMessage"] = message;
            if (type == "success")
            {
                TempData["AlertType"] = "success";
            }
            else
            {
                if (type == "error")
                {
                    TempData["AlertType"] = "error";
                }
                else
                {
                    if (type == "failed")
                    {
                        TempData["AlertType"] = "failed";
                    }
                }
            }
        }



    }
}

