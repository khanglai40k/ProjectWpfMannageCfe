   M S B A M L   `   `   `  ���� F  BQuanLiCaphe, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:QuanLiCaphe.ViewsQuanLiCaphe.Views  K*clr-namespace:QuanLiCaphe.UserControlCaPheQuanLiCaphe.UserControlCaPhe  *    $QuanLiCaphe.Views.ManagementFoodView   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     1localclr-namespace:QuanLiCaphe.Views     9uc*clr-namespace:QuanLiCaphe.UserControlCaPhe     -     >�Name$  FoodManagementUserControl��   MaterialDesignPaper#���   .��� .+��� $��10q�.+��� $��Quản lý món ăn��$��24(�$
��Bold"�$��10,30q�$��Center=�� $��10q� � ColumnDefinitions �� $
��Auto ��� $��* � � RowDefinitions �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto �.+��� $��Danh mục:��$	��Top=�$��
10,10,10,0q�$��1���� -    ��Name$ cbFoodCategory��$��1��$��	0,10,20,0q�$	��Top=�$��1���� $��Tên danh mục:��$	��Top=�$��
10,10,10,0q�$��2���� -    ��Name$ tbCategoryName��$��1��$��	0,10,20,0q�$	��Top=�$��2���� $��Tên món ăn:��$	��Top=�$��
10,10,10,0q�$��0���� -   $ 
tbFoodName��$��1��$��	0,10,20,0q�$	��Top=�$��0���� $��Giá:��$	��Top=�$��
10,10,10,0q�$��3���� -   $ tbFoodPrice��$��1��$��	0,10,20,0q�$	��Top=�$��3����  �� Orientation$ 
Horizontal=�$��Right=�$��10q�.+��� -   $��Thêm danh mục��$��5q��� -   $��Sửa danh mục��$��5q��� -   $��Xóa danh mục��$��5q��� $ 
Horizontal=�$��Right=�$��10q�.+��� -	   $��
Thêm món��$��5q��� -
   $��
Sửa món��$��5q��� -   $��	Xóa món��$��5q�&   System.Windows.Controls.DataGrid  -     Name$ dgFoods��   AutoGenerateColumns .  $��10q�   CanUserAddRows .  	   
IsReadOnly	 . $	��200��
   Columns
 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ Tên món ăn��   Width5  /System.Windows.Controls.DataGridLengthConverter$ * 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *Name+  $ 
Danh mục��$ *  �� *
Category+  $
 Giá��$ *  �� *Price+