using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TraoDoiDo.ViewModels;

namespace TraoDoiDo.Database
{
    public class DbConnection
    {
        private SqlConnection conn;

        public DbConnection()
        {
            conn = new SqlConnection(Properties.Settings.Default.connStr);
        }

        public void ThucThi(string s)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(s, conn);
                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Thành công");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Thất bại" + ex);
            }
            finally
            {
                conn.Close();
            }
        }
        public string LayMotDoiTuong(string s,string data)
        {
            XuLyTienIch xly = new XuLyTienIch();
            List<object> list = LayDanhSachDoiTuong(s,data);
            if (list.Count == 0)
            {
                return null;
            }
            else
            {
                return xly.TaoIdMoi(list);
            }
        }

        public List<object> LayDanhSachDoiTuong(string s,string data)
        {
            List<object> list = new List<object>();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(s, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(reader[$"{data}"]);
                }
                cmd.Dispose();
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("");
            }
            finally
            {
                conn.Close();
            }
            return list;
        }
    }
}
