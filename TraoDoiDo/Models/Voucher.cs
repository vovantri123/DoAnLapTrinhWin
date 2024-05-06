using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TraoDoiDo.ViewModels;

namespace TraoDoiDo.Models
{
    public class Voucher
    {
        private string idVoucher = "";
        private string tenVoucher = "";
        private string giaTri = "";
        private string soLuotSuDungToiDa = "";
        private string soLuotDaSuDung = "";
        private string ngayBatDau = "";
        private string ngayKetThuc = "";
        private string errorMessage = "";
        public Voucher(string idVoucher, string tenVoucher, string giaTri, string soLuotSuDungToiDa, string soLuotDaSuDung, string ngayBatDau, string ngayKetThuc)
        {
            this.idVoucher = idVoucher;
            this.tenVoucher = tenVoucher;
            this.giaTri = giaTri;
            this.soLuotSuDungToiDa = soLuotSuDungToiDa;
            this.soLuotDaSuDung = soLuotDaSuDung;
            this.ngayBatDau = ngayBatDau;
            this.ngayKetThuc = ngayKetThuc;
        }

        public string IdVoucher { get => idVoucher; set => idVoucher = value; }
        public string TenVoucher { get => tenVoucher; set => tenVoucher = value; }
        public string GiaTri { get => giaTri; set => giaTri = value; }
    
        public string SoLuotSuDungToiDa { get => soLuotSuDungToiDa; set => soLuotSuDungToiDa = value; }
        public string SoLuotDaSuDung { get => soLuotDaSuDung; set => soLuotDaSuDung = value; }
        public string NgayBatDau { get => ngayBatDau; set => ngayBatDau = value; }
        public string NgayKetThuc { get => ngayKetThuc; set => ngayKetThuc = value; }
        KiemTraDinhDang kiemTra = new KiemTraDinhDang();
        public bool kiemTraCacTextBox()
        {
            errorMessage = "";
            foreach (var property in typeof(Voucher).GetProperties())
            {
                var value = property.GetValue(this);
                if (value == null || string.IsNullOrWhiteSpace(value.ToString()))
                {
                    errorMessage = XuLyTienIch.TinNhanTrongKhongHopLe;
                    MessageBox.Show(errorMessage);
                    return false;
                }
            }
            DateTime ngayMua = DateTime.ParseExact(NgayBatDau, "d/M/yyyy", null);
            DateTime ngayDang = DateTime.ParseExact(NgayKetThuc, "d/M/yyyy", null);
            if (!kiemTra.kiemTraNgayMuaSanPham(ngayMua, ngayDang))
            {
                errorMessage = XuLyTienIch.TinNhanNgayMuaHopLe;
                MessageBox.Show(errorMessage);
                return false;
            }
            if (!kiemTra.kiemTraSo(GiaTri))
            {
                errorMessage = XuLyTienIch.TinNhanSoHopLe;
                MessageBox.Show(errorMessage);
                return false;
            }
            if (!kiemTra.kiemTraSoLuong(SoLuotDaSuDung, SoLuotSuDungToiDa))
            {
                errorMessage = XuLyTienIch.TinNhanSoLuongHopLe;
                MessageBox.Show(errorMessage);
                return false;
            }
            return true;
        }
    }
}

 
