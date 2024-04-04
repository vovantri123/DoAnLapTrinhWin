using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraoDoiDo.Models
{
    public class TrangThaiDonHang
    {
        private string idNguoiMua = "";
        private string idSanPham = "";
        private string soLuongMua = "";
        private string tongThanhToan = "";
        private string ngay = "";
        private string trangThai = "";
        public TrangThaiDonHang() { }
        public TrangThaiDonHang(string idNguoiMua, string idSanPham, string soLuongMua, string tongThanhToan, string ngay, string trangThai)
        {
            this.IdNguoiMua = idNguoiMua;
            this.IdSanPham = idSanPham;
            this.SoLuongMua = soLuongMua;
            this.TongThanhToan = tongThanhToan;
            this.Ngay = ngay;
            this.TrangThai = trangThai;
        }

        public string IdNguoiMua { get => idNguoiMua; set => idNguoiMua = value; }
        public string IdSanPham { get => idSanPham; set => idSanPham = value; }
        public string SoLuongMua { get => soLuongMua; set => soLuongMua = value; }
        public string TongThanhToan { get => tongThanhToan; set => tongThanhToan = value; }
        public string Ngay { get => ngay; set => ngay = value; }
        public string TrangThai { get => trangThai; set => trangThai = value; }
    }
}
