using QL_NoiThat.DAL;
using QL_NoiThat.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_NoiThat.BUS
{
    public class SanPham_BUS
    {
        SanPham_DAL sp_dal;
        public SanPham_BUS()
        {
            sp_dal = new SanPham_DAL();
        }
        public async Task<List<SanPham_Model>> getSanPham()
        {
            List<SanPham_Model> listSp = await sp_dal.GetSanPham();
            return listSp;
        }
        public async Task<List<Loai_Model>> getLoai()
        {
            List<Loai_Model> listSp = await sp_dal.GetLoai();
            return listSp;
        }
        public async Task<List<XuatXu_Model>> getXuatXu()
        {
            List<XuatXu_Model> listSp = await sp_dal.GetXuatXu();
            return listSp;
        }
        public async Task<List<ChatLieu_Model>> getChatLieu()
        {
            List<ChatLieu_Model> listSp = await sp_dal.GetChatLieu();
            return listSp;
        }
        public async Task<List<SanPham_Model>> AddSanPham(SanPham_Model sanPham)
        {
            List<SanPham_Model> updatedList = await sp_dal.PostSanPham(sanPham);
            return updatedList;
        }
        public async Task<bool> DeleteProductAsync(string maSP)
        {
            return await sp_dal.DeleteProductAsync(maSP);
        }
        public async Task<bool> UpdateProductAsync(string maSP, SanPham_Model updatedProduct)
        {
            return await sp_dal.UpdateProductAsync(maSP, updatedProduct);
        }
        public async Task<List<ChatLieu_Model>> getByCL(string macl)
        {
            List<ChatLieu_Model> listSP = await sp_dal.GetTenCL(macl);
            return listSP;
        }
        public async Task<List<Loai_Model>> getByLH(string malh)
        {
            List<Loai_Model> listSP = await sp_dal.GetTenLH(malh);
            return listSP;
        }
        public async Task<List<XuatXu_Model>> getByXX(string maxx)
        {
            List<XuatXu_Model> listSP = await sp_dal.GetXuatXu(maxx);
            return listSP;
        }
    }
}
