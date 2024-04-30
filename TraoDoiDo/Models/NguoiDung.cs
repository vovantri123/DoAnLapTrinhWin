using System.Net.Http.Headers;
using System.Windows;
using TraoDoiDo.ViewModels;
using System;
namespace TraoDoiDo.Models
{
    public class NguoiDung : ThuocTinhViewModel
    {
        private string id = "";
        private string hoTen = "";
        private string gioiTinh = "";
        private string ngaySinh = "";
        private string cmnd = "";
        private string email = "";
        private string sdt = "";
        private string diaChi = "";
        private string anh = "";
        private TaiKhoan taiKhoan = new TaiKhoan();
        private string tien = "";
        private string errorMessage = "";

        private string soLuotMua = "0";

        public NguoiDung()
        { }

        public NguoiDung(string id, string hoTen, string gioiTinh, string ngaySinh, string cmnd, string email, string sdt, string diaChi, string anh, TaiKhoan taiKhoan, string tien)
        {
            this.id = id;
            this.hoTen = hoTen;
            this.gioiTinh = gioiTinh;
            this.ngaySinh = ngaySinh;
            this.cmnd = cmnd;
            this.email = email;
            this.sdt = sdt;
            this.diaChi = diaChi;
            this.anh = anh;
            this.taiKhoan = taiKhoan;
            this.tien = tien;
        }

        public NguoiDung(string id, string hoTen, string diaChi, string anh, string soLuotMua)
        {
            this.id = id;
            this.hoTen = hoTen;
            this.diaChi = diaChi;
            this.anh = anh;
            this.SoLuotMua = soLuotMua;
        }
        public string Id { get => id; set { id = value; OnPropertyChanged(); } }
        public string HoTen { get => hoTen; set { hoTen = value; OnPropertyChanged(); } }
        public string GioiTinh { get => gioiTinh; set { gioiTinh = value; OnPropertyChanged(); } }
        public string NgaySinh { get => ngaySinh; set { ngaySinh = value; OnPropertyChanged(); } }
        public string Cmnd { get => cmnd; set { cmnd = value; OnPropertyChanged(); } }
        public string Email { get => email; set { email = value; OnPropertyChanged(); } }
        public string Sdt { get => sdt; set { sdt = value; OnPropertyChanged(); } }
        public string DiaChi { get => diaChi; set { diaChi = value; OnPropertyChanged(); } }
        public string Anh { get => anh; set { anh = value; OnPropertyChanged(); } }
        public string Tien { get => tien; set { tien = value; OnPropertyChanged(); } }
        public TaiKhoan TaiKhoan { get => taiKhoan; set { taiKhoan = value; OnPropertyChanged(); } }
        public string SoLuotMua { get => soLuotMua; set { soLuotMua = value; OnPropertyChanged(); } }

        //public string ErrorMessage { get => errorMessage; set { errorMessage = value; OnPropertyChanged(); } }
        KiemTraDinhDang kiemTra = new KiemTraDinhDang();
        public bool kiemTraCacTextBox()
        {

            errorMessage = "";
            foreach (var property in typeof(NguoiDung).GetProperties())
            {
                var value = property.GetValue(this);
                if (value == null || string.IsNullOrWhiteSpace(value.ToString()))
                {
                    errorMessage = XuLyTienIch.TinNhanTrongKhongHopLe;
                    MessageBox.Show(errorMessage);
                    return false;
                }
            }
            DateTime ngaySinh = DateTime.ParseExact(NgaySinh, "dd/MM/yyyy", null);
            if (!kiemTra.kiemTraNgaySinh(ngaySinh))
            {
                errorMessage = XuLyTienIch.TinNhanNgaySinhKhongHopLe;
                MessageBox.Show(errorMessage);
                return false;
            }
            if (!kiemTra.kiemTraEmail(Email))
            {
                errorMessage = XuLyTienIch.TinNhanEmailKhongHopLe;
                MessageBox.Show(errorMessage);
                return false;
            }
            if (!kiemTra.kiemTraSoDienThoai(Sdt))
            {
                errorMessage = XuLyTienIch.TinNhanSdtKhongHopLe;
                MessageBox.Show(errorMessage);
                return false;
            }
            if (!kiemTra.kiemTraCMND(Cmnd))
            {
                errorMessage = XuLyTienIch.TinNhanCMNDKhongHopLe;
                MessageBox.Show(errorMessage);
                return false;
            }
            return true;
        }
    }
}
