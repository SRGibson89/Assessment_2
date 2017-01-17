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
 * Class name: GuestWindow
 * Description: This is where the user will enter details for new guests, update or remove existing
 *	            guests. When this window is closed using the close the button the form it will 
 *	            save all date that was entered and any that was loaded to Guest.csv
 * Date Last Modified: 09/12/16

 */
namespace Assessment_2
{
    /// <summary>
    /// Interaction logic for GuestWindow.xaml
    /// </summary>
    public partial class GuestWindow : Window
    {
        MainWindow Parent;
        SingletonLists Class_List = SingletonLists.Instance;
        Fac_Guest F_Guest = new Fac_Guest();
        public GuestWindow(MainWindow myParent)
        {
            Parent = myParent;
            InitializeComponent();
            for (int i = 0; i <= 101; i++) //adds the possible ages that a guest might be to a combo box
            {
                cmbAge.Items.Add(i);
            }
            populateBooking();
        }

        public void Clean()
        {
            txtname.Clear();
            txtPassport.Clear();
            cmbAge.Text="";
            cmbBooking.Text = "";
        }
        private void populateBooking()
        {
            foreach (Customer c in Class_List.CustomerList)
            {
                foreach (Booking b in c.BookingList)
                {
                    cmbBooking.Items.Add(b.Booking_ref); // adds booking referance numbers to the combo box
                    if (b.Guest_List.Count !=0)
                    {
                        chkEdit.IsEnabled = true;
                    }
                }//foreach booking ends
            }//foreach customer ends
        }

        private void btnget_Click(object sender, RoutedEventArgs e)
        {
            foreach (Customer c in Class_List.CustomerList)
            {
                foreach (Booking b in c.BookingList)
                {
                    foreach (Guest g in b.Guest_List)
                    {
                        if (txtPassport.Text == g.Passport)
                        {
                            //populates the fields with data from the guest object
                            txtPassport.Text = g.Passport;
                            txtname.Text = g.Name;
                            cmbAge.Text = g.Age.ToString();
                            cmbBooking.Text = g.Booking_ref.ToString();
                        
                        }//if ends
                    }//foreach guest_list ends
                }//foreach booking_list ends
            }//foreach Customer_list ends
            chkEdit.IsChecked = false;
            btnget.Visibility = Visibility.Hidden;
            btnupdate.Visibility = Visibility.Visible;
            btncancel.Visibility = Visibility.Visible;
            btnremove.Visibility = Visibility.Visible;
        }

        private void btnupdate_Click(object sender, RoutedEventArgs e)
        {
            int Age = int.Parse(cmbAge.Text); //converts string to int
            int BookingRef = int.Parse(cmbBooking.Text);//converts string to int
            F_Guest.GuestUpdate(txtPassport.Text, txtname.Text, Age, BookingRef); //calls the update method from the facade
            btnupdate.Visibility = Visibility.Hidden;
            btncancel.Visibility = Visibility.Hidden;
            btnremove.Visibility = Visibility.Hidden;
            Clean();
        }

        private void btncancel_Click(object sender, RoutedEventArgs e)
        {
            Clean();
            btnupdate.Visibility = Visibility.Hidden;
            btncancel.Visibility = Visibility.Hidden;
            btnremove.Visibility = Visibility.Hidden;
        }

        private void btnsave_Click(object sender, RoutedEventArgs e)
        {
            int Age = int.Parse(cmbAge.Text);//converts string to int
            int BookingRef =int.Parse(cmbBooking.Text);//converts string to int
            F_Guest.Guest_add(txtPassport.Text,txtname.Text,Age,BookingRef);// calls the add method from the facade
            chkEdit.IsEnabled = true;
            Clean();
        }

        private void btnclose_Click(object sender, RoutedEventArgs e)
        {
            Save_Guests();//saves data to file
            Parent.Show();
            this.Close();

        }

        private void btnremove_Click(object sender, RoutedEventArgs e)
        {
            F_Guest.Guest_remover(txtPassport.Text); //calls the remover meth from the facade
            btnupdate.Visibility = Visibility.Hidden;
            btncancel.Visibility = Visibility.Hidden;
            btnremove.Visibility = Visibility.Hidden;
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            btnget.Visibility = Visibility.Visible;
        }

         private void Save_Guests()
        {
            string filename = @"F:\Visual Studio 2013\Projects\Assessment 2\csv files\Guest.csv"; //filename of where the data will be stored
            StreamWriter writer = new StreamWriter(filename);
            foreach (Customer C in Class_List.CustomerList)
            {
                foreach (Booking B in C.BookingList)
                {
                    foreach (Guest G in B.Guest_List)
                    {
                        writer.WriteLine("{0},{1},{2},{3},{4}", G.Passport, G.Name, G.Age, G.Booking_ref, G.Guest_id);
                        //write each guest object as line of text in the file
                    }//foreach guest ends                                                                       
                }//foreach booking ends
            }//foreach customer ends
            writer.Close(); //closes the file
            MessageBox.Show("All data saved to " + filename);
         }
    }
}
