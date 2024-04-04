using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraoDoiDo.Models
{
    public class QuanLyDonHang
    {
        private string idDonHang = "";
        private string idNguoiDang = "";
        private string idNguoiMua = "";
        private string idSanPham = "";
        private string trangThai = "";
        private string lyDo = "";
        public QuanLyDonHang() { }
        public QuanLyDonHang(string idDonHang, string idNguoiDang, string idNguoiMua, string idSanPham, string trangThai, string lyDo)
        {
            this.IdDonHang = idDonHang;
            this.IdNguoiDang = idNguoiDang;
            this.IdNguoiMua = idNguoiMua;
            this.IdSanPham = idSanPham;
            this.TrangThai = trangThai;
            this.LyDo = lyDo;
        }

        public string IdDonHang { get => idDonHang; set => idDonHang = value; }
        public string IdNguoiDang { get => idNguoiDang; set => idNguoiDang = value; }
        public string IdNguoiMua { get => idNguoiMua; set => idNguoiMua = value; }
        public string IdSanPham { get => idSanPham; set => idSanPham = value; }
        public string TrangThai { get => trangThai; set => trangThai = value; }
        public string LyDo { get => lyDo; set => lyDo = value; }
    }
}
