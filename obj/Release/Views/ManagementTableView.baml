   M S B A M L   `   `   `  ����   QuanLiCaphe+    %QuanLiCaphe.Views.ManagementTableView   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     -     >�Name$   TableManagementUserControl��   MaterialDesignPaper#���   .��� .+��� $��10q�.+��� $��Quản lý bàn��$��24(�$
��Bold"�$��10,30q�$��Center=�� $��10q� � ColumnDefinitions �� $
��Auto ��� $��* �.+��� $��
Tên bàn:��$	��Top=�$��	10,0,10,0q�$��0��� $��1��$��
10,0,10,50q�.+��� -    ��Name$ placeholderText��$��Nhập tên bàn��
�������$��Center=� J� IsHitTestVisible .  �� -    ��Name$ txtTableName��$��0q�$��Center=��� $��Trạng thái bàn:��$��Center=�$
��10,0q�$��0���� -    ��Name$ cbTableStatus��$��1��$
��10,0q�$��Center=�.@��� $��Trống���� $��
Có khách���� $��Đã đặt����  �� Orientation$ 
Horizontal=�$��Right=�$��10q�.+��� -   $��
Thêm bàn��$��5q��� -   $��
Sửa bàn��$��5q��� -   $��	Xóa bàn��$��5q��� -   $��	Tìm bàn��$��5q�&   System.Windows.Controls.DataGrid  -	     Name$ dgTables��   AutoGenerateColumns .  $��10q�	   CanUserAddRows	 .  
   
IsReadOnly
 . $	��200��   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ 	Tên bàn��   Width5  /System.Windows.Controls.DataGridLengthConverter$ * 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *Name+  $ Trạng thái��$ *  �� *Status+