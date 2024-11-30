using QuanLiCaphe.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using QuanLiCaphe.Service;
using System.Diagnostics;
using QuanLiCaphe.Views;
namespace QuanLiCaphe.ViewModel
{
    public class LoginViewModel : ViewModelBase
    {
        private string _username;
        private string _password;
        private UserService _userService;

        public string Username
        {
            get { return _username; }
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));  // Sử dụng nameof cho an toàn hơn
            }
        }

        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));  // Sử dụng nameof cho an toàn hơn
            }
        }

        public ICommand LoginCommand { get; }

        public LoginViewModel()
        {
            _userService = new UserService();
            LoginCommand = new RelayCommand(Login);
        }

        private void Login(object parameter)
        {
            Debug.WriteLine($"Username: {Username}, Password: {Password}");

            if (_userService.Login(Username, Password))
            {
                // Mở cửa sổ HomeView
                HomeView homeView = new HomeView();

                // Kiểm tra xem cửa sổ hiện tại có đang toàn màn hình hay không
                var currentWindow = Application.Current.MainWindow;
                if (currentWindow.WindowState == WindowState.Maximized)
                {
                    homeView.WindowState = WindowState.Maximized; // Đặt HomeView ở chế độ toàn màn hình
                }

                homeView.Show();

                // Đóng cửa sổ hiện tại
                currentWindow.Close();
            }
            else
            {
                MessageBox.Show("Tên người dùng hoặc mật khẩu không đúng.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
