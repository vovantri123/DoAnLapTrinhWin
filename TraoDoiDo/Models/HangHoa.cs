using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraoDoiDo.Models
{
    public class HangHoa
    {
        private string id = "";
        private string tenSanPham = "";
        private string anhSanPham = "";
        private string loaiSanPham = "";
        private int soLuong = 0;
        private int soLuongDaBan = 0;
        private long giaBanGoc = 0;
        private long giaBan = 0;
        private long phiShip = 0;
        private string trangThai = "";
        private string noiBan = "";
        private string xuatXu = "";
        private DateTime ngayMua = DateTime.Now;

        public string Id { get => id; set => id = value; }
        public string TenSanPham { get => tenSanPham; set => tenSanPham = value; }
        public string AnhSanPham { get => anhSanPham; set => anhSanPham = value; }
        public string LoaiSanPham { get => loaiSanPham; set => loaiSanPham = value; }
        public int SoLuong { get => soLuong; set => soLuong = value; }
        public int SoLuongDaBan { get => soLuongDaBan; set => soLuongDaBan = value; }
        public long GiaBanGoc { get => giaBanGoc; set => giaBanGoc = value; }
        public long GiaBan { get => giaBan; set => giaBan = value; }
        public long PhiShip { get => phiShip; set => phiShip = value; }
        public string TrangThai { get => trangThai; set => trangThai = value; }
        public string NoiBan { get => noiBan; set => noiBan = value; }
        public string XuatXu { get => xuatXu; set => xuatXu = value; }
        public DateTime NgayMua { get => ngayMua; set => ngayMua = value; }
    }
}
