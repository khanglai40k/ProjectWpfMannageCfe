using QuanLiCaphe.Model;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace QuanLiCaphe.Views
{
    public partial class AddFoodWindow : Window
    {
        public int SelectedFoodId { get; private set; }
        public int SelectedQuantity { get; private set; }

        public AddFoodWindow(List<FoodItem> foodList)
        {
            InitializeComponent();
            cbFood.ItemsSource = foodList;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (cbFood.SelectedValue is int selectedId)
            {
                SelectedFoodId = selectedId;
            }
            else
            {
                MessageBox.Show("Vui lòng chọn món ăn!", "Cảnh báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (cbQuantity.SelectedItem is ComboBoxItem selectedItem)
            {
                SelectedQuantity = int.Parse(selectedItem.Content.ToString());
            }
            else
            {
                MessageBox.Show("Vui lòng chọn số lượng món ăn!", "Cảnh báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            DialogResult = true;
            Close();
        }
    }
} 
