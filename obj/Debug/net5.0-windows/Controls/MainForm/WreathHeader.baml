   M S B A M L   `   `   `  ����A  =Wreath, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullS.clr-namespace:Wreath.Controls.Binds.Converters Wreath.Controls.Binds.Converters  5      +    %Wreath.Controls.MainForm.WreathHeader   5      W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      E
converters.clr-namespace:Wreath.Controls.Binds.Converters     5      .��5	      �    CaptionImpact1#��[  6     � RowDefinitions  5
   
   �� 5      $��0.25* �6   �� 5      $
��0.5* �6   �� 5      $��0.25* �6    � ColumnDefinitions 5   
   �� 5      $��0.05* �6   �� 5      $
��0.2* �6   �� 5      $
��0.2* �6   �� 5      $��0.05* �6   �� 5      $
��0.2* �6   �� 5      $��0.05* �6   �� 5      $
��0.2* �6   �� 5      $��0.05* �6   .+�5   
   (� $��1��6   $��1��6"   $
��Left=�6/   .��5      �� $��
Венец��6   5      (� 5   
   $��2��6   $��1��6"   .��5       �� $��Размеры��6   5!      �� 5#   
   -   5         ��Name$ ColumnSizes��5#      $��2��6&   $��1��66     ImpactButton2#��[ 6C   .��5$      (� .��5%      �� $��База FI��6   5&      5'      (� 5)   
   $��4��6   $��1��6"   .��5*      �� $��Редакторы��6   5+      �� 5-   
   -   5        $ Roles��5-      $��4��6    $��1��60   #��[ 6=   .��5.      (� .��5/      �� $��Роли &I��6   50      51      �� 53   
   -   5         ��Name$ TableSelector��53      $��6��6*   $��1��6:     ComboBoxStyle#��[ 6G   ��55      �� 56       �� 
TargetType" ��6     ItemsBox �� BasedOn# [ 62   .@�59      �� .��6   Дисциплины5;      �� 5<      .��6   Специальности5>      �� 5?      .��6   Соответствия5A      ��5C      �� 5D       �� RelativeSource 6   �� *Self+ �� Path$ ActualHeight�5G   $    �� 	Converter 5H      @   :Wreath.Controls.Binds.Converters.ProcentualHeightConverter  5I      	 �� ConverterParameter$		 1,6��5M   2   5N      5P      �� 5R   
   -   5        $ Records��5R      $��6��6"   $��1��62   #��[ 6?   $y�Hidden=�6f   .��5S      (� .��5T      �� $��Записи _=��6   5U      5V      5W      5X      