   M S B A M L   `   `   `  ���� F  BQuanLiCaphe, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:QuanLiCaphe.UserControlCaPheQuanLiCaphe.UserControlCaPhe       QuanLiCaphe.Views.HomeView   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     _ [MaterialDesignThemes.Wpf, Version=5.1.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  3uc*clr-namespace:QuanLiCaphe.UserControlCaPhe    � Title$  HomeView��$	��600��$
��1000�� � 
ResizeMode$ 	CanResize=� � WindowStyle$
 None=�$	��660��$	��600�� � Icon$, &pack://application:,,,/Images/Logo.jpg��   MaterialDesignPaper#���   .���  � RowDefinitions �� $��50 ��� $��* �.+�3   -QuanLiCaphe.UserControlCaPhe.UserControlBarUC  $��0��
 � Tag �� *Title+ �� ElementName$ window��� $��1��$��10q� � ColumnDefinitions �� $	��200 ��� $��* �.+��� $��0��#���   .+��� -   $��50������ *GoToHomeCommand+.����  �� Orientation$ 
Horizontal=�.+�'  !MaterialDesignThemes.Wpf.PackIcon  	   Kind$
	 Home=�$��30��$��30��$��0,0,10,0q��� $��Trang chủ��$��Center=��� -   $��50������ *GoToFoodManagementCommand+.���� $ 
Horizontal=�.+�  $
	 Food=�$��30��$��30��$��0,0,10,0q��� $��Quản lý sản phẩm��$��Center=��� -   $��50������ *GoToEmployeeManagementCommand+.���� $ 
Horizontal=�.+�  $	 Account=�$��30��$��30��$��0,0,10,0q��� $��Quản lý nhân viên��$��Center=��� -   $��50������ *GoToInvoiceManagementCommand+.���� $ 
Horizontal=�.+�  $	 FileDocument=�$��30��$��30��$��0,0,10,0q��� $��Quản lý hóa đơn��$��Center=��� -   $��50������ *GoToTableManagementCommand+.���� $ 
Horizontal=�.+�  $	 Table=�$��30��$��30��$��0,0,10,0q��� $��Quản lý bàn ăn��$��Center=��� -   $��50������ *GoToRevenueReportCommand+.���� $ 
Horizontal=�.+�  $	 ChartBar=�$��30��$��30��$��0,0,10,0q��� $��Báo cáo doanh thu��$��Center=��� -   $��50������ * GoToInventoryManagementCommand+.���� $ 
Horizontal=�.+�  $	 	Lightbulb=�$��30��$��30��$��0,0,10,0q��� $��Quản lý đồ vật��$��Center=��� -   $��50������ *LogoutCommand+.���� $ 
Horizontal=�.+�  $	 	ExitToApp=�$��30��$��30��$��0,0,10,0q��� $��Thoát ứng dụng��$��Center=��� $��1��$��1q����#D3D3D3
 �� CornerRadius$
 5�� �� Padding$ 10q�._�� ���#F0F0F0.+��� -	    ��Name$ WelcomeTextBlock��$G��AChào mừng đến với Phần mềm quản lý Quán Cà Phê!��$��30(�$
��Bold"�$��Center=�$��	0,20,0,20q��� $��1��$��1q����#D3D3D3$	
 200��$ 10q�$	��400��$	��400��$��Center=�����  �� ImageSource$, &pack://application:,,,/Images/Logo.jpg���� ���� *CurrentView+y��� *IsCurrentViewVisible+   BooleanToVisibilityConverter �� 	Converter# [ r� -
    r�Name$ mediaElement��$��0��$��0�� r� LoadedBehavior$ Manual=� r� UnloadedBehavior$ Manual=�