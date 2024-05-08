using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraoDoiDo.Models;

namespace TraoDoiDo.Database
{
    public class NguoiDungVoucherDao:ThuocTinhDao
    {
        public void Them(NguoiDungVoucher ndvc)
        {
            string sqlStr = $@"INSERT INTO {nguoiDungVoucherHeader} ({nguoiDungVoucherIdNguoiDung},{nguoiDungVoucherIdVoucher}) 
                   VALUES ('{ndvc.IdNguoiDung}', '{ndvc.IdVoucher}')";
            dbConnection.ThucThi(sqlStr);
        }

        public void Xoa(NguoiDungVoucher ndvc) //Xóa theo cả id NguoiDung và Id voucher
        {
            string sqlStr = $@" DELETE FROM {nguoiDungVoucherHeader}
                WHERE {nguoiDungVoucherIdNguoiDung} = '{ndvc.IdNguoiDung}' AND {nguoiDungVoucherIdVoucher} = '{ndvc.IdVoucher}'";
            dbConnection.ThucThi(sqlStr);
        } 

        public void XoaTheoIdVoucher(string idVoucher) //Xóa theo cả id NguoiDung và Id voucher
        {
            string sqlStr = $@" DELETE FROM {nguoiDungVoucherHeader}
                WHERE {nguoiDungVoucherIdVoucher} = '{idVoucher}'";
            dbConnection.ThucThi(sqlStr);
        } 
    }
}
