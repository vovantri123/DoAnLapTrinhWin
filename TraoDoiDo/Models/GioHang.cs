using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraoDoiDo.Models
{
    public  class GioHang
    {
        private string idNguoiMua;
        private string idSanPham;
        private string soLuongMua;
        public GioHang() { }
        public GioHang(string idNguoiMua, string idSanPham, string soLuongMua)
        {
            this.IdNguoiMua = idNguoiMua;
            this.IdSanPham = idSanPham;
            this.SoLuongMua = soLuongMua;
        }

        public string IdNguoiMua { get => idNguoiMua; set => idNguoiMua = value; }
        public string IdSanPham { get => idSanPham; set => idSanPham = value; }
        public string SoLuongMua { get => soLuongMua; set => soLuongMua = value; }
    }
}
