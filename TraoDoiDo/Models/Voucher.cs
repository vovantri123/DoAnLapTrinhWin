using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraoDoiDo.Models
{ 
    public class Voucher
    {
        private string idVoucher;
        private string tenVoucher;
        private string giaTri;
        private string soLuotSuDungToiDa;
        private string soLuotDaSuDung;
        private string ngayBatDau;
        private string ngayKetThuc;

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
    } 
} 
