using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Assessment_2
{
    /*
    * Author: Steven Gibson
    * Matriculation Number: 40270320
    * Class name: Fac_Customer
    * Description: This is a bridge between the GUI and the backend, this class will update the customer 
    *              object. This will allow the GUI to update without additional code needed in the object 
    *              class and vice versa.
    * Date Last Modified: 09/12/16
    * Design Pattern: Facade 

     */
    public class Fac_Customer
    {
        SingletonLists Class_List = SingletonLists.Instance;
        private int Ref_number;

        public void Customer_add (string Name, string Address )
        {
            try
            {
            //makes a new customer then adds them to the singalton list
            Customer C = new Customer();
            C.Name = Name;
            C.Address = Address;
            Ref_number = Class_List.CustomerList.Count();
            //generates a customer id with auto-incrementing
                if (Class_List.CustomerList.Count() == 0)
                {
                C.Refnumber = Ref_number + 1;
                }

                else
                {
                    foreach (Customer c_loop in Class_List.CustomerList)
                    {
                        if (c_loop.Refnumber >= Ref_number)
                        {
                         Ref_number = c_loop.Refnumber + 1;
                        }
                        else
                        {
                         C.Refnumber = Ref_number;
                        }
                    }
                C.Refnumber = Ref_number;
            }

            Class_List.CustomerList.Add(C);
            MessageBox.Show("Saved " + C.Refnumber);
            }
            catch (Exception custadd)
            {

                MessageBox.Show(custadd.Message);
            }
        }

        public void Customer_update(string Name, string Address,int Ref_num)
        {
            foreach (Customer c in Class_List.CustomerList)
            {
                if (Ref_num == c.Refnumber)
                {
                    //updates customer
                    try
                    {
                        c.Name = Name;
                        c.Address = Address;
                        MessageBox.Show("Updated " + c.Refnumber);
                    }
                    catch (Exception custup)
                    {
                        MessageBox.Show(custup.Message);
                    }
                }//if ends
            }//froeach ends
        }

        public void Customer_remove(int ref_num)
        {
            foreach (Customer c in Class_List.CustomerList)
            {
                if (ref_num == c.Refnumber)
                {
                    //removes customer
                    if (c.BookingList.Count == 0)
                    {
                        Class_List.CustomerList.Remove(c);
                        MessageBox.Show("Deleted " + c.Refnumber);
                        break;
                    }
                    else
                    {
                        MessageBox.Show("Cannot remove" + c.Refnumber + "has they have bookings" + "\nPlease remove booking first");
                    }//second if ends
                }//first if ends
            }//for each ends
        }


    }
}
