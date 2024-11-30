using MaterialDesignExtensions.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Windows;

namespace QuanLiCaphe.Model
{
    internal class BillInfo
    {
        private string connectionString = "Server=DESKTOP-7FVAQ4R\\SQLEXPRESS;Database=QuanLyCaPhe;Trusted_Connection=True;";

        // Thêm chi tiết hóa đơn
        public void AddBillInfo(int idBill, int idFood, int count)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO BillInfo (idBill, idFood, Count) VALUES (@IdBill, @IdFood, @Count)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@IdBill", idBill);
                command.Parameters.AddWithValue("@IdFood", idFood);
                command.Parameters.AddWithValue("@Count", count);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        // Sửa chi tiết hóa đơn
        public void UpdateBillInfo(int idBill, int idFood, int count)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE BillInfo SET Count = @Count WHERE idBill = @IdBill AND idFood = @IdFood";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Count", count);
                command.Parameters.AddWithValue("@IdBill", idBill);
                command.Parameters.AddWithValue("@IdFood", idFood);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }


        // lấy quantity cũ 
        public int GetCurrentFoodCount(int idBill, int idFood)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT Count FROM BillInfo WHERE idBill = @IdBill AND idFood = @IdFood";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@IdBill", idBill);
                command.Parameters.AddWithValue("@IdFood", idFood);

                connection.Open();
                object result = command.ExecuteScalar(); // Lấy số lượng hiện tại

                return result != null ? (int)result : 0; // Nếu không tìm thấy, trả về 0
            }
        }



        // lấy idFood khi có idBill
        public List<int> GetFoodIdsByBillId(int idBill)
        {
            List<int> foodIds = new List<int>(); // Danh sách để chứa idFood

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Truy vấn để lấy idFood từ BillInfo dựa trên idBill
                string query = "SELECT idFood FROM BillInfo WHERE idBill = @IdBill";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@IdBill", idBill);

                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // Thêm idFood vào danh sách
                        foodIds.Add(reader.GetInt32(0)); // Giả sử idFood là cột đầu tiên trong kết quả
                    }
                }
            }

            return foodIds; // Trả về danh sách idFood
        }



        // update item in BillInfo
        // lấy được cái idFood mới 
        public void UpdateBillInfoItem(int idBill, int idFood, int count)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE BillInfo SET count = @Count , idFood = @IdFood WHERE id = @IdBill";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Count", count);
                    command.Parameters.AddWithValue("@IdBill", idBill);
                    command.Parameters.AddWithValue("@IdFood", idFood);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }


        // Xóa chi tiết hóa đơn
        public void DeleteBillInfo(int idBill)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM BillInfo WHERE id = @IdBill";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@IdBill", idBill);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
        //thanh toán hoá đơn
        public void PayBillInfo(int idBill)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM BillInfo WHERE idBill = @IdBill";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@IdBill", idBill);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        // Lấy danh sách chi tiết hóa đơn
        //public List<BillInfoItem> GetAllBillInfos()
        //{
        //    List<BillInfoItem> billInfos = new List<BillInfoItem>();

        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        string query = "SELECT Id, idBill, idFood, Count FROM BillInfo";
        //        SqlCommand command = new SqlCommand(query, connection);
        //        connection.Open();
        //        using (SqlDataReader reader = command.ExecuteReader())
        //        {
        //            while (reader.Read())
        //            {
        //                BillInfoItem billInfo = new BillInfoItem
        //                {
        //                    Id = reader.GetInt32(0),
        //                    IdBill = reader.GetInt32(1),
        //                    IdFood = reader.GetInt32(2),
        //                    Count = reader.GetInt32(3)
        //                };
        //                billInfos.Add(billInfo);
        //            }
        //        }
        //    }

        //    return billInfos;
        //}

        // Lấy chi tiết hóa đơn theo số hóa đơn
        // Lấy chi tiết hóa đơn theo idBill
        public List<BillInfoItem> GetBillDetails(int billId)
        {
            List<BillInfoItem> billDetails = new List<BillInfoItem>();
            float totalAmount = 0; // Biến tạm để lưu tổng tiền

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"
        SELECT bi.id, bi.idBill, bi.idFood, bi.count, f.name AS FoodName, f.Price
        FROM BillInfo bi
        INNER JOIN Food f ON bi.idFood = f.id
        WHERE bi.idBill = @IdBill";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@IdBill", billId);
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // Tạo đối tượng BillInfoItem cho từng món ăn
                        BillInfoItem billInfo = new BillInfoItem
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("id")),
                            IdBill = reader.GetInt32(reader.GetOrdinal("idBill")),
                            IdFood = reader.GetInt32(reader.GetOrdinal("idFood")),
                            Count = reader.GetInt32(reader.GetOrdinal("count")),
                            FoodName = reader.GetString(reader.GetOrdinal("FoodName")),
                            Price = (float)reader.GetDouble(reader.GetOrdinal("Price")),
                        };

                        // Tính tổng tiền cho từng món ăn
                        totalAmount += billInfo.TotalPrice; // Cộng dồn vào totalAmount

                        // Thêm món ăn vào danh sách chi tiết hóa đơn
                        billDetails.Add(billInfo);
                    }
                }
            }

            // Gán tổng tiền cho từng món ăn trong danh sách billDetails
            if (billDetails.Count > 0)
            {
                // Gán tổng tiền cho hóa đơn
                foreach (var item in billDetails)
                {
                    item.TotalAmount = totalAmount; // Gán giá trị tổng tiền cho mỗi món
                }


            }

            return billDetails;
        }



      




        public List<Bill> GetBillsByTable(int tableId)
        {
            List<Bill> bills = new List<Bill>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM Bill WHERE idTable = @TableId"; // Thay đổi tên bảng nếu cần
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@TableId", tableId);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            bills.Add(new Bill
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("id")),
                                IdTable = reader.GetInt32(reader.GetOrdinal("idTable")),
                                Time = reader.GetDateTime(reader.GetOrdinal("DateCheckIn")),

                                // Thêm các thuộc tính khác của Bill nếu cần
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Danh sách bill trống");

            }
            int idBill =  bills[0].Id;
            //MessageBox.Show(bills[0].Id.ToString());
            return bills;
        }

     





    }
}
