   M S B A M L   `   `   `  ����L  HPresentationLayer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:PresentationLayerPresentationLayer  5   	   (    "PresentationLayer.frmGroupWaitlist   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:PresentationLayer     5   	     � Title$  frmGroupWaitlist��5   	   $	��600��6"   $	��400��6/   .��5	      �  � RowDefinitions 5
   
   �� 5      $��50 �6   6*   �� 5      6   �� 5      $	��100 �6   6+   .+�5   
   �� $��0��6   $��20(�6   $
��Bold"�6+   $��Center=�6=   $��Bottom=�6Z   $��Group Waitlist��6u   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dgGroupWaitlist��5       $��1��6   $��
50 10 50 0q�69      SelectionMode$ Single=�5         
IsReadOnly . 6<   � 5   
   $��2��6    � ColumnDefinitions 5      �� 5      �� 5      �� 5      .+�5      �� -   5         ��Name$ btnBack��5      $��30 30 20 30q�6&   $
��Back��6;   6J   �� 5      -   5        $ 
btnApprove��5      $��1��6)   $��20 30 20 30q�69   $��Approve��6N   6`   �� 5      -   5        $ btnDeny��5      $��2��6&   $��20 30 30 30q�66   $
��Deny��6K   6Z   5      5      5      