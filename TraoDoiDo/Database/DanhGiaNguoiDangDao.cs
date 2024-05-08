using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraoDoiDo.Models;

namespace TraoDoiDo.Database
{
    public class DanhGiaNguoiDangDao:ThuocTinhDao
    {
        List<string> dongKetQua;
        List<List<string>> bangKetQua;
        List<DanhGiaNguoiDang> dsDanhGiaNguoiDang; 
         
        public void Them(DanhGiaNguoiDang danhGiaNguoiDung)
        {
            string sqlStr = $@" 
                INSERT INTO {danhGiaHeader} ({danhGiaIdNguoiDang}, {danhGiaIdNguoiMua} ,{danhGiaSoSao}, {danhGiaNhanXet})  
                VALUES ({danhGiaNguoiDung.IdNguoiDang}, {danhGiaNguoiDung.IdNguoiMua}, N'{danhGiaNguoiDung.SoSao}', N'{danhGiaNguoiDung.NhanXet}')
            ";
            dbConnection.ThucThi(sqlStr);
        }

        public void Xoa(DanhGiaNguoiDang danhGiaNguoiDung)
        {
            string sqlStr = $@" 
                DELETE {danhGiaHeader} 
                WHERE {danhGiaIdNguoiDang} = {danhGiaNguoiDung.IdNguoiDang} AND {danhGiaIdNguoiMua} = {danhGiaNguoiDung.IdNguoiMua}
            ";
            dbConnection.ThucThi(sqlStr);
        }

        public DanhGiaNguoiDang timTenNguoiDangVaNhanXet(string idNguoi)
        {
            string sqlStr = $@"
                SELECT {nguoiDungTen}, COUNT({danhGiaNhanXet}) as SLNhanXet
                FROM {nguoiDungHeader}
                INNER JOIN {danhGiaHeader} ON {nguoiDungHeader}.{nguoiDungID} = {danhGiaHeader}.{danhGiaIdNguoiDang}
                GROUP BY {nguoiDungID},{nguoiDungTen}
                HAVING {nguoiDungID} = '{idNguoi}' 
            ";
            dongKetQua = dbConnection.LayMotDongDuLieu<string>(sqlStr);
            if (dongKetQua != null)
                return new DanhGiaNguoiDang(null, dongKetQua[0], null, null, null, null, dongKetQua[1], null);
            return null;
        }

        public List<DanhGiaNguoiDang> DemSoLuotDanhGiaTheoTungSoSao(string idNguoiDang)
        {
            string sqlStr = $@"
                SELECT {danhGiaSoSao}, COUNT({danhGiaIdNguoiMua}) 
                FROM {danhGiaHeader}
                WHERE {danhGiaIdNguoiDang}= '{idNguoiDang}'
                GROUP BY {danhGiaSoSao} 
            ";
            bangKetQua = dbConnection.LayNhieuDongDuLieu<string>(sqlStr);
            dsDanhGiaNguoiDang = new List<DanhGiaNguoiDang>();
            foreach (var dong in bangKetQua)
                dsDanhGiaNguoiDang.Add(new DanhGiaNguoiDang(null, null, null, null, dong[0], null, dong[1], null));
            return dsDanhGiaNguoiDang;
        }

        public List<DanhGiaNguoiDang> TinhTrungBinhSoSao(string soSaoDau, string soSaoCuoi)
        {
            string sqlStr = $@"
                SELECT {danhGiaHeader}.{danhGiaIdNguoiDang}, ROUND(AVG(CONVERT(FLOAT,{danhGiaHeader}.{danhGiaSoSao})),2) as SoSaoTB
                FROM {danhGiaHeader}
                GROUP BY {danhGiaHeader}.{danhGiaIdNguoiDang}
                HAVING AVG(CONVERT(FLOAT,{danhGiaSoSao})) BETWEEN '{soSaoDau}' AND '{soSaoCuoi}' 
            ";
            bangKetQua = dbConnection.LayNhieuDongDuLieu<string>(sqlStr);
            dsDanhGiaNguoiDang = new List<DanhGiaNguoiDang>();
            foreach (var dong in bangKetQua)
                dsDanhGiaNguoiDang.Add(new DanhGiaNguoiDang(dong[0], null, null, null, dong[1], null, null, null));
            return dsDanhGiaNguoiDang;
        }

        public string TinhTrungBinhSoSaoTheoIdNguoiDang(string idNguoiDang)
        {
            string sqlStr = $@"
                SELECT ROUND(AVG(CONVERT(FLOAT,{danhGiaSoSao})),2) AS SoSaoTB
                FROM {danhGiaHeader}
                GROUP BY {danhGiaIdNguoiDang}
                HAVING {danhGiaIdNguoiDang} = {idNguoiDang}
            "; 
            return dbConnection.LayMotGiaTri(sqlStr, "SoSaoTB");
        }

        public NguoiDung LoadThongTinNguoiDang(string idNguoiDang)
        {
            string sqlStr = $@" 
                SELECT distinct {nguoiDungTen}, {nguoiDungSdt}, {nguoiDungEmail}, {nguoiDungDiaChi}, {nguoiDungHeader}.{nguoiDungAnh} 
                FROM {danhGiaHeader}
                INNER JOIN {nguoiDungHeader} ON {danhGiaHeader}.{sanPhamIdNguoiDang} = {nguoiDungHeader}.{nguoiDungID} 
                WHERE {danhGiaHeader}.{danhGiaIdNguoiDang} =  '{idNguoiDang}'
                ";
            dongKetQua = dbConnection.LayMotDongDuLieu<string>(sqlStr);
            if(dongKetQua!=null)
                return new NguoiDung(null, dongKetQua[0], null, null, null, dongKetQua[2], dongKetQua[1], dongKetQua[3], dongKetQua[4], null, null);
            return null;
        }

        public List<DanhGiaNguoiDang> LoadDanhSachDanhGia(string idNguoiDang)
        {
            string sqlStr = $@" 
                SELECT {nguoiDungHeader}.{nguoiDungTen}, {danhGiaHeader}.{danhGiaSoSao}, {danhGiaHeader}.{danhGiaNhanXet}, {nguoiDungHeader}.{nguoiDungAnh} 
                FROM {danhGiaHeader}
                INNER JOIN {nguoiDungHeader} ON {danhGiaHeader}.{danhGiaIdNguoiMua} = {nguoiDungHeader}.{nguoiDungID} 
                WHERE {danhGiaHeader}.{danhGiaIdNguoiDang} = '{idNguoiDang}' ";
            bangKetQua = dbConnection.LayNhieuDongDuLieu<string>(sqlStr);
            dsDanhGiaNguoiDang = new List<DanhGiaNguoiDang>();
            foreach (var dong in bangKetQua)
                dsDanhGiaNguoiDang.Add(new DanhGiaNguoiDang(null, null, null, dong[0], dong[1], dong[2], null, dong[3]));     
            return dsDanhGiaNguoiDang; 
        }
    }
}
