using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
