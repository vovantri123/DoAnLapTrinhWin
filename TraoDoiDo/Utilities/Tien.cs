using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraoDoiDo.Utilities
{
    public class Tien
    {
        public static string DinhDangTien(string tien)
        {
            return Convert.ToDouble(tien).ToString("#,##0");
        }
    }
}
