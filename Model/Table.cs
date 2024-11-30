using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace QuanLiCaphe.Model
{
    internal class Table
    {
        private string connectionString = "Server=DESKTOP-7FVAQ4R\\SQLEXPRESS;Database=QuanLyCaPhe;Trusted_Connection=True;";





        // Thêm bàn
        public void AddTable(string name, string status)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO TableFood (Name, Status) VALUES (@Name, @Status)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@Status", status);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        // Sửa bàn
        public void UpdateTable(int id, string name, string status)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE TableFood SET Name = @Name, Status = @Status WHERE Id = @Id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", id);
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@Status", status);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        // sửa status
        public void UpdateStatusTable(int id, string status)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE TableFood SET  Status = @Status WHERE Id = @Id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", id);
                command.Parameters.AddWithValue("@Status", status);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        // Xóa bàn
        public void DeleteTable(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM TableFood WHERE Id = @Id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", id);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
        public int GetTableIdByName(string tableName)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT Id FROM Table WHERE Name = @TableName";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@TableName", tableName);
                connection.Open();
                return (int)command.ExecuteScalar(); // Trả về ID của bàn
            }
        }
 


        // Lấy danh sách tất cả bàn
        public List<TableItem> GetAllTables()
        {
            List<TableItem> tables = new List<TableItem>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT Id, Name, Status FROM TableFood";
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        TableItem table = new TableItem
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            Status = reader.GetString(2)
                        };
                        tables.Add(table);
                    }
                }
            }

            return tables;
        }
    }





    public class TableItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
    }




}
