using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows;

namespace TraoDoiDo.Database
{ 
    public class DbConnection
    {
        SqlConnection conn;

        public DbConnection()
        {
            conn = new SqlConnection(Properties.Settings.Default.connStr);
        }

        public bool ThucThi(string sqlStr) // dùng cho mấy cái lệnh DELETE và UPDATE
        {
            bool co = false;
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sqlStr, conn);
                if (cmd.ExecuteNonQuery() > 0) 
                    co = true;  
            }
            catch (Exception ex)
            {
                MessageBox.Show("Thực thi thất bại\nLỗi: " + ex);
            }
            finally
            {
                conn.Close();
            }    
            return co;
        }
      
        public string LayMotGiaTri(string sqlStr, string tenCot) //Trong 1 cột, lấy ra thuộc tính đầu tiên thỏa sqlStr  (đã xài)
        {
            List<string> list = new List<string>();

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sqlStr, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(reader[tenCot].ToString());
                }
                cmd.Dispose();
                reader.Close();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            finally
            { 
                conn.Close(); 
            }

            if (list.Count == 0)
                return null;
            return list[0];
        }
 
        public List<List<T>>LayNhieuDongDuLieu<T>(string sqlStr) // Lấy ra nhiều dòng dữ liệu thỏa sqlStr 
        {
            List<List<T>> bangKetQua = new List<List<T>>(); // T hoặc là int, hoặc là string, hoặc là đối tượng(cho phép lưu nhiều kiểu dữ liệu khác nhau)

            try
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(sqlStr, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    List<T> dong = new List<T>();
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        var giaTri = (T)Convert.ChangeType(reader.GetValue(i), typeof(T));
                        dong.Add(giaTri);
                    }
                    bangKetQua.Add(dong);
                }
                cmd.Dispose();
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return bangKetQua;
        }

        public List<T>LayMotDongDuLieu<T>(string sqlStr) // Lấy ra 1 dòng dữ liệu thỏa sqlStr 
        {
            List<List<T>> bangKetQua = LayNhieuDongDuLieu<T>(sqlStr);
            return bangKetQua.Count == 0 ? null : bangKetQua[0];
        }

    }
}
