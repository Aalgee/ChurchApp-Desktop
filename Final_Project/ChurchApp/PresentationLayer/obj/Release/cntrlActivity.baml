   M S B A M L   `   `   `  ���� L  HPresentationLayer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:PresentationLayerPresentationLayer  %    PresentationLayer.cntrlActivity   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     1localclr-namespace:PresentationLayer     
�������.���   � ColumnDefinitions  �� $	��500 ��� .+�� $��0�� � RowDefinitions �� $��50 ��� $	��250 ��� $��50 ��� �� $��80 �.+��� $��0��$��25(�$
��Bold"�$��Center=�$!��List of Upcoming Activities��&   System.Windows.Controls.DataGrid  -     Name$ dgActivityList��$��1��$��
30 10 30 0q�   SelectionMode$ Single=�   
IsReadOnly . �� $��2��$��25(�$
��Bold"�$��Center=�$��My Upcoming Activities��  -   $ dgUserActivityList��$��3��$��
30 0 30 20q�$ Single=� . � $��4��  �� �� �� $	��150 �.+��� -    ��Name$ 	btnSignUp��$��20 20q�$��Sign Up for Activity��$��DemiBold"�$��0���� -   $ 	btnCancel��$��20 20q�$��Cancel Attendance��$��DemiBold"�$��0��$��2��� $��1�� �� $��50 ��� $	��180 ��� �� $��80 �.+��� $��0��$��25(�$
��Bold"�$��Center=�$��Activity Details��� $��1�� �� �� �� �� �� ��   �� $	��100 ��� �� $	��100 ��� �� $��20 �.+��� $��0��$��0��$��12(�$��DemiBold"�$��Right=�$��Center=�$��Activity Name: ���� $��0��$��1��$��12(�$��DemiBold"�$��Right=�$��Center=�$��Activity Type: ���� $��0��$��2��$��12(�$��DemiBold"�$��Right=�$��Center=�$��Start: ���� $��0��$��3��$��12(�$��DemiBold"�$��Right=�$��Center=�$��End: ���� $��2��$��0��$��12(�$��DemiBold"�$��Right=�$��Center=�$��
Location: ���� $��2��$��1��$��12(�$��DemiBold"�$��Right=�$��Center=�$��
Address1: ���� $��2��$��2��$��12(�$��DemiBold"�$��Right=�$��Center=�$��
Address2: ���� $��2��$��3��$��12(�$��DemiBold"�$��Right=�$��Center=�$��City: ���� $��2��$��4��$��12(�$��DemiBold"�$��Right=�$��Center=�$��State: ���� $��2��$��5��$��12(�$��DemiBold"�$��Right=�$��Center=�$��Zip: ���� $��0��$��5��$��12(�$��DemiBold"�$��Right=�$��Center=�$��Description: ���� -    ��Name$ txtActivityName�� �� 
IsReadOnly . $��1��$��0��$��12(�$��2 2 20 2q�$
��Left=�$��Center=�
��������� -    ��Name$ cmbActivityType��{�.  $��1��$��1��$��2 2 20 2q��� -   $ txtStart�� . $��1��$��2��$��12(�$��2 2 20 2q�$
��Left=�$��Center=�
��������� -   $ txtEnd�� . $��1��$��3��$��12(�$��2 2 20 2q�$
��Left=�$��Center=�
��������� -	   $ txtLocation�� . $��3��$��0��$��12(�$��2 2 20 2q�$
��Left=�$��Center=�
��������� -
   $ txtAddress1�� . $��3��$��1��$��12(�$��2 2 20 2q�$
��Left=�$��Center=�
��������� -   $ txtAddress2�� . $��3��$��2��$��12(�$��2 2 20 2q�$
��Left=�$��Center=�
��������� -   $ txtCity�� . $��3��$��3��$��12(�$��2 2 20 2q�$
��Left=�$��Center=�
��������� -   $ txtState�� . $��3��$��4��$��12(�$��2 2 20 2q�$
��Left=�$��Center=�
��������� -   $ txtZip�� . $��3��$��5��$��12(�$��2 2 20 2q�$
��Left=�$��Center=�
�������� $��2��  �� $	��300 ��� .+�� $��0��  ��  �� $	��100 ��� $��50 ��� .+��� -   $ txtDescription�� . $��0��	 �� TextWrapping$
	 Wrap=�$��12(�$��
20 0 30 40q�
�������$��2���� $��1��$��22(�$
��Bold"�$��Center=�$��Groups Participating���� -   
 ��Name$
 lbGroupsParticipating��$��2��$��
30 0 30 20q�� $��1��  �� �� $��20 � �� $��50 ��� .+��� $��0��$��0��$��20(�$
��Bold"�$��Center=�$��Bottom=�$��People Attending��  -   $ dgPeopleAttending��$��0��$��1��$��30 10 30 20q�$ Single=� . � $��3��  �� �� �� .+��� -   $ btnEdit��$y�Hidden=�$��20 20q�$��Edit Actvivity��$��DemiBold"�$��2���� -   $ btnSave��$y�Hidden=�$��20 20q�$
��Save��$��DemiBold"�$��2���� -   $ 	btnAddNew��$y�Hidden=�$��20 20q�$��Add New Acivity��$��DemiBold"�$��1���� -   $ btnCancelActivity��$y�Hidden=�$��20 20q�$��Cancel Activity��$��DemiBold"�$��0��