   M S B A M L   `   `   `  ���� 
  Wreath    Wreath.EntryWindow   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006       � Icon$  /Wreath.ico�� � Title$ Вход��$	��300��$	��450�� � WindowStartupLocation$ CenterScreen=� � 
ResizeMode$ NoResize=�   FontAdditor#��[   � DataContext ��  �� RelativeSource �� *Self+.���   CaptionImpact2#��[  � ColumnDefinitions �� $��0.05* ��� $
��0.9* ��� $��0.05* � � RowDefinitions �� $��0.125* ��� $��0.125* ��� $��0.125* ��� $��0.125* ��� $��0.125* ��� $��0.125* ��� $��0.125* ��� $��0.125* �.+��� $��1��$��1��.������  �� Path$ Login�	 �� Mode$	 TwoWay=�
 �� UpdateSourceTrigger$
 	LostFocus=�.��G� -    G�Name$ PassBox��$��3��$��1��(� $��4��$��1��.���� #��[ $��Center=� d� 	IsChecked �� $ MemberMe�$	 TwoWay=�$
 PropertyChanged=�.��Запомнить меня� $��6��$��1�� �� $
��0.1* ��� $��0.35* ��� $
��0.1* ��� $��0.35* ��� $
��0.1* �.+��� -   $��1�� �� 	IsDefault$
 True��  ImpactButton#��[ .��(� .���� $��
Войти���� -   $��3�� �� IsCancel$
 True��  ImpactButton2#��[ .��(� .���� $��Настроить��