using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace QuanLiCaphe.Model
{
    public class CategoryFood
    {
        private string connectionString = "Server=DESKTOP-7FVAQ4R\\SQLEXPRESS;Database=QuanLyCaPhe;Trusted_Connection=True;";

        // Thêm danh mục món ăn
        public void AddCategory(string name)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Kiểm tra xem danh mục đã tồn tại hay chưa
                string checkQuery = "SELECT COUNT(*) FROM FoodCategory WHERE Name = @Name";
                SqlCommand checkCommand = new SqlCommand(checkQuery, connection);
                checkCommand.Parameters.AddWithValue("@Name", name);
                connection.Open();

                int count = (int)checkCommand.ExecuteScalar(); // Trả về số lượng danh mục trùng tên

                if (count > 0)
                {
                    // Nếu danh mục đã tồn tại, ném ngoại lệ
                    throw new Exception("Danh mục đã tồn tại.");
                }
                else
                {
                    // Thêm danh mục nếu chưa tồn tại
                    string query = "INSERT INTO FoodCategory (Name) VALUES (@Name)";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Name", name);
                    command.ExecuteNonQuery();
                }
            }
        }


        // Sửa danh mục món ăn
        public void UpdateCategory(int id, string name)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Kiểm tra xem tên danh mục đã tồn tại chưa
                string checkQuery = "SELECT COUNT(*) FROM FoodCategory WHERE Name = @Name AND Id != @Id";
                SqlCommand checkCommand = new SqlCommand(checkQuery, connection);
                checkCommand.Parameters.AddWithValue("@Name", name);
                checkCommand.Parameters.AddWithValue("@Id", id);

                connection.Open();
                int count = (int)checkCommand.ExecuteScalar();

                if (count > 0)
                {
                    // Nếu tên đã tồn tại, thông báo cho người dùng
                    throw new Exception("Tên danh mục đã tồn tại. Vui lòng chọn tên khác.");
                }
                else
                {
                    // Nếu tên không tồn tại, tiến hành cập nhật danh mục
                    string query = "UPDATE FoodCategory SET Name = @Name WHERE Id = @Id";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Id", id);
                    command.Parameters.AddWithValue("@Name", name);
                    command.ExecuteNonQuery();
                }
            }
        }

        // Xóa danh mục món ăn
        public void DeleteCategory(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Kiểm tra xem có món ăn nào thuộc danh mục này không
                string checkQuery = "SELECT COUNT(*) FROM Food WHERE Id = @Id";
                SqlCommand checkCommand = new SqlCommand(checkQuery, connection);
                checkCommand.Parameters.AddWithValue("@Id", id);

                connection.Open();
                int count = (int)checkCommand.ExecuteScalar();

                if (count > 0)
                {
                    // Nếu có món ăn thuộc danh mục, thông báo cho người dùng
                    throw new Exception("Không thể xóa danh mục này vì vẫn còn món ăn thuộc danh mục.");
                }
                else
                {
                    // Nếu không có món ăn nào thuộc danh mục, tiến hành xóa
                    string query = "DELETE FROM FoodCategory WHERE Id = @Id";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Id", id);
                    command.ExecuteNonQuery();
                }
            }
        }
        // Lấy danh sách tất cả danh mục món ăn
        public List<CategoryItem> GetAllCategories()
        {
            List<CategoryItem> categories = new List<CategoryItem>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT Id, Name FROM FoodCategory";
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        CategoryItem category = new CategoryItem
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1)
                        };
                        categories.Add(category);
                    }
                }
            }

            return categories;
        }
    }

    public class CategoryItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
