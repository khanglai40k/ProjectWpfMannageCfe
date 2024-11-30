using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using QuanLiCaphe.Model;
using static QuanLiCaphe.Model.Staff; // Đảm bảo import model Staff

namespace QuanLiCaphe.Views
{
    /// <summary>
    /// Interaction logic for ManagementStaffView.xaml
    /// </summary>
    public partial class ManagementStaffView : UserControl
    {
        private Staff staffModel = new Staff(); // Khởi tạo model Staff
        private List<StaffItem> staffList; // Danh sách nhân viên

        public ManagementStaffView()
        {
            InitializeComponent();
            LoadStaffData();
        }

        private void LoadStaffData()
        {
            staffList = staffModel.GetAllStaff();
            dgEmployees.ItemsSource = staffList; // Gán nguồn dữ liệu cho DataGrid
        }

        private void AddStaff_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtEmployeeName.Text) || string.IsNullOrEmpty(txtUsername.Text) ||
                string.IsNullOrEmpty(txtPassword.Password) || string.IsNullOrEmpty(txtSalary.Text) ||
                cmbPosition.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            string position = (cmbPosition.SelectedItem as ComboBoxItem)?.Content.ToString();
            staffModel.AddStaff(txtEmployeeName.Text, txtUsername.Text, txtPassword.Password, txtSalary.Text, position);
            MessageBox.Show("Thêm nhân viên thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            LoadStaffData();
        }

        private void UpdateStaff_Click(object sender, RoutedEventArgs e)
        {
            if (dgEmployees.SelectedItem is StaffItem selectedStaff)
            {
                if (string.IsNullOrEmpty(txtEmployeeName.Text) || string.IsNullOrEmpty(txtUsername.Text) ||
                    string.IsNullOrEmpty(txtPassword.Password) || string.IsNullOrEmpty(txtSalary.Text) ||
                    cmbPosition.SelectedItem == null)
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                string displayName = txtEmployeeName.Text;
                string userName = txtUsername.Text;
                string password = txtPassword.Password;
                string wage = txtSalary.Text;
                string position = (cmbPosition.SelectedItem as ComboBoxItem)?.Content.ToString();

                staffModel.UpdateStaff(displayName, userName, password, wage, position);
                MessageBox.Show("Cập nhật nhân viên thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                LoadStaffData();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn nhân viên để sửa.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }




        private void DeleteStaff_Click(object sender, RoutedEventArgs e)
        {
            if (dgEmployees.SelectedItem is StaffItem selectedStaff)
            {
                // Xóa nhân viên
                staffModel.DeleteStaff(selectedStaff.UserName);
                LoadStaffData(); // Tải lại dữ liệu
            }
            else
            {
                MessageBox.Show("Vui lòng chọn nhân viên để xóa.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void dgEmployees_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgEmployees.SelectedItem is StaffItem selectedStaff)
            {
                // Hiển thị thông tin nhân viên đã chọn
                txtEmployeeName.Text = selectedStaff.DisplayName;
                txtUsername.Text = selectedStaff.UserName;
                txtPassword.Password = selectedStaff.Password; // Không hiển thị mật khẩu
                txtSalary.Text = selectedStaff.Wage;
                cmbPosition.SelectedItem = cmbPosition.Items.Cast<ComboBoxItem>()
                    .FirstOrDefault(i => i.Content.ToString() == selectedStaff.Position);
            }
        }


        private void txtEmployeeName_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Có thể bỏ qua hoặc thực hiện hành động gì đó
        }
    }
}
