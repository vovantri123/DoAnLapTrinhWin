using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows;

namespace TraoDoiDo.Database
{
    public class DbConnection
    {
        private SqlConnection conn;

        public DbConnection()
        {
            conn = new SqlConnection(Properties.Settings.Default.connStr);
        }

        public bool ThucThi(string s)
        {
            bool co = false;
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(s, conn);
                if (cmd.ExecuteNonQuery() > 0)
                {
                    co = true;
                    MessageBoxButton messageBox = MessageBoxButton.OK;
                    if ((messageBox & MessageBoxButton.OK)!=0)
                    {
                        MessageBox.Show("Thành công");
                    }
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
            return co;
        }

        public string LayMotDoiTuong(string s, string data)
        {
            List<string> list = LayDanhSachMotDoiTuong(s, data);
            if (list.Count == 0)
            {
                return null;
            }
            else
            {
                return list[0];
            }
        }

        public List<string> LayDanhSachMotDoiTuong(string s, string data)
        {
            List<string> list = new List<string>();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(s, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(reader[data].ToString());
                }
                cmd.Dispose();
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return list;
        }
        public List<List<T>> LayDanhSachNhieuPhanTu<T>(string s)
        {
            List<List<T>> listResult = new List<List<T>>();

            try
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(s, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    List<T> list = new List<T>();
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        var value = (T)Convert.ChangeType(reader.GetValue(i), typeof(T));
                        list.Add(value);
                    }
                    listResult.Add(list);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return listResult;
        }
        public List<T> LayDanhSach<T>(string s)
        {
            List<T> list = new List<T>();
            try
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(s, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        var value = (T)Convert.ChangeType(reader.GetValue(i), typeof(T));
                        list.Add(value);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return list;
        }

    }
}
