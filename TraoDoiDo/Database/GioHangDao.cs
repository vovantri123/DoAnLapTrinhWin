using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraoDoiDo.Models;

namespace TraoDoiDo.Database
{
    public class GioHangDao:ThuocTinhDao
    {
        public void Them(GioHang gioHang)
        {
            string sqlStr = $@"
                    INSERT INTO {gioHangHeader} ({quanLyIdNguoiMua},{sanPhamID}, {gioHangSoLuongMua})  
                    VALUES ('{gioHang.IdNguoiMua}', '{gioHang.IdSanPham}','{gioHang.SoLuongMua}') ";
            dbConnection.ThucThi(sqlStr);
        }
        public void Xoa(GioHang gioHang)
        {
            string strSql = $@"DELETE FROM GioHang WHERE IdNguoiMua= '{gioHang.IdNguoiMua}' AND IdSanPham = '{gioHang.IdSanPham}' ";
            dbConnection.ThucThi(strSql);
        }
        public List<List<string>> timThongTinSanPham(string idNguoi)
        {
            string sqlStr = $@" SELECT {gioHangHeader}.{sanPhamID}, {sanPhamTen}, {sanPhamAnh}, {sanPhamGiaBan}, {sanPhamPhiShip}, {gioHangHeader}.{gioHangSoLuongMua}, {sanPhamSoLuong}, {sanPhamSLDaBan} 
                    FROM {gioHangHeader} INNER JOIN {nguoiDungHeader} ON {gioHangHeader}.{quanLyIdNguoiMua} = {nguoiDungHeader}.{nguoiDungID}
                    INNER JOIN {sanPhamHeader} ON {gioHangHeader}.{sanPhamID} = {sanPhamHeader}.{sanPhamID}
                    WHERE {nguoiDungHeader}.{nguoiDungID} = '{idNguoi}' ";
            return dbConnection.LayDanhSachNhieuPhanTu<string>(sqlStr);
        }
    }
}
