using Microsoft.AspNetCore.Mvc;
using System.Web;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using System;
using System.Drawing;
using System.IO;
using Newtonsoft.Json;
using WebsiteNoiThat.Models;

namespace WebsiteNoiThat.Controllers
{
    public class AIController : Controller
    {


        Uri baseAddress = new Uri("https://localhost:7053/api");
        private readonly HttpClient _client;
        public AIController()
        {
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;

        }

        public IActionResult Index()
        {
            return View();
        }

        
        [HttpPost]
        public  async Task<ActionResult> UploadImage(IFormFile file)
        {
            string fileName = Path.GetFileName(file.FileName);
            
            List<SanPham> sp =await load(fileName);

            return View(sp);
        }

        async Task<List<SanPham>> load (string a)
        {
            List<SanPham> sp = await search(a);
            return sp;
        }


        // C:\Users\admin\Desktop\Project_FurnitureShop_PM\Project_FurnitureShop_PM\WebsiteNoiThat\wwwroot\Images\product-image\
        async Task<List<SanPham>> search(string img1)
        {
            string url = @"C:\Users\admin\Downloads\hihi\Project_FurnitureShop_PM\Project_FurnitureShop_PM\WebsiteNoiThat\wwwroot\Images\product-image";
            List<string> imageList = await getImagesAsync();

            string a = Path.Combine(url, img1);
            Mat inputImage = CvInvoke.Imread(a, ImreadModes.Color);

            List<byte[]> imageBytesList = new List<byte[]>();
            foreach (var imageName in imageList)
            {
                string fullPath = Path.Combine(url, imageName);
                Mat image = CvInvoke.Imread(fullPath, ImreadModes.Color);
                CvInvoke.Resize(image, image, new Size(inputImage.Width, inputImage.Height));
                byte[] imageBytes = ImageToByteArray(image);
                imageBytesList.Add(imageBytes);
            }

            byte[] inputImageBytes = ImageToByteArray(inputImage);

            string mostSimilarImage = await FindMostSimilarImageAsync(inputImageBytes, imageBytesList);
            Console.WriteLine("Most Similar Image: " + mostSimilarImage);
           List<SanPham> sanpham= await LoadSanPhambyImgAsync(int.Parse(mostSimilarImage));
            return sanpham;
        }

        //https://localhost:7053/api/XuatXu/GetSanPhambyidHinh?idHinh=fdgdfg

        public async Task<List<SanPham>> LoadSanPhambyImgAsync (int index)
        {
            List<string> imageList = await getImagesAsync();
            string hinh = imageList[index];


            HttpResponseMessage response = await _client.GetAsync(_client.BaseAddress + $"/XuatXu/GetSanPhambyidHinh?idHinh={hinh}");
            List<SanPham> listSP = new List<SanPham>();
            if (response.IsSuccessStatusCode)
            {

                string data = await response.Content.ReadAsStringAsync();
                if (!string.IsNullOrEmpty(data) || data != "[0]")
                {
                    listSP = JsonConvert.DeserializeObject<List<SanPham>>(data);
                    string aa = listSP[0].MaSP.ToString();

                }
            }


return listSP;
        }



        

        static async Task<string> FindMostSimilarImageAsync(byte[] inputImageBytes, List<byte[]> imageBytesList)
        {
            if (imageBytesList.Count == 0)
            {
                return "No images to compare.";
            }

            double maxSimilarity = double.MinValue;
            string mostSimilarImage = "";

            foreach (var imageBytes in imageBytesList)
            {
                if (inputImageBytes.SequenceEqual(imageBytes))
                {
                    mostSimilarImage = "Identical Image";
                    mostSimilarImage =  (imageBytesList.IndexOf(imageBytes) ).ToString();
                    break;
                }
                else
                {
                    double similarity = CalculateImageSimilarity(inputImageBytes, imageBytes);

                    if (similarity > maxSimilarity)
                    {
                        maxSimilarity = similarity;
                        mostSimilarImage = (imageBytesList.IndexOf(imageBytes) ).ToString();
                    }
                }
            }

            return mostSimilarImage;
        }

        static double CalculateImageSimilarity(byte[] image1, byte[] image2)
        {
            // Chuyển đổi mảng byte thành HashSet để sử dụng Intersect và Union
            HashSet<byte> set1 = new HashSet<byte>(image1);
            HashSet<byte> set2 = new HashSet<byte>(image2);

            // Kiểm tra trường hợp mảng rỗng để tránh chia cho 0
            if (set1.Count == 0 || set2.Count == 0)
            {
                // Trả về 0 trong trường hợp một trong hai mảng là rỗng
                return 0;
            }

            // Tính toán độ tương đồng Jaccard
            int intersection = set1.Intersect(set2).Count();
            int union = set1.Union(set2).Count();

            double jaccardSimilarity = (double)intersection / union;
            return jaccardSimilarity;
        }

        static byte[] ImageToByteArray(Mat image)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                // Convert Mat back to Bitmap
                Bitmap otherBmp = image.ToBitmap();

                // Convert Bitmap to byte array
                otherBmp.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                return stream.ToArray();
            }
        }

    

        [HttpGet]
        async Task<List<string>> getImagesAsync()
        {
            HttpResponseMessage response = await _client.GetAsync(_client.BaseAddress + $"/XuatXu/GetHinh");
            List<string> listHinh = new List<string>();
            if (response.IsSuccessStatusCode)
            {

                string data = await response.Content.ReadAsStringAsync();

                if (!string.IsNullOrEmpty(data) || data != "[0]")
                {
                    listHinh = JsonConvert.DeserializeObject<List<string>>(data);


                }


            }
            return listHinh;
        }

        
    }
}
