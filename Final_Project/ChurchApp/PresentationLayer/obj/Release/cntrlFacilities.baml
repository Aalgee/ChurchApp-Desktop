   M S B A M L   `   `   `  ���� L  HPresentationLayer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:PresentationLayerPresentationLayer  '    !PresentationLayer.cntrlFacilities   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     1localclr-namespace:PresentationLayer     
�������.���   � ColumnDefinitions  �� $	��450 ��� .+�� $��0�� � RowDefinitions �� $��50 ��� �� $	��100 �.+��� $��Center=�$��Center=�$��25(�$
��Bold"�$��
Facilities��&   System.Windows.Controls.DataGrid  -     Name$ dgAllFacilities��$��1��$
��30 0q�   
IsReadOnly .    SelectionMode$ Single=�� $��2��  �� �� �� .+��� -    ��Name$ btnFacilitySchedule��$��Facility Schedule��$��20 30q��� -   $ btnViewMyReservations��$��Center=�$��1��$��   View My
Reservations��$��20 30q��� -   $ btnReserveFacility��$��2��$��Reserve Facility��$��20 30q�� $��1�� �� $��50 ��� �� $	��100 �.+��� $��Facility Details��$��Center=�$��Center=�$��25(�$
��Bold"�� $��1�� �� �� �� �� �� $	��200 �  �� $	��200 ��� .+��� -    ��Name$ lblFacilityID��$��Facility ID: ��$��DemiBold"�$��Right=�$��Center=��� -   $ lblFacilityName��$��Facility Name: ��$��1��$��DemiBold"�$��Right=�$��Center=��� -   $ lblPricePerHour��$��Price Per Hour: ��$��2��$��DemiBold"�$��Right=�$��Center=��� -   $ lblFacilityType��$��Factility Type: ��$��3��$��DemiBold"�$��Right=�$��Center=��� -	   $ lblDescription��$��Description: ��$��4��$��DemiBold"�$��Right=�$
��0 10q�$	��Top=��� -
    ��Name$ txtFacilityID�� �� 
IsReadOnly . $��1��$��0��$��0 0 50 0q�$��30��
�������$��Center=��� -   $ txtFacilityName�� . $��1��$��1��$��0 0 50 0q�$��30��
�������$��Center=��� -   $ txtPricePerHour�� . $��1��$��2��$��0 0 50 0q�$��30��
�������$��Center=��� -   $ txtFacilityType�� . $��1��$��3��$��0 0 50 0q�$��30��
�������$��Center=��� -   $ txtDescription�� . $��1��$��4��$��	0 13 50 0q�$	��130��$	��Top=�
�������� $��2��  �� �� �� .+��� -   $ 	btnAddNew��$��Add New Facility��$��20 30q��� -   $ btnSave��$��2��$
��Save��$��20 30q��� -   $ btnEdit��$��2��$
��Edit��$��20 30q�