using QuanLiCaphe.ViewModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace QuanLiCaphe.UserControlCaPhe
{
    /// <summary>
    /// Interaction logic for UserControlBarUC.xaml
    /// </summary>
    public partial class UserControlBarUC : UserControl
    {
        public ControlBarViewModel ViewModel { get; set; }

        public UserControlBarUC()
        {
            InitializeComponent();
            this.DataContext = ViewModel = new ControlBarViewModel();
        }

        private void UserControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape) // Kiểm tra xem phím ESC có được nhấn không
            {
                if (ViewModel?.EscapeCommand != null && ViewModel.EscapeCommand.CanExecute(this))
                {
                    ViewModel.EscapeCommand.Execute(this);
                }
            }
        }
    }
}
