   M S B A M L   `   `   `  ���� L  HPresentationLayer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:PresentationLayerPresentationLayer  "    PresentationLayer.frmReserve   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     1localclr-namespace:PresentationLayer       � Title$  Reserve a Facility��$	��450��$	��300��.���  � RowDefinitions �� �� �� �� �� �� $	��100 � � ColumnDefinitions �� �� .+��� $��0��$��0��$��Center=�$��Right=�$��DemiBold"�$��Date: ���� $��0��$��1��$��Center=�$��Right=�$��DemiBold"�$��Start Time: ���� $��0��$��2��$��Center=�$��Right=�$��DemiBold"�$��Hours to Reserve: ���� $��0��$��3��$��Center=�$��Right=�$��DemiBold"�$��Price Per Hour: ���� $��0��$��4��$��Center=�$��Right=�$��DemiBold"�$��Total: ���� -    ��Name$ txtDate��$��1��$��0��
�������$��
0 15 30 15q�$��Center=��� -   $ txtTime��$��1��$��1��
�������$��
0 15 30 15q�$��Center=��� -   $ txtHoursToReserve��$��1��$��2��
�������$��
0 15 30 15q�$��Center=��� -   $ txtPricePerHour�� �� 
IsReadOnly . $��1��$��3��
�������$��
0 15 30 15q�$��Center=��� -   $ txtTotal�� . $��1��$��4��
�������$��
0 15 30 15q�$��Center=��� -    ��Name$ Cancel��$��5��$��Cancel��$��20 30q��� -   $ Submit��$��5��$��1��$��Submit��$��20 30q�