   M S B A M L   `   `   `  ���� L  HPresentationLayer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:PresentationLayerPresentationLayer  "    PresentationLayer.MainWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     1localclr-namespace:PresentationLayer     -     � Title$  Hillside��$	��700��$
��1300��.���  � RowDefinitions �� $��25 ��� .+�o� $��0��.@�m� $
��File��m� $
��Edit��m� $
��Help��� $��1�� � ColumnDefinitions �� $	��200 ��� .+�� $��0�� �� $	��100 ��� �� �� �� �� �� �� �� �� $��30 ��� $��30 ��� $��30 ��� $��30 ��� $��37 ��� .+��� -    ��Name$ imgHillside���� -    ��Name$ btnVolunteer��$��4��.��	Volunteer�� -   $ btnSchedule��$��5��.��
Schedule�� -   $ btnActivities��$��1��.��
Activities�� -   $ btnFacilities��$��3��.��
Facilities�� -   $ 	btnGroups��$��2��.��Groups�� -   $ btnScheduling��$��6��$��
Scheduling���� -	   $ btnAdmin��$��7��.��User Administration�� -
    ��Name$ lblEmail��$��9��$
��Bold"�$��Center=�$��30��$��55,0.2,55,0q�$	��Top=�.��Email Address�� -    ��Name$ txtEmail��$��10��
�������$��Center=�$��5 1 5 0q�$	��5 1q�
���   �$��Center=�$��Frank@email.com���� -   $ lblPassword��$��11��$
��Bold"�$��Center=�.��
PasswordG� -    G�Name$ pwdPassword��$��12�� G� Password$ password��
�������$��5 1 5 0q�$	��5 1q�
���   �$��Center=��� -   $ btnLogin��$��13��$	��190��$��Center=�$��5q�$
��Bold"�.��Login� $��1�� �� �� $��35 �.+�>� -   	 >�Name$	 ctrlMainContent��$��0��
���OO/�$��1 0 0 1q��� $��1��.@��� 
���OO/�$��1 0 0 0 q�.���� -   $ lblStatusMessage��$��DemiBold"�.��20You are not logged in. Please login to continue.