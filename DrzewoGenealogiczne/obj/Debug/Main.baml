   M S B A M L   `   `   `  ����  GeoTreeApplication    GeoTree.UI.Main   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$
  Main��5   	   $	��450��6   $	��600��6#   .��5      �  � ColumnDefinitions 5   
   �� 5      �� 5      $
��Auto �6   .+�5
   
   &   System.Windows.Controls.DataGrid  -   5          Name$ dgrid��5
         CanUserAddRows .     
IsReadOnly . $��0��6K      AutoGenerateColumns . 5      �� 5   
   $��1��6    � 	Resources 5       �� 
TargetType �� Property	 �� Value��%y   '��       �� 5      " ��6   .�5      ��  � ��$	 5q�6/   6;   �� 5       � ��$	 5q�60   5      5      .+�5      �� -   5        .��5   /   Dodaj osobę6<   �� 5      -   5        .��5   *   Usuń osobę66   �� 5      -   5        .��5   0   Edytuj osobę6>   �� 5      -   5        .��5   1   Dodaj relację6@   �� 5      -   5        .��5   4   Pokaż spadkobierców6I   �� 5      -   5        .��5   6   Wspólni przodkowie6J   �� 5      -   5        .��5   *   Rysuj drzewo68   5      5      5      