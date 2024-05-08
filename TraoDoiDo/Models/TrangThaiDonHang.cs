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
        private string tenSanPham;
        private string anhSP;
        private string giaBan;
        private string phiShip; 

        public TrangThaiDonHang() { }

        public TrangThaiDonHang(string idNguoiMua, string idSanPham, string soLuongMua, string tongThanhToan, string ngay, string trangThai, string tenSanPham, string anhSP, string giaBan, string phiShip)
        {
            this.IdNguoiMua = idNguoiMua;
            this.IdSanPham = idSanPham;
            this.SoLuongMua = soLuongMua;
            this.TongThanhToan = tongThanhToan;
            this.Ngay = ngay;
            this.TrangThai = trangThai;
            this.TenSanPham = tenSanPham;
            this.AnhSP = anhSP;
            this.GiaBan = giaBan;
            this.PhiShip = phiShip; 
        }

        public string IdNguoiMua { get => idNguoiMua; set => idNguoiMua = value; }
        public string IdSanPham { get => idSanPham; set => idSanPham = value; }
        public string SoLuongMua { get => soLuongMua; set => soLuongMua = value; }
        public string TongThanhToan { get => tongThanhToan; set => tongThanhToan = value; }
        public string Ngay { get => ngay; set => ngay = value; }
        public string TrangThai { get => trangThai; set => trangThai = value; }
        public string TenSanPham { get => tenSanPham; set => tenSanPham = value; }
        public string AnhSP { get => anhSP; set => anhSP = value; }
        public string GiaBan { get => giaBan; set => giaBan = value; }
        public string PhiShip { get => phiShip; set => phiShip = value; } 
    }
}
