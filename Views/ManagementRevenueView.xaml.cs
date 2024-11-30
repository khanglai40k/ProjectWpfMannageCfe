using OxyPlot;
using QuanLiCaphe.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;
using OxyPlot.Axes;
using OxyPlot.Wpf;
using OxyPlot.Series;

namespace QuanLiCaphe.Views
{
    /// <summary>
    /// Interaction logic for ManagementRevenueView.xaml
    /// </summary>
    public partial class ManagementRevenueView : UserControl
    {
        // Định nghĩa connectionString như một trường của lớp
        private string connectionString = "Server=DESKTOP-7FVAQ4R\\SQLEXPRESS;Database=QuanLyCaPhe;Trusted_Connection=True;";


        public ManagementRevenueView()
        {
            InitializeComponent();
            LoadRevenue(); // Gọi hàm để tải dữ liệu khi khởi tạo UserControl
        }

        private void LoadRevenue()
        {
            List<Revenue> revenues = new List<Revenue>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT TOP (1000) [Id], [Time], [TotalMoney] FROM [QuanLyCaPhe].[dbo].[Revenue]";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Revenue revenue = new Revenue
                    {
                        Id = reader.GetInt32(0),
                        Time = reader.GetDateTime(1),
                        TotalMoney = reader.GetDecimal(2)
                    };
                    revenues.Add(revenue);
                }
            }

            RevenueDataGrid.ItemsSource = revenues; // Gán dữ liệu cho DataGrid
        }
        private void FilterByDate_Click(object sender, RoutedEventArgs e)
        {
            if (DatePicker.SelectedDate.HasValue)
            {
                DateTime selectedDate = DatePicker.SelectedDate.Value;

                List<Revenue> filteredRevenues = new List<Revenue>();

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT [Id], [Time], [TotalMoney] FROM [QuanLyCaPhe].[dbo].[Revenue] WHERE CAST([Time] AS DATE) = @SelectedDate";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@SelectedDate", selectedDate);

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Revenue revenue = new Revenue
                        {
                            Id = reader.GetInt32(0),
                            Time = reader.GetDateTime(1),
                            TotalMoney = reader.GetDecimal(2)
                        };
                        filteredRevenues.Add(revenue);
                    }
                }

                RevenueDataGrid.ItemsSource = filteredRevenues; // Gán dữ liệu đã lọc vào DataGrid
            }
            else
            {
                MessageBox.Show("Vui lòng chọn ngày.");
            }
        }


        private void FilterByMonthYear_Click(object sender, RoutedEventArgs e)
        {

            if (MonthComboBox.SelectedItem is ComboBoxItem selectedMonth && YearComboBox.SelectedItem is ComboBoxItem selectedYearItem && YearComboBox.SelectedItem != null)
            {
                int year = int.Parse(selectedYearItem.Content.ToString());
                int month = int.Parse(selectedMonth.Content.ToString()); // Lấy tháng từ ComboBox
                List<Revenue> filteredRevenues = new List<Revenue>();

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT [Id], [Time], [TotalMoney] FROM [QuanLyCaPhe].[dbo].[Revenue] WHERE MONTH([Time]) = @Month AND YEAR([Time]) = @Year";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Month", month);
                    command.Parameters.AddWithValue("@Year", year);

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Revenue revenue = new Revenue
                        {
                            Id = reader.GetInt32(0),
                            Time = reader.GetDateTime(1),
                            TotalMoney = reader.GetDecimal(2)
                        };
                        filteredRevenues.Add(revenue);
                    }
                }

                RevenueDataGrid.ItemsSource = filteredRevenues; // Gán dữ liệu đã lọc vào DataGrid
            }
            else
            {
                MessageBox.Show("Vui lòng chọn tháng và năm.");
            }

        }

        private void LoadRevenue_Click(object sender, RoutedEventArgs e)
        {
            LoadRevenue(); // Tải tất cả dữ liệu mà không có bộ lọc
        }




        // xemt thống kê
        private void ViewStatistics_Click(object sender, RoutedEventArgs e)
        {
            var statisticsWindow = new Window
            {
                Title = "Thống Kê Doanh Thu",
                Width = 800,
                Height = 450,
            };

            var plotModel = new PlotModel { Title = "Thống Kê Doanh Thu" };

            // Thiết lập trục hoành là trục thời gian
            var dateTimeAxis = new DateTimeAxis
            {
                Position = AxisPosition.Bottom,
                Title = "Ngày",
                StringFormat = "dd/MM/yyyy" // Định dạng hiển thị ngày
            };
            plotModel.Axes.Add(dateTimeAxis);

            // Tạo dữ liệu thống kê
            var series = new LineSeries
            {
                Title = "Doanh Thu",
                MarkerType = MarkerType.Circle
            };

            // Lấy dữ liệu doanh thu theo ngày
            var revenueData = GetRevenueData();

            foreach (var data in revenueData)
            {
                // Thêm dữ liệu vào series với trục hoành là ngày
                series.Points.Add(new DataPoint(DateTimeAxis.ToDouble(data.Time), (double)data.TotalMoney));
            }

            plotModel.Series.Add(series);

            // Thêm PlotView để hiển thị biểu đồ
            var plotView = new OxyPlot.Wpf.PlotView
            {
                Model = plotModel
            };

            statisticsWindow.Content = plotView;
            statisticsWindow.Show();
        }

     

        private List<Revenue> GetRevenueData()
        {
            var revenueList = new List<Revenue>();
         string connectionString = "Server=DESKTOP-7FVAQ4R\\SQLEXPRESS;Database=QuanLyCaPhe;Trusted_Connection=True;";

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = @"
        SELECT 
            CAST(Time AS DATE) AS Date, 
            SUM(TotalMoney) AS TotalMoney 
        FROM Revenue 
        GROUP BY CAST(Time AS DATE)";

                using (var command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            revenueList.Add(new Revenue
                            {
                                Time = reader.GetDateTime(0), // Ngày
                                TotalMoney = reader.GetDecimal(1) // Tổng tiền
                            });
                        }
                    }
                }
            }

            return revenueList;
        }


        // xem biểu đồ cột
        private void ViewColumnStatistics_Click(object sender, RoutedEventArgs e)
        {
            var statisticsWindow = new Window
            {
                Title = "Thống Kê Doanh Thu (Cột)",
                Width = 800,
                Height = 450,
            };

            var plotModel = new PlotModel { Title = "Thống Kê Doanh Thu (Cột)" };

            // Thiết lập trục giá trị (LinearAxis) ở trục X
            var valueAxis = new LinearAxis
            {
                Position = AxisPosition.Bottom,
                Title = "Doanh Thu"
            };
            plotModel.Axes.Add(valueAxis);

            // Thiết lập trục danh mục (CategoryAxis) ở trục Y
            var categoryAxis = new CategoryAxis
            {
                Position = AxisPosition.Left,
                Title = "Ngày"
            };
            plotModel.Axes.Add(categoryAxis);

            // Tạo dữ liệu thống kê dạng cột với BarSeries
            var barSeries = new BarSeries
            {
                Title = "Doanh Thu",
                StrokeColor = OxyColors.Black,
                StrokeThickness = 1,
                LabelPlacement = LabelPlacement.Base
            };

            // Lấy dữ liệu doanh thu theo ngày
            var revenueData = GetRevenueData();

            foreach (var data in revenueData)
            {
                // Thêm dữ liệu vào series dạng cột
                barSeries.Items.Add(new BarItem { Value = (double)data.TotalMoney });

                // Thêm ngày vào trục danh mục
                categoryAxis.Labels.Add(data.Time.ToString("dd/MM/yyyy"));
            }

            plotModel.Series.Add(barSeries);

            // Thêm PlotView để hiển thị biểu đồ
            var plotView = new OxyPlot.Wpf.PlotView
            {
                Model = plotModel
            };

            statisticsWindow.Content = plotView;
            statisticsWindow.Show();
        }


    }
}