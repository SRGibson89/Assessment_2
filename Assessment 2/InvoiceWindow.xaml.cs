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

/*
 * Author: Steven Gibson
 * Matriculation Number: 40270320
 * Class name: InvoiceWindow
 * Description: This is where the user will be able to find the cost of a customer’s booking and a guest 
 *	            list associated with a particular booking
 * Date Last Modified: 09/12/16

 */
namespace Assessment_2
{
    /// <summary>
    /// Interaction logic for InvoiceWindow.xaml
    /// </summary>
    public partial class InvoiceWindow : Window
    {
        MainWindow Parent;
        Booking B;
        TimeSpan nights_staying, car_hire_days,nights;
        SingletonLists Class_List = SingletonLists.Instance;
        public InvoiceWindow(MainWindow myParent)
        {
            Parent = myParent;
            InitializeComponent();
            if (Class_List.CustomerList.Count() != 0)
            {
                foreach (Customer c in Class_List.CustomerList)
                {
                    cmbCustomer.Items.Add(c.Refnumber); //populates the combobox with all the customers on record
                }
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Parent.Show();
            this.Close();
        }

        

        private void cmbBooking_Drop(object sender, EventArgs e)
        {
            
            cmbBooking.Items.Clear();
            foreach (Customer c in Class_List.CustomerList)
            {
                
                foreach (Booking b_loop in c.BookingList)
                {
                    if (b_loop.Customer_ref == int.Parse(cmbCustomer.Text))
                    {
                        cmbBooking.Items.Add(b_loop.Booking_ref);//populate the combox with bookings for that customer
                    }
                }
            }
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {

            lstDisplay.Items.Clear(); //clears the listbox of any data
            try
            {
            foreach (Customer c in Class_List.CustomerList)
            {

                foreach (Booking b_loop in c.BookingList)
                {
                        if (b_loop.Booking_ref == int.Parse(cmbBooking.Text))
                        {
                            nights = b_loop.Departure.Subtract(b_loop.Arrival); //works out the number of nights the customer is staying
                            //popluates the list box with bookings details
                            lstDisplay.Items.Add("                      Booking Detail"
                                                    + "\nCustomer Ref: " + c.Refnumber
                                                    + "\nCustomer Name: " + c.Name
                                                    + "\nCustomer Address: " + c.Address
                                                    + "\nBooking ref: " + b_loop.Booking_ref
                                                    + "\nArrival Date: " + b_loop.Arrival.Date.ToShortDateString()
                                                    + "\nDeparture Date: " + b_loop.Departure.Date.ToShortDateString()
                                                    + "\nNumber of Nights: " + nights.Days
                                                    + "\nNumber of Guests: " + b_loop.Number_guests
                                                    + "\n--------------------------------------------");
                            lstDisplay.Items.Add (  "                    Extras"
                                                    + "\nBreakfast: " + b_loop.Breakfast
                                                    + "\nBreakfast notes: " + b_loop.Breakfast_note
                                                    + "\nEvening Meals: " + b_loop.Evening_meal
                                                    + "\nEvening Meal Notes: " + b_loop.Evening_note
                                                    + "\nCar Hire: " + b_loop.Carhire
                                                    + "\nDriver Name: " + b_loop.Driver_name
                                                    + "\nCar Hire Days: " +b_loop.Carhire_dropoff.Subtract(b_loop.Carhire_pickup).Days
                                                    + "\nCar Hire Pick-up: " + b_loop.Carhire_pickup.Date.ToShortDateString()
                                                    + "\nCar Hire Drop-off: " + b_loop.Carhire_dropoff.Date.ToShortDateString()
                                                    + "\n---------------------------------------------"
                                                  );
                            

                        } // if ends
                } //booking foreach ends
             }//customer foreach ends
            get_total_price();// calls the get_total_price method
            }//try ends
                    catch (Exception invoice_Button)
                    {

                        MessageBox.Show("Please select a booking");
                    }
        }

        private void get_total_price()
        {
            double Adult_price = 50.00, Child_price = 30.00, breakfast = 5.00, evening = 15.00, car_hire_cost = 50.00, fulltotal = 0.00, staytotal=0.00, extratotal=0.00;
            
            foreach (Customer c in Class_List.CustomerList)
            {

                foreach (Booking b_loop in c.BookingList)
                {
                    if (b_loop.Booking_ref == int.Parse(cmbBooking.Text))
                    {
                        foreach (Guest g in b_loop.Guest_List)
                        {


                            nights_staying = b_loop.Departure.Subtract(b_loop.Arrival); // calculate the number of night the customer is staying
                            {

                                if (g.Age <= 18)
                                {
                                    staytotal = staytotal + Child_price; // calulate the cost if the guest is under 18
                                }
                                else
                                {
                                    staytotal = staytotal + Adult_price; // calulate the cost if the guest is over 18
                                }//if ends

                            } // if ends

                        }//guest foreach ends
                       
                        if (b_loop.Carhire == true)
                        {
                            //calulates the car hire cost if there is one 
                            car_hire_days = b_loop.Carhire_dropoff.Subtract(b_loop.Carhire_pickup); 
                            car_hire_cost = car_hire_cost * car_hire_days.TotalDays;
                            extratotal = (extratotal + car_hire_cost);
                        }
                        if (b_loop.Breakfast == true)
                        {
                            //calucatles the breakfast if it sbeen selected
                            extratotal = (extratotal + (breakfast * b_loop.Number_guests*nights_staying.TotalDays));
                        }
                        if (b_loop.Evening_meal == true)
                        {
                            extratotal = (extratotal + (evening * b_loop.Number_guests * nights_staying.TotalDays));
                        }
                    }//if ends
                } //booking foreach ends
            }//customer foreach ends
            staytotal = staytotal * nights_staying.TotalDays;
            
            fulltotal = staytotal + extratotal;
            lstDisplay.Items.Add("           Costs"
                                +"\nStay Cost: £" + staytotal
                                +"\nExtra Cost: £" + extratotal
                                +"\nTotal Cost: £"+ fulltotal
                                +"\n-----------Report ends-----------------");
        }

        private void btnguest_Click(object sender, RoutedEventArgs e)
        {
            lstDisplay.Items.Clear();
            lstDisplay.Items.Add("Guest List");
            foreach (Customer c in Class_List.CustomerList)
            {

                foreach (Booking b_loop in c.BookingList)
                {
                    foreach (Guest g in b_loop.Guest_List)
                    {
                        if (b_loop.Booking_ref == int.Parse(cmbBooking.Text))
                        {
                            //populated the list box with guest infomation for selected booking
                            lstDisplay.Items.Add("Guest Details"
                                                    + "\nGuest Name: " + g.Name
                                                    + "\nGuest Age: " + g.Age
                                                    + "\nGuest's Passport Number: "+ g.Passport
                                                    + "\n**************************************"
                                                  );
                        
                                                    
                        } // if ends
                    }//guest foreach ends
                } //booking foreach ends
            }//customer foreach ends
            lstDisplay.Items.Add("--End Of Guest List--");
        }

       

       
    }
}
