using QuanLiCaphe.Model;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace QuanLiCaphe.Views
{
    public partial class HomeView : Window
    {
        public HomeView()
        {
            InitializeComponent();
            this.DataContext = new HomeViewModel();
        }

        private void PlaySound()
        {
            try
            {
                // Đảm bảo rằng file âm thanh có sẵn trong thư mục Audio
                mediaElement.Source = new Uri("C:\\xampp\\htdocs\\KNOWLEDGE IT\\ASP_NET\\C#\\WPF\\PROJECT\\QuanLiCaphe\\Audio\\MenuClick.wav"); // Đường dẫn tệp âm thanh

                // Đảm bảo âm thanh không tự động phát mà cần gọi Play()
                mediaElement.LoadedBehavior = MediaState.Manual;
                mediaElement.UnloadedBehavior = MediaState.Manual;

                // Đặt âm lượng là 1 (âm lượng tối đa)
                mediaElement.Volume = 1.0;

                // Kiểm tra nếu mediaElement có thể phát âm thanh
                mediaElement.Play();
            }
            catch (Exception ex)
            {
                // Hiển thị thông báo lỗi nếu không thể phát âm thanh
                MessageBox.Show($"Không thể phát âm thanh: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        // Sự kiện Click chung cho các nút menu
        private void MenuButton_Click(object sender, RoutedEventArgs e)
        {
            PlaySound(); // Phát âm thanh khi nhấn nút

            // Gọi command tương ứng (nếu có logic khác, xử lý tại đây)
            var button = sender as Button;
            if (button?.Command != null && button.Command.CanExecute(null))
            {
                button.Command.Execute(null);
            }
        }

        // Kiểm tra khi phát âm thanh bị lỗi
        private void MediaElement_MediaFailed(object sender, ExceptionRoutedEventArgs e)
        {
            // Hiển thị thông báo lỗi nếu không thể phát âm thanh
            MessageBox.Show($"Lỗi khi phát âm thanh: {e.ErrorException.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
        }


        // chuyển dổi themes
        private void ToggleThemeButton_Click(object sender, RoutedEventArgs e)
        {
            // Kiểm tra theme hiện tại
            var currentTheme = Application.Current.Resources.MergedDictionaries.Count > 0 ? Application.Current.Resources.MergedDictionaries[0].Source.ToString() : "No theme";

            if (currentTheme.Contains("Dark.xaml"))
            {
                // Loại bỏ Dark theme và thêm Light theme
                Application.Current.Resources.MergedDictionaries.RemoveAt(0);

                var lightTheme = new ResourceDictionary
                {
                    Source = new Uri("pack://application:,,,/Views/Themes/Dark.xaml")
                };
                Application.Current.Resources.MergedDictionaries.Insert(0, lightTheme);
            }
            else
            {
                // Thêm Dark theme
                var darkTheme = new ResourceDictionary
                {
                    Source = new Uri("pack://application:,,,/Views/Themes/Dark.xaml")
                };
                Application.Current.Resources.MergedDictionaries.Insert(0, darkTheme);
            }

            // Gọi UpdateLayout() để làm mới giao diện sau khi thay đổi theme
            this.UpdateLayout();
        }




    }
}
