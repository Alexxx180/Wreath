   M S B A M L   `   `   `  ����
  Wreath    Wreath.EntryWindow   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	     � Icon$  /Wreath.ico��5   	    � Title$ Вход��5	   	   $	��300��5
   	   $	��450��6    � WindowStartupLocation$ CenterScreen=�5   	    � 
ResizeMode$ NoResize=�5   	      FontAdditor#��[  6    � DataContext 5   	   ��  �� RelativeSource �� *Self+.��5      �   CaptionImpact2#��[ 6    � ColumnDefinitions 5   
   �� 5      $��0.05* �6   �� 5      $
��0.9* �6   �� 5      $��0.05* �6    � RowDefinitions 5   
   �� 5      $��0.125* �6   �� 5      $��0.125* �6   �� 5      $��0.125* �6   �� 5      $��0.125* �6   �� 5      $��0.125* �6   �� 5      $��0.125* �6   �� 5      $��0.125* �6   �� 5      $��0.125* �6   .+�5   
   �� $��1��6   $��1��6   .��6/   ��5      �� 5        �� Path$ Login�6   	 �� Mode$	 TwoWay=�6'   
 �� UpdateSourceTrigger$
 	LostFocus=�65   .��5!      5"      G� 5$   
   -   5         G�Name$ PassBox��5$      $��3��6'   $��1��64   (� 5&   
   $��4��6   $��1��6   .��5'      �� #��[ 6   $��Center=�6?    d� 	IsChecked 5(      �� 5)      $ MemberMe�6   $	 TwoWay=�6.   $
 PropertyChanged=�6<   .��5*   &   Запомнить меня5,      5-      � 5/   
   $��6��6   $��1��6    50      �� 51      $
��0.1* �6#   �� 52      $��0.35* �6#   �� 53      $
��0.1* �6#   �� 54      $��0.35* �6#   �� 55      $
��0.1* �6#   .+�58      �� -   5        $��1��58       �� 	IsDefault$
 True��68     ImpactButton#��[ 6I   .��59      (� .��5:      �� $��
Войти��6    5;      5<      �� 5>      -   5        $��3��5>       �� IsCancel$
 True��67     ImpactButton2#��[ 6G   .��5?      (� .��5@      �� $��Настроить��6    5A      5B      5C      5D      5E      