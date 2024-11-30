using QuanLiCaphe.Commands;
using QuanLiCaphe.Views;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace QuanLiCaphe.Model
{
    public class HomeViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private UserControl _currentView;
        public UserControl CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged(nameof(CurrentView));
            }
        }

        public ICommand GoToHomeCommand { get; private set; }
        public ICommand GoToFoodManagementCommand { get; private set; }
        public ICommand GoToEmployeeManagementCommand { get; private set; }
        public ICommand GoToInvoiceManagementCommand { get; private set; }
        public ICommand GoToRevenueReportCommand { get; private set; }
        public ICommand GoToTableManagementCommand { get; private set; }
        public ICommand GoToInventoryManagementCommand { get; private set; }
        public ICommand LogoutCommand { get; private set; }

        public HomeViewModel()
        {
            GoToHomeCommand = new RelayCommand(GoToHome);
            GoToFoodManagementCommand = new RelayCommand(GoToFoodManagement);
            GoToEmployeeManagementCommand = new RelayCommand(GoToEmployeeManagement);
            GoToInvoiceManagementCommand = new RelayCommand(GoToInvoiceManagement);
            GoToTableManagementCommand = new RelayCommand(GoToTableManagement);
            GoToInventoryManagementCommand = new RelayCommand(GoToInventoryManagement);
            GoToRevenueReportCommand = new RelayCommand(GoToRevenueReport);
            LogoutCommand = new RelayCommand(Logout);

            // Thiết lập view mặc định
            //CurrentView = new HomeView(); // Giả sử bạn có một view HomeView
        }
        public void GoToInventoryManagement(object obj)
        {
            CurrentView = new InventoryManagementView();
        }
        private void GoToHome(object obj)
        {
            CurrentView = new HomeMain();
        }
        private void GoToTableManagement(object obj)
        {
            CurrentView = new ManagementTableView();
        }

        private void GoToFoodManagement(object obj)
        {

            CurrentView = new ManagementFoodView();
        }

        private void GoToEmployeeManagement(object obj)
        {
            CurrentView = new ManagementStaffView();
        }

        private void GoToInvoiceManagement(object obj)
        {
            CurrentView = new ManagementInvoiceView();
        }

        private void GoToRevenueReport(object obj)
        {
            CurrentView = new ManagementRevenueView(); // Tạo RevenueReportView nếu chưa có
        }

        private void Logout(object obj)
        {
            // Logic đăng xuất
            // Hiện thông báo xác nhận
            var result = MessageBox.Show("Bạn có chắc chắn muốn thoát ứng dụng không?",
                                           "Xác nhận thoát",
                                           MessageBoxButton.YesNo,
                                           MessageBoxImage.Warning);

            // Nếu người dùng chọn Yes, thì thoát ứng dụng
            if (result == MessageBoxResult.Yes)
            {
                System.Windows.Application.Current.Shutdown();
            }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class RelayCommand : ICommand
    {
        private readonly Action<object> _execute;
        private readonly Func<object, bool> _canExecute;

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }
    }
}