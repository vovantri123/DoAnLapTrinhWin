using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraoDoiDo.Models
{
    public class SanPham
    {
        private string id;
        private string ten;
        private string linkAnhBia;
        private string loai;
        private string soLuong;
        private string soLuongDaBan;
        private string giaGoc;
        private string giaBan;
        private string phiShip;
        private string trangThai;
        private string noiBan;
        private string xuatXu;
        private string ngayMua;
        private string moTaChung;
        private string phanTramMoi;

        public SanPham(string id, string ten, string linkAnhBia, string loai, string soLuong, string soLuongDaBan, string giaGoc, string giaBan, string phiShip, string trangThai, string noiBan, string xuatXu, string ngayMua, string moTaChung, string phanTramMoi)
        {
            this.id = id;
            this.ten = ten;
            this.linkAnhBia = linkAnhBia;
            this.loai = loai;
            this.soLuong = soLuong;
            this.soLuongDaBan = soLuongDaBan;
            this.giaGoc = giaGoc;
            this.giaBan = giaBan;
            this.phiShip = phiShip;
            this.trangThai = trangThai;
            this.noiBan = noiBan;
            this.xuatXu = xuatXu;
            this.ngayMua = ngayMua;
            this.moTaChung = moTaChung;
            this.phanTramMoi = phanTramMoi;
        }

        public string Id { get => id; set => id = value; }
        public string Ten { get => ten; set => ten = value; }
        public string LinkAnh { get => linkAnhBia; set => linkAnhBia = value; }
        public string Loai { get => loai; set => loai = value; }
        public string SoLuong { get => soLuong; set => soLuong = value; }
        public string SoLuongDaBan { get => soLuongDaBan; set => soLuongDaBan = value; }
        public string GiaGoc { get => giaGoc; set => giaGoc = value; }
        public string GiaBan { get => giaBan; set => giaBan = value; }
        public string PhiShip { get => phiShip; set => phiShip = value; }
        public string TrangThai { get => trangThai; set => trangThai = value; }
        public string NoiBan { get => noiBan; set => noiBan = value; }
        public string XuatXu { get => xuatXu; set => xuatXu = value; }
        public string NgayMua { get => ngayMua; set => ngayMua = value; }
        public string MoTaChung { get => moTaChung; set => moTaChung = value; }
        public string PhanTramMoi { get => phanTramMoi; set => phanTramMoi = value; }
    }
}
