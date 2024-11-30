using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace QuanLiCaphe.Views
{
    /// <summary>
    /// Interaction logic for HomeMain.xaml
    /// </summary>
    public partial class HomeMain : UserControl
    {
        public HomeMain()
        {
            InitializeComponent();
        }



        private void OpenWebsite_Click(object sender, RoutedEventArgs e)
        {
            string url = "https://hazzz.io.vn/ca-phe-huu-khang.html";

            try
            {
                Process.Start("chrome.exe", url); // Hoặc thay "chrome.exe" bằng "msedge.exe" hoặc "firefox.exe" nếu cần
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Không thể mở trang web với Chrome: " + ex.Message);
            }
        }
    }




    }
