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
using DataObjects;
using LogicLayer;

namespace PresentationLayer
{
    /// <summary>
    /// Interaction logic for frmReserve.xaml
    /// </summary>
    public partial class frmReserve : Window
    {
        // This class is where the user will reserve a facility.

        User _user;
        cntrlFacilities _facilitiesControl;
        Facility _facility;
        IBookingManager _bookingManager;

        // This is the constructor for this class
        public frmReserve(cntrlFacilities facilitiesControl, User user, Facility facilty)
        {
            InitializeComponent();
            _bookingManager = new BookingManager();
            _user = user;
            _facilitiesControl = facilitiesControl;
            _facility = facilty;

            txtPricePerHour.Text = facilty.PricePerHour.ToString();
            this.Title = "Reserve " + facilty.FacilityName;
        }

        // This event handler is fired when the cancel button is clicked. This closes the form.
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        // This event handler is fired when the submit button is clicked. It uses the data that is entered into the text boxes to create
        // a booking object and inserts it into the database.
        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            if (txtDate.Text == "")
            {
                MessageBox.Show("You must fill out the date box.");
                txtDate.Focus();
                return;
            }
            try
            {
                DateTime.Parse(txtDate.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("You must enter the date in the proper format(mm/dd/yyyy).");
                txtDate.Focus();
                return;
            }

            if (txtTime.Text == "")
            {
                MessageBox.Show("You must fill out the time box.");
                txtTime.Focus();
                return;
            }
            try
            {
                DateTime.Parse(txtTime.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("You must enter the date in the proper format(HH:MM:SS am/pm).");
                txtTime.Focus();
                return;
            }
            if (txtHoursToReserve.Text == "")
            {
                MessageBox.Show("You must fill out the Hours to Reserve box");
                txtHoursToReserve.Focus();
                return;
            }
            try
            {
                int.Parse(txtHoursToReserve.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("You nust enter a whole number in the Hours to Reserve field.");
                txtHoursToReserve.Focus();
                return;
            }

            DateTime dateTime = DateTime.Parse(txtDate.Text + " " + txtTime.Text);

            try
            {
                Booking booking = new Booking()
                {
                    FacilityID = _facility.FacilityID,
                    PersonID = _user.PersonID,
                    ScheduledCheckOut = dateTime,
                    ScheduledCheckIn = dateTime.AddHours(int.Parse(txtHoursToReserve.Text))  
                };

                if (_bookingManager.AddBooking(booking))
                {
                    this.Close();
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        // This event handler is fired when the hours to reserve text box is changed. it uses the price per hour and the number that
        // is given to calculate how much the facility reservation will cost.
        private void TxtHoursToReserve_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                decimal pricePerHour = decimal.Parse(txtPricePerHour.Text);
                int hours = int.Parse(txtHoursToReserve.Text);
                decimal total = hours * pricePerHour;
                txtTotal.Text = total.ToString();
            }
            catch (Exception)
            {
                txtTotal.Clear();
            }
        }
    }
}
