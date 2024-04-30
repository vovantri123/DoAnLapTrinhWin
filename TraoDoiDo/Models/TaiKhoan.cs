using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TraoDoiDo.ViewModels;

namespace TraoDoiDo.Models
{
    public class TaiKhoan : ThuocTinhViewModel
    {
        private string tenDangNhap = "";
        private string matKhau = "";
        private string iDNguoiDung = "";
        private string errorMessage = "";
        public TaiKhoan() { }

        public TaiKhoan(string tenDangNhap, string matKhau, string iDNguoiDung)
        {
            this.TenDangNhap = tenDangNhap;
            this.MatKhau = matKhau;
            this.IDNguoiDung = iDNguoiDung;
        }

        public string TenDangNhap { get => tenDangNhap; set => tenDangNhap = value; }
        public string MatKhau { get => matKhau; set => matKhau = value; }
        public string IDNguoiDung { get => iDNguoiDung; set => iDNguoiDung = value; }
       


        public bool kiemTraCacTextBox()
        {

            errorMessage = "";
            foreach (var property in typeof(TaiKhoan).GetProperties())
            {
                var value = property.GetValue(this);
                if (value == null || string.IsNullOrWhiteSpace(value.ToString()))
                {
                    errorMessage = XuLyTienIch.TinNhanTrongKhongHopLe;
                    MessageBox.Show(errorMessage);
                    return false;
                }
            }
            return true;
        }
    }
}
