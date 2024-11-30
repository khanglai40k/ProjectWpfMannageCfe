using QuanLiCaphe.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;

namespace QuanLiCaphe.Views
{
    public partial class EditFoodWindow : Window
    {
        private List<BillInfoItem> existingFoods;
        public List<FoodItem> FoodList { get; set; } // Danh sách món ăn

        public EditFoodWindow(List<BillInfoItem> existingFoods)
        {
            InitializeComponent();
            this.existingFoods = existingFoods;

            LoadFoodList(); // Tải danh sách món ăn từ cơ sở dữ liệu
            LoadFoodItems(existingFoods); // Hiển thị danh sách món ăn cũ

            this.DataContext = this; // Thiết lập DataContext
        }

        private void LoadFoodItems(List<BillInfoItem> existingFoods)
        {
            itemsControl.ItemsSource = existingFoods; // Gán danh sách món ăn cho ItemsControl

            // Kiểm tra nội dung của existingFoods
            foreach (var item in existingFoods)
            {
                Debug.WriteLine($"IdFood: {item.IdFood}, Count: {item.Count}, FoodName: {item.FoodName}");
            }
        }

        private void LoadFoodList()
        {
            Food foodModel = new Food();
            FoodList = foodModel.GetAllFoods(); // Lấy danh sách món ăn

            // Kiểm tra xem danh sách món ăn có dữ liệu hay không
            if (FoodList == null || FoodList.Count == 0)
            {
                MessageBox.Show("Không có món ăn nào trong danh sách.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                foreach (var food in FoodList)
                {
                    Debug.WriteLine($"Id: {food.Id}, Name: {food.Name}, Price: {food.Price}");
                }
            }
        }


        private void SaveChanges_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                BillInfo billInfo = new BillInfo();
                // Lưu các thay đổi cho các món ăn trong hóa đơn
                foreach (var item in existingFoods)
                {
                    // Cập nhật thông tin món ăn từ ItemsControl
                    billInfo.UpdateBillInfoItem(item.Id, item.IdFood, item.Count); // Cập nhật vào cơ sở dữ liệu
                }

                MessageBox.Show("Đã lưu các thay đổi thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                this.DialogResult = true; // Trả về true để xác nhận rằng đã lưu thành công
                this.Close(); // Đóng cửa sổ
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi xảy ra: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


    }


}
