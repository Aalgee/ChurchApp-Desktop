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
    /// Interaction logic for frmCheckOut.xaml
    /// </summary>
    public partial class frmCheckOut : Window
    {
        // This class is a form class that is used to check out and check in facilities.

        IBookingManager _bookingManager;
        Booking _booking;
        TextBox _txtCheckOut;
        TextBox _txtCeckIn;
        frmFacilitySchedule _facilitySchedule;
        bool _isCheckout;

        // This is the constructor for this class.
        public frmCheckOut(bool isCheckOut, Booking booking, frmFacilitySchedule facilitySchedule)
        {
            InitializeComponent();
            //_txtCheckOut = txtCheckOut;
            //_txtCeckIn = txtCheckOut;
            _bookingManager = new BookingManager();
            _booking = booking;
            _facilitySchedule = facilitySchedule;

            _isCheckout = isCheckOut;
            if (!isCheckOut)
            {
                this.Title = "Check In";
            }

        }

        // This is the event handler for the submit button. It collects the information from the various text boxes
        // and uses it to update the booking check in or check out info.
        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            if(txtDate.Text == "")
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

            DateTime newDateTime = DateTime.Parse(txtDate.Text + " " + txtTime.Text);

            if (_isCheckout)
            {
                try
                {
                    if(_bookingManager.EditBookingCheckOut(_booking.BookingID, newDateTime))
                    {
                        _facilitySchedule.PopulateBookings();
                        _facilitySchedule.ClearTextBoxes();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + "\n\n" + ex.InnerException.Message);
                }
            }
            // if this is the check in page
            else
            {
                try
                {
                    if (_bookingManager.EditBookingCheckIn(_booking.BookingID, newDateTime))
                    {
                        _facilitySchedule.PopulateBookings();
                        _facilitySchedule.ClearTextBoxes();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + "\n\n" + ex.InnerException.Message);
                }
            }
            

            this.Close();
        }

        // This is the event handler for the cancel button. When it is clicked this form closes.
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
