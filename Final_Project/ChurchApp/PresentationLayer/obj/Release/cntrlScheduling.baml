   M S B A M L   `   `   `  ���� L  HPresentationLayer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:PresentationLayerPresentationLayer  '    !PresentationLayer.cntrlScheduling   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     1localclr-namespace:PresentationLayer     
�������.���   � ColumnDefinitions  �� $	��450 ��� �� .+�� $��0�� � RowDefinitions �� $��50 ��� �� $	��100 �.+��� $��All Activities��$��20(�$
��Bold"�$��Center=�$��Bottom=�&   System.Windows.Controls.DataGrid  -     Name$ dgAllActivities��$��1��$��	20 0 20 0q�   
IsReadOnly . � $��1�� �� $��50 ��� �� $	��100 �.+��� $��
Scheduling��$��25(�$
��Bold"�$��Center=�$��Center=�� $��1��  �� ��  �� $��30 ��� �� $��30 ��� .+��� $��Volunteers signed up��$��DemiBold"�$��15(�$��Center=�$��Bottom=�  -   $ dgVolunteersSignedUp��$��1��$
��10 0q�   SelectionMode$ Single=� .    GridLinesVisibility$
 None=�   HeadersVisibility$
 None=��� $��2��$��Employees Scheduled��$��DemiBold"�$��15(�$��Center=�$��Bottom=�  -   $ dgScheduledEmployees��$��3��$
��10 0q�$ Single=� . $
 None=�$
 None=��� $��All Volunteers��$��1��$��0��$��DemiBold"�$��15(�$��Center=�$��Bottom=�  -   $ dgAllVolunteers��$��1��$��1��$
��10 0q�$ Single=� . $
 None=�$
 None=��� $��All Employees��$��1��$��2��$��DemiBold"�$��15(�$��Center=�$��Bottom=�  -   $ dgAllEmployees��$��1��$��3��$
��10 0q�$ Single=� . $
 None=�$
 None=�� $��2��  �� ��  �� $��30 ��� .+��� -    ��Name$ lblAssignEmployeeActivity��$��1��$��Activity��$��Center=�$��DemiBold"�$��12(��� -   $! lblUnassignEmployeeActivity��$��0��$��Activity��$��Center=�$��DemiBold"�$��12(��� -    ��Name$ btnUnassignEmployee��$��0��$��1��$��
20 0 20 30q�$��Unassign Employee���� -	   $ btnAssignEmployee��$��1��$��1��$��
20 0 20 30q�$��Assign Employee��� $��2�� �� $��50 ��� �� $	��100 �.+��� -
   $ lblIndividualsSchedule��$��Individuals Schedule��$��20(�$
��Bold"�$��Center=�$��Bottom=�  -   $ dgIndividualsSchedule��$��1��$��	20 0 20 0q� . $ Single=�� $��2��  �� �� .+��� -   $ btnUnassignActivity��$��1��$��10 30 20 30q�$��Unassign Activity��