using System;
using System.Collections.Generic;
using System.IO;
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

/*
 * Author: Steven Gibson
 * Matriculation Number: 40270320
 * Class name: BookingWindow
 * Description: This is where the user will enter details for new bookings, update or remove existing
 *	            bookings. When this window is closed using the close the button the form it will 
 *	            save all date that was entered and any that was loaded to Booking.csv
 * Date Last Modified: 09/12/16

 */
namespace Assessment_2
{
    /// <summary>
    /// Interaction logic for BookingWindow.xaml
    /// </summary>
    public partial class BookingWindow : Window
    {
        MainWindow Parent;
        DateTime DepatureDate;
        DateTime ArrivalDate;
        SingletonLists Class_List = SingletonLists.Instance;
        Fac_Booking Facade_Booking = new Fac_Booking();
        private bool Breakfast,Evening_meal,carhire;
        private string Breakfast_note,Evening_note,driver;
        
        private int Ref_number;
    public BookingWindow(MainWindow myParent)
        {
            Parent = myParent;
            InitializeComponent();
            populate();
        }

        private void populate()
        {
            datepickerArrival.DisplayDateStart = DateTime.Now; //sets the startdaet for the date picker to today's date
            
            if (Class_List.CustomerList.Count() != 0) //checks to see if customers have been enetered and if not will not allow you to save bookings
                //if there are customers it will add them to the combo box
            {
                foreach (Customer c in Class_List.CustomerList)
                {
                    cmbCustomer.Items.Add(c.Refnumber);
                    if (c.BookingList.Count !=0)
                    {
                        chkEdit.IsEnabled = true;
                    }
                }
            }
            else
            {
               MessageBoxResult Warning = MessageBox.Show("No Customers are avaivble no bookings can saved. \nDo you wish to continue?", "Warning",MessageBoxButton.YesNo,MessageBoxImage.Warning);
                if (Warning == MessageBoxResult.No)
                {
                    closewindow();
                                       
                }
                else
                {
                    cmbCustomer.Items.Add("No Customers Avaible");
                    btnSave.IsEnabled = false;
                }
            }
        }

        private void closewindow()
        {
            Save_Booking(); //saves bookings to file
            Parent.Show();
            this.Close();
        }

        private void Save_Booking()
        {
            string filename = @"F:\Visual Studio 2013\Projects\Assessment 2\csv files\Booking.csv"; //filename of where the data will be saved to
            StreamWriter writer = new StreamWriter(filename);
            foreach (Customer C in Class_List.CustomerList)
            {
                foreach (Booking B in C.BookingList)
                {
                    writer.WriteLine("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12}", B.Booking_ref.ToString(), B.Arrival, B.Departure, B.Customer_ref.ToString(), B.Number_guests.ToString()
                                                                                             , B.Evening_meal, B.Evening_note, B.Breakfast, B.Breakfast_note, B.Carhire, B.Driver_name, B.Carhire_pickup, B.Carhire_dropoff);
                    //write each booking as a line in the file
                }//foreach booking ends
            }//foreach customer ends
            writer.Close();//closes file
            MessageBox.Show("All data saved to " + filename);
        }

        private void Hire_Checked(object sender, RoutedEventArgs e)
        {
            cvsHire.Visibility = Visibility.Visible; //show the hire car canvas
            this.Height = 490; //extends the window

        }

        private void Hire_Unchecked(object sender, RoutedEventArgs e)
        {
            //resets the data on the canvas and puts the window back to default size
            txtdriver.Text = "N/A";
            DatePickerStartHire.SelectedDate = null;
            DatePickerEndHire.SelectedDate = null;
            cvsHire.Visibility = Visibility.Hidden;
            this.Height = 390;
        }

        private void Breakfast_checked(object sender, RoutedEventArgs e)
        {
            txtBreakfast.Visibility = Visibility.Visible;
        }

        private void Breakfast_unchecked(object sender, RoutedEventArgs e)
        {
            txtBreakfast.Visibility = Visibility.Hidden;
        }

        private void Evening_Checked(object sender, RoutedEventArgs e)
        {
            txtMeal.Visibility = Visibility.Visible;
        }

        private void Evening_Unchecked(object sender, RoutedEventArgs e)
        {
            txtMeal.Visibility = Visibility.Hidden;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int Number_guests = int.Parse(cmbNumber_guest.Text); //converts the string to an int
                int Customer_ref = int.Parse(cmbCustomer.Text); //converts the string to an int
            
            
                if (chkBreakfast.IsChecked == true)
                {
                   Breakfast = true;
                   Breakfast_note = txtBreakfast.Text;
                }
                else
                {
                    Breakfast = false;
                    Breakfast_note = txtBreakfast.Text;
                }

                if (chkMeal.IsChecked == true)
                {
                    Evening_meal = true;
                    Evening_note = txtMeal.Text;
                }
                else
                {
                    Evening_meal = false;
                    Evening_note = txtMeal.Text;
                }
                
                if (chkHire.IsChecked ==true)
                {
                    carhire = true;
                    driver = txtdriver.Text;
                }
                else
                {
                    carhire = false;
                    driver = "N/A";
                }
                if (carhire == true)
                {
                    //if the booking has car hire it will call this method from the facade
                    Facade_Booking.Booking_Add_with_carhire(datepickerArrival.SelectedDate.Value.Date, datepickerDepature.SelectedDate.Value.Date, Number_guests, Customer_ref,
                                                            Breakfast, Breakfast_note, Evening_meal, Evening_note, carhire, driver, DatePickerStartHire.SelectedDate.Value, DatePickerEndHire.SelectedDate.Value);
                }
                else
                {
                    //if the booking does not car hire it will call this method from the facade
                    Facade_Booking.Booking_Add_without_carhire(datepickerArrival.SelectedDate.Value.Date, datepickerDepature.SelectedDate.Value.Date, Number_guests, Customer_ref,
                                                               Breakfast, Breakfast_note, Evening_meal, Evening_note, carhire);
                }
                
        }
            catch (Exception Exc)
            {
                MessageBox.Show(Exc.Message);
                
            }
                Clean();
                chkEdit.IsEnabled = true;
                
            
        }

        private void Clean()
        {
            //sets everything back to deafult
            datepickerArrival.SelectedDate = DateTime.Now;
            datepickerDepature.SelectedDate = null;

            datepickerDepature.IsEnabled = false;
            lblBookingRef.Content = "";
            cmbCustomer.Text = "";
            cmbNumber_guest.Text = "";
            chkBreakfast.IsChecked = false;
            chkHire.IsChecked = false;
            chkMeal.IsChecked = false;
            txtBreakfast.Text = "N/A";
            txtdriver.Text = "N/A";
            txtMeal.Text = "N/A";
            txtBookingref.Clear();
            

        }

        private void DatePickerEndHire_CalendarOpened(object sender, RoutedEventArgs e)
        {
            DatePickerEndHire.DisplayDateStart = ArrivalDate.AddDays(1);//sets the start date to the arrival date +1 day
            DatePickerEndHire.DisplayDateEnd = DepatureDate;
        }

        private void datepickerArrival_CalendarClosed(object sender, RoutedEventArgs e)
        {
            try
            {
                ArrivalDate = datepickerArrival.SelectedDate.Value.Date;
                datepickerDepature.IsEnabled = true;
            }
            catch (System.InvalidOperationException except)
            {
                MessageBox.Show("Please select an arrival date","Warning",MessageBoxButton.OK,MessageBoxImage.Warning);

            }
        }

        private void datepickerDepature_CalendarClosed(object sender, RoutedEventArgs e)
        {
            try
            {
                DepatureDate = datepickerDepature.SelectedDate.Value.Date;
            }
            catch (System.InvalidOperationException except)
            {
               MessageBox.Show("Please select a departure date","Warning",MessageBoxButton.OK,MessageBoxImage.Warning);

                
            }

        }

        private void DatePickerStartHire_CalendarOpened(object sender, RoutedEventArgs e)
        {
            DatePickerStartHire.DisplayDateStart = ArrivalDate;
            DatePickerStartHire.DisplayDateEnd = DepatureDate;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            closewindow();
            
        }

        private void datepickerDepature_CalendarOpened(object sender, RoutedEventArgs e)
        {
            datepickerDepature.DisplayDateStart = ArrivalDate.AddDays(1);
        }

        private void btnGet_Click(object sender, RoutedEventArgs e)
        {
            string Find_Number = txtBookingref.Text; 
            int Find_Booking = int.Parse(Find_Number);//converts the string to an int
            foreach (Customer C in Class_List.CustomerList)
            {
                foreach (Booking b_loop in C.BookingList)
                {
                    if (Find_Booking == b_loop.Booking_ref)
                {
                        //populatest the fields with data from the booking object
                        txtBookingref.Visibility = Visibility.Hidden;
                        lblBookingRef.Content = b_loop.Booking_ref;
                        datepickerArrival.SelectedDate = b_loop.Arrival;
                        datepickerDepature.SelectedDate = b_loop.Departure;
                    
                        cmbCustomer.Text = b_loop.Customer_ref.ToString();
                        cmbNumber_guest.Text = b_loop.Number_guests.ToString();
                        chkBreakfast.IsChecked = b_loop.Breakfast;
                        txtBreakfast.Text = b_loop.Breakfast_note;
                        chkMeal.IsChecked = b_loop.Evening_meal;
                        txtMeal.Text = b_loop.Evening_note;
                        chkHire.IsChecked = b_loop.Carhire;
                        txtdriver.Text = b_loop.Driver_name;
                        DatePickerStartHire.SelectedDate = b_loop.Carhire_pickup;
                        DatePickerEndHire.SelectedDate = b_loop.Carhire_dropoff;
                        btnGet.Visibility = Visibility.Hidden;
                        btnRemove.Visibility = Visibility.Visible;
                        btnUpdate.Visibility = Visibility.Visible;                    
                } //if ends
                } //Booking foreach ends
            } //customer for each ends
           

           
        }

        private void chkEdit_Checked(object sender, RoutedEventArgs e)
        {
            btnGet.Visibility = Visibility.Visible;
            txtBookingref.Visibility = Visibility.Visible;
        }

        private void chkEdit_Unchecked(object sender, RoutedEventArgs e)
        {
            txtBookingref.Visibility = Visibility.Hidden;
            btnGet.Visibility = Visibility.Hidden;
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {


                int Customer_ref = int.Parse(cmbCustomer.Text); //converts string to int
                int Number_guests = int.Parse(cmbNumber_guest.Text);//converts string to int
                int Booking_ref = int.Parse(txtBookingref.Text);//converts string to int

                if (chkBreakfast.IsChecked == true)
                {
                    Breakfast = true;
                    Breakfast_note = txtBreakfast.Text;
                }
                else
                {
                    Breakfast = false;
                    Breakfast_note = txtBreakfast.Text;
                }

                if (chkMeal.IsChecked == true)
                {
                    Evening_meal = true;
                    Evening_note = txtMeal.Text;
                }
                else
                {
                    Evening_meal = false;
                    Evening_note = txtMeal.Text;
                }
                if (chkHire.IsChecked == true)
                {
                    carhire = true;
                    driver = txtdriver.Text;
                }
                else
                {
                    carhire = false;
                    driver = "N/A";
                }
                if (carhire == true)
                {
                    //if the booking has car hire it will call this method from the facade
                    Facade_Booking.Booking_Update_with_carhire(datepickerArrival.SelectedDate.Value.Date, datepickerDepature.SelectedDate.Value.Date, Number_guests, Customer_ref, Booking_ref, 
                                                               Breakfast, Breakfast_note, Evening_meal, Evening_note, carhire, driver, DatePickerStartHire.SelectedDate.Value, DatePickerEndHire.SelectedDate.Value);

                }
                else
                {
                    //if the booking does not car hire it will call this method from the facade
                    Facade_Booking.Booking_Update_without_carhire(datepickerArrival.SelectedDate.Value.Date, datepickerDepature.SelectedDate.Value.Date, Number_guests, Customer_ref, Booking_ref,
                                                                  Breakfast, Breakfast_note, Evening_meal, Evening_note, carhire);

                }
            }
            catch (Exception upexc)
            {
                MessageBox.Show(upexc.Message);

            }
                chkEdit.IsChecked = false;
            btnRemove.Visibility = Visibility.Hidden;
            btnUpdate.Visibility = Visibility.Hidden;
            Clean();
            MessageBox.Show("Updated booking");
        }
        

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            int Booking_ref = int.Parse(txtBookingref.Text); //convert string to int
            Facade_Booking.Booking_remover(Booking_ref);    //calls the remover method from the facade
            chkEdit.IsChecked = false;
            btnRemove.Visibility = Visibility.Hidden;
            btnUpdate.Visibility = Visibility.Hidden;
        }

       
    }
}
