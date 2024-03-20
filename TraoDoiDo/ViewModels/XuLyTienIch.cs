using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraoDoiDo.ViewModels
{
    public class XuLyTienIch
    { 
        public string TaoIdMoi(List<object> list)
        {
            string IdMoi = "";
            int max = 0;
            foreach (string item in list)
            {
                string numStr = item.Substring(2);
                int num = int.Parse(numStr);
                if (num > max)
                {
                    max = num;
                }
            }
            int newNum = max + 1;
            string newNumStr = newNum.ToString("000");
            IdMoi = "US" + newNumStr;
            return IdMoi;
        }
    }
}
