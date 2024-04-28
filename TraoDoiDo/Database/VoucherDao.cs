using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TraoDoiDo.Models;

namespace TraoDoiDo.Database
{
    public class VoucherDao:ThuocTinhDao
    {
        List<Voucher> dsVoucher;
        //List<string> dongKetQua;
        List<List<string>> bangKetQua;


        public void Them(Voucher voucher)
        {
            string sqlStr = $@"INSERT INTO {voucherHeader} ({voucherTenVoucher}, {voucherGiaTri}, {voucherSoLuotSuDungToiDa}, {voucherSoLuotDaSuDung}, {voucherNgayBatDau}, {voucherNgayKetThuc})
                       VALUES (N'{voucher.TenVoucher}', '{voucher.GiaTri}', '{voucher.SoLuotSuDungToiDa}', '{voucher.SoLuotDaSuDung}', '{voucher.NgayBatDau}', '{voucher.NgayKetThuc}')";

            dbConnection.ThucThi(sqlStr);
        }

        public void Sua(Voucher voucher) //Xóa theo cả id NguoiDung và Id voucher
        { 
            string sqlStr = $@" UPDATE {voucherHeader} 
                                SET 
                                    {voucherTenVoucher} = N'{voucher.TenVoucher}',
                                    {voucherGiaTri} = '{voucher.GiaTri}',
                                    {voucherSoLuotSuDungToiDa} = '{voucher.SoLuotSuDungToiDa}',
                                    {voucherSoLuotDaSuDung} = '{voucher.SoLuotDaSuDung}',
                                    {voucherNgayBatDau} = '{voucher.NgayBatDau}',
                                    {voucherNgayKetThuc} = '{voucher.NgayKetThuc}'
                                WHERE {voucherIdVoucher} = '{voucher.IdVoucher}'";
            dbConnection.ThucThi(sqlStr); 
        }


        public void XoaVoucherTheoIdVoucher(string idVoucher)
        {
            string sqlStr = $@" DELETE FROM {voucherHeader}
                WHERE {voucherIdVoucher} = '{idVoucher}'";
            dbConnection.ThucThi(sqlStr);
        }
        public List<Voucher> LoadVoucher() //Load hết bảng
        {
            string sqlStr = $@"SELECT * FROM {voucherHeader}";

            dsVoucher = new List<Voucher>();
            bangKetQua = dbConnection.LayDanhSachNhieuPhanTu<string>(sqlStr);
            foreach (var dong in bangKetQua)
            {
                dsVoucher.Add(new Voucher(dong[0], dong[1], dong[2], dong[3], dong[4], dong[5], dong[6]));
            }

            return dsVoucher;
        }
        public List<Voucher> LoadVoucherTheoIdNguoiMua(string idNguoiMua)
        {
            string sqlStr = $@"
                    SELECT {voucherHeader}.{voucherIdVoucher},{voucherTenVoucher},{voucherGiaTri},{voucherSoLuotDaSuDung},{voucherSoLuotSuDungToiDa},{voucherNgayBatDau},{voucherNgayKetThuc}
                    FROM {voucherHeader}
                    INNER JOIN {nguoiDungVoucherHeader} ON {voucherHeader}.{voucherIdVoucher} = {nguoiDungVoucherHeader}.{nguoiDungVoucherIdVoucher}                        
                    WHERE {nguoiDungVoucherIdNguoiDung} = {idNguoiMua}
";

            dsVoucher = new List<Voucher>();
            bangKetQua = dbConnection.LayDanhSachNhieuPhanTu<string>(sqlStr);
            foreach (var dong in bangKetQua)
            {
                dsVoucher.Add(new Voucher(dong[0], dong[1], dong[2], dong[3], dong[4], dong[5], dong[6]));
            }

            return dsVoucher;
        }
        public string TimSoLuotDaSuDungTheoIdVoucher(string idVoucher)
        {
            string sqlStr = $@"
                    SELECT {voucherSoLuotDaSuDung}
                    FROM {voucherHeader}
                    WHERE {voucherIdVoucher}='{idVoucher}'
            "; 

            return dbConnection.LayMotDoiTuong(sqlStr,$"{voucherSoLuotDaSuDung}");
        }
        public void TangSoLuotSuDungThem1(string idVoucher) // Tăng số lượt sử dụng thêm 1
        {
            int soLuotHienTai = Convert.ToInt32(TimSoLuotDaSuDungTheoIdVoucher(idVoucher));
            //MessageBox.Show(soLuotHienTai + "SL hiên tại");

            string sqlStr = $@" UPDATE {voucherHeader}
                SET {voucherSoLuotDaSuDung} = '{soLuotHienTai+1}'
                WHERE {voucherIdVoucher} = '{idVoucher}'";
            
            dbConnection.ThucThi(sqlStr); 
        }
    }
}
