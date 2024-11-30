using QuanLiCaphe.ViewModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace QuanLiCaphe.Views
{
    public partial class LoginView : Window
    {
        public LoginView()
        {
            InitializeComponent();
            DataContext = new LoginViewModel();
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            PasswordBox passwordBox = sender as PasswordBox;
            var viewModel = DataContext as LoginViewModel;
            if (viewModel != null)
            {
                viewModel.Password = passwordBox.Password; // Lấy mật khẩu từ PasswordBox
            }
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                // Gọi lệnh đăng nhập
                PerformLogin();
            }
        }

        private void PasswordBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                // Gọi lệnh đăng nhập
                PerformLogin();
            }
        }

        private void PerformLogin()
        {
            // Kiểm tra ViewModel và thực thi lệnh đăng nhập
            if (DataContext is LoginViewModel viewModel)
            {
                if (viewModel.LoginCommand.CanExecute(null))
                {
                    viewModel.LoginCommand.Execute(null);
                }
            }
        }
    }
}
