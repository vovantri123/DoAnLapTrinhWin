﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TraoDoiDo.Models;

namespace TraoDoiDo.Database
{
    public class GioHangDao:ThuocTinhDao
    {
        List<List<string>> bangKetQua;

        public void Them(GioHang gioHang)
        {
            string sqlStr = $@"
                INSERT INTO {gioHangHeader} ({gioHangIdNguoiMua}, {gioHangIdSanPham}, {gioHangSoLuongMua})  
                VALUES ('{gioHang.IdNguoiMua}', '{gioHang.IdSanPham}','{gioHang.SoLuongMua}') 
            ";
            dbConnection.ThucThi(sqlStr);
        }

        public void Xoa(string idSP, string idNguoiMua)
        {
            string strSql = $@"
                DELETE FROM {gioHangHeader} 
                WHERE {gioHangIdNguoiMua}= '{idNguoiMua}' AND {gioHangIdSanPham} = '{idSP}' 
            ";
            dbConnection.ThucThi(strSql);
        }

        public List<GioHang> timThongTinSanPhamTheoIDNguoiMua(string idNguoi)
        {
            string sqlStr = $@" 
                SELECT {gioHangHeader}.{gioHangIdSanPham}, {sanPhamTen}, {sanPhamAnh}, {sanPhamGiaBan}, {sanPhamPhiShip}, {gioHangHeader}.{gioHangSoLuongMua}, {sanPhamSoLuong}, {sanPhamSLDaBan} 
                FROM {gioHangHeader} INNER JOIN {nguoiDungHeader} ON {gioHangHeader}.{quanLyIdNguoiMua} = {nguoiDungHeader}.{nguoiDungID}
                INNER JOIN {sanPhamHeader} ON {gioHangHeader}.{gioHangIdSanPham} = {sanPhamHeader}.{sanPhamID}
                WHERE {nguoiDungHeader}.{nguoiDungID} = '{idNguoi}' 
            ";
            bangKetQua = dbConnection.LayNhieuDongDuLieu<string>(sqlStr);
            List<GioHang> dsGioHang = new List<GioHang>();
            foreach (var dong in bangKetQua)
                dsGioHang.Add(new GioHang(idNguoi, dong[0], dong[5], dong[1], dong[2], dong[3], dong[4], dong[6], dong[7]));

            return dsGioHang;
        }
    }
}
