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
            string sqlStr = $@"
                INSERT INTO {taiKhoanHeader} ({taiKhoanIdNguoiDung},{taiKhoanTenDangNhap}, {taiKhoanMatKhau}) 
                VALUES ({tk.IDNguoiDung},'{tk.TenDangNhap}','{tk.MatKhau}')
            ";
            dbConnection.ThucThi(sqlStr);
        }

        public void Xoa(string id)
        {
            string sqlStr = $@"
                DELETE FROM {taiKhoanHeader} 
                WHERE {taiKhoanIdNguoiDung} = '{id}' 
            ";
            dbConnection.ThucThi(sqlStr);
        }

        public void CapNhat(TaiKhoan tk)
        {
            string sql = $@"
                UPDATE {taiKhoanHeader} 
                SET {taiKhoanMatKhau}='{tk.MatKhau}' 
                WHERE {taiKhoanTenDangNhap}='{tk.TenDangNhap}'
            ";
            dbConnection.ThucThi(sql);
        }  
    }
}
