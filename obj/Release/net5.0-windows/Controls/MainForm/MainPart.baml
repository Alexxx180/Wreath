   M S B A M L   `   `   `  ���� 
  Wreath'    !Wreath.Controls.MainForm.MainPart   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     -     >�Name$  MainRedactor��   FontIdle#��[   � DataContext ��  �� RelativeSource �� *Self+.���   
ViewImpact#��[  ��  �� Path$ 	ViewModel� � RowDefinitions �� $��0.075* ��� $��0.85* ��� $��0.075* �.+��  � ColumnDefinitions �� $��0.15* ��� $��0.85* �.+��� -     ImpactButton#��[ y��� $ BackOperations�.��(� .���� $��
Назад��� $��1�� �� $��0.025* ��� $
��0.7* ��� $��0.275* �.+�(� $��1��$
��Left=�.���� ���� $ CurrentState.Name� �� Mode$ OneWay=� �� TargetNullValue$&  Пополнений стека:��(� $��2��$��Right=�.���� ���� $ CurrentState.Id�$ OneWay=�$ 0���� $��1��$
��Auto=�.���  �� $ 	TableView� �� $
��0.1* ��� $
��0.9* �.+��� -    ��Name$ CurrentHeaders��  CaptionImpact1#��[ ._��� .���� -   TableHeader��$ Header��� -   $ TableViewControl��$��1��  CaptionImpact2#��[ ._��� .���� -   
AllRecords��$ Records�� $��2��#��[  �� $��0.32* ��� $��0.32* ��� $��0.02* ��� $��0.05* ��� $��0.02* ��� $��0.05* ��� $��0.02* ��� $��0.04* ��� $��0.02* ��� $��0.04* �.+�]� .+�(� $
��Left=�.���� $�� Записи: ��	 �� Padding$	 2q�(� $��Right=�$
��Left=�.���� -   
 ��Name$
 CountRecords��$	 2q� �� $ 	TableView����� $ Count�]� $��1��.+�(� $
��Left=�.���� $��Выделено: ��$	 2q�(� $��Right=�$
��Left=�.���� $	 2q����� $ SelectedRows��� -    ��Name$ 	UnmarkAll��$��3��  InvisibleButton#��[  � ToolTip �� $Q��KСнять пометки со всех помеченных записей��$y�Hidden=�.��(� .���� $��+=���� -	   $ DropAll��$��5��#��[  �� $=��7Удалить все помеченные записи��$y�Hidden=�.��(� .���� $��X=���� -
   $ 
FastAction��$��3��$��3��#��[  �� $%��Быстрые действия��.��(� .���� $��!���� -   $��7��#��[  �� $D��>Снять пометки с выбранных записей��{��� $ CanBeAffected�.��(� .���� $��+���� -   $��9��#��[  �� $4��.Удалить выбранные записи��{��� $ CanBeAffected�.��(� .���� $��X��