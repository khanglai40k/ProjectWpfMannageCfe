using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows;

namespace QuanLiCaphe.Model
{
    public class Food
    {
        private string name;
        private string connectionString = "Server=DESKTOP-7FVAQ4R\\SQLEXPRESS;Database=QuanLyCaPhe;Trusted_Connection=True;";

        // Thêm món ăn
        public void AddFood(string name, int idCategory, double price)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Kiểm tra xem món ăn đã tồn tại chưa
                string checkQuery = "SELECT COUNT(*) FROM Food WHERE Name = @Name AND IdCategory = @IdCategory";
                SqlCommand checkCommand = new SqlCommand(checkQuery, connection);
                checkCommand.Parameters.AddWithValue("@Name", name);
                checkCommand.Parameters.AddWithValue("@IdCategory", idCategory);

                connection.Open();
                int count = (int)checkCommand.ExecuteScalar();

                if (count > 0)
                {
                    // Nếu món ăn đã tồn tại, thông báo cho người dùng
                    throw new Exception("Món ăn này đã tồn tại trong danh mục.");
                }
                else
                {
                    // Nếu chưa tồn tại, tiến hành thêm món ăn mới
                    string query = "INSERT INTO Food (Name, IdCategory, Price) VALUES (@Name, @IdCategory, @Price)";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@IdCategory", idCategory);
                    command.Parameters.AddWithValue("@Price", price);
                    command.ExecuteNonQuery();
                }
            }
        }

        // Sửa món ăn
        public void UpdateFood(int id, string name, int idCategory, double price)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE Food SET Name = @Name, IdCategory = @IdCategory, Price = @Price WHERE Id = @Id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", id);
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@IdCategory", idCategory);
                command.Parameters.AddWithValue("@Price", price);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        // Xóa món ăn
        public void DeleteFood(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Food WHERE Id = @Id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", id);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

  



      






        // Lấy danh sách tất cả món ăn
        public List<FoodItem> GetAllFoods()
        {
            List<FoodItem> foods = new List<FoodItem>();
            string query = "SELECT f.Id, f.Name, f.IdCategory, f.Price, c.Name AS CategoryName FROM Food f JOIN FoodCategory c ON f.IdCategory = c.Id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        FoodItem food = new FoodItem
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            IdCategory = reader.GetInt32(2),
                            Price = reader.GetDouble(3), // Thay đổi ở đây
                            Category = reader.GetString(4)
                        };
                        foods.Add(food);
                    }
                }
            }

            return foods;
        }


    }



    public class FoodItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int IdCategory { get; set; }
        public double Price { get; set; } // Thay đổi kiểu thành double
        public string Category { get; set; } // Thêm thuộc tính Category để lưu tên danh mục

    }


}
