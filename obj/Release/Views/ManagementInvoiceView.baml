   M S B A M L   `   `   `  ����   QuanLiCaphe-    'QuanLiCaphe.Views.ManagementInvoiceView   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     -     >�Name$"  InvoiceManagementUserControl��   MaterialDesignPaper#���   .��� .+��� $��10q�.+��� $��Quản lý hóa đơn��$��24(�$
��Bold"�$��10,30q�$��Center=��� -    ��Name$ cbTables��$	��200��$��10q�&   System.Windows.Controls.DataGrid  -     Name$ dgBills��   AutoGenerateColumns .  $��10q�   CanUserAddRows .     
IsReadOnly . $��80��   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ Tổng tiền��   Width5  /System.Windows.Controls.DataGridLengthConverter$ * 1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 �� *TotalAmount+�� 
 �� Orientation$
 
Horizontal=�$��42��.+��� -   $��
Thêm món��$	��100��$��5q��� -   $��
Sửa món��$	��100��$��5q��� -   $��	Xóa món��$	��100��$��5q�  -   $ dgBillDetails�� .  $��10q� .   . $	��200��   $
 Món��$ * 	 �� *
FoodName+  $ Số lượng��$ * 	 �� *Count+  $
 Giá��$ * 	 �� *Price+  $ Thành tiền��$ * 	 �� *
TotalPrice+�� $
 
Horizontal=�$��Center=�.+��� -    ��Name$ qrCodeImage��$	��200��$	��200��$��10q��� $��10q�.+��� $��STK: 0984127353��$��16(�$
��Bold"��� $-��'Tên tài khoản: MBB NGUYEN HUU KHANG��$��16(�$
��Bold"�$��0,5,0,0q��� -	   $��Thanh toán��$��0q�$��Center=�