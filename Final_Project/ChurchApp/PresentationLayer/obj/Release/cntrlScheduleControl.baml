   M S B A M L   `   `   `  ���� L  HPresentationLayer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:PresentationLayerPresentationLayer  ,    &PresentationLayer.cntrlScheduleControl   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     1localclr-namespace:PresentationLayer     
�������.���   � ColumnDefinitions  �� $	��500 ��� .+�� $��0�� � RowDefinitions �� $��50 ��� �� $	��100 �.+��� $��0��$��25(�$
��Bold"�$��Center=�$��Center=�.��Your Upcoming Schedule&   System.Windows.Controls.DataGrid  -     Name$ 
dgSchedule��$��1��$��20 10 20 20q�$��12(�   
IsReadOnly .    SelectionMode$ Single=�� $��2��  �� �� �� � $��1�� �� $��50 ��� �� $��30 ��� .+��� $��0��$��25(�$
��Bold"�$��Center=�$��Center=�.��	Details� $��1��  �� $	��100 ��� �� $	��100 ��� �� $��20 � �� �� �� �� �� �� �� �� .+��� $��0��$��0��$��12(�$��DemiBold"�$��Right=�$��Center=�$��Event Name: ���� $��0��$��1��$��12(�$��DemiBold"�$��Right=�$��Center=�$��Schedule Type: ���� $��0��$��2��$��12(�$��DemiBold"�$��Right=�$��Center=�$��Start Time: ���� $��0��$��3��$��12(�$��DemiBold"�$��Right=�$��Center=�$��
End Time: ���� $��0��$��4��$��12(�$��DemiBold"�$��Right=�$��Center=�$��First Name: ���� $��0��$��5��$��12(�$��DemiBold"�$��Right=�$��Center=�$��Last Name: ���� $��0��$��6��$��12(�$��DemiBold"�$��Right=�$��Center=�$��Activity Type: ���� $��2��$��0��$��12(�$��DemiBold"�$��Right=�$��Center=�$��Location Name: ���� $��2��$��1��$��12(�$��DemiBold"�$��Right=�$��Center=�$��
Address1: ���� $��2��$��2��$��12(�$��DemiBold"�$��Right=�$��Center=�$��
Address2: ���� $��2��$��3��$��12(�$��DemiBold"�$��Right=�$��Center=�$��City: ���� $��2��$��4��$��12(�$��DemiBold"�$��Right=�$��Center=�$��State: ���� $��2��$��5��$��12(�$��DemiBold"�$��Right=�$��Center=�$��Zip: ���� -    ��Name$ txtActivityName�� �� 
IsReadOnly . $��1��$��0��$��12(�$��2 2 20 2q�$��Center=�$
��Left=�
��������� -   $ txtScheduleType�� . $��1��$��1��$��12(�$��2 2 20 2q�$��Center=�$
��Left=�
��������� -   $ txtStartTime�� . $��1��$��2��$��12(�$��2 2 20 2q�$��Center=�$
��Left=�
��������� -   $ 
txtEndTime�� . $��1��$��3��$��12(�$��2 2 20 2q�$��Center=�$
��Left=�
��������� -   $ txtFirstName�� . $��1��$��4��$��12(�$��2 2 20 2q�$��Center=�$
��Left=�
��������� -   $ txtLastName�� . $��1��$��5��$��12(�$��2 2 20 2q�$��Center=�$
��Left=�
��������� -   $ txtActivityType�� . $��1��$��6��$��12(�$��2 2 20 2q�$��Center=�$
��Left=�
��������� -	   $ txtLocationName�� . $��3��$��0��$��12(�$��2 2 20 2q�$��Center=�$
��Left=�
��������� -
   $ txtAddress1�� . $��3��$��1��$��12(�$��2 2 20 2q�$��Center=�$
��Left=�
��������� -   $ txtAddress2�� . $��3��$��2��$��12(�$��2 2 20 2q�$��Center=�$
��Left=�
��������� -   $ txtCity�� . $��3��$��3��$��12(�$��2 2 20 2q�$��Center=�$
��Left=�
��������� -   $ txtState�� . $��3��$��4��$��12(�$��2 2 20 2q�$��Center=�$
��Left=�
��������� -   $ txtZip�� . $��3��$��5��$��12(�$��2 2 20 2q�$��Center=�$
��Left=�
�������� $��2��  �� $	��100 ��� .+��� $��0��$��12(�$��DemiBold"�$��Right=�$��Center=�$��Description: ��� $��3��.+��� -   $ txtDescription�� . $��
25 0 50 50q�