   M S B A M L   `   `   `  ���� L  HPresentationLayer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:PresentationLayerPresentationLayer  )    #PresentationLayer.frmUpdatePassword   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     1localclr-namespace:PresentationLayer       � Title$  Update Password��$	��300��$	��450��.���  � RowDefinitions �� �� �� �� �� ��  � ColumnDefinitions �� $	��250 ��� .+��� -    ��Name$ lblCurrentPassword��$��0��$��1��$��Center=�$��Right=�$��Current Password:��$��Center=�$��Right=�$
��10 0q�$��DemiBold"��� -   $ lblNewPassword��$��0��$��2��$��Center=�$��Right=�$��New Password:��$��Center=�$��Right=�$
��10 0q�$��DemiBold"��� -   $ lblRetypePassword��$��0��$��3��$��Center=�$��Right=�$��Retype Password:��$��Center=�$��Right=�$
��10 0q�$��DemiBold"��� -    ��Name$ 	btnSubmit��$��0��$��4��$��Submit��$��Right=�$
��10 5q�$��5q�$��DemiBold"�G� -    G�Name$ pwdCurrentPassword��$��1��$��1��$	��100��$��30��$
��10 5q�$��Center=�$��Center=�$
��Left=�G� -   $ pwdNewPassword��$��1��$��2��$	��100��$��30��$
��10 5q�$��Center=�$��Center=�$
��Left=�G� -   $ pwdRetypePassword��$��1��$��3��$	��100��$��30��$
��10 5q�$��Center=�$��Center=�$
��Left=�