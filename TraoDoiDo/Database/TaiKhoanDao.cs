using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraoDoiDo.Models;

namespace TraoDoiDo.Database
{
    public class TaiKhoanDao : ThuocTinhDao
    {
        public void Them(TaiKhoan tk)
        {
            string sqlStr = $"INSERT INTO {taiKhoanHeader} ({taiKhoanTenDangNhap}, {taiKhoanMatKhau}, {taiKhoanIdNguoiDung})" + $"VALUES ('{tk.TenDangNhap}','{tk.MatKhau}','{tk.IDNguoiDung}')";
            dbConnection.ThucThi(sqlStr);
        }
        public string TaoID(TaiKhoan tk)
        {
            string sqlStr = $"SELECT MAX({taiKhoanIdNguoiDung}) FROM {taiKhoanHeader}";
            return dbConnection.LayMotDoiTuong(sqlStr, "ID");
        }
    }
}
