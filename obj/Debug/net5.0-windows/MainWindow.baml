   M S B A M L   `   `   `  ����A  =Wreath, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:Wreath.Controls.MainFormWreath.Controls.MainForm  5   	       Wreath.MainWindow   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7main&clr-namespace:Wreath.Controls.MainForm     5   	   -   5          �Name$  AdminWindow��5   	    � Icon$ /Wreath.ico��5	   	    � Title$( "Администрирование��5
   	    � WindowState$ 	Maximized=�5   	   $
��1080��5   	   $
��1920��6    � WindowStartupLocation$ Manual=�5   	    � DataContext 5   	   ��  �� RelativeSource �� *Self+.��5      �    
ViewImpact#��[  6   $ TotalViewModel��6/    � ColumnDefinitions 5   
   �� 5      $��0.05* �6   �� 5      $
��0.9* �6   �� 5      $��0.05* �6    � RowDefinitions 5   
   �� 5      $
��0.1* �6   �� 5      $��0.05* �6   �� 5      $
��0.8* �6   �� 5      $��0.05* �6   .+�5   
   +   %Wreath.Controls.MainForm.WreathHeader  -   5        	  Name$	 Header��5      $��3��6�   
   	ViewModel
 6,   ��  �� ElementName$ AdminWindow�� �� Path$  DataContext.TotalViewModel�   Layout 6{   �� $ AdminWindow��6�   .   (Wreath.Controls.MainForm.SizeScalingPart  5   
   -   5          Name$ 
SizeScaler��5      $y�Hidden=�6�   $��2��6�   $��1��6�      	ViewModel 63   �� $ AdminWindow��$  DataContext.TotalViewModel�6�   (   "Wreath.Controls.MainForm.RolesPart  5   
   -   5          Name$ Roles��5      $y�Hidden=�6w   $��2��6�   $��1��6�      	ViewModel 6(   �� $ AdminWindow��$  DataContext.TotalViewModel�6�   '   !Wreath.Controls.MainForm.MainPart  5    
   -   5          Name$ RowView��5       $��2��6x   $��1��6�      	ViewModel 6)   �� $ AdminWindow��$  DataContext.TotalViewModel�6�   5!      5"      