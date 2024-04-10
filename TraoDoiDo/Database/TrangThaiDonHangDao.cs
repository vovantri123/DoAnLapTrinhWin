using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraoDoiDo.Models;
using static TraoDoiDo.QuanLyUC;

namespace TraoDoiDo.Database
{
    public class TrangThaiDonHangDao:ThuocTinhDao
    {
        public List<List<string>> TimKiemTheoId(string idNguoiMua,string idSanPham)
        {
            string sqlStr = $" SELECT distinct {nguoiDungTen}, {nguoiDungSdt}, {nguoiDungEmail}, {nguoiDungDiaChi} FROM {trangThaiHeader}" +
                            $" INNER JOIN {nguoiDungHeader} ON {trangThaiHeader}.{trangThaiIdNguoiMua} = {nguoiDungHeader}.{nguoiDungID}" +
                            $" WHERE {trangThaiHeader}.{trangThaiIdNguoiMua} = '{idNguoiMua}' AND {trangThaiHeader}.{trangThaiIdSanPham} = '{idSanPham}' ";
            return dbConnection.LayDanhSachNhieuPhanTu<string>(sqlStr);
        }
        public void CapNhat(TrangThaiDonHang trangThaiDon)
        {
            string sqlStr = $@"
                                UPDATE {trangThaiHeader} 
                                SET {trangThaiTrangThai} = N'{trangThaiDon.TrangThai}'
                                WHERE {sanPhamID} = '{trangThaiDon.IdSanPham}' AND {nguoiDungID} = '{trangThaiDon.IdNguoiMua}' ";
            dbConnection.ThucThi(sqlStr);
        }
        public void Them(TrangThaiDonHang trangThaiDon)
        {
            string sqlStr = $"INSERT INTO {trangThaiHeader} ({trangThaiIdNguoiMua},{trangThaiIdSanPham},{trangThaiSoLuongMua},{trangThaiTongThanhToan},{trangThaiNgay},{trangThaiTrangThai})"
            + $"VALUES ('{trangThaiDon.IdNguoiMua}',N'{trangThaiDon.IdSanPham}','{trangThaiDon.SoLuongMua}','{trangThaiDon.TongThanhToan}','{trangThaiDon.Ngay}',N'{trangThaiDon.TrangThai}')";
            dbConnection.ThucThi(sqlStr);
        }
        public void Xoa(TrangThaiDonHang trangThaiDon)
        {
            string sqlStr = $"DELETE FROM {trangThaiHeader} WHERE {trangThaiIdSanPham} = {trangThaiDon.IdSanPham} AND {trangThaiIdNguoiMua} = {trangThaiDon.IdNguoiMua}";
            dbConnection.ThucThi(sqlStr);
        }
        public List<List<string>> LoadTrangThaiDonHang(TrangThaiDonHang trangThaiDon)
        {
            string sqlStr = $@"
                    SELECT 
            {sanPhamHeader}.{sanPhamID},{sanPhamHeader}.{sanPhamTen},{sanPhamHeader}.{sanPhamAnh}, {trangThaiHeader}.{trangThaiSoLuongMua}, {sanPhamHeader}.{sanPhamGiaBan}, {sanPhamHeader}.{sanPhamPhiShip}, {trangThaiHeader}.{trangThaiTongThanhToan}, {trangThaiHeader}.{trangThaiNgay}
                    FROM 
            {trangThaiHeader}
                    INNER JOIN 
            {nguoiDungHeader} ON {trangThaiHeader}.{trangThaiIdNguoiMua} = {nguoiDungHeader}.{nguoiDungID}
                    INNER JOIN 
            {sanPhamHeader} ON {trangThaiHeader}.{trangThaiIdSanPham} = {sanPhamHeader}.{sanPhamID}
                    WHERE {nguoiDungHeader}.{nguoiDungID} = {trangThaiDon.IdNguoiMua} and {trangThaiHeader}.{trangThaiTrangThai} = N'{trangThaiDon.TrangThai}' ";
            return dbConnection.LayDanhSachNhieuPhanTu<string>(sqlStr);
        }
        public List<List<string>> tinhTongKhachHang(string idNguoiDang)
        {
            string sqlStr = $@"
            SELECT DISTINCT {sanPhamHeader}.{sanPhamIdNguoiDang}, COUNT({trangThaiHeader}.{trangThaiIdNguoiMua})
            FROM {trangThaiHeader}
            INNER JOIN {sanPhamHeader} ON {trangThaiHeader}.{trangThaiIdSanPham} = {sanPhamHeader}.{sanPhamID}
            GROUP BY {sanPhamHeader}.{sanPhamIdNguoiDang}
            HAVING {sanPhamIdNguoiDang} = '{idNguoiDang}' ";
            return dbConnection.LayDanhSachNhieuPhanTu<string>(sqlStr);
        }
    
    }
}
