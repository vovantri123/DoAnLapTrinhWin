using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls.Primitives;
using TraoDoiDo.Models;
using static TraoDoiDo.QuanLyUC;

namespace TraoDoiDo.Database
{
    public class TrangThaiDonHangDao:ThuocTinhDao
    {
        List<TrangThaiDonHang> dsTrangThaiDonHang;
        List<string> dongKetQua;
        List<List<string>> bangKetQua;
         
        public void Them(TrangThaiDonHang trangThaiDon)
        {
            string sqlStr = $@"
                INSERT INTO {trangThaiHeader} ({trangThaiIdNguoiMua},{trangThaiIdSanPham},{trangThaiSoLuongMua},{trangThaiTongThanhToan},{trangThaiNgay},{trangThaiTrangThai})
                VALUES ('{trangThaiDon.IdNguoiMua}',N'{trangThaiDon.IdSanPham}','{trangThaiDon.SoLuongMua}','{trangThaiDon.TongThanhToan}','{trangThaiDon.Ngay}',N'{trangThaiDon.TrangThai}')
            ";
            dbConnection.ThucThi(sqlStr);
        }

        public void Xoa(TrangThaiDonHang trangThaiDon)
        {
            string sqlStr = $@"
                DELETE FROM {trangThaiHeader} 
                WHERE {trangThaiIdSanPham} = {trangThaiDon.IdSanPham} AND {trangThaiIdNguoiMua} = {trangThaiDon.IdNguoiMua}
            ";
            dbConnection.ThucThi(sqlStr);
        }

        public void CapNhat(TrangThaiDonHang trangThaiDon)
        {
            string sqlStr = $@"
                UPDATE {trangThaiHeader} 
                SET {trangThaiTrangThai} = N'{trangThaiDon.TrangThai}'
                WHERE {trangThaiIdSanPham} = '{trangThaiDon.IdSanPham}' AND {trangThaiIdNguoiMua} = '{trangThaiDon.IdNguoiMua}' 
            ";
            dbConnection.ThucThi(sqlStr);
        }

        public List<TrangThaiDonHang> LoadTrangThaiDonHang(string idNguoiMua, string trangThai)
        {
            string sqlStr = $@"
                SELECT {sanPhamHeader}.{sanPhamID},{sanPhamHeader}.{sanPhamTen},{sanPhamHeader}.{sanPhamAnh}, {trangThaiHeader}.{trangThaiSoLuongMua}, {sanPhamHeader}.{sanPhamGiaBan}, {sanPhamHeader}.{sanPhamPhiShip}, {trangThaiHeader}.{trangThaiTongThanhToan}, {trangThaiHeader}.{trangThaiNgay}
                FROM {trangThaiHeader}
                INNER JOIN {nguoiDungHeader} ON {trangThaiHeader}.{trangThaiIdNguoiMua} = {nguoiDungHeader}.{nguoiDungID}
                INNER JOIN  {sanPhamHeader} ON {trangThaiHeader}.{trangThaiIdSanPham} = {sanPhamHeader}.{sanPhamID}
                WHERE {nguoiDungHeader}.{nguoiDungID} = {idNguoiMua} AND {trangThaiHeader}.{trangThaiTrangThai} = N'{trangThai}' 
            ";
            bangKetQua = dbConnection.LayNhieuDongDuLieu<string>(sqlStr);
            dsTrangThaiDonHang = new List<TrangThaiDonHang>();
            foreach (var dong in bangKetQua)
                dsTrangThaiDonHang.Add(new TrangThaiDonHang(idNguoiMua, dong[0], dong[3], dong[6], dong[7], trangThai, dong[1], dong[2], dong[4], dong[5]));
            return dsTrangThaiDonHang;
        }
         
        public List<TrangThaiDonHang> LoadDoThiThongKeDoanhThuTheoNam(string idNguoi, string nam)
        {
            string sqlStr = $@"
                SELECT {sanPhamHeader}.{sanPhamIdNguoiDang},{sanPhamHeader}.{sanPhamID},{trangThaiHeader}.{trangThaiNgay},{trangThaiHeader}.{trangThaiTongThanhToan}
                FROM {trangThaiHeader} INNER JOIN {sanPhamHeader} ON {trangThaiHeader}.{trangThaiIdSanPham} = {sanPhamHeader}.{sanPhamID} 
                WHERE {sanPhamHeader}.{sanPhamIdNguoiDang} = '{idNguoi}' AND {trangThaiHeader}.{trangThaiTrangThai} = N'Đã nhận' AND YEAR(TRY_CAST({trangThaiHeader}.{trangThaiNgay} AS date)) = '{nam}' 
            ";
            bangKetQua = dbConnection.LayNhieuDongDuLieu<string>(sqlStr);
            dsTrangThaiDonHang = new List<TrangThaiDonHang>();
            foreach (var dong in bangKetQua)
                dsTrangThaiDonHang.Add(new TrangThaiDonHang(dong[0], dong[1], null, dong[3], dong[2], "Đã nhận", null, null, null, null));
            return dsTrangThaiDonHang;
        } 
    }
}
