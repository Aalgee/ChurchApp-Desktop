   M S B A M L   `   `   `  ����L  HPresentationLayer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:PresentationLayerPresentationLayer  5      '    !PresentationLayer.cntrlScheduling   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      1localclr-namespace:PresentationLayer     5      
�������.��5
      �   � ColumnDefinitions  5   
   �� 5      $	��450 �6   �� 5      �� 5      .+�5   
   � $��0��6    � RowDefinitions 5      �� 5      $��50 �6    �� 5      �� 5      $	��100 �6    .+�5      �� $��All Activities��6   $��20(�6-   $
��Bold"�6;   $��Center=�6M   $��Bottom=�6j   &   System.Windows.Controls.DataGrid  5      -   5          Name$ dgAllActivities��5      $��1��60   $��	20 0 20 0q�6=      
IsReadOnly . 6�   5      � 5   
   $��1��6    5      �� 5      $��50 �6    �� 5      �� 5      $	��100 �6    .+�5      �� $��
Scheduling��6   $��25(�6)   $
��Bold"�67   $��Center=�6I   $��Center=�6f   � 5       $��1��6     5!      �� 5"      �� 5#       5&      �� 5'      $��30 �6(   �� 5(      �� 5)      $��30 �6(   �� 5*      .+�5,      �� $��Volunteers signed up��6   $��DemiBold"�6;   $��15(�6Q   $��Center=�6_   $��Bottom=�6|     5-      -   5        $ dgVolunteersSignedUp��5-      $��1��6=   $
��10 0q�6J      SelectionMode$ Single=�6X    .    GridLinesVisibility$
 None=�6�      HeadersVisibility$
 None=�6�   6�   �� 5.      $��2��6   $��Employees Scheduled��6)   $��DemiBold"�6G   $��15(�6]   $��Center=�6k   $��Bottom=�6�     5/      -   5        $ dgScheduledEmployees��5/      $��3��6=   $
��10 0q�6J   $ Single=�6X    . $
 None=�6�   $
 None=�6�   6�   �� 52      $��All Volunteers��6   $��1��61   $��0��6A   $��DemiBold"�6N   $��15(�6d   $��Center=�6r   $��Bottom=�6�     53      -   5        $ dgAllVolunteers��53      $��1��64   $��1��6D   $
��10 0q�6Q   $ Single=�6_    . $
 None=�6�   $
 None=�6�   6�   �� 55      $��All Employees��6   $��1��60   $��2��6@   $��DemiBold"�6M   $��15(�6c   $��Center=�6q   $��Bottom=�6�     56      -   5        $ dgAllEmployees��56      $��1��67   $��3��6G   $
��10 0q�6T   $ Single=�6b    . $
 None=�6�   $
 None=�6�   6�   58      � 59      $��2��6     5:      �� 5;      �� 5<       5>      �� 5?      $��30 �6$   �� 5@      .+�5B      �� -   5         ��Name$ lblAssignEmployeeActivity��5B      $��1��6;   $��Activity��6K   $��Center=�6^   $��DemiBold"�6{   $��12(�6�   �� 5C      -   5        $! lblUnassignEmployeeActivity��5C      $��0��6=   $��Activity��6M   $��Center=�6`   $��DemiBold"�6}   $��12(�6�   �� 5D      -   5         ��Name$ btnUnassignEmployee��5D      $��0��66   $��1��6F   $��
20 0 20 30q�6S   $��Unassign Employee��6g   6�   �� 5E      -	   5        $ btnAssignEmployee��5E      $��1��64   $��1��6D   $��
20 0 20 30q�6R   $��Assign Employee��6f   6�   5F      5G      � 5H   
   $��2��6    5I      �� 5J      $��50 �6    �� 5K      �� 5L      $	��100 �6    .+�5N      �� -
   5        $ lblIndividualsSchedule��5N      $��Individuals Schedule��64   $��20(�6S   $
��Bold"�6a   $��Center=�6s   $��Bottom=�6�     5O      -   5        $ dgIndividualsSchedule��5O      $��1��66   $��	20 0 20 0q�6C    . $ Single=�6h   6   � 5P      $��2��6     5Q      �� 5R      �� 5S      .+�5U      �� -   5        $ btnUnassignActivity��5U      $��1��66   $��10 30 20 30q�6F   $��Unassign Activity��6[   5V      5X      5Y      5Z      