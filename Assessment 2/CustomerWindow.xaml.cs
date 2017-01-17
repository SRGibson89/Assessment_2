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
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
/*
 * Author: Steven Gibson
 * Matriculation Number: 40270320
 * Class name: CustomerWindow
 * Description: This is where the user will enter details for new customers, update or remove existing * 	            customers. When this window is closed using the close the button the form it will 
 *	            save all date that was entered and any that was loaded to Customer.csv
 * Date Last Modified: 09/12/16

 */

namespace Assessment_2
{

    /// <summary>
    /// Interaction logic for CustomerWindow.xaml
    /// </summary>
    public partial class CustomerWindow : Window
    {
        MainWindow Parent;
        SingletonLists Class_List = SingletonLists.Instance;
        Fac_Customer Facade_Customer = new Fac_Customer();
        private int Ref_number;
       

        public CustomerWindow(MainWindow myParent)
        {
            Parent = myParent;
            InitializeComponent();
            // checks to see if any customers have been enetered if the answer is yes it will allow the eedit check bpx to be enabled
           if (Class_List.CustomerList.Count != 0 )
           {
               chkEdit.IsEnabled = true;
           }
         
        }



        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            txtref.Visibility = Visibility.Visible;
            BtnGet.Visibility = Visibility.Visible;
        }

        private void chkEdit_Unchecked(object sender, RoutedEventArgs e)
        {

            txtref.Visibility = Visibility.Hidden;
            BtnGet.Visibility = Visibility.Hidden;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
           
            try
            {
                Facade_Customer.Customer_add(txtname.Text, txtaddress.Text);    //calls the facade to make a new customer object
            Clean();    //calls the clean meathod to restore the form to default
            chkEdit.IsEnabled = true;
            }
            catch (Exception add_execpt)
            {
                System.Windows.MessageBox.Show(add_execpt.Message);
               
            }
        }

        private void BtnGet_Click(object sender, RoutedEventArgs e)
        {
            string Find_Number = txtref.Text;
            try
            {
            int Find_Customer = int.Parse(Find_Number);     //conevrts the string to an int
            foreach (Customer c_loop in Class_List.CustomerList)
            {
                if (Find_Customer == c_loop.Refnumber)
                {
                    //populates the form with data from object
                    lblref.Content = c_loop.Refnumber;
                    txtname.Text = c_loop.Name;
                    txtaddress.Text = c_loop.Address;
                    txtref.Visibility = Visibility.Hidden;
                    BtnGet.Visibility = Visibility.Hidden;
                    btnCancel.Visibility = Visibility.Visible;
                    BtnUpdate.Visibility = Visibility.Visible;
                    BtnRemove.Visibility = Visibility.Visible;
                }//if ends
            }//foreach ends
              

            }
            catch (Exception)
                {
                    System.Windows.MessageBox.Show ("Customer Reference "+ txtref.Text + "\nIs not a vaild reference number");
                }


        }
        private void Clean()
        {
            txtaddress.Clear(); //removes text from txtaddress
            txtname.Clear();    //removes text from txtname
            lblref.Content = "";//clears lblref
            txtref.Clear();     //removes text from txtref

        }

        private void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {


            int ref_num = int.Parse(txtref.Text);   //conevrts the string to an int
            Facade_Customer.Customer_update(txtname.Text, txtaddress.Text, ref_num);  //calls the update method on the facade  
            chkEdit.IsChecked = false;
            
            Clean(); //calls the clean method
            btnCancel.Visibility = Visibility.Hidden;
            BtnUpdate.Visibility = Visibility.Hidden;
            BtnRemove.Visibility = Visibility.Hidden;
                
            
        }

        private void BtnRemove_Click(object sender, RoutedEventArgs e)
        {
            int refnum = int.Parse(txtref.Text); //conevrts the string to an int
            Facade_Customer.Customer_remove(refnum);    //calls the remove method on the facade
            chkEdit.IsChecked = false;
            Clean(); //calls the clean method
            btnCancel.Visibility = Visibility.Hidden;
            BtnUpdate.Visibility = Visibility.Hidden;
            BtnRemove.Visibility = Visibility.Hidden;
            
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Save_Customers(); //save the data to file
            Parent.Show();
            this.Close();
        }

        private void Save_Customers()
        {
            string filename = @"F:\Visual Studio 2013\Projects\Assessment 2\csv files\Customer.csv"; //filenmae where data will be stored
            StreamWriter writer = new StreamWriter(filename);
            foreach (Customer C in Class_List.CustomerList)
            {
                writer.WriteLine("{0},{1},{2}", C.Refnumber.ToString(), C.Name, C.Address); //adds each object to the file as a line of text
                
            }//foreach customer ends
            writer.Close(); //closes the file
            System.Windows.MessageBox.Show("All data saved to "+ filename);
        }

        

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            
            Clean(); //calls the clean method
            chkEdit.IsChecked = false;
            btnCancel.Visibility = Visibility.Hidden;
            BtnUpdate.Visibility = Visibility.Hidden;
            BtnRemove.Visibility = Visibility.Hidden;
        }


        
    }

}

