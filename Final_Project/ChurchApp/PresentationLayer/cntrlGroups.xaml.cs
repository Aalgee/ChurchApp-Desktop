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
using DataObjects;
using LogicLayer;

namespace PresentationLayer
{
    /// <summary>
    /// Interaction logic for cntrlGroups.xaml
    /// </summary>
    public partial class cntrlGroups : UserControl
    {
        // This class is used to display information to the user about different groups. from here they can apply to join a group,
        // look at activities their groups are involved with and cancel membership in a group. Manager level users can add activites
        // to their groups and also approve applicants for membership from this page.

        private IActivityManager _activityManager;
        private IUserManager _userManager;
        private IGroupManager _groupManager;
        private User _user;
        private GroupActivityVM _activity;
        
        // This is the constructor for this class.
        public cntrlGroups(User user)
        {
            InitializeComponent();
            _activityManager = new ActivityManager();
            _userManager = new UserManager();
            _groupManager = new GroupManager();
            _user = user;
            lblGroupName.Content = "";
            
            // populates various lists
            populateGroups();
            populateWaitlist();
            populateUserGroups();

            // if you are approved you can use these features
            if (checkUserRole())
            {
                btnApproveDeny.Visibility = Visibility.Visible;
                btnAddActivities.Visibility = Visibility.Visible;
                btnDeleteActivity.Visibility = Visibility.Visible;
            }
        }

        // This mthod checks the user's roles and returns a true value if they are Pastor, Administrator, or Manager
        private bool checkUserRole()
        {
            bool isAbleToEdit = false;
            var roles = _userManager.RetrievePersonRoles(_user.PersonID);
            foreach (var r in roles)
            {
                if (r == "Pastor" || r == "Administrator" || r == "Manager")
                {
                    return isAbleToEdit = true;
                }
            }
            return isAbleToEdit;
        }

        // This method populates the waitlist that is used to indicate to the user which groups they are waiting to
        // be approved for
        private void populateWaitlist()
        {
            try
            {
                lbWaitlist.ItemsSource = _groupManager.RetriveUnapprovedPersonGroups(_user.PersonID);
            }
            catch (Exception) { }
        }

        // This method populates the user groups listbox which indicates which groups the user is a member of.
        private void populateUserGroups()
        {
            try
            {
                lbUserGroups.ItemsSource = _userManager.RetrievePersonGroups(_user.PersonID);
            }
            catch (Exception) { }
        }

        // This method populates the groups list which shows the groups that the user is not a member of.
        private void populateGroups()
        {
            var userGroups = _userManager.RetrievePersonGroups(_user.PersonID);
            var unapprovedUserGroups = _groupManager.RetriveUnapprovedPersonGroups(_user.PersonID);
            var groups = _userManager.RetrievePersonGroups();
            foreach(var ug in userGroups)
            {
                groups.Remove(ug);
            }
            foreach(var uug in unapprovedUserGroups)
            {
                groups.Remove(uug);
            }


            lbGroups.ItemsSource = groups;
        }

        // This event handler is fired when the user groups list box selection is changed. This in turn populates the dgGroupActivities
        // data grid and the dgGroupMembers data grid with the appropriate information.
        private void LbUserGroups_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            dgGroupActivities.ItemsSource = _groupManager.RetrieveActivitiesByGroupID(lbUserGroups.SelectedItem.ToString());
            dgGroupMembers.ItemsSource = _userManager.RetrieveUsersByGroupID(lbUserGroups.SelectedItem.ToString());

            lblGroupName.Content = "Group: " + lbUserGroups.SelectedItem.ToString();
        }

        // This event handler is fired when the groups list box selection is changed.
        private void LbGroups_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //dgGroupActivities.ItemsSource = _groupManager.RetrieveActivitiesByGroupID(lbGroups.SelectedItem.ToString());
            //dgGroupMembers.ItemsSource = _userManager.RetrieveUsersByGroupID(lbGroups.SelectedItem.ToString());

            
        }

        // This event handler is fired when the columns for the dgGroupActivities data grid are auto generated. It is used to 
        // format the information in the data grid into a more human readable form.
        private void DgGroupActivities_AutoGeneratedColumns(object sender, EventArgs e)
        {
            dgGroupActivities.Columns.RemoveAt(4);
            dgGroupActivities.Columns.RemoveAt(3);
            dgGroupActivities.Columns.RemoveAt(0);

            dgGroupActivities.Columns[0].Header = "Activity Name";
            dgGroupActivities.Columns[1].Header = "Start Time";
        }

        // This event handler is fired when the columns for the dgGroupMembers data grid are auto generated. It is used to 
        // format the information in the data grid into a more human readable form.
        private void DgGroupMembers_AutoGeneratedColumns(object sender, EventArgs e)
        {
            dgGroupMembers.Columns.RemoveAt(13);
            dgGroupMembers.Columns.RemoveAt(12);
            dgGroupMembers.Columns.RemoveAt(11);
            dgGroupMembers.Columns.RemoveAt(10);
            dgGroupMembers.Columns.RemoveAt(9);
            dgGroupMembers.Columns.RemoveAt(8);
            dgGroupMembers.Columns.RemoveAt(7);
            dgGroupMembers.Columns.RemoveAt(6);
            dgGroupMembers.Columns.RemoveAt(5);
            dgGroupMembers.Columns.RemoveAt(4);
            dgGroupMembers.Columns.RemoveAt(3);
            dgGroupMembers.Columns.RemoveAt(0);

            dgGroupMembers.Columns[0].Header = "First Name";
            dgGroupMembers.Columns[1].Header = "Last Name";
        }

        // This event handler is fired when the delete activity button is clicked. It deletes an activity from the list of 
        // activities that a group is involved with.
        private void BtnDeleteActivity_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                GroupActivityVM activity = (GroupActivityVM)dgGroupActivities.SelectedItem;
                _activityManager.DeleteGroupActivity(activity.ActivityID, activity.GroupID);
                dgGroupActivities.ItemsSource = _groupManager.RetrieveActivitiesByGroupID(lbUserGroups.SelectedItem.ToString());
            }
            catch (Exception)
            {
                MessageBox.Show("You must make an Activity selection.");
            }
        }

        // This event handler is fired when the sign up button is clicked. It puts the user in a wailist for the selected group.
        private void BtnSignup_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                var group = lbGroups.SelectedItem.ToString();
                if (_groupManager.AddUnapprovedPersonGroup(_user.PersonID, lbGroups.SelectedItem.ToString()))
                {
                    populateWaitlist();
                    populateGroups();
                    MessageBox.Show("You have been added to the wait list for the " + group + " group.");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("You must make a group selection.");
            }
        }

        // This event handler is fired when the cancel group button is clicked. It cancels a user's membership to a selected group.
        private void BtnCancelGroup_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _userManager.DeleteUserGroup(_user.PersonID, lbUserGroups.SelectedItem.ToString());
                populateUserGroups();
                populateGroups();
            }
            catch (Exception)
            {
                MessageBox.Show("You must make a group selection.");
            }
        }

        // This event handler is fired when the cancel waitlist button is clicked. It cancels a user's spot on a group waitlist.
        private void BtnCancelWaitlist_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _userManager.DeleteUserGroup(_user.PersonID, lbWaitlist.SelectedItem.ToString());
                populateUserGroups();
                populateGroups();
                populateWaitlist();
            }
            catch (Exception)
            {
                MessageBox.Show("You must make a group selection.");
            }
        }

        // This event handler is fired when the add activities button is clicked. It loads the group activities sign up form.
        private void BtnAddActivities_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var group = lbUserGroups.SelectedItem.ToString();
                frmGroupActivitySignUp groupActivitySignUp = new frmGroupActivitySignUp(group, _groupManager, _activityManager, this.dgGroupActivities);
                if (groupActivitySignUp.ShowDialog() == true)
                {
                    dgGroupActivities.ItemsSource = _groupManager.RetrieveActivitiesByGroupID(lbUserGroups.SelectedItem.ToString());
                    
                }
            }
            catch (Exception)
            {

                MessageBox.Show("You must make a My Groups selection.");
            }
            
        }

        // This event handler is fired when the approve/deny button is clicked. it loads the group waitlist form.
        private void BtnApproveDeny_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var groupID = lbUserGroups.SelectedItem.ToString();
                frmGroupWaitlist groupWaitlist = new frmGroupWaitlist(groupID, _groupManager, _activityManager, dgGroupMembers, _userManager);
                if (groupWaitlist.ShowDialog() == true)
                {
                    dgGroupMembers.ItemsSource = _groupManager.RetrieveActivitiesByGroupID(lbUserGroups.SelectedItem.ToString());

                }
            }
            catch (Exception)
            {

                MessageBox.Show("You must make a My Groups selection.");
            }
        }
    }
}
