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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PresentationLayer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // This class is the central hub of the entire app. It handles log-ins and also has the menu options that allow users to
        // access the rest of the app.

        private User _user = null;
        private IUserManager _userManager;
        
        public MainWindow()
        {
            InitializeComponent();
            _userManager = new UserManager();
            hideButtons();
            

        }

        // This method hides all the menu buttons
        private void hideButtons()
        {
            btnActivities.Visibility = Visibility.Hidden;
            btnAdmin.Visibility = Visibility.Hidden;
            btnFacilities.Visibility = Visibility.Hidden;
            btnGroups.Visibility = Visibility.Hidden;
            btnSchedule.Visibility = Visibility.Hidden;
            btnVolunteer.Visibility = Visibility.Hidden;
            btnScheduling.Visibility = Visibility.Hidden;
        }

        // This event handler is fired when the
        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            var email = txtEmail.Text;
            var password = pwdPassword.Password;

            if (btnLogin.Content.ToString() == "Logout")
            {
                _user = null;
                lblStatusMessage.Content = "You are not logged in. Please login to continue.";

                hideButtons();
                cntrEmpty emptyControl = new cntrEmpty();
                ctrlMainContent.Content = emptyControl;


                // reset the login
                btnLogin.Content = "Login";
                txtEmail.Text = "";
                pwdPassword.Password = "";
                txtEmail.IsEnabled = true;
                pwdPassword.IsEnabled = true;
                txtEmail.Visibility = Visibility.Visible;
                pwdPassword.Visibility = Visibility.Visible;
                lblEmail.Visibility = Visibility.Visible;
                lblPassword.Visibility = Visibility.Visible;
                return;
            }

            if (email.Length < 7 || password.Length < 7)
            {
                MessageBox.Show("Bad username or password.", "Login Failed",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                txtEmail.Text = "";
                pwdPassword.Password = "";
                txtEmail.Focus();
                return;
            }
            // try to login
            try
            {
                _user = _userManager.AuthenticateUser(email, password);

                string roles = "";
                for (int i = 0; i < _user.Roles.Count; i++)
                {
                    roles += _user.Roles[i];
                    if (i < _user.Roles.Count - 1)
                    {
                        roles += ", ";
                    }
                }

                string message = "Welcome Back " + _user.FirstName + ".: You are logged in as: " + roles;

                lblStatusMessage.Content = message;

                // force new user to reset their password
                if (pwdPassword.Password == "newuser")
                {
                    var updatePassword = new frmUpdatePassword(_user, _userManager);
                    if (updatePassword.ShowDialog() == false)
                    {
                        // code to log the user back out
                    }
                }

                // reset the login
                btnLogin.Content = "Logout";
                txtEmail.Text = "";
                pwdPassword.Password = "";
                txtEmail.IsEnabled = false;
                pwdPassword.IsEnabled = false;
                txtEmail.Visibility = Visibility.Hidden;
                pwdPassword.Visibility = Visibility.Hidden;
                lblEmail.Visibility = Visibility.Hidden;
                lblPassword.Visibility = Visibility.Hidden;

                showUserButtons();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n" + ex.InnerException.Message,
                    "Login Failed", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }

        // This shows the menu buttons based upon the access level of the user
        private void showUserButtons()
        {
            foreach(var r in _user.Roles)
            {
                switch (r)
                {
                    case "Manager":
                        btnScheduling.Visibility = Visibility.Visible;
                        break;
                    case "Administrator":
                        btnAdmin.Visibility = Visibility.Visible;
                        break;
                    case "Employee":
                        btnSchedule.Visibility = Visibility.Visible;
                        break;
                    case "Volunteer":
                        btnSchedule.Visibility = Visibility.Visible;
                        break;
                    default:
                        
                        break;
                }
            }
            btnActivities.Visibility = Visibility.Visible;
            btnGroups.Visibility = Visibility.Visible;
            btnVolunteer.Visibility = Visibility.Visible;
            btnFacilities.Visibility = Visibility.Visible;
        }

        // This event handler is fired when the admin button is clicked. It loads the admin user control.
        private void BtnAdmin_Click(object sender, RoutedEventArgs e)
        {
            cntrlAdministration adminControl = new cntrlAdministration(_userManager);
            ctrlMainContent.Content = adminControl;
        }

        // This event handler is fired when the schedule button is clicked. It loads the schedule user control.
        private void BtnSchedule_Click(object sender, RoutedEventArgs e)
        {
            cntrlScheduleControl scheduleControl = new cntrlScheduleControl(_user);
            ctrlMainContent.Content = scheduleControl;
        }

        // This event handler is fired when the activities button is clicked. It loads the activities user control.
        private void BtnActivities_Click(object sender, RoutedEventArgs e)
        {
            cntrlActivity activityControl = new cntrlActivity(_user);
            ctrlMainContent.Content = activityControl;
        }

        // This event handler is fired when the groups button is clicked. It loads the groups user control.
        private void BtnGroups_Click(object sender, RoutedEventArgs e)
        {
            cntrlGroups groupsControl = new cntrlGroups(_user);
            ctrlMainContent.Content = groupsControl;
        }

        // This event handler is fired when the volunteer button is clicked. It loads the volunteer user control.
        private void BtnVolunteer_Click(object sender, RoutedEventArgs e)
        {
            cntrlVolunteer volunteerControl = new cntrlVolunteer(_user);
            ctrlMainContent.Content = volunteerControl;
        }

        // This event handler is fired when the scheduling button is clicked. It loads the scheduling user control.
        private void BtnScheduling_Click(object sender, RoutedEventArgs e)
        {
            cntrlScheduling scheduling = new cntrlScheduling();
            ctrlMainContent.Content = scheduling;
        }

        // This event handler is fired when the facilities button is clicked. It loads the facilities user control.
        private void BtnFacilities_Click(object sender, RoutedEventArgs e)
        {
            cntrlFacilities facilities = new cntrlFacilities(_user);
            ctrlMainContent.Content = facilities;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            AppDetails.AppPath = AppContext.BaseDirectory;
            imgHillside.Source = new BitmapImage(new Uri(AppDetails.ImagePath + "Hillside.png"));
        }
    }
}
