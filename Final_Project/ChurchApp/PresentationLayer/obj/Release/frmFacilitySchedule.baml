   M S B A M L   `   `   `  ���� L  HPresentationLayer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:PresentationLayerPresentationLayer  +    %PresentationLayer.frmFacilitySchedule   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     1localclr-namespace:PresentationLayer       � Title$  frmFacilitySchedule��$	��600��$
��1000��.���  � ColumnDefinitions �� �� $	��350 �.+�� $��0�� � RowDefinitions �� $��50 ��� �� $	��100 �.+��� -    ��Name$ lblMyReservations��$��Facility Schedule��$��Center=�$��Center=�$��25(�$
��Bold"�&   System.Windows.Controls.DataGrid  -     Name$ dgFacilitySchedule��$��1��$
��30 0q�   
IsReadOnly .    SelectionMode$ Single=�� $��1�� �� $��50 ��� �� $	��100 �.+�� $��1�� �� $	��130 ���  �� �� �� �� �� �� �� �� �� �� �� .+��� $��0��$��0��$��Center=�$��Right=�$��DemiBold"�$��FacilityName: ���� $��0��$��1��$��Center=�$��Right=�$��DemiBold"�$��Price Per Hour: ���� $��0��$��2��$��Center=�$��Right=�$��DemiBold"�$��Facility Type: ���� $��0��$��3��$��Center=�$��Right=�$��DemiBold"�$��First Name: ���� $��0��$��4��$��Center=�$��Right=�$��DemiBold"�$��Last Name: ���� $��0��$��5��$��Center=�$��Right=�$��DemiBold"�$��Phone Number: ���� $��0��$��6��$��Center=�$��Right=�$��DemiBold"�$��Email: ���� $��0��$��7��$��Center=�$��Right=�$��DemiBold"�$��Scheduled Check Out: ���� $��0��$��8��$��Center=�$��Right=�$��DemiBold"�$��Scheduled Check In: ���� $��0��$��9��$��Center=�$��Right=�$��DemiBold"�$��Check Out: ���� $��0��$��10��$��Center=�$��Right=�$��DemiBold"�$��
Check In: ���� -    ��Name$ txtFacilityName��$��1��$��0��
�������$��0 5 30 5q�$��Center=� �� 
IsReadOnly . �� -   $ txtPricePerHour��$��1��$��1��
�������$��0 5 30 5q�$��Center=� . �� -   $ txtFacilityType��$��1��$��2��
�������$��0 5 30 5q�$��Center=� . �� -   $ txtFirstName��$��1��$��3��
�������$��0 5 30 5q�$��Center=� . �� -   $ txtLastName��$��1��$��4��
�������$��0 5 30 5q�$��Center=� . �� -   $ txtPhoneNumber��$��1��$��5��
�������$��0 5 30 5q�$��Center=� . �� -	   $ txtEmail��$��1��$��6��
�������$��0 5 30 5q�$��Center=� . �� -
   $ txtScheduledCheckOut��$��1��$��7��
�������$��0 5 30 5q�$��Center=� . �� -   $ txtScheduledCheckIn��$��1��$��8��
�������$��0 5 30 5q�$��Center=� . �� -   $ txtCheckOut��$��1��$��9��
�������$��0 5 30 5q�$��Center=� . �� -   $ 
txtCheckIn��$��1��$��10��
�������$��0 5 30 5q�$��Center=� . � $��2�� �� �� .+��� -   	 ��Name$	 btnCheckOut��$��Check Out Facility��$��20 30q��� -   $	 
btnCheckIn��$��1��$��Check In Facility��$��20 30q�