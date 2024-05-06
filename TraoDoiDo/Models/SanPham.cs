using System;
using System.Runtime.Remoting.Messaging;
using System.Windows;
using TraoDoiDo.ViewModels;

namespace TraoDoiDo.Models
{
    public class SanPham 
    {
        private string id = "";
        private string idNguoiDang = "";
        private string ten = "";
        private string linkAnhBia = "";
        private string loai = "";
        private string soLuong = "";
        private string soLuongDaBan = "";
        private string giaGoc = "";
        private string giaBan = "";
        private string phiShip = "";
        private string trangThai = "";
        private string noiBan = "";
        private string xuatXu = "";
        private string ngayMua = "";
        private string moTaChung = "";
        private string phanTramMoi = "";
        private string luotXem = "";
        private string idNguoiMua = "";
        private string ngayDang = "";
        private QuanLyDonHang quanLyDonHang; 
        public SanPham() { }
        public SanPham(string id, string idNguoiDang, string ten, string linkAnhBia, string loai, string soLuong, string soLuongDaBan, string giaGoc, string giaBan, string phiShip, string trangThai, string noiBan, string xuatXu, string ngayMua, string moTaChung, string phanTramMoi, string luotXem, string idNguoiMua, string ngayDang)
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
            this.idNguoiDang = idNguoiDang;
            this.luotXem = luotXem;
            this.idNguoiMua = idNguoiMua;
            this.ngayDang = ngayDang;
        }

        public string Id { get => id; set => id = value;  }
        public string Ten { get => ten; set => ten = value; }
        public string LinkAnh { get => linkAnhBia; set => linkAnhBia = value;  }
        public string Loai { get => loai; set => loai = value;  }
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
        public string IdNguoiDang { get => idNguoiDang; set => idNguoiDang = value; }
        public string LuotXem { get => luotXem; set => luotXem = value; }
        //public QuanLyDonHang QuanLyDonHang { get => quanLyDonHang; set => quanLyDonHang = value; }
        public string IdNguoiMua { get => idNguoiMua; set => idNguoiMua = value; }
        public string NgayDang { get => ngayDang; set => ngayDang = value; }
        //public string ErrorMessage { get => errorMessage; set { errorMessage = value; OnPropertyChanged(); } }
        KiemTraDinhDang kiemTra = new KiemTraDinhDang();
        public bool kiemTraCacTextBox()
        {
            string errorMessage = "";
            foreach (var property in typeof(SanPham).GetProperties())
            {
                var value = property.GetValue(this);
                if (value == null || string.IsNullOrWhiteSpace(value.ToString()))
                {
                    errorMessage = XuLyTienIch.TinNhanTrongKhongHopLe;
                    MessageBox.Show(errorMessage);
                    return false;
                }
            } 

            DateTime ngayMua = DateTime.ParseExact(NgayMua, "d/M/yyyy", null);
            DateTime ngayDang = DateTime.ParseExact(NgayDang, "d/M/yyyy", null);
            if (!kiemTra.kiemTraNgayMuaSanPham(ngayMua, ngayDang))
            {
                errorMessage = XuLyTienIch.TinNhanNgayMuaHopLe;
                MessageBox.Show(errorMessage);
                return false;
            }
            return true;
        }
    }
}
