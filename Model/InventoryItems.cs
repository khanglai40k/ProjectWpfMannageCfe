using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows; // Thêm using để sử dụng MessageBox

namespace QuanLiCaphe.Model
{
    public class InventoryItem
    {
        private string connectionString = "Server=DESKTOP-7FVAQ4R\\SQLEXPRESS;Database=QuanLyCaPhe;Trusted_Connection=True;";

        // Các thuộc tính của mặt hàng
        public int Id { get; set; } // Sử dụng Id thay cho ItemID
        public string Name { get; set; }
        public int Quantity { get; set; }
        public bool IsOn { get; set; }

        // Lấy danh sách tất cả các thiết bị từ database
        public List<InventoryItem> GetAllItems()
        {
            List<InventoryItem> items = new List<InventoryItem>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT [id], [name], [quantity], [isOn] FROM [QuanLyCaPhe].[dbo].[InventoryItems]";
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        items.Add(new InventoryItem
                        {
                            Id = reader.GetInt32(0), // Đọc Id từ cột đầu tiên
                            Name = reader.GetString(1),
                            Quantity = reader.GetInt32(2),
                            IsOn = reader.GetBoolean(3)
                        });
                    }
                }
            }
            return items;
        }

        // Thêm mới một thiết bị vào bảng InventoryItems
        public void AddItem()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO [QuanLyCaPhe].[dbo].[InventoryItems] ([name], [quantity], [isOn]) VALUES (@Name, @Quantity, @IsOn)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Name", Name);
                        command.Parameters.AddWithValue("@Quantity", Quantity);
                        command.Parameters.AddWithValue("@IsOn", IsOn);

                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException ex)
            {
                // Kiểm tra thông báo lỗi để hiển thị cho người dùng
                if (ex.Message.Contains("An item with the same name already exists."))
                {
                    MessageBox.Show("Món đồ này đã tồn tại. Vui lòng nhập tên khác.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else
                {
                    MessageBox.Show("Đã xảy ra lỗi khi thêm món đồ: " + ex.Message, "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        // Cập nhật thông tin của thiết bị hiện tại dựa trên Id
        public void UpdateItem()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "UPDATE [QuanLyCaPhe].[dbo].[InventoryItems] SET [name] = @Name, [quantity] = @Quantity, [isOn] = @IsOn WHERE [id] = @Id";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Id", Id); // Sử dụng Id cho điều kiện WHERE
                        command.Parameters.AddWithValue("@Name", Name);
                        command.Parameters.AddWithValue("@Quantity", Quantity);
                        command.Parameters.AddWithValue("@IsOn", IsOn);

                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException ex)
            {
                // Kiểm tra thông báo lỗi để hiển thị cho người dùng
                if (ex.Message.Contains("An item with the same name already exists."))
                {
                    MessageBox.Show("Món đồ này đã tồn tại. Vui lòng nhập tên khác.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else
                {
                    MessageBox.Show("Đã xảy ra lỗi khi cập nhật món đồ: " + ex.Message, "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        // Xóa thiết bị khỏi bảng InventoryItems dựa trên Id
        public void DeleteItem()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM [QuanLyCaPhe].[dbo].[InventoryItems] WHERE [id] = @Id";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", Id); // Sử dụng Id cho điều kiện WHERE

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
