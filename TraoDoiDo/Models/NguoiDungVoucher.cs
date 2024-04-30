namespace TraoDoiDo.Models
{
    public class NguoiDungVoucher
    {
        string idVoucher="";
        string idNguoiDung="";
        

        public NguoiDungVoucher(string idVoucher, string idNguoiDung)
        {
            this.IdVoucher = idVoucher;
            this.IdNguoiDung = idNguoiDung;
        }

        public string IdVoucher { get => idVoucher; set => idVoucher = value; }
        public string IdNguoiDung { get => idNguoiDung; set => idNguoiDung = value; }
    }
}
