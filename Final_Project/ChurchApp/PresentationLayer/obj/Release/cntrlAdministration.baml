   M S B A M L   `   `   `  ���� L  HPresentationLayer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:PresentationLayerPresentationLayer  [ WSystem.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089Y@clr-namespace:System.Windows.Forms;assembly=System.Windows.FormsSystem.Windows.Forms +    %PresentationLayer.cntrlAdministration   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     1localclr-namespace:PresentationLayer     RForms@clr-namespace:System.Windows.Forms;assembly=System.Windows.Forms     
�������.���   � ColumnDefinitions  �� $	��400 ��� .+�� $��0�� � RowDefinitions �� $��40 ��� �� $	��100 �.+��� $��0��$��25(�$
��Bold"�$��Center=�.��	User List&   System.Windows.Controls.DataGrid  -     Name$ 
dgUserList��$��1��$��
30 10 30 0q�   SelectionMode$ Single=�   
IsReadOnly . � $��2��  �� �� �� .+��� -    ��Name$ chkShowActive�� d� 	IsChecked$
 TrueY�$��1��$��Center=��� $��Center=�$��Right=�$��Show Active: ��� $��1�� �� $��50 ��� $	��150 ��� �� $	��100 �.+��� $��0��$��25(�$
��Bold"�$��Center=�.��User Details� $��1�� �� �� �� �� �� ��   �� $	��100 ��� �� $��65 ��� .+��� $��0��$��0��$��12(�$��DemiBold"�$��Right=�$��Center=�.��
User ID:�� $��2��$��0��$��DemiBold"�$��Right=�$��Active:���� $��0��$��1��$��12(�$��DemiBold"�$��Right=�$��Center=�.��First Name:�� $��0��$��2��$��12(�$��DemiBold"�$��Right=�$��Center=�.��
Last Name:�� $��0��$��3��$��12(�$��DemiBold"�$��Right=�$��Center=�.��DOB:�� $��0��$��4��$��12(�$��DemiBold"�$��Right=�$��Center=�.��Phone Number:�� $��0��$��5��$��12(�$��DemiBold"�$��Right=�$��Center=�.��Email Address:�� $��2��$��1��$��12(�$��DemiBold"�$��Right=�$��Center=�.��	Address1:�� $��2��$��2��$��12(�$��DemiBold"�$��Right=�$��Center=�.��	Address2:�� $��2��$��3��$��12(�$��DemiBold"�$��Right=�$��Center=�.��City:�� $��2��$��4��$��12(�$��DemiBold"�$��Right=�$��Center=�.��State:�� $��2��$��5��$��12(�$��DemiBold"�$��Right=�$��Center=�.��Zip:�� -    ��Name$ 	lblUserId��$��1��$��0��$��12(��� -    ��Name$ txtFirstName��{�.  $��1��$��1��$��12(�$��2 2 20 2q�$
��Left=�$��Center=�
��������� -   $ txtLastName��{�.  $��1��$��2��$��12(�$��2 2 20 2q�$
��Left=�$��Center=�
��������� -   $ txtDob��{�.  $��1��$��3��$��12(�$��2 2 20 2q�$
��Left=�$��Center=�
��������� -   $ txtPhoneNumber��{�.  $��1��$��4��$��12(�$��2 2 20 2q�$
��Left=�$��Center=�
��������� -   $ txtEmail��{�.  $��1��$��5��$��12(�$��2 2 20 2q�$
��Left=�$��Center=�
��������� -	   $ 	chkActive��{�.  $��3��$��0��$
��Left=�$��Center=��� -
   $ txtAddress1��{�.  $��3��$��1��$��12(�$��2 2 30 2q�$
��Left=�$��Center=�
��������� -   $ txtAddress2��{�.  $��3��$��2��$��12(�$��2 2 30 2q�$
��Left=�$��Center=�
��������� -   $ txtCity��{�.  $��3��$��3��$��12(�$��2 2 30 2q�$
��Left=�$��Center=�
��������� -   $ txtState��{�.  $��3��$��4��$��12(�$��2 2 30 2q�$
��Left=�$��Center=�
��������� -   $ txtZip��{�.  $��3��$��5��$��12(�$��2 2 30 2q�$
��Left=�$��Center=�
�������� $��2�� �� $��50 ���   �� �� $��50 ��� �� $��10 ��� �� $��50 ��� �� $��30 �.+��� $��0��$��0��$��Center=�$��Bottom=�$��DemiBold"�.��
User Roles�� $��2��$��0��$��Center=�$��Bottom=�$��DemiBold"�.��Roles�� $��4��$��0��$��Center=�$��Bottom=�$��DemiBold"�.��User Groups�� $��6��$��0��$��Center=�$��Bottom=�$��DemiBold"�.��Groups�� -   	 ��Name$	 lbUserRoles��$��0��$��1���� -   $	 lbRoles��$��2��$��1���� -   $	 lbUserGroups��$��4��$��1���� -   $	 lbGroups��$��6��$��1��� $��1��$��1�� �� �� $��50 ��� $��20 ��� $��50 ��� .+��� -   
 ��Name$
 btnRolesToUserRoles��$��0��$��1��$��8q�$��15(�$��DemiBold"�$��<<���� -   $
 btnUserRolesToRoles��$��0��$��3��$��8q�$��15(�$��DemiBold"�$��>>��� $��1��$��5�� �� �� $��50 ��� $��20 ��� $��50 ��� .+��� -   $
 btnGroupsToUserGroups��$��0��$��1��$��8q�$��15(�$��DemiBold"�$��<<���� -   $
 btnUserGroupsToGroups��$��0��$��3��$��8q�$��15(�$��DemiBold"�$��>>��� $��3��  �� �� �� �� .+��� -   $
 btnNew��$��0��$��2��$��30q�$��Creat New User���� -   $
 btnEdit��$��0��$��3��$��30q�$��	Edit User���� -   $
 btnSave��$��0��$��3��$��30q�$��	Save User��$y�Hidden=�