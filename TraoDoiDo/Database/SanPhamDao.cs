﻿using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using TraoDoiDo.Models;

namespace TraoDoiDo.Database
{
    public class SanPhamDao : ThuocTinhDao
    {
        List<SanPham> dsSanPham; 
        List<string> dongKetQua;
        List<List<string>> bangKetQua;

        public void Them(SanPham sp)
        {
            string sqlStr = $@"
                INSERT INTO SanPham ({sanPhamID},{sanPhamIdNguoiDang},{sanPhamTen}, {sanPhamAnh}, {sanPhamLoai}, {sanPhamSoLuong}, {sanPhamSLDaBan}, {sanPhamGiaGoc}, {sanPhamGiaBan}, {sanPhamPhiShip}, {sanPhamTrangThai}, {sanPhamNoiBan}, {sanPhamXuatXu}, {sanPhamNgayMua}, {sanPhamPhamTramMoi}, {sanPhamMoTaChung}, {sanPhamSoLuotXem}, {sanPhamNgayDang}) 
                VALUES ('{sp.Id}','{sp.IdNguoiDang}' , N'{sp.Ten}', '{sp.LinkAnh}', N'{sp.Loai}', '{sp.SoLuong}', '{sp.SoLuongDaBan}', '{sp.GiaGoc}', '{sp.GiaBan}', '{sp.PhiShip}', N'{sp.TrangThai}', N'{sp.NoiBan}', N'{sp.XuatXu}', '{sp.NgayMua}', '{sp.PhanTramMoi}', N'{sp.MoTaChung}','{0}','{sp.NgayDang}' )
            ";
            dbConnection.ThucThi(sqlStr);
        }

        public void Xoa(string idSanPham)
        {
            string sqlStr = $@"
                DELETE FROM {sanPhamHeader} 
                WHERE {sanPhamID} = {idSanPham}
            ";
            dbConnection.ThucThi(sqlStr);
        }

        public void CapNhat(SanPham sp)
        {
            string sqlStr = $@"
                UPDATE {sanPhamHeader} 
                SET {sanPhamTen} = N'{sp.Ten}', 
                    {sanPhamAnh} = '{sp.LinkAnh}', 
                    {sanPhamLoai} = N'{sp.Loai}', 
                    {sanPhamSoLuong} = '{sp.SoLuong}',   
                    {sanPhamSLDaBan} = '{sp.SoLuongDaBan}', 
                    {sanPhamGiaGoc} = '{sp.GiaGoc}', 
                    {sanPhamGiaBan} = '{sp.GiaBan}', 
                    {sanPhamPhiShip} = '{sp.PhiShip}', 
                    {sanPhamTrangThai} = N'{sp.TrangThai}', 
                    {sanPhamNoiBan} = N'{sp.NoiBan}', 
                    {sanPhamXuatXu} = N'{sp.XuatXu}', 
                    {sanPhamNgayMua} = '{sp.NgayMua}',   
                    {sanPhamPhamTramMoi} = '{sp.PhanTramMoi}', 
                    {sanPhamMoTaChung} = N'{sp.MoTaChung}' 
                WHERE {sanPhamID} = '{sp.Id}'
            ";
            dbConnection.ThucThi(sqlStr);
        }

        public List<SanPham> LoadSanPhamCungLoai(SanPham sp)
        { 
            string sqlStr = $@"
                SELECT {sanPhamHeader}.{sanPhamID}, {sanPhamTen}, {sanPhamAnh}, {sanPhamGiaGoc}, {sanPhamGiaBan}, {sanPhamNoiBan} , {sanPhamLoai}, {sanPhamIdNguoiDang}
                FROM {sanPhamHeader} 
                WHERE {sanPhamLoai} = N'{sp.Loai}' AND {sanPhamHeader}.{sanPhamID} != '{sp.Id}' AND {sanPhamHeader}.{sanPhamIdNguoiDang} != '{sp.IdNguoiMua}' AND CONVERT(INT,{sanPhamSLDaBan}) < CONVERT(INT,{sanPhamSoLuong})
            "; 
            dsSanPham = new List<SanPham>();
            bangKetQua = dbConnection.LayNhieuDongDuLieu<string>(sqlStr);
            foreach (var dong in bangKetQua) 
                dsSanPham.Add(new SanPham(dong[0], dong[7], dong[1], dong[2], dong[6], null, null, dong[3], dong[4], null, null, dong[5], null, null, null, null, null, sp.IdNguoiMua, null));

            return dsSanPham;
        }
         
        public List<SanPham> LoadSanPhamTheoIdNguoiMua(string idNguoiMua) //Xét yêu thích (lên wpnl_hienThi)
        {
            // Cái idNguoiMua chỗ dong[9] đại diện cho biến người đó có đang thích sản phẩm k, chứ nó k phải là id của người mua
            string sqlStr = $@" 
                SELECT {sanPhamHeader}.{sanPhamID}, {sanPhamHeader}.{sanPhamTen}, {sanPhamHeader}.{sanPhamAnh}, {sanPhamHeader}.{sanPhamGiaGoc}, {sanPhamHeader}.{sanPhamGiaBan}, {sanPhamHeader}.{sanPhamNoiBan}, {sanPhamHeader}.{sanPhamSoLuotXem}, {nguoiDungHeader}.{nguoiDungID}, {sanPhamHeader}.{sanPhamLoai}, {danhMucHeader}.{danhMucIdNguoiMua} 
                FROM {sanPhamHeader} 
                INNER JOIN {nguoiDungHeader} ON {sanPhamHeader}.{sanPhamIdNguoiDang} = {nguoiDungHeader}.{nguoiDungID} 
                LEFT OUTER JOIN {danhMucHeader} ON {danhMucHeader}.{danhMucIdNguoiMua} = '{idNguoiMua}' AND {danhMucHeader}.{sanPhamID} = {sanPhamHeader}.{sanPhamID} 
                WHERE {sanPhamIdNguoiDang} != '{idNguoiMua}' AND CONVERT(INT,{sanPhamSLDaBan}) < CONVERT(INT,{sanPhamSoLuong})
            ";
            dsSanPham = new List<SanPham>();
            bangKetQua = dbConnection.LayNhieuDongDuLieu<string>(sqlStr);
            foreach (var dong in bangKetQua)
                dsSanPham.Add(new SanPham(dong[0], dong[7], dong[1], dong[2], dong[8], null, null, dong[3], dong[4], null, null, dong[5], null, null, null, null, dong[6], dong[9], null));
            return dsSanPham;
        }

        public List<SanPham> LoadDanhSachSanPhamTheoIdNguoiDang(string idNguoiDang)  
        {
            string sqlStr = $@" 
                SELECT {sanPhamID}, {sanPhamTen}, {sanPhamAnh}, {sanPhamLoai}, {sanPhamSoLuong}, {sanPhamSLDaBan}, {sanPhamGiaGoc}, {sanPhamGiaBan}, {sanPhamPhiShip}, {sanPhamTrangThai}, {sanPhamNgayDang}
                FROM {sanPhamHeader} 
                WHERE {sanPhamIdNguoiDang} = '{idNguoiDang}' 
            ";
            dsSanPham = new List<SanPham>();
            bangKetQua = dbConnection.LayNhieuDongDuLieu<string>(sqlStr);
            foreach (var dong in bangKetQua)
                dsSanPham.Add(new SanPham(dong[0], idNguoiDang, dong[1], dong[2], dong[3], dong[4], dong[5], dong[6], dong[7], dong[8], dong[9], null, null, null, null, null, null, "0", dong[10]));
            return dsSanPham;
        } 

        public SanPham timKiemSanPhamBangIdSanPham(string id)
        {
            string sqlStr = $@" 
                SELECT * 
                FROM {sanPhamHeader} 
                WHERE {sanPhamID} = '{id}'
            ";
            dongKetQua = dbConnection.LayMotDongDuLieu<string>(sqlStr);
            if (dongKetQua != null)
                return new SanPham(dongKetQua[0], dongKetQua[1], dongKetQua[2], dongKetQua[3], dongKetQua[4], dongKetQua[5], dongKetQua[6], dongKetQua[7], dongKetQua[8], dongKetQua[9], dongKetQua[10], dongKetQua[11], dongKetQua[12], dongKetQua[13], dongKetQua[15], dongKetQua[14], dongKetQua[16], null, null);
            return null;
        }
         

        public void TangLuotXemThem1(string idSP)
        {
            string sqlStr = $@"
                UPDATE {sanPhamHeader} 
                SET {sanPhamSoLuotXem} = CONVERT(INT,{sanPhamSoLuotXem}) + 1
                WHERE IdSanPham = {idSP} 
            ";
            dbConnection.ThucThi(sqlStr); 
        }
          
        public List<SanPham> LoadToanBoSanPham()
        {
            string sqlStr = $@"
                SELECT {sanPhamID}, {sanPhamTen},{sanPhamAnh},{sanPhamLoai},{sanPhamSoLuong},{sanPhamSLDaBan},{sanPhamGiaGoc},{sanPhamGiaBan},{sanPhamPhiShip},{sanPhamNgayDang} 
                FROM {sanPhamHeader}
            ";
            dsSanPham = new List<SanPham>();
            bangKetQua = dbConnection.LayNhieuDongDuLieu<string>(sqlStr);
            foreach (var dong in bangKetQua)
                dsSanPham.Add(new SanPham(dong[0], null, dong[1], dong[2], dong[3], dong[4], dong[5], dong[6], dong[7], dong[8], null, null, null, null, null, null, null, "0", dong[9]));
            return dsSanPham;
        }
         
        public int timKiemIdMax()
        {
            string sqlStr = $@"
                SELECT MAX({sanPhamID}) AS IdMax 
                FROM {sanPhamHeader}
            ";
            return Convert.ToInt32(dbConnection.LayMotGiaTri(sqlStr, "IdMax"));
        }

        public List<SanPham> timKiemBangLoai(string loai)
        {
            string sqlStr = $@" 
                SELECT {sanPhamID}, {sanPhamTen}, {sanPhamAnh}, {sanPhamLoai}, {sanPhamSoLuong}, {sanPhamSLDaBan}, {sanPhamGiaGoc}, {sanPhamGiaBan}, {sanPhamPhiShip}, {sanPhamTrangThai}, {sanPhamNgayDang}
                FROM {sanPhamHeader} 
                WHERE {sanPhamLoai} LIKE N'{loai}%' 
            ";
            dsSanPham = new List<SanPham>();
            bangKetQua = dbConnection.LayNhieuDongDuLieu<string>(sqlStr);
            foreach (var dong in bangKetQua)
                dsSanPham.Add(new SanPham(dong[0], null, dong[1], dong[2], dong[3], dong[4], dong[5], dong[6], dong[7], dong[8], dong[9], null, null, null, null, null, null, "0", dong[10]));
            return dsSanPham;
        }

        public List<SanPham> LoadThongSoSanPhamDeThongKe(string idNguoiDang)   //code là gộp mấy cái đồ thị dô chung, rồi gộp lên 2 ô tổng doanh thu và bán được dô chung, còn tong khach hang thì sài riêng
        {
            string sqlStr = $@"
                SELECT {sanPhamTen}, {sanPhamSLDaBan}, {sanPhamSoLuong} , {sanPhamGiaBan}, {sanPhamIdNguoiDang}
                FROM {sanPhamHeader}
                WHERE {sanPhamIdNguoiDang} = '{idNguoiDang}' 
            ";
            dsSanPham = new List<SanPham>();
            bangKetQua = dbConnection.LayNhieuDongDuLieu<string>(sqlStr);
            foreach (var dong in bangKetQua)
                dsSanPham.Add(new SanPham(null, dong[4], dong[0], null, null, dong[2], dong[1], null, dong[3], null, null, null, null, null, null, null, null, null, null));
            return dsSanPham;
        }

        public List<SanPham> LoadThongSoSanPhamDeThongKeTheoNam(string idNguoiDang,string nam)   //code là gộp mấy cái đồ thị dô chung, rồi gộp lên 2 ô tổng doanh thu và bán được dô chung, còn tong khach hang thì sài riêng
        {
            string sqlStr = $@"

                SELECT {sanPhamHeader}.{sanPhamIdNguoiDang},{sanPhamHeader}.{sanPhamID},{sanPhamHeader}.{sanPhamSLDaBan},{sanPhamHeader}.{sanPhamSoLuong},{trangThaiHeader}.{trangThaiNgay},{trangThaiHeader}.{trangThaiTongThanhToan}
                FROM {trangThaiHeader} INNER JOIN {sanPhamHeader} ON {trangThaiHeader}.{trangThaiIdSanPham} = {sanPhamHeader}.{sanPhamID} 
                WHERE {sanPhamHeader}.{sanPhamIdNguoiDang} = '{idNguoiDang}' AND {trangThaiHeader}.{trangThaiTrangThai} = N'Đã nhận' AND YEAR(TRY_CAST({trangThaiHeader}.{trangThaiNgay} AS date)) = '{nam}'
            ";
            dsSanPham = new List<SanPham>();
            bangKetQua = dbConnection.LayNhieuDongDuLieu<string>(sqlStr);
            foreach (var dong in bangKetQua)
                dsSanPham.Add(new SanPham(dong[1], dong[0],null, null, null, dong[3], dong[2], null, dong[5], null, null, null, null, dong[4], null, null, null, null, null));
            return dsSanPham;
        }

        public string TinhTongKhachHang(string idNguoiDang) // Tính cái ô Tổng số lượng Khách hàng bên thống kê
        {
            string sqlStr = $@"
                SELECT DISTINCT COUNT({trangThaiHeader}.{trangThaiIdNguoiMua}) as TongSoKhachHang
                FROM {trangThaiHeader}
                INNER JOIN {sanPhamHeader} ON {trangThaiHeader}.{trangThaiIdSanPham} = {sanPhamHeader}.{sanPhamID}
                GROUP BY {sanPhamHeader}.{sanPhamIdNguoiDang}
                HAVING {sanPhamIdNguoiDang} = '{idNguoiDang}' 
            ";
            return dbConnection.LayMotGiaTri(sqlStr, "TongSoKhachHang");
        }

        public string TinhTongKhachHangTheoNam(string idNguoiDang,string nam,string thang) // Tính cái ô Tổng số lượng Khách hàng bên thống kê
        {
            string sqlStr = $@"
                SELECT COUNT(DISTINCT {trangThaiHeader}.{trangThaiIdNguoiMua}) as TongSoKhachHang
                FROM {trangThaiHeader}
                INNER JOIN {sanPhamHeader} ON {trangThaiHeader}.{trangThaiIdSanPham} = {sanPhamHeader}.{sanPhamID}
                WHERE YEAR(TRY_CAST({trangThaiHeader}.{trangThaiNgay} AS date)) = '{nam}' AND MONTH(TRY_CAST({trangThaiHeader}.{trangThaiNgay} AS date)) = '{thang}' AND {trangThaiHeader}.{trangThaiTrangThai} = N'Đã nhận'
                GROUP BY {sanPhamHeader}.{sanPhamIdNguoiDang}
                HAVING {sanPhamHeader}.{sanPhamIdNguoiDang} = '{idNguoiDang}' 
            ";
            return dbConnection.LayMotGiaTri(sqlStr, "TongSoKhachHang");
        }

        public void TangSoLuongDaBan(string idSanPham,int soLuongMua)
        {
            string sqlStr = $@" 
                UPDATE {sanPhamHeader}  
                SET {sanPhamSLDaBan} = CONVERT(INT,{sanPhamSLDaBan})+{soLuongMua}
                WHERE {sanPhamID} = {idSanPham}
            ";
            dbConnection.ThucThi(sqlStr);
        }
        public void GiamSoLuongDaBan(string idSanPham, int soLuongMua)
        {
            string sqlStr = $@" 
                UPDATE {sanPhamHeader}  
                SET {sanPhamSLDaBan} = CONVERT(INT,{sanPhamSLDaBan})-{soLuongMua}
                WHERE {sanPhamID} = {idSanPham}
            ";
            dbConnection.ThucThi(sqlStr);
        }
    }
}
