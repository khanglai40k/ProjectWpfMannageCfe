using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using ZXing; // Đảm bảo bạn đã thêm thư viện ZXing.Net
using QuanLiCaphe.Model;
using QRCoder;
using System.Drawing;

namespace QuanLiCaphe.Views
{
    public partial class ManagementInvoiceView : UserControl
    {
        private const string AccountNumber = "0984127353"; // STK cố định
        private const string AccountName = "MBB NGUYEN HUU KHANG"; // Tên tài khoản cố định
        private BillInfo invoiceModel = new BillInfo(); // Model xử lý dữ liệu hóa đơn
        private QuanLiCaphe.Model.Table table = new QuanLiCaphe.Model.Table();
        private List<TableItem> tableList; // Danh sách các bàn
        private List<Bill> billList; // Danh sách hóa đơn
        private Food food = new Food();
        private Bill bill = new Bill();
        private Revenue revenue = new Revenue();

        public ManagementInvoiceView()
        {
            InitializeComponent();
            LoadTables();
        }

        private void LoadTables()
        {
            try
            {
                // Lấy danh sách các bàn
                tableList = table.GetAllTables();
                cbTables.ItemsSource = tableList;
                cbTables.DisplayMemberPath = "Name"; // Thuộc tính hiển thị của TableItem
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách bàn: {ex.Message}", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CbTables_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbTables.SelectedItem is TableItem selectedTable)
            {
                try
                {
                    // Lấy danh sách hóa đơn cho bàn được chọn
                    var bills = invoiceModel.GetBillsByTable(selectedTable.Id);
                    dgBills.ItemsSource = bills; // Hiển thị danh sách hóa đơn

                    // Nếu có hóa đơn, hiển thị chi tiết hóa đơn của hóa đơn mới nhất
                    if (bills.Count > 0)
                    {
                        int idBill = bills.Last().Id; // Lấy id của hóa đơn mới nhất
                        var billDetails = invoiceModel.GetBillDetails(idBill); // Lấy chi tiết hóa đơn theo idBill
                        dgBillDetails.ItemsSource = billDetails; // Hiển thị chi tiết hóa đơn
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Bàn đang trống");
                }
            }
        }

        private void DgBills_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgBills.SelectedItem is Bill selectedBill)
            {
                try
                {
                    // Hiển thị chi tiết hóa đơn của hóa đơn được chọn
                    var billDetails = invoiceModel.GetBillDetails(selectedBill.Id);
                    dgBillDetails.ItemsSource = billDetails; // Chỉ hiển thị chi tiết hóa đơn
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi tải chi tiết hóa đơn: {ex.Message}", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void DgBills_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (cbTables.SelectedItem is TableItem selectedTable)
            {
                int idTable = selectedTable.Id;
                int idBill = bill.GetBillIdByTableId(idTable);
                var billDetails = invoiceModel.GetBillDetails(idBill); // Gọi phương thức để lấy chi tiết hóa đơn

                if (billDetails != null && billDetails.Count > 0)
                {
                    float totalMoney = billDetails.Sum(b => b.TotalPrice); // Tính tổng tiền từ danh sách billDetails
                    // Gán dữ liệu cho DataGrid để hiển thị
                    dgBills.ItemsSource = billDetails;
                }
            }
        }

        private void PayBill_Click(object sender, RoutedEventArgs e)
        {
            if (cbTables.SelectedItem is TableItem selectedTable) // Đảm bảo chọn kiểu đúng
            {
                int idTable = selectedTable.Id;
                try
                {
                    int idBill = bill.GetBillIdByTableId(idTable);
                    var billDetails = invoiceModel.GetBillDetails(idBill); // Gọi phương thức để lấy chi tiết hóa đơn

                    if (billDetails != null && billDetails.Count > 0)
                    {
                        float totalMoney = billDetails.Sum(b => b.TotalPrice); // Tính tổng tiền từ danh sách billDetails
                        MessageBox.Show($"total {totalMoney}");

                        // Xóa hết bill trong cái detail trong billInfo
                        invoiceModel.PayBillInfo(idBill);
                        bill.DeleteBill(idBill);
                        // Cập nhật trạng thái bàn trong Table
                        table.UpdateStatusTable(idTable, "Trống");
                        MessageBox.Show("Thanh toán thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);

                        // thêm vào bảng doanh thu
                        Revenue revenues = new Revenue();
                        revenues.AddRevenue(totalMoney);

                        // Tạo mã QR và hiển thị
                        WriteableBitmap qrCode = GenerateQRCode(totalMoney);
                        qrCodeImage.Source = qrCode; // Gán trực tiếp WriteableBitmap cho Image

                        // Tải lại hóa đơn và chi tiết hóa đơn
                        dgBills.ItemsSource = billList;
                        dgBillDetails.ItemsSource = null; // Xóa chi tiết hóa đơn
                    }
                    else
                    {
                        MessageBox.Show("Không có chi tiết hóa đơn để thanh toán.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi thanh toán hóa đơn: {ex.Message}", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn hóa đơn để thanh toán.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        // Hàm tạo mã QR
        private WriteableBitmap ConvertBitmapToWriteableBitmap(Bitmap bitmap)
        {
            // Chuyển đổi Bitmap sang WriteableBitmap
            var writeableBitmap = new WriteableBitmap(bitmap.Width, bitmap.Height, 96, 96, System.Windows.Media.PixelFormats.Bgra32, null);

            // Sao chép pixel từ Bitmap vào WriteableBitmap
            var bitmapData = new byte[bitmap.Width * bitmap.Height * 4]; // Bgra32 là 4 bytes cho mỗi pixel
            var rect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);

            // Lấy dữ liệu pixel từ Bitmap
            System.Drawing.Imaging.BitmapData bmpData = bitmap.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadOnly, bitmap.PixelFormat);
            System.Runtime.InteropServices.Marshal.Copy(bmpData.Scan0, bitmapData, 0, bitmapData.Length);
            bitmap.UnlockBits(bmpData);

            // Gán dữ liệu vào WriteableBitmap
            writeableBitmap.WritePixels(new Int32Rect(0, 0, bitmap.Width, bitmap.Height), bitmapData, bitmap.Width * 4, 0);

            return writeableBitmap;
        }



        private WriteableBitmap GenerateQRCode(float totalMoney)
        {
            string qrCodeData = $"bank-transfer?account={AccountNumber}&name={AccountName}&amount={totalMoney}&content=THANH TOÁN TIỀN";

            using (var qrGenerator = new QRCodeGenerator())
            {
                var qrCodeDataObject = qrGenerator.CreateQrCode(qrCodeData, QRCodeGenerator.ECCLevel.Q);
                using (var qrCode = new QRCode(qrCodeDataObject))
                {
                    Bitmap qrBitmap = qrCode.GetGraphic(20);
                    return ConvertBitmapToWriteableBitmap(qrBitmap);
                }
            }
        }






        // add foood
        private void AddFood_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int idTable;
                if (cbTables.SelectedItem is TableItem selectedTable)
                {
                    idTable = selectedTable.Id;

                    // Lấy danh sách món ăn từ model
                    List<FoodItem> foodList = food.GetAllFoods(); // Bạn cần có phương thức này trong model của bạn

                    // Mở cửa sổ thêm món vào hóa đơn
                    AddFoodWindow addFoodWindow = new AddFoodWindow(foodList);
                    if (addFoodWindow.ShowDialog() == true)
                    {
                        // Lấy thông tin món ăn và số lượng
                        int foodId = addFoodWindow.SelectedFoodId; // id của món ăn đã chọn
                        int quantity = addFoodWindow.SelectedQuantity; // số lượng đã chọn

                        // Kiểm tra xem hóa đơn đã tồn tại cho bàn này chưa
                        int checkIdBill = GetInvoiceByTableId(idTable);

                        if (checkIdBill != 0)
                        {
                            List<int> foodIds = invoiceModel.GetFoodIdsByBillId(checkIdBill);
                            // Hóa đơn đã tồn tại, thêm món vào bảng BillInfo
                            if (foodIds.Contains(foodId))
                            {
                                int currentCount = invoiceModel.GetCurrentFoodCount(checkIdBill, foodId);

                                // Cộng thêm số lượng mới
                                int newCount = currentCount + quantity;
                                invoiceModel.UpdateBillInfo(checkIdBill, foodId, newCount); // Cập nhật số lượng món
                            }
                            else
                            {
                                // Nếu idFood chưa tồn tại, thêm món mới vào BillInfo
                                invoiceModel.AddBillInfo(checkIdBill, foodId, quantity);
                            }

                            // Cập nhật lại chi tiết hóa đơn sau khi thêm món
                            var billDetails = invoiceModel.GetBillDetails(checkIdBill);
                            dgBillDetails.ItemsSource = billDetails; // Chỉ cập nhật nếu có hóa đơn
                        }
                        else
                        {
                            // Hóa đơn chưa tồn tại, tạo hóa đơn mới và thêm món
                            bill.AddBill(idTable); // Tạo hóa đơn mới
                            int newBillId = GetInvoiceByTableId(idTable);
                            invoiceModel.AddBillInfo(newBillId, foodId, quantity); // Thêm món vào BillInfo

                            // Nếu bạn muốn cập nhật ngay sau khi tạo hóa đơn mới
                            var billDetails = invoiceModel.GetBillDetails(newBillId);
                            dgBillDetails.ItemsSource = billDetails; // Cập nhật chi tiết hóa đơn mới
                        }
                        // update status bàn 
                        table.UpdateStatusTable(idTable, "Có khách");

                        MessageBox.Show("Thêm món ăn thành công");

                    }
                }




            }
            catch (Exception exx)
            {
                MessageBox.Show($"Lỗi khi thêm : {exx.Message}", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);


            }



        }



        private void EditFood_Click(object sender, RoutedEventArgs e)
        {
            // Đảm bảo đã chọn bàn
            if (cbTables.SelectedItem is TableItem selectedTable)
            {
                int idTable = selectedTable.Id;

                // Lấy idBill dựa trên idTable
                int idBill = bill.GetBillIdByTableId(idTable);

                // Kiểm tra nếu hóa đơn tồn tại
                if (idBill != -1)
                {
                    // Lấy danh sách món ăn trong hóa đơn
                    List<BillInfoItem> existingFoods = invoiceModel.GetBillDetails(idBill);

                    // Mở cửa sổ EditFoodWindow với danh sách món ăn hiện có
                    if (existingFoods != null && existingFoods.Count > 0)
                    {
                        EditFoodWindow editFoodWindow = new EditFoodWindow(existingFoods); // Truyền danh sách BillInfoItem
                        if (editFoodWindow.ShowDialog() == true)
                        {
                            // Cập nhật giao diện sau khi sửa đổi nếu cần
                            var updatedBillDetails = invoiceModel.GetBillDetails(idBill);
                            dgBillDetails.ItemsSource = updatedBillDetails; // Cập nhật chi tiết hóa đơn
                        }
                    }
                    else
                    {
                        MessageBox.Show("Không có món ăn nào trong hóa đơn.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Hóa đơn không tồn tại cho bàn này.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn bàn để sửa hóa đơn.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }





        private void DeleteFood_Click(object sender, RoutedEventArgs e)
        {
            if (dgBillDetails.SelectedItem is BillInfoItem selectedFood)
            {
                // Xóa món ăn khỏi hóa đơn
                invoiceModel.DeleteBillInfo(selectedFood.Id);
                // Cập nhật lại chi tiết hóa đơn sau khi xóa món
                var billDetails = invoiceModel.GetBillDetails(selectedFood.IdBill);
                dgBillDetails.ItemsSource = billDetails;
            }
        }


        // check table Bill có bàn đó hay chưa
        private int GetInvoiceByTableId(int tableId)
        {
              string connectionString = "Server=DESKTOP-7FVAQ4R\\SQLEXPRESS;Database=QuanLyCaPhe;Trusted_Connection=True;";

               string query = "SELECT id FROM Bill WHERE idTable = @tableId"; // Lấy id của hóa đơn

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@tableId", tableId); // Thêm tham số vào truy vấn

                connection.Open();

                // Thực hiện truy vấn và lấy id hóa đơn
                object result = command.ExecuteScalar();

                // Nếu có hóa đơn, trả về id, ngược lại trả về 0
                return result != null ? (int)result : 0;
            }
        }



    }



}
