   M S B A M L   `   `   `  ����L  HPresentationLayer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:PresentationLayerPresentationLayer  5   	   )    #PresentationLayer.frmUpdatePassword   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:PresentationLayer     5   	     � Title$  Update Password��5   	   $	��300��6!   $	��450��6.   .��5
      �  � RowDefinitions 5   
   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6    � ColumnDefinitions 5   
   �� 5      $	��250 �6   6-   �� 5      6!   .+�5   
   �� -   5         ��Name$ lblCurrentPassword��5      $��0��5      $��1��6    $��Center=�5      $��Right=�5      $��Current Password:��5      $��Center=�5      $��Right=�5      $
��10 0q�5      $��DemiBold"�5      �� 5    
   -   5        $ lblNewPassword��5       $��0��5!      $��2��6    $��Center=�5"      $��Right=�5#      $��New Password:��5$      $��Center=�5%      $��Right=�5&      $
��10 0q�5'      $��DemiBold"�5(      �� 5)   
   -   5        $ lblRetypePassword��5)      $��0��5*      $��3��6    $��Center=�5+      $��Right=�5,      $��Retype Password:��5-      $��Center=�5.      $��Right=�5/      $
��10 0q�50      $��DemiBold"�51      �� 52   
   -   5         ��Name$ 	btnSubmit��52      $��0��53      $��4��6!   $��Submit��54      $��Right=�55      $
��10 5q�56      $��5q�57      $��DemiBold"�58      6'   G� 59   
   -   5         G�Name$ pwdCurrentPassword��59      $��1��5:      $��1��6&   $	��100��5;      $��30��6"   $
��10 5q�5<      $��Center=�5=      $��Center=�5>      $
��Left=�5?      G� 5A   
   -   5        $ pwdNewPassword��5A      $��1��5B      $��2��6&   $	��100��5C      $��30��6"   $
��10 5q�5D      $��Center=�5E      $��Center=�5F      $
��Left=�5G      G� 5I   
   -   5        $ pwdRetypePassword��5I      $��1��5J      $��3��6&   $	��100��5K      $��30��6"   $
��10 5q�5L      $��Center=�5M      $��Center=�5N      $
��Left=�5O      5Q      5R      