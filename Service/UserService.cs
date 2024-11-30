using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiCaphe.Service
{
    public class UserService
    {
        private string connectionString = "Server=DESKTOP-7FVAQ4R\\SQLEXPRESS;Database=QuanLyCaPhe;Trusted_Connection=True;";

        // Đăng ký người dùng
        //public bool Register(string username, string password)
        //{
        //    using (SqlConnection conn = new SqlConnection(connectionString))
        //    {
        //        conn.Open();
        //        SqlCommand cmd = new SqlCommand("INSERT INTO Users (Username, Password) VALUES (@Username, @Password)", conn);
        //        cmd.Parameters.AddWithValue("@Username", username);
        //        cmd.Parameters.AddWithValue("@Password", password);  // Lưu trực tiếp mật khẩu
        //        return cmd.ExecuteNonQuery() > 0;
        //    }
        //}

        // Đăng nhập người dùng
        public bool Login(string username, string password)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT Password FROM Users WHERE Username = @Username", conn);
                cmd.Parameters.AddWithValue("@Username", username);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string storedPassword = reader["Password"].ToString();  // Lấy mật khẩu lưu trữ
                        return storedPassword == password;  // So sánh trực tiếp mật khẩu
                    }
                }
            }
            return false;
        }
    }
}
