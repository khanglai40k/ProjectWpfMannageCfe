using System;
using System.Data;
using System.Data.SqlClient;

namespace QuanLiCaphe.Model
{
    public class Revenue
    {
        private string connectionString = "Server=DESKTOP-7FVAQ4R\\SQLEXPRESS;Database=QuanLyCaPhe;Trusted_Connection=True;";

        public int Id { get; set; }
        public DateTime Time { get; set; }
        public decimal TotalMoney { get; set; }

        // Phương thức để thêm doanh thu vào bảng
        public void AddRevenue(float totalMoney)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO [QuanLyCaPhe].[dbo].[Revenue] ([Time], [TotalMoney]) VALUES (@Time, @TotalMoney)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Time", SqlDbType.DateTime).Value = DateTime.Now;
                    command.Parameters.AddWithValue("@TotalMoney", totalMoney);

                    connection.Open();
                    int result = command.ExecuteNonQuery(); // Thực hiện câu lệnh INSERT

                }
            }
        }
    }
}
