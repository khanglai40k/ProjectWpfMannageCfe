   M S B A M L   `   `   `  ����O  Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem  5   	    QuanLiCaphe&    QuanLiCaphe.Views.EditFoodWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   6sys&clr-namespace:System;assembly=mscorlib     5   	     � Title$  Sửa món ăn��5   	   $	��400��6   $	��400��6)    � 
ResizeMode$ CanMinimize=�5   	    � Icon$- 'pack://application:,,,/Images/sun52.jpg��5   	    � WindowStartupLocation$ CenterScreen=�5   	   .��5	      � .+�5
   
   �� $��Danh sách món ăn��6   $��18(�6,   $��
10,10,10,0q�6:   $	��Top=�6N   �� 5   
   -   5         ��Name$ itemsControl��5      $��10,40,10,100q�6-   ��6C   �� ��5      �� 5      .R�5      ��  �� Orientation$ 
Horizontal=�6!   $��5q�6:   .+�5      ��  ��Name$ cbFood��6#    �� SelectedValuePath$ Id��5   #    �� DisplayMemberPath$
 Name��5   #   $	��120��5   #   	 �� SelectedValue	 5   #   �� *IdFood+
 �� Mode$
 TwoWay=���5   #   �� *DataContext.FoodList+ �� RelativeSource ��  �� AncestorType$ WindowL��� 5      $ 
cbQuantity��6#   $��80��5   #   	 5   #   �� *Count+$
 TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=���5      �� 5   "    �� Type" ��6*   .s�5   &   ��1��63   ��5   &   2��63   ��5   &   3��63   ��5   &   4��63   ��5    &   5��63   ��5!   &   6��63   ��5"   &   7��63   ��5#   &   8��63   ��5$   &   9��63   ��5%   &   10��64   5&   #   5(      5)      5*      5,      �� 5.   
   -   5        $��Lưu thay đổi��5.      $��10,320,10,10q�6(   $��Bottom=�6>   $	��360��5/      6   50      51      