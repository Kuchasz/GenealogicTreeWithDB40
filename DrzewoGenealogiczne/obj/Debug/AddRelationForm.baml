   M S B A M L   `   `   `  ����M  IGeoTreeApplication, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:GeoTree.UI
GeoTree.UI  5   	        GeoTree.UI.AddRelationForm   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   'myclr-namespace:GeoTree.UI     5   	     � Title$  Utwórz relację��5   	   $	��300��6    $	��300��6-   .��5      �  � 	Resources 5   
   '   !GeoTree.UI.InvertBooleanConverter   ibConverter��%   &	          5      6(   5	       � ColumnDefinitions 5
   
   �� 5      �� 5      �� 5       � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      �� 5      $
��Auto �6   .+�5   
   �� $��0��6   $��5q�6%   .+�5      �� -   5        $��3q�5   8   $��5q�6C   {�6   �� *AddingMather+.��6f   Dodaj matke6s   �� 5      -   5        $��3q�5   5   $��5q�6@   {�6   �� *	GotMother+.��6c   Usuń matke6o   5      �� 5   
   $��1��6   $��5q�6&   .+�5      �� -   5        $��3q�5   O   $��5q�6Z   {�6   �� *AddingFather+.��6f   
Dodaj ojca6r   �� 5      -   5        $��3q�5   5   $��5q�6@   {�6   �� *	GotFather+.��6c   
Usuń ojca6n   5      �� 5   
   -   5        $��2��5   J   $��8q�6Z   $��5q�6e   {�6   �� *AddingChild+.��6q   Dodaj dziecko6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ gridList��5         SelectionMode$ Single=�6%      AutoGenerateColumns .    
IsReadOnly . $��1��6�   $��3��6�   $��8q�6�   ��6<   �� *People+6�   �� 5   
   -   5        $��8q�5      $��5q�6   $��2��6(   $��2��65   .��6\   Dodaj6c   5       5!      