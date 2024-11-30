using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace QuanLiCaphe.Model
{
    internal class Staff
    {
        private string connectionString = "Server=DESKTOP-7FVAQ4R\\SQLEXPRESS;Database=QuanLyCaPhe;Trusted_Connection=True;";

        // Thêm tài khoản nhân viên
        public void AddStaff(string displayName, string userName, string password, string wage, string position)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Account (DisplayName, UserName, Password, Wage, Position) VALUES (@DisplayName, @UserName, @Password, @Wage, @Position)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@DisplayName", displayName);
                command.Parameters.AddWithValue("@UserName", userName);
                command.Parameters.AddWithValue("@Password", password);
                command.Parameters.AddWithValue("@Wage", wage);
                command.Parameters.AddWithValue("@Position", position);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
        // update
        public void UpdateStaff(string displayName, string userName, string password, string wage, string position)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE Account SET DisplayName = @DisplayName, Password = @Password, Wage = @Wage, Position = @Position WHERE UserName = @UserName";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@DisplayName", displayName);
                command.Parameters.AddWithValue("@UserName", userName);
                command.Parameters.AddWithValue("@Password", password);
                command.Parameters.AddWithValue("@Wage", wage);
                command.Parameters.AddWithValue("@Position", position);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }


        // Xóa tài khoản nhân viên
        public void DeleteStaff(string userName)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Account WHERE UserName = @UserName";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@UserName", userName);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        // Lấy danh sách tất cả tài khoản nhân viên
        public List<StaffItem> GetAllStaff()
        {
            List<StaffItem> staffList = new List<StaffItem>();
            string query = "SELECT DisplayName, UserName, Password, Wage, Position FROM Account";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        StaffItem staff = new StaffItem
                        {
                            DisplayName = reader.GetString(0),
                            UserName = reader.GetString(1),
                            Password = reader.GetString(2),
                            Wage = reader.GetString(3),
                            Position = reader.GetString(4) // Đọc thông tin chức vụ
                        };
                        staffList.Add(staff);
                    }
                }
            }

            return staffList;
        }


        public class StaffItem
        {
            public string DisplayName { get; set; }
            public string UserName { get; set; }
            public string Password { get; set; }
            public string Wage { get; set; }
            public string Position { get; set; } // Lưu trữ thông tin chức vụ dưới dạng chuỗi
        }
    }
}
