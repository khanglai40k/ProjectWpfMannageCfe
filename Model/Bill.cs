using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace QuanLiCaphe.Model
{
    public class Bill
    {
       
        private string connectionString = "Server=DESKTOP-7FVAQ4R\\SQLEXPRESS;Database=QuanLyCaPhe;Trusted_Connection=True;";
        public int Id { get; set; }
        public int IdTable { get; set; }
        public DateTime Time { get; set; }
     

        // Thêm hóa đơn
        public void AddBill(int idTable)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO Bill (DateCheckIn, idTable, Status) VALUES (@DateCheckIn, @IdTable, @Status)";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.Add("@DateCheckIn", SqlDbType.DateTime).Value = DateTime.Now; // Chèn thời gian hiện tại
                    command.Parameters.Add("@IdTable", SqlDbType.Int).Value = idTable;
                    command.Parameters.Add("@Status", SqlDbType.NVarChar, 50).Value = "Chưa thanh toán"; // Điều chỉnh kích thước nếu cần

                    connection.Open();
                    int result = command.ExecuteNonQuery();
                    if (result > 0)
                    {
                        MessageBox.Show("Thêm hóa đơn thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        MessageBox.Show("Không có hóa đơn nào được thêm.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm hóa đơn: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }






        // Sửa hóa đơn
        public void UpdateBill(int idTable)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "UPDATE Bill SET DateCheckOut = @DateCheckOut, Status = @Status WHERE idTable = @IdTable AND DateCheckOut IS NULL";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@DateCheckOut", DateTime.Now); // Chèn thời gian hiện tại
                    command.Parameters.AddWithValue("@IdTable", idTable);
                    command.Parameters.AddWithValue("@Status", "Đã thanh toán");

                    connection.Open();
                    int result = command.ExecuteNonQuery();

                    if (result > 0)
                    {
                        // Cập nhật thành công
                        Console.WriteLine("Hóa đơn đã được cập nhật thành công.");
                    }
                    else
                    {
                        // Không tìm thấy bản ghi để cập nhật
                        Console.WriteLine("Không có hóa đơn nào để cập nhật.");
                    }
                }
            }
            catch (Exception ex)
            {
                // Ghi log hoặc hiển thị thông báo lỗi
                Console.WriteLine($"Lỗi khi cập nhật hóa đơn: {ex.Message}");
            }
        }


        // Xóa hóa đơn
        public void DeleteBill(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Bill WHERE Id = @Id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", id);
                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
            }
        }

        // Lấy danh sách hóa đơn
        public List<BillItem> GetAllBills()
        {
            List<BillItem> bills = new List<BillItem>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT Id, DateCheckIn, DateCheckOut, idTable, Status FROM Bill";
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        BillItem bill = new BillItem
                        {
                            Id = reader.GetInt32(0),
                            DateCheckIn = reader.GetDateTime(1),
                            DateCheckOut = reader.IsDBNull(2) ? (DateTime?)null : reader.GetDateTime(2),
                            IdTable = reader.GetInt32(3),
                            Status = reader.GetString(4)
                        };
                        bills.Add(bill);
                    }
                }
            }

            return bills;
        }

        public int GetBillIdByTableId(int idTable)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT id FROM Bill WHERE idTable = @IdTable";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@IdTable", idTable);
                connection.Open();

                object result = command.ExecuteScalar();

              

                return result != null ? Convert.ToInt32(result) : -1;
            }
        }



        public bool IsTableOccupied(int idTable)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT COUNT(*) FROM Bill WHERE idTable = @IdTable AND status = 'Chưa thanh toán'";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@IdTable", idTable);
                    connection.Open();

                    int count = (int)command.ExecuteScalar();
                    return count > 0; // Trả về true nếu có hóa đơn cho bàn
                }
            }
            catch (Exception ex)
            {
                // Ghi log hoặc xử lý lỗi
                Console.WriteLine($"Lỗi: {ex.Message}");
                return false; // Giả định bàn không có khách trong trường hợp lỗi
            }
        }

    }

    public class BillItem
    {
        public int Id { get; set; }
        public DateTime DateCheckIn { get; set; }
        public DateTime? DateCheckOut { get; set; }
        public int IdTable { get; set; }
        public string Status { get; set; }
    }
}
