using DataObjects;
using LogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PresentationLayer
{
    /// <summary>
    /// Interaction logic for frmUpdatePassword.xaml
    /// </summary>
    public partial class frmUpdatePassword : Window
    {
        // This class is where the user will update their password.

        private User _user = null;
        private IUserManager _userManager;

        // This is the constructor for this class.
        public frmUpdatePassword(User user, IUserManager userManager)
        {
            InitializeComponent();

            _user = user;
            _userManager = userManager;
        }

        // This event handler is fired when the submit button is clicked. This takes the old password, confirms it and then uses the new password to update.
        private void BtnSubmit_Click(object sender, RoutedEventArgs e)
        {
            if (pwdCurrentPassword.Password.Length < 7)
            {
                MessageBox.Show("Current Password is incorrect. Please try again.");
                pwdCurrentPassword.Password = "";
                pwdCurrentPassword.Focus();
                return;
            }

            if (pwdNewPassword.Password.Length < 7 || pwdNewPassword.Password == pwdCurrentPassword.Password)
            {
                MessageBox.Show("New Password is incorrect. Please try again.");
                pwdNewPassword.Password = "";
                pwdNewPassword.Focus();
                return;
            }

            if (pwdRetypePassword.Password.Length != pwdNewPassword.Password.Length)
            {
                MessageBox.Show("New password and Retype must match.");
                pwdNewPassword.Password = "";
                pwdRetypePassword.Password = "";
                pwdNewPassword.Focus();
                return;
            }

            try
            {
                if (_userManager.UpdatePassword(_user.PersonID,
                    pwdNewPassword.Password.ToString(),
                    pwdCurrentPassword.Password.ToString()))
                {
                    MessageBox.Show("Password Updated");
                    this.DialogResult = true;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + "\n\n" + ex.InnerException.Message);
                this.DialogResult = false;
            }
        }
    }
}
