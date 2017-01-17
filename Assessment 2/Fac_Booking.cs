using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Assessment_2
{
    /*
     * * Author: Steven Gibson
     * Matriculation Number: 40270320
     * Class name: Fac_Booking
     * Description: This is a bridge between the GUI and the backend, this class will update the booking
     *              object. This will allow the GUI to update without additional code needed in the object class and vice versa.
     * Date Last Modified: 09/12/16
     * Design Pattern: Facade 

     * */
    class Fac_Booking
    {
        SingletonLists Class_List = SingletonLists.Instance;
        

        public void Booking_Add_without_carhire(DateTime Arrival, DateTime Depart, int Guest, int Customer_ref, bool Breakfast, string Breakfast_note, bool Meal, string Meal_note, bool CarHire)
        {
            int refcount = 1, holding = 0;
               

            foreach (Customer c in Class_List.CustomerList)
            {
                foreach (Booking b in c.BookingList)
                {
                    if (b.Booking_ref >= refcount)
                    {
                        refcount = b.Booking_ref + 1;
                    }//if ends
                }//foreach booking ends
            }//foreach customer ends


            foreach (Customer c in Class_List.CustomerList)
            {
                if (c.Refnumber == Customer_ref)
                {

                    //auto genterates a referance number
                    try
                    {
                        Booking Booking = new Booking();
                        Booking.Arrival = Arrival;
                        Booking.Departure = Depart;
                        Booking.Number_guests = Guest;
                        Booking.Breakfast = Breakfast;
                        Booking.Breakfast_note = Breakfast_note;
                        Booking.Evening_meal = Meal;
                        Booking.Evening_note = Meal_note;
                        Booking.Customer_ref = Customer_ref;
                        Booking.Booking_ref = refcount;
                        Booking.Carhire = CarHire;
                        Booking.Driver_name = "No Car Hire";
                        

                        c.BookingList.Add(Booking);
                        MessageBox.Show("Booking " + Booking.Booking_ref + " Saved");
                    }
                    catch (Exception E)
                    {
                        MessageBox.Show(E.Message);
                    }
                }//if ends
            }//Foreach ends

        }//method booking_add ends

        public void Booking_Add_with_carhire(DateTime Arrival, DateTime Depart, int Guest, int Customer_ref, bool Breakfast, string Breakfast_note, bool Meal, string Meal_note, bool CarHire, string Driver, DateTime PickDate, DateTime DropDate)
        {
            int refcount = 1, holding = 0;
            
            foreach (Customer c in Class_List.CustomerList)
            {
                foreach(Booking b in c.BookingList)
                {
                    if (b.Booking_ref >=refcount)
                    {
                        //auto genterates a referance number
                        refcount = b.Booking_ref + 1;
                    }//if ends
                }//foreach booking ends
            }//foreach customer ends
                  
        
        foreach (Customer c in Class_List.CustomerList)
        {
            if (c.Refnumber == Customer_ref)
            {
                
                    //makes a new booking and adds it to the approiate customer list
                try
                {
                    Booking Booking = new Booking();
                    Booking.Arrival = Arrival;
                    Booking.Departure = Depart;
                    Booking.Number_guests = Guest;
                    Booking.Breakfast = Breakfast;
                    Booking.Breakfast_note = Breakfast_note;
                    Booking.Evening_meal = Meal;
                    Booking.Evening_note = Meal_note;
                    Booking.Customer_ref = Customer_ref;
                    Booking.Booking_ref = refcount;
                    Booking.Carhire = CarHire;
                    Booking.Driver_name = Driver;
                    Booking.Carhire_pickup = PickDate;
                    Booking.Carhire_dropoff = DropDate;
                   
                   c.BookingList.Add(Booking);
                   MessageBox.Show("Booking " + Booking.Booking_ref +" Saved");
                }
                catch (Exception E)
                {
                    MessageBox.Show(E.Message);
                }
            }//if ends
        }//Foreach ends
           
        }//method booking_add ends

        public void Booking_Update_without_carhire(DateTime Arrival, DateTime Depart, int Guest, int Customer_ref, int Booking_ref, bool Breakfast, string Breakfast_note, bool Meal, string Meal_note, bool CarHire)
        {
            foreach (Customer c in Class_List.CustomerList)
            {
                foreach (Booking B_loop in c.BookingList)
                    if (B_loop.Booking_ref == Booking_ref)
                    {

                        //updates a booking
                        try
                        {
                            B_loop.Arrival = Arrival;
                            B_loop.Departure = Depart;
                            B_loop.Number_guests = Guest;
                            B_loop.Breakfast = Breakfast;
                            B_loop.Breakfast_note = Breakfast_note;
                            B_loop.Evening_meal = Meal;
                            B_loop.Evening_note = Meal_note;
                            B_loop.Customer_ref = Customer_ref;
                            B_loop.Carhire = CarHire;
                            B_loop.Driver_name = "No Carhire";

                        }
                        catch (Exception E)
                        {
                            MessageBox.Show(E.Message);
                        }
                    }//if ends
            }//for each ends
        }

        public void Booking_Update_with_carhire(DateTime Arrival, DateTime Depart, int Guest, int Customer_ref, int Booking_ref, bool Breakfast, string Breakfast_note, bool Meal, string Meal_note, bool CarHire, string Driver, DateTime PickDate, DateTime DropDate)
        {
            foreach (Customer c in Class_List.CustomerList)
            {
                foreach (Booking B_loop in c.BookingList)
                if (B_loop.Booking_ref == Booking_ref)
                {

                    //updates booking
                    try
                    {
                        B_loop.Arrival = Arrival;
                        B_loop.Departure = Depart;
                        B_loop.Number_guests = Guest;
                        B_loop.Breakfast = Breakfast;
                        B_loop.Breakfast_note = Breakfast_note;
                        B_loop.Evening_meal = Meal;
                        B_loop.Evening_note = Meal_note;
                        B_loop.Customer_ref = Customer_ref;
                        B_loop.Carhire = CarHire;
                        B_loop.Driver_name = Driver;
                        B_loop.Carhire_pickup = PickDate;
                        B_loop.Carhire_dropoff = DropDate;
                    }
                    catch (Exception E)
                    {
                        MessageBox.Show(E.Message);
                    }
                }//if ends
            }//for each ends
        }
   

    public void Booking_remover(int B_ref)
    {
        //removes booking
        foreach  (Customer c in Class_List.CustomerList)
        {
            foreach (Booking B_loop in c.BookingList)
            {
                if (B_loop.Booking_ref == B_ref)
                {
                    if (B_loop.Guest_List.Count == 0)
                    {
                        MessageBox.Show(B_ref + " has been removed");
                        c.BookingList.Remove(B_loop);
                        break;
                    }
                    else
                    {
                        MessageBox.Show("Cannont Remove " + B_ref + " as it has guests");
                    }//if ends
                }
            }// foreach booking ends
        }// foreach customer ends
    } 

    }
}
