   M S B A M L   `   `   `  ����H  DGeoTree.Logic, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullR9clr-namespace:GeoTree.Logic.Models;assembly=GeoTree.LogicGeoTree.Logic.Models  5   	    GeoTreeApplication   GeoTree.UI.AddPersonForm   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Hmy9clr-namespace:GeoTree.Logic.Models;assembly=GeoTree.Logic     5   	     � Title$  Dodawanie osoby��5   	   $	��300��6!   $	��250��6.   .��5      � $��5q�6    � ColumnDefinitions 5   
   �� 5      �� 5	       � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      �� 5      $
��Auto �6   �� 5      �� 5      $
��Auto �6   �� 5      �� 5      $
��Auto �6   �� 5      �� 5      �� 5      .+�5   
   �� $��Imię i nazwisko��6   �� 5   
   $��1��6   $��2��65   $��0,0,0,5q�6I   ��6   �� *Name+6I   �� 5   
   $��2��6   $��Data urodzenia��6!   (  "System.Windows.Controls.DatePicker  5   
   $��3��6   $��2��6G   $��0,0,0,5q�6[      SelectedDate 6"   �� *DateOfBirth+6n   �� 5   
   $��4��6   $��Data śmierci��6!   �� 5   
   -   5        $
��cbox��5      $��5��6   $��0,0,0,5q�6,   6?     5   
   $��5��6   $��1��6|   $��0,0,0,5q�6�   {�6"   ��  �� ElementName$
 cbox�� �� Path$ 	IsChecked� 6X   �� *
DateOfDead+6�   �� 5   
   $��6��6   $��Płeć��6!   �� 5   
   $��7��6   $��2��6    $��0,0,0,5q�6Q    �� SelectedItem 64   �� *Sex+@�5          GeoTree.Logic.Models.Sex 5!      Male=�6    5"      
Female=�6!   5$      �� 5%   
   -   5        $��9��5%      .��65   Zapisz6=   �� 5&   
   -   5        $��9��5&      $��1��6   .��6C   Anuluj6K   5'      5(      