using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace QuanLiCaphe.ViewModel
{
    public class ControlBarViewModel : BaseViewModel
    {
        #region Commands
        public ICommand CloseWindowCommand { get; set; }
        public ICommand MaximizeWindowCommand { get; set; }
        public ICommand MinimizeWindowCommand { get; set; }
        public ICommand MouseMoveWindowCommand { get; set; }
        public ICommand EscapeCommand { get; set; }
        #endregion

        public ControlBarViewModel()
        {
            // Đóng cửa sổ
            CloseWindowCommand = new RelayCommand<UserControl>((p) => p != null, (p) =>
            {
                var window = GetWindowParent(p);
                if (window != null)
                {
                    window.Close();
                }
            });

            // Phóng to/Thu nhỏ cửa sổ
            MaximizeWindowCommand = new RelayCommand<UserControl>((p) => p != null, (p) =>
            {
                var window = GetWindowParent(p);
                if (window != null)
                {
                    window.WindowState = window.WindowState == WindowState.Maximized
                        ? WindowState.Normal
                        : WindowState.Maximized;
                }
            });

            // Thu nhỏ cửa sổ
            MinimizeWindowCommand = new RelayCommand<UserControl>((p) => p != null, (p) =>
            {
                var window = GetWindowParent(p);
                if (window != null)
                {
                    window.WindowState = WindowState.Minimized;
                }
            });

            // Di chuyển cửa sổ
            MouseMoveWindowCommand = new RelayCommand<UserControl>((p) => p != null, (p) =>
            {
                var window = GetWindowParent(p);
                if (window != null && window.WindowState != WindowState.Maximized)
                {
                    window.DragMove();
                }
            });

            // Xử lý phím ESC
            EscapeCommand = new RelayCommand<UserControl>((p) => p != null, (p) =>
            {
                var window = GetWindowParent(p);
                if (window != null)
                {
                    if (window.WindowState == WindowState.Maximized)
                    {
                        window.WindowState = WindowState.Normal; // Thu nhỏ cửa sổ
                    }
                    else
                    {
                        window.Close(); // Đóng cửa sổ
                    }
                }
            });
        }

        /// <summary>
        /// Lấy cửa sổ cha của một UserControl.
        /// </summary>
        /// <param name="control">UserControl cần lấy cửa sổ cha.</param>
        /// <returns>Window cha hoặc null nếu không tìm thấy.</returns>
        private Window GetWindowParent(UserControl control)
        {
            return Window.GetWindow(control);
        }
    }
}
