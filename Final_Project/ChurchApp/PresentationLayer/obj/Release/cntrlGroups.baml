   M S B A M L   `   `   `  ���� L  HPresentationLayer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:PresentationLayerPresentationLayer  #    PresentationLayer.cntrlGroups   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     1localclr-namespace:PresentationLayer     
�������.���   � ColumnDefinitions  �� $	��350 ��� $	��500 ��� .+�� $��0�� � RowDefinitions �� $��50 ��� �� $	��100 �.+��� $��0��$��20(�$
��Bold"�$��Center=�$��Center=�$��Group Activities��&   System.Windows.Controls.DataGrid  -     Name$ dgGroupActivities��$��1��$��
30 10 30 0q�   SelectionMode$ Single=�   
IsReadOnly . � $��2��  �� �� .+��� -    ��Name$ btnAddActivities��$��30 30 20 30q�$y�Hidden=�$��DemiBold"�$��Add Activity���� -   $ btnDeleteActivity��$��1��$y�Hidden=�$��20 30 30 30q�$��DemiBold"�$��Delete Activity��� $��1�� �� $��80 ��� �� $	��100 �.+��� -    ��Name$ lblGroupName��$��0��$��25(�$
��Bold"�$��Center=�$��Center=�$��
Group Name��� $��1�� �� $	��100 ���   �� �� �� .+��� -    ��Name$ lbUserGroups��$��1��$��0��$��
20 10 20 0q� �� SelectionMode$ Single=��� -   $ lbGroups��$��1��$��2��$��
20 10 20 0q�$ Single=��� -   $ 
lbWaitlist��$��1��$��1��$��
20 10 20 0q�$ Single=��� $��0��$��1��$��20(�$
��Bold"�$��Center=�$��Bottom=�$��Waitlist���� -   $ 	lblGroups��$��0��$��2��$��20(�$
��Bold"�$��Center=�$��Bottom=�$��Groups���� $��0��$��0��$��20(�$
��Bold"�$��Center=�$��Bottom=�$��MyGroups��� $��2��  �� �� �� .+��� -	   $ btnCancelGroup��$��20 30 20 30q�$��DemiBold"�$��Cancel Group���� -
   $ btnCancelWaitlist��$��1��$��20 30 20 30q�$��DemiBold"�$��Cancel Waitlist���� -   $ 	btnSignup��$��2��$��20 30 20 30q�$��DemiBold"�$��Sign Up��� $��2�� �� $��50 ��� �� $	��100 �.+��� $��0��$��20(�$
��Bold"�$��Center=�$��Center=�$��Group Members��  -   $ dgGroupMembers��$��1��$��
30 10 30 0q�$ Single=� . � $��2��.+��� -   $ btnApproveDeny��$��1��$y�Hidden=�$��30 30 30 30q�$��DemiBold"�$��Approve / Deny��