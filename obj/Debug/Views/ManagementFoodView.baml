   M S B A M L   `   `   `  ����F  BQuanLiCaphe, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:QuanLiCaphe.ViewsQuanLiCaphe.Views  5      K*clr-namespace:QuanLiCaphe.UserControlCaPheQuanLiCaphe.UserControlCaPhe  5      *    $QuanLiCaphe.Views.ManagementFoodView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      1localclr-namespace:QuanLiCaphe.Views     5      9uc*clr-namespace:QuanLiCaphe.UserControlCaPhe     5      -   5          >�Name$  FoodManagementUserControl��5         MaterialDesignPaper#���   5	      .��5      � .+�5   
   �� $��10q�6   .+�5      �� $��Quản lý món ăn��6   $��24(�6.   $
��Bold"�6<   $��10,30q�6N   $��Center=�6]   � 5      $��10q�6    � ColumnDefinitions 5      �� 5      $
��Auto �6'   �� 5      $��* �6'    � RowDefinitions 5      �� 5      $
��Auto �6$   �� 5      $
��Auto �6$   �� 5      $
��Auto �6$   �� 5      $
��Auto �6$   �� 5      $
��Auto �6$   .+�5      �� $��Danh mục:��6   $	��Top=�6-   $��
10,10,10,0q�6E   $��1��6Y   �� 5       -   5         ��Name$ cbFoodCategory��5       $��1��63   $��	0,10,20,0q�6C   $	��Top=�6V   $��1��6�   �� 5"      $��Tên danh mục:��6   $	��Top=�61   $��
10,10,10,0q�6I   $��2��6]   �� 5#      -   5         ��Name$ tbCategoryName��5#      $��1��62   $��	0,10,20,0q�6B   $	��Top=�6U   $��2��6m   �� 5'      $��Tên món ăn:��6   $	��Top=�6/   $��
10,10,10,0q�6G   $��0��6[   �� 5(      -   5        $ 
tbFoodName��5(      $��1��6.   $��	0,10,20,0q�6>   $	��Top=�6Q   $��0��6i   �� 5*      $��Giá:��6   $	��Top=�6(   $��
10,10,10,0q�6@   $��3��6T   �� 5+      -   5        $ tbFoodPrice��5+      $��1��6/   $��	0,10,20,0q�6?   $	��Top=�6R   $��3��6j   5,      �� 5/       �� Orientation$ 
Horizontal=�6   $��Right=�62   $��10q�6N   .+�50      �� -   5        $��Thêm danh mục��50      $��5q�61   6<   �� 51      -   5        $��Sửa danh mục��51      $��5q�60   6;   �� 52      -   5        $��Xóa danh mục��52      $��5q�60   6;   53      �� 56      $ 
Horizontal=�6   $��Right=�62   $��10q�6N   .+�57      �� -	   5        $��
Thêm món��57      $��5q�6,   67   �� 58      -
   5        $��
Sửa món��58      $��5q�6+   66   �� 59      -   5        $��	Xóa món��59      $��5q�6+   66   5:      &   System.Windows.Controls.DataGrid  5=      -   5          Name$ dgFoods��5=         AutoGenerateColumns .  $��10q�6D      CanUserAddRows .  	   
IsReadOnly	 . $	��200��6y   
   Columns
 5>      0  *System.Windows.Controls.DataGridTextColumn  5?      ,  &System.Windows.Controls.DataGridColumn   Header$ Tên món ăn��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6V   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6=   �� *Name+6V     5@      $ 
Danh mục��6)   $ * 6X    6;   �� *
Category+6X     5B      $
 Giá��6)   $ * 6P    66   �� *Price+6P   5D      5E      5F      5G      