   M S B A M L   `   `   `  ����  QuanLiCaphe+    %QuanLiCaphe.Views.ManagementTableView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      -   5          >�Name$   TableManagementUserControl��5         MaterialDesignPaper#���   5      .��5	      � .+�5
   
   �� $��10q�6   .+�5      �� $��Quản lý bàn��6   $��24(�6+   $
��Bold"�69   $��10,30q�6K   $��Center=�6Z   � 5      $��10q�6    � ColumnDefinitions 5      �� 5      $
��Auto �6'   �� 5      $��* �6'   .+�5      �� $��
Tên bàn:��6   $	��Top=�6,   $��	10,0,10,0q�6D   $��0��6W   � 5      $��1��6   $��
10,0,10,50q�6'   .+�5      �� -   5         ��Name$ placeholderText��5       $��Nhập tên bàn��69   
�������$��Center=�6_    J� IsHitTestVisible .  6z   �� 5      -   5         ��Name$ txtTableName��5      $��0q�64   $��Center=�6?   6{   5      �� 5      $��Trạng thái bàn:��6   $��Center=�63   $
��10,0q�6N   $��0��6\   �� 5      -   5         ��Name$ cbTableStatus��5      $��1��62   $
��10,0q�6B   $��Center=�6P   .@�5      �� $��Trống��6#   �� 5      $��
Có khách��6#   �� 5      $��Đã đặt��6#   5       5!      �� 5$       �� Orientation$ 
Horizontal=�6   $��Right=�62   $��10q�6N   .+�5%      �� -   5        $��
Thêm bàn��5%      $��5q�6,   67   �� 5&      -   5        $��
Sửa bàn��5&      $��5q�6+   66   �� 5'      -   5        $��	Xóa bàn��5'      $��5q�6+   66   �� 5(      -   5        $��	Tìm bàn��5(      $��5q�6+   66   5*      &   System.Windows.Controls.DataGrid  5-      -	   5          Name$ dgTables��5-         AutoGenerateColumns .  $��10q�6E   	   CanUserAddRows	 .  
   
IsReadOnly
 . $	��200��6z      Columns 5.      0  *System.Windows.Controls.DataGridTextColumn  5/      ,  &System.Windows.Controls.DataGridColumn   Header$ 	Tên bàn��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6S   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6:   �� *Name+6S     50      $ Trạng thái��6)   $ * 6X    6=   �� *Status+6X   52      53      54      55      