using QuanLiCaphe.Model;
using System.Windows;
using System;
using System.Windows.Controls;
using System.Collections.Generic;

namespace QuanLiCaphe.Views
{
    /// <summary>
    /// Interaction logic for ManagementFoodView.xaml
    /// </summary>
    public partial class ManagementFoodView : UserControl
    {
        private CategoryFood categoryFoodModel = new CategoryFood();
        private Food food = new Food();
        private int selectedCategoryId; // Biến để lưu ID của danh mục được chọn

        public ManagementFoodView()
        {
            InitializeComponent();
            LoadCategories();
            LoadFoods(); // Nạp danh sách món ăn
        }

        //CATEGORY
        // Phương thức tải danh mục vào ComboBox
        private void LoadCategories()
        {
            List<CategoryItem> categories = categoryFoodModel.GetAllCategories(); // Lấy tất cả danh mục
            cbFoodCategory.ItemsSource = categories; // Gán dữ liệu vào ComboBox
            cbFoodCategory.DisplayMemberPath = "Name"; // Hiển thị tên danh mục
            cbFoodCategory.SelectedValuePath = "Id"; // Sử dụng Id làm giá trị
        }
        // Sự kiện khi nhấn nút "Thêm danh mục"
        private void AddCategory_Click(object sender, RoutedEventArgs e)
        {
            string categoryName = tbCategoryName.Text; // Lấy tên danh mục từ TextBox

            if (!string.IsNullOrEmpty(categoryName))
            {
                try
                {
                    categoryFoodModel.AddCategory(categoryName); // Gọi phương thức thêm danh mục
                    MessageBox.Show("Thêm danh mục thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                    LoadCategories(); // Cập nhật lại danh sách sau khi thêm
                }
                catch (Exception ex)
                {
                    if (ex.Message == "Danh mục đã tồn tại.")
                    {
                        MessageBox.Show("Danh mục đã tồn tại. Vui lòng chọn tên khác.", "Cảnh báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                    else
                    {
                        MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập tên danh mục.", "Cảnh báo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        // Sự kiện khi chọn một danh mục trong ComboBox
        private void cbFoodCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbFoodCategory.SelectedItem != null)
            {
                CategoryItem selectedCategory = (CategoryItem)cbFoodCategory.SelectedItem;
                tbCategoryName.Text = selectedCategory.Name; // Hiển thị tên danh mục trong TextBox
                selectedCategoryId = selectedCategory.Id; // Lưu lại ID danh mục
            }
        }

        // Sự kiện khi nhấn nút "Sửa danh mục"
        private void UpdateCategory_Click(object sender, RoutedEventArgs e)
        {
            string newCategoryName = tbCategoryName.Text; // Lấy tên danh mục mới từ TextBox

            if (!string.IsNullOrEmpty(newCategoryName) && selectedCategoryId != 0)
            {
                try
                {
                    categoryFoodModel.UpdateCategory(selectedCategoryId, newCategoryName); // Gọi phương thức để cập nhật danh mục
                    MessageBox.Show("Sửa danh mục thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                    LoadCategories(); // Cập nhật lại danh sách sau khi sửa
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn danh mục và nhập tên mới.", "Cảnh báo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        // Sự kiện xoá danh mục
        private void DeleteCategory_Click(object sender, RoutedEventArgs e)
        {
            if (selectedCategoryId != 0)
            {
                try
                {
                    categoryFoodModel.DeleteCategory(selectedCategoryId); // Gọi phương thức để xóa danh mục
                    MessageBox.Show("Xóa danh mục thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                    LoadCategories(); // Cập nhật lại danh sách sau khi xóa
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error); // Hiển thị thông báo lỗi
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn danh mục để xóa.", "Cảnh báo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }


        // FOOD

        private void AddFood_Click(object sender, RoutedEventArgs e)
        {
            string foodName = tbFoodName.Text;
            if (cbFoodCategory.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn danh mục.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            int selectedCategoryId = (int)cbFoodCategory.SelectedValue;
            double price;

            if (string.IsNullOrWhiteSpace(foodName))
            {
                MessageBox.Show("Tên món ăn không được để trống.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (double.TryParse(tbFoodPrice.Text, out price) && price > 0)
            {
                try
                {
                    food.AddFood(foodName, selectedCategoryId, price);
                    MessageBox.Show("Thêm món ăn thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                    LoadFoods();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Giá không hợp lệ hoặc không được âm.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        // Sửa món ăn
        private void UpdateFood_Click(object sender, RoutedEventArgs e)
        {
            if (dgFoods.SelectedItem is FoodItem selectedFood)
            {
                string foodName = tbFoodName.Text;
                int selectedCategoryId = (int)cbFoodCategory.SelectedValue;
                double price;

                // Kiểm tra các trường đầu vào
                if (string.IsNullOrWhiteSpace(foodName))
                {
                    MessageBox.Show("Tên món ăn không được để trống.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                if (double.TryParse(tbFoodPrice.Text, out price))
                {
                    try
                    {
                        food.UpdateFood(selectedFood.Id, foodName, selectedCategoryId, price);
                        MessageBox.Show("Sửa món ăn thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                        LoadFoods(); // Cập nhật lại danh sách món ăn
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Giá không hợp lệ.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn món ăn để sửa.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        // Xóa món ăn
        private void DeleteFood_Click(object sender, RoutedEventArgs e)
        {
            if (dgFoods.SelectedItem is FoodItem selectedFood)
            {
                try
                {
                    food.DeleteFood(selectedFood.Id);
                    MessageBox.Show("Xóa món ăn thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                    LoadFoods(); // Cập nhật lại danh sách món ăn
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn món ăn để xóa.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        // Cập nhật các trường nhập liệu khi chọn món ăn trong DataGrid
        private void dgFoods_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgFoods.SelectedItem is FoodItem selectedFood)
            {
                tbFoodName.Text = selectedFood.Name;
                cbFoodCategory.SelectedValue = selectedFood.IdCategory; // Giả sử bạn có CategoryId trong FoodItem
                tbFoodPrice.Text = selectedFood.Price.ToString();
            }
        }

        private void LoadFoods()
        {
            var foods = food.GetAllFoods(); // Gọi phương thức để lấy danh sách món ăn từ mô hình
            dgFoods.ItemsSource = foods; // Cập nhật DataGrid với danh sách món ăn
        }



    }
}