using System;
using System.Windows.Input;

namespace QuanLiCaphe.Commands
{
    public class RelayCommand : ICommand
    {
        private readonly Action<object> _execute;
        private readonly Func<object, bool> _canExecute;

        // Sự kiện này được kích hoạt khi điều kiện thực thi của lệnh thay đổi
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        // Constructor chỉ nhận Action để thực thi lệnh
        public RelayCommand(Action<object> execute) : this(execute, null)
        {
        }

        // Constructor nhận cả Action thực thi và điều kiện CanExecute
        public RelayCommand(Action<object> execute, Func<object, bool> canExecute)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        // Xác định xem lệnh có thể được thực thi hay không
        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute(parameter);
        }

        // Thực hiện lệnh
        public void Execute(object parameter)
        {
            // Kiểm tra để tránh trường hợp null
            if (_execute != null)
            {
                _execute(parameter);
            }
        }
    }
}
