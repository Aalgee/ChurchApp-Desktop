   M S B A M L   `   `   `  ����L  HPresentationLayer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:PresentationLayerPresentationLayer  5   	   #    PresentationLayer.frmCheckOut   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:PresentationLayer     5   	     � Title$  	Check Out��5   	   $	��250��6   $	��300��6(   .��5	      �  � RowDefinitions 5
   
   �� 5      �� 5      �� 5      $	��100 �6    � ColumnDefinitions 5   
   �� 5      �� 5      .+�5   
   �� $��0��6   $��0��6    $��Center=�6-   $��Right=�6H   $��DemiBold"�6d   $��Date: ��6z   �� 5   
   $��0��6   $��1��6    $��Center=�6-   $��Right=�6H   $��DemiBold"�6d   $��Time: ��6z   �� 5   
   -   5         ��Name$ txtDate��5      $��1��6#   $��0��63   
�������$��
0 15 30 15q�6b   $��Center=�6v   �� 5   
   -   5        $ txtTime��5      $��1��6#   $��1��63   
�������$��
0 15 30 15q�6b   $��Center=�6v   �� 5   
   -   5         ��Name$ Cancel��5      $��2��6!   $��Cancel��6.   $��20 30q�6?   6N   �� 5   
   -   5        $ Submit��5      $��2��6!   $��1��6.   $��Submit��6>   $��20 30q�6O   6^   5      5      