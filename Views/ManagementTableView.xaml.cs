using QuanLiCaphe.Model;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace QuanLiCaphe.Views
{
    public partial class ManagementTableView : UserControl
    {
        private Table tableModel = new Table();
        private Bill billModel = new Bill();

        public ManagementTableView()
        {
            InitializeComponent();
            LoadTableData(); // Tải dữ liệu bàn khi khởi động
        }

        private void LoadTableData()
        {
            var tables = tableModel.GetAllTables();
            dgTables.ItemsSource = tables;
        }

        private void AddTable_Click(object sender, RoutedEventArgs e)
        {
            string name = txtTableName.Text;
            string status = ((ComboBoxItem)cbTableStatus.SelectedItem)?.Content.ToString();

            if (!string.IsNullOrEmpty(name) && status != null)
            {
                tableModel.AddTable(name, status);
                LoadTableData(); // Tải lại dữ liệu

                // Nếu trạng thái là "Có khách", thêm hóa đơn
              

                txtTableName.Clear();
                cbTableStatus.SelectedIndex = -1;
            }
            else
            {
                MessageBox.Show("Vui lòng nhập tên bàn và chọn trạng thái.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

// UPDATE TABLE STATUS OR NAME AND ADD BILL IF UPDATE STATUS
        private void UpdateTable_Click(object sender, RoutedEventArgs e)
        {
            if (dgTables.SelectedItem is TableItem selectedTable)
            {
                string name = txtTableName.Text;
                string status = ((ComboBoxItem)cbTableStatus.SelectedItem)?.Content.ToString();

                if (!string.IsNullOrEmpty(name) && status != null)
                {
                    tableModel.UpdateTable(selectedTable.Id, name, status);
                    LoadTableData(); // Tải lại dữ liệu

                    // Cập nhật hóa đơn nếu trạng thái bàn thay đổi
                    if (status == "Có khách")
                    {
                        billModel.AddBill(selectedTable.Id);


                    }
                    else if (status == "Trống")
                    {
                        // Nếu sửa thành trống tức là lúc mà khách ăn song

                        billModel.UpdateBill(selectedTable.Id);

                    }

                    txtTableName.Clear();
                    cbTableStatus.SelectedIndex = -1;
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập tên bàn và chọn trạng thái.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn bàn để sửa.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }


        private void DeleteTable_Click(object sender, RoutedEventArgs e)
        {
            if (dgTables.SelectedItem is TableItem selectedTable)
            {
                tableModel.DeleteTable(selectedTable.Id);
                LoadTableData(); // Tải lại dữ liệu
                txtTableName.Clear(); // Xóa TextBox
                cbTableStatus.SelectedIndex = -1; // Đặt lại ComboBox
            }
            else
            {
                MessageBox.Show("Vui lòng chọn bàn để xóa.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void SearchTable_Click(object sender, RoutedEventArgs e)
        {
            string status = ((ComboBoxItem)cbTableStatus.SelectedItem)?.Content.ToString();

            if (status != null)
            {
                var filteredTables = tableModel.GetAllTables()
                    .Where(t => t.Status == status)
                    .ToList();
                dgTables.ItemsSource = filteredTables; // Cập nhật danh sách bàn hiển thị
            }
            else
            {
                MessageBox.Show("Vui lòng chọn trạng thái để tìm kiếm.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void cbTableStatus_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Xử lý thay đổi trạng thái nếu cần
        }

        private void txtTableName_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTableName.Text))
            {
                // Nếu TextBox trống, hiển thị placeholder
                placeholderText.Visibility = Visibility.Visible;
            }
        }

        private void txtTableName_GotFocus(object sender, RoutedEventArgs e)
        {
            // Khi TextBox được focus, ẩn placeholder
            placeholderText.Visibility = Visibility.Hidden;
        }

        private void dgTables_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgTables.SelectedItem is TableItem selectedTable)
            {
                // Hiển thị tên bàn và trạng thái khi chọn hàng
                txtTableName.Text = selectedTable.Name;
                cbTableStatus.SelectedItem = cbTableStatus.Items
                    .Cast<ComboBoxItem>()
                    .FirstOrDefault(item => item.Content.ToString() == selectedTable.Status);
            }
        }
    }
}
