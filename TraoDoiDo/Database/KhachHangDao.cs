using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraoDoiDo.Models;

namespace TraoDoiDo.Database
{
    public class KhacHangDao : ThuocTinhDao
    {
        public void Them(KhachHang user)
        {
            string sqlStr = $"INSERT INTO {nguoiDungHeader} ({nguoiDungID},{nguoiDungTen},{nguoiDungGioiTinh},{nguoiDungNgaySinh},{nguoiDungSdt},{nguoiDungCMND},{nguoiDungDiaChi},{nguoiDungEmail})"
                            + $"VALUES ('{user.Id}','{user.HoTen}','{user.GioiTinh}','{Convert.ToString(user.NgaySinh)}','{user.Sdt}','{user.Cmnd}','{user.DiaChi}','{user.Email}')";
            dbConnection.ThucThi(sqlStr);
        }
        public void Xoa(string id)
        {
            string sqlStr = $"DELETE FROM {nguoiDungHeader} WHERE {nguoiDungID}='{id}'";
            dbConnection.ThucThi(sqlStr);
        }
        public void Update(KhachHang user)
        {
            string sqlStr = $"UPDATE {nguoiDungHeader} SET " +
                $"{nguoiDungTen}=N'{user.HoTen}', {nguoiDungGioiTinh}=N'{user.GioiTinh}', {nguoiDungNgaySinh}='{Convert.ToString(user.NgaySinh)}'," +
                $"{nguoiDungCMND} = '{user.Cmnd}', {nguoiDungEmail} = '{user.Email}',{nguoiDungSdt} = '{user.Sdt}'," +
                $"{nguoiDungDiaChi} = '{user.DiaChi}' WHERE {nguoiDungID}='{user.Id}'";
            dbConnection.ThucThi(sqlStr);
        }
    }
}
