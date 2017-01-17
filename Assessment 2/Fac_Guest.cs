using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

/*
* Author: Steven Gibson
* Matriculation Number: 40270320
* Class name: Fac_Guest
* Description: This is a bridge between the GUI and the backend, this class will update the guest
*              object. This will allow the GUI to update without additional code needed in the object 
*              class and vice versa.
* Date Last Modified: 09/12/16
* Design Pattern: Facade 
*/

namespace Assessment_2
{
    class Fac_Guest
    {
        SingletonLists Class_List = SingletonLists.Instance;

        public void Guest_add(string P, string N, int A, int B)
        {
             
            int idcount = 1;
               
            //geneate an id number
            foreach (Customer c in Class_List.CustomerList)
            {
                foreach (Booking b in c.BookingList)
                {
                    foreach (Guest g in b.Guest_List)
                    {
                        if (g.Guest_id <= idcount)
                        {
                            idcount = g.Guest_id + 1;
                        }//if ends
                    }//foreach guestlist ends
                }//foreach booking ends
            }//foreach customer ends
            foreach (Customer c in Class_List.CustomerList)
            {
               foreach (Booking b in c.BookingList)
               {
                   if (b.Booking_ref == B)
                   {
                       Guest g = new Guest();
                       if (b.Guest_List.Count < b.Number_guests) //checks to see if all guest have been added
                       {
                           try
                           {
                               //add guests details to object then adds them to a list in the booking class
                               g.Name = N;
                               g.Passport = P;
                               g.Age = A;
                               g.Booking_ref = B;
                               g.Guest_id = idcount;
                               b.Guest_List.Add(g);
                               MessageBox.Show("Saved Guest");
                           }
                           catch (Exception gaddexc)
                           {
                               throw new ArgumentException(gaddexc.Message);
                           }

                       }
                       else
                       {
                           MessageBox.Show("Too many guest for this Booking Please update Booking " + b.Booking_ref + " in the booking window");
                       }//if ends
                   }//if ends
               }//foreach end (booking_list
            }//foreach end (customer_list)
        }

        public void GuestUpdate(string P, string N, int A, int B)
        {
            foreach (Customer c in Class_List.CustomerList)
            {
                foreach (Booking b in c.BookingList)
                {
                    foreach (Guest g in b.Guest_List)
                    {
                        if (g.Passport == P)
                        {
                            try
                            {
                                //updates guest
                                g.Name = N;
                                g.Passport = P;
                                g.Age = A;
                                g.Booking_ref = B;

                                MessageBox.Show("Updated Guest");
                            }
                            catch (Exception gupdate)
                            {
                                throw new ArgumentException(gupdate.Message);
                            }

                        }//if ends
                    }//foreach end (Guest_list)
                }//foreach end (booking_list
               }//foreach end (customer_list)
            }
        
        public void Guest_remover(string p)
        {
            foreach (Customer c in Class_List.CustomerList)
            {
                foreach (Booking B_loop in c.BookingList)
                {
                    foreach (Guest g in B_loop.Guest_List)
                    {
                        if (p == g.Passport)
                        {
                            //removes guests from booking list
                            MessageBox.Show(g.Passport + " has been removed");
                            B_loop.Guest_List.Remove(g);
                            break;
                        }//if ends
                    }//foreach guestList ends
                }// foreach booking ends
             }// foreach customer ends
            }
        
    
    }
       
}

