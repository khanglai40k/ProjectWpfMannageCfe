   M S B A M L   `   `   `  ����   QuanLiCaphe+    %QuanLiCaphe.Views.ManagementStaffView   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     -     >�Name$   StaffManagementUserControl��   MaterialDesignPaper#���   .��� .+��� $��10q�.+��� $��Quản lý nhân viên��$��24(�$
��Bold"�$��10,30,10,10q�$��Center=�� $��10q� � ColumnDefinitions �� $
��Auto ��� $��* � � RowDefinitions �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto �.+��� $��Tên nhân viên:��$��10q�$��Center=��� -    ��Name$ txtEmployeeName��$��1��$��10q�$��Center=��� $��Tài khoản:��$��10q�$��Center=�$��1���� -   $ txtUsername��$��1��$��1��$��10q�$��Center=��� $��Mật khẩu:��$��10q�$��Center=�$��2��G� -    G�Name$ txtPassword��$��1��$��2��$��10q�$��Center=��� $��Chức vụ:��$��10q�$��Center=�$��3���� -    ��Name$ cmbPosition��$��1��$��3��$��10q�$��Center=� �� SelectedIndex$ 0��.@��� $��Nhân viên bưng bê��
 � Tag$ 0���� $!��Quản lý quầy thu ngân��$ 1���� $��Quản lý kho��$ 2���� $��Quản lý nhân viên��$ 3���� $��Lương:��$��10q�$��Center=�$��4���� -   $ 	txtSalary��$��1��$��4��$��10q�$��Center=���  �� Orientation$ 
Horizontal=�$��Right=�$��10q�.+��� -   $��Thêm��$��5q�$��80���� -   $��Sửa��$��5q�$��80���� -	   $
��Xóa��$��5q�$��80��&   System.Windows.Controls.DataGrid  -
   	  Name$	 dgEmployees��
   AutoGenerateColumns
 .  $��10q�   CanUserAddRows .     
IsReadOnly .    Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ Tên nhân viên��   Width5  /System.Windows.Controls.DataGridLengthConverter$ * 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *DisplayName+  $ Tài khoản��$ *  �� *
UserName+  $ Mật khẩu��$ *  �� *
Password+   ElementStyle ��  �� 
TargetType" ��.���  �� Property � �� �� Value$ *****��  $ Chức vụ��$ *  �� *
Position+  $ Lương��$ *  �� *Wage+