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
using System.Windows.Navigation;
using System.Windows.Shapes;

/*
 * Author: Steven Gibson
 * Matriculation Number: 40270320
 * Class name: MainWindow
 * Description: This is the first window the user will see when the program starts. This contains all the
 *	            buttons for CustomerWindow ,BookingWindow , GuestWindow and InvoiceWindow.
 *	            it will also populate the class lists with any saved data from csv files. Which are stored 
 *	            locally.
 * Date Last Modified: 09/12/16

 */
namespace Assessment_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SingletonLists Class_List = SingletonLists.Instance;
        public MainWindow()
        {
            InitializeComponent();
            Read_Customers(); //reads any saved date from  Customers.csv
            Read_Bookings(); //reads any saved date from  Booking.csv
            Read_Guests(); //reads any saved date from  Guest.csv
        }

        private void btnCustomer_Click(object sender, RoutedEventArgs e)
        {

            CustomerWindow new_customer_win = new CustomerWindow(this);
            this.Hide();
            new_customer_win.Show();

        }

        private void BtnBooking_Click(object sender, RoutedEventArgs e)
        {
            BookingWindow new_booking_win = new BookingWindow(this);
            //this will give an option is the booking window should be open if there are no customers
            if (new_booking_win.cmbCustomer.Items.Count != 0)
            {
                this.Hide();
                new_booking_win.Show();
            }


        }

        private void BtnInvoice_Click(object sender, RoutedEventArgs e)
        {
            InvoiceWindow new_invoice_win = new InvoiceWindow(this);
            this.Hide();
            new_invoice_win.Show();
        }

        private void BtnGuest_Click(object sender, RoutedEventArgs e)
        {
            GuestWindow new_guest_win = new GuestWindow(this);
            this.Hide();
            new_guest_win.Show();
        }

        private void Read_Customers()
        {
            string filename = @"F:\Visual Studio 2013\Projects\Assessment 2\csv files\Customer.csv"; //fillename of where the data is stored
            StreamReader reader = new StreamReader(File.OpenRead(filename));
            if (reader.Peek() == 0) //checks to see if the file is empty
            {

            }

            else
            {
                while (!reader.EndOfStream) // will read until the end of the file
                {
                    try
                    {
                    string line = reader.ReadLine();
                    var value = line.Split(',');
                    Customer C = new Customer(value[0], value[1], value[2]); //makes a new customer object with the infomation from the file
                    Class_List.CustomerList.Add(C);
                    }
                  catch (Exception cust)
                    {
                        
                        MessageBox.Show(cust.Message);
                    }
                   

                 }
                    reader.Close(); // closes the file
                  
            }
        }

        

        private void Read_Bookings()
        {
            string filename = @"F:\Visual Studio 2013\Projects\Assessment 2\csv files\Booking.csv";//fillename of where the data is stored
            StreamReader reader = new StreamReader(File.OpenRead(filename));

            while (!reader.EndOfStream)// will read until the end of the file
            {
                string line = reader.ReadLine();
                var value = line.Split(',');
                foreach (Customer c in Class_List.CustomerList) // this needed to add the booking to the coorect customer
                {
                    if (c.Refnumber.ToString() == value[3])//adds the booking to the correct customer 
                    {
                        try
                        {

                        
                        Booking B = new Booking(value[0], value[1], value[2], value[3], value[4], value[5], value[6], value[7], value[8], value[9], value[10], value[11], value[12]); //makes a new Booking object with the infomation from the file
                        c.BookingList.Add(B);
                        }
                        catch (Exception book)
                        {

                            MessageBox.Show(book.Message);
                        }
                    }//end if
                }//foreach end

            }//while end
            reader.Close();// closes the file
        }

        private void Read_Guests()
        {
            string filename = @"F:\Visual Studio 2013\Projects\Assessment 2\csv files\Guest.csv";//fillename of where the data is stored
            StreamReader reader = new StreamReader(File.OpenRead(filename));

            while (!reader.EndOfStream)// will read until the end of the file
            {
                string line = reader.ReadLine();
                var value = line.Split(',');
                foreach (Customer c in Class_List.CustomerList) //this is need to add the guest to the right booking
                {
                    foreach (Booking b in c.BookingList)
                    {
                        if (b.Booking_ref.ToString() == value[3])//adds the guest to the correct booking
                        {
                            try
                            {


                                Guest G = new Guest(value[0], value[1], value[2], value[3], value[4]); //makes a new guest object with the infomation from the file
                                b.Guest_List.Add(G);
                            }
                            catch (Exception gue)
                            {

                                MessageBox.Show(gue.Message);
                            }
                        }//end if
                    }//foreach booking ends
                }//foreach end

            }//while end
            reader.Close();// closes the file
        }
        
    }
}
