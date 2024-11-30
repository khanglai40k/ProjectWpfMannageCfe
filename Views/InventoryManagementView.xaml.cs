using QuanLiCaphe.Model;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace QuanLiCaphe.Views
{
    public partial class InventoryManagementView : UserControl
    {
        private List<InventoryItem> items;

        public InventoryManagementView()
        {
            InitializeComponent();
            LoadItems();
        }

        private void LoadItems()
        {
            InventoryItem item = new InventoryItem(); // Khởi tạo lớp InventoryItem
            items = item.GetAllItems(); // Lấy danh sách đồ vật từ DB

            // Đặt DataContext để liên kết với giao diện
            DataContext = this;

            // Cập nhật nguồn dữ liệu cho DataGrid
            DataGrid.ItemsSource = items; // Gán lại danh sách mới
            CheckForEmptyList(); // Kiểm tra nếu danh sách trống
        }

        public List<InventoryItem> Items => items;

        private void CheckForEmptyList()
        {
            if (items.Count == 0)
            {
                MessageBox.Show("Không có mặt hàng nào trong danh sách.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Lấy món đồ đã chọn và hiển thị thông tin trong các TextBox
            if (DataGrid.SelectedItem is InventoryItem selectedItem)
            {
                ItemNameTextBox.Text = selectedItem.Name;
                ItemQuantityTextBox.Text = selectedItem.Quantity.ToString();
                ItemIsOnCheckBox.IsChecked = selectedItem.IsOn;
            }
            else
            {
                // Nếu không có mục nào được chọn, xóa thông tin khỏi TextBox
                ClearTextBoxes();
            }
        }

        private void ClearTextBoxes()
        {
            ItemNameTextBox.Clear();
            ItemQuantityTextBox.Clear();
            ItemIsOnCheckBox.IsChecked = null;
        }

        private void AddItem_Click(object sender, RoutedEventArgs e)
        {
            // Kiểm tra dữ liệu đầu vào
            if (string.IsNullOrWhiteSpace(ItemNameTextBox.Text) ||
                !int.TryParse(ItemQuantityTextBox.Text, out int quantity))
            {
                MessageBox.Show("Vui lòng nhập tên và số lượng hợp lệ.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Kiểm tra xem mặt hàng đã tồn tại chưa
            InventoryItem existingItem = items.Find(i => i.Name.Equals(ItemNameTextBox.Text, StringComparison.OrdinalIgnoreCase));
            if (existingItem != null)
            {
                MessageBox.Show("Mặt hàng đã tồn tại. Vui lòng sửa đổi thông tin.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Tạo mới một món đồ
            InventoryItem newItem = new InventoryItem
            {
                Name = ItemNameTextBox.Text,
                Quantity = quantity,
                IsOn = ItemIsOnCheckBox.IsChecked == true
            };

            newItem.AddItem(); // Thêm món đồ vào cơ sở dữ liệu
            LoadItems(); // Tải lại danh sách đồ vật để cập nhật giao diện
            MessageBox.Show("Mặt hàng đã được thêm thành công.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void EditItem_Click(object sender, RoutedEventArgs e)
        {
            // Lấy món đồ đã chọn từ DataGrid
            if (DataGrid.SelectedItem is InventoryItem selectedItem)
            {
                // Kiểm tra dữ liệu đầu vào
                if (string.IsNullOrWhiteSpace(ItemNameTextBox.Text) ||
                    !int.TryParse(ItemQuantityTextBox.Text, out int quantity))
                {
                    MessageBox.Show("Vui lòng nhập tên và số lượng hợp lệ.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                // Kiểm tra xem món đồ khác đã tồn tại với tên mới không
                InventoryItem existingItem = items.Find(i =>
                    i.Name.Equals(ItemNameTextBox.Text, StringComparison.OrdinalIgnoreCase) && i.Id != selectedItem.Id);
                if (existingItem != null)
                {
                    MessageBox.Show("Mặt hàng với tên này đã tồn tại. Vui lòng sửa đổi thông tin.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                // Cập nhật thông tin cho món đồ đã chọn
                selectedItem.Name = ItemNameTextBox.Text;
                selectedItem.Quantity = quantity; 
                selectedItem.IsOn = ItemIsOnCheckBox.IsChecked == true;

                selectedItem.UpdateItem(); // Cập nhật món đồ trong cơ sở dữ liệu
                LoadItems(); // Tải lại danh sách đồ vật để cập nhật giao diện
                MessageBox.Show("Mặt hàng đã được cập nhật thành công.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một mặt hàng để cập nhật.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void DeleteItem_Click(object sender, RoutedEventArgs e)
        {
            // Lấy món đồ đã chọn từ DataGrid
            if (DataGrid.SelectedItem is InventoryItem selectedItem)
            {
                MessageBoxResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa món đồ này?", "Xác nhận", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    selectedItem.DeleteItem(); // Xóa món đồ khỏi cơ sở dữ liệu
                    LoadItems(); // Tải lại danh sách đồ vật để cập nhật giao diện
                    MessageBox.Show("Mặt hàng đã được xóa thành công.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một mặt hàng để xóa.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void NumericTextBox_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            // Chặn các ký tự không phải là số
            e.Handled = !IsTextAllowed(e.Text);
        }

        private static bool IsTextAllowed(string text)
        {
            foreach (char c in text)
            {
                if (!char.IsDigit(c))
                    return false;
            }
            return true;
        }
    }
}
