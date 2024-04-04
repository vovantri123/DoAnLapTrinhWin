using System.Collections.Generic;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using TraoDoiDo.Models;

namespace TraoDoiDo.Database
{
    public class SanPhamDao : ThuocTinhDao
    {
        public void Them(SanPham sp)
        {
            string sqlStr = $@"INSERT INTO SanPham ({sanPhamID},{sanPhamIdNguoiDang},{sanPhamTen}, {sanPhamAnh}, {sanPhamLoai}, {sanPhamSoLuong}, {sanPhamSLDaBan}, {sanPhamGiaGoc}, {sanPhamGiaBan}, {sanPhamPhiShip}, {sanPhamTrangThai}, {sanPhamNoiBan}, {sanPhamXuatXu}, {sanPhamNgayMua}, {sanPhamPhamTramMoi}, {sanPhamMoTaChung}, {sanPhamSoLuotXem}) 
                   VALUES ('{sp.Id}','{sp.IdNguoi}' , N'{sp.Ten}', '{sp.LinkAnh}', N'{sp.Loai}', '{sp.SoLuong}', '{sp.SoLuongDaBan}', '{sp.GiaGoc}', '{sp.GiaBan}', '{sp.PhiShip}', N'{sp.TrangThai}', N'{sp.NoiBan}', N'{sp.XuatXu}', '{sp.NgayMua}', '{sp.PhanTramMoi}', N'{sp.MoTaChung}','{0}')";
            dbConnection.ThucThi(sqlStr);
        }
        public void Xoa(SanPham sp)
        {
            string sqlStr = $"DELETE FROM {sanPhamHeader} WHERE {sanPhamID} = {sp.Id}";
            dbConnection.ThucThi(sqlStr);
        }
        public void CapNhat(SanPham sp)
        {
            string sqlStr = $@"UPDATE {sanPhamHeader} SET {sanPhamTen} = N'{sp.Ten}', {sanPhamAnh} = '{sp.LinkAnh}', {sanPhamLoai} = N'{sp.Loai}', {sanPhamSoLuong} = '{sp.SoLuong}', "+
                      $" {sanPhamSLDaBan} = '{sp.SoLuongDaBan}', {sanPhamGiaGoc} = '{sp.GiaGoc}', {sanPhamGiaBan} = '{sp.GiaBan}', {sanPhamPhiShip} = '{sp.PhiShip}', "+
                     $" {sanPhamTrangThai} = N'{sp.TrangThai}', {sanPhamNoiBan} = N'{sp.NoiBan}', {sanPhamXuatXu} = N'{sp.XuatXu}', {sanPhamNgayMua} = '{sp.NgayMua}', "+
                      $" {sanPhamPhamTramMoi} = '{sp.PhanTramMoi}', {sanPhamMoTaChung} = N'{sp.MoTaChung}' WHERE {sanPhamID} = '{sp.Id}'";
            dbConnection.ThucThi(sqlStr);
        }
        public List<List<string>> LoadSanPhamCungLoai(SanPham sp)
        {
            string sqlStr = $@"
                        SELECT {sanPhamHeader}.{sanPhamID}, {sanPhamTen}, {sanPhamAnh}, {sanPhamGiaGoc}, {sanPhamGiaBan}, {sanPhamNoiBan} , {danhMucHeader}.{danhMucNguoiMua}, {sanPhamLoai}
                        FROM {sanPhamHeader} 
                        LEFT OUTER JOIN {danhMucHeader} ON {danhMucHeader}.{danhMucNguoiMua} = '{sp.IdNguoi}' AND {danhMucHeader}.{sanPhamID} = {sanPhamHeader}.{sanPhamID}
                        WHERE Loai = N'{sp.Loai}' AND SanPham.IdSanPham != '{sp.Id}'
                        ";
            return dbConnection.LayDanhSachNhieuPhanTu<string>(sqlStr);
        }
        public List<List<string>> LoadAnhVaMoTa(SanPham sp)
        {
            string sqlStr = $@"
                    SELECT {sanPhamHeader}.{sanPhamAnh}, {moTaSanPhamHeader}.{moTaSanPhamLinkAnh}, {moTaSanPhamHeader}.{moTaSanPhamMoTa} 
                    FROM {sanPhamHeader} INNER JOIN {moTaSanPhamHeader} 
                    ON {sanPhamHeader}.{sanPhamID} = {moTaSanPhamHeader}.{sanPhamID}
                    WHERE {sanPhamHeader}.{sanPhamID} = '{sp.Id}'
                ";
            return dbConnection.LayDanhSachNhieuPhanTu<string>(sqlStr);
        }
        public List<string> LoadThongTinSanPham(SanPham sp)
        {
            string sqlStr = $@"
                    SELECT {sanPhamTen}, {sanPhamLoai}, {sanPhamSoLuong}, {sanPhamSLDaBan}, {sanPhamGiaGoc}, {sanPhamGiaBan}, {sanPhamPhiShip}, {sanPhamNoiBan}, {sanPhamXuatXu}, {sanPhamNgayMua}, {sanPhamPhamTramMoi}, {sanPhamMoTaChung} 
                    FROM {sanPhamHeader}
                    WHERE {sanPhamID} = '{sp.Id}' ";
            return dbConnection.LayDanhSach<string>(sqlStr);
        }
        public List<List<string>> LoadSanPham(string idNguoiMua)
        {
            string sqlStr = $@" SELECT {sanPhamHeader}.{sanPhamID}, {sanPhamHeader}.{sanPhamTen}, {sanPhamHeader}.{sanPhamAnh}, {sanPhamHeader}.{sanPhamGiaGoc}, {sanPhamHeader}.{sanPhamGiaBan}, {sanPhamHeader}.{sanPhamNoiBan}, {sanPhamHeader}.{sanPhamSoLuotXem}, {nguoiDungHeader}.{nguoiDungID},{danhMucHeader}.{danhMucNguoiMua} ,{sanPhamHeader}.{sanPhamLoai}
                    FROM {sanPhamHeader} INNER JOIN {nguoiDungHeader} ON {sanPhamHeader}.{sanPhamIdNguoiDang} = {nguoiDungHeader}.{nguoiDungID} LEFT OUTER JOIN {danhMucHeader} ON {danhMucHeader}.{danhMucNguoiMua} = '{idNguoiMua}' AND {danhMucHeader}.{sanPhamID} = {sanPhamHeader}.{sanPhamID}
                ";
            return dbConnection.LayDanhSachNhieuPhanTu<string>(sqlStr);
        }
        public string LayLuotXem(string idSP)
        {
            string sqlStr = $"SELECT {sanPhamSoLuotXem} FROM {sanPhamHeader} WHERE {sanPhamID}='{idSP}'";
            return dbConnection.LayMotDoiTuong(sqlStr, $"{sanPhamSoLuotXem}");
        }
        public List<List<string>> timKiemBangId(string id)
        {
            string sqlStr = $" SELECT {sanPhamID}, {sanPhamTen}, {sanPhamAnh}, {sanPhamLoai}, {sanPhamSoLuong}, {sanPhamSLDaBan}, {sanPhamGiaGoc}, {sanPhamGiaBan}, {sanPhamPhiShip}, {sanPhamTrangThai}" +
                $" FROM {sanPhamHeader} WHERE {sanPhamIdNguoiDang} = '{id}' ";
            return dbConnection.LayDanhSachNhieuPhanTu<string>(sqlStr);
        }
        public List<string> timKiemToanBoBangId(string id)
        {
            string sqlStr = $" SELECT *FROM {sanPhamHeader} WHERE {sanPhamID} = '{id}' ";
            return dbConnection.LayDanhSach<string>(sqlStr);
        }
        public List<List<string>> timKiemBangTen(string ten, string id)
        {
            string sqlStr = $" SELECT {sanPhamID}, {sanPhamTen}, {sanPhamAnh}, {sanPhamLoai}, {sanPhamSoLuong}, {sanPhamSLDaBan}, {sanPhamGiaGoc}, {sanPhamGiaBan}, {sanPhamPhiShip}, {sanPhamTrangThai}" +
                    $" FROM {sanPhamHeader} WHERE {sanPhamTen} LIKE N'{ten}%' AND {sanPhamIdNguoiDang}='{id}'";
            return dbConnection.LayDanhSachNhieuPhanTu<string>(sqlStr);
        }
        public List<List<string>> timKiemBangLoai(string loai, string id)
        {
            string sqlStr = $" SELECT {sanPhamID}, {sanPhamTen}, {sanPhamAnh}, {sanPhamLoai}, {sanPhamSoLuong}, {sanPhamSLDaBan}, {sanPhamGiaGoc}, {sanPhamGiaBan}, {sanPhamPhiShip}, {sanPhamTrangThai}" +
                    $" FROM {sanPhamHeader} WHERE {sanPhamLoai} LIKE N'{loai}%' AND {sanPhamIdNguoiDang}='{id}'";
            return dbConnection.LayDanhSachNhieuPhanTu<string>(sqlStr);
        }
        public List<string> timKiemId()
        {
            string sqlStr = $"SELECT {sanPhamID} FROM {sanPhamHeader}";
            return dbConnection.LayDanhSachMotDoiTuong(sqlStr, $"{sanPhamID}");
        }
    }
}
