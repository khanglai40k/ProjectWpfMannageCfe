   M S B A M L   `   `   `  ����  QuanLiCaphe-    'QuanLiCaphe.Views.ManagementInvoiceView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      -   5          >�Name$"  InvoiceManagementUserControl��5         MaterialDesignPaper#���   5      .��5	      � .+�5
   
   �� $��10q�6   .+�5      �� $��Quản lý hóa đơn��6   $��24(�6/   $
��Bold"�6=   $��10,30q�6O   $��Center=�6^   �� 5      -   5         ��Name$ cbTables��5      $	��200��6V   $��10q�6b   5      &   System.Windows.Controls.DataGrid  5      -   5          Name$ dgBills��5         AutoGenerateColumns .  $��10q�6D      CanUserAddRows .     
IsReadOnly . $��80��6y      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Tổng tiền��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6\   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 6<   �� *TotalAmount+6\   5      �� 5      
 �� Orientation$
 
Horizontal=�6   $��42��62   .+�5      �� -   5        $��
Thêm món��5      $	��100��6,   $��5q�68   6C   �� 5      -   5        $��
Sửa món��5      $	��100��6+   $��5q�67   6B   �� 5      -   5        $��	Xóa món��5      $	��100��6+   $��5q�67   6B   5        5"      -   5        $ dgBillDetails��5"       .  $��10q�6J    .   . $	��200��6    5#        5$      $
 Món��6)   $ * 6S   	 66   �� *
FoodName+6S     5%      $ Số lượng��6)   $ * 6U   	 6;   �� *Count+6U     5&      $
 Giá��6)   $ * 6P   	 66   �� *Price+6P     5'      $ Thành tiền��6)   $ * 6\   	 6=   �� *
TotalPrice+6\   5)      �� 5.      -   5        $��Thanh toán��5.      $��10q�6*   $��Center=�6L   5/      50      51      