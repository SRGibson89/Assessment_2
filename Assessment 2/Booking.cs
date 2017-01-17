using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * Author: Steven Gibson
 * Matriculation Number: 40270320
 * Class name: Booking
 * Description: This is where the booking objects will be made and error checked to make sure all
 * 	            information is entered correctly.
 * Date Last Modified: 09/12/16

 */
namespace Assessment_2
{
   public class Booking
    {
        public List<Guest> Guest_List = new List<Guest>();
        private string driver_name, evening_note, breakfast_note ;
        private int  booking_ref, customer_ref, number_guests;
        
        private DateTime arrival, departure, car_pickup, car_dropoff;
        private bool evening_meal = false, breakfast = false, carhire = false;

        public int Booking_ref
        {
            get { return booking_ref; }
            set { booking_ref = value; }
        }
        public DateTime Arrival
        {
            get { return arrival; }
            //date cannont before today
            set 
            { 
                if (value <=DateTime.Now.AddDays(-1)) 
                {
                    throw new ArgumentOutOfRangeException("You cannot arrive before Today");
                }
                else
                {
                    arrival = value; 
                }
            }
        }
        public DateTime Departure
        {
            get { return departure; }
            //date cant be before the arrival date
            set
            {
                if (value <=arrival)
                {
                    throw new ArgumentOutOfRangeException("you cannont depart until at least tomorrow");
                }
                else
                {
                    departure = value;
                }
            }
        }
        public string Driver_name
        {
        get{return driver_name;}
            //car hire name cant be blank unless no car haire is selected it will the default to N/A
        set
        {
            if ((value ==  "") ||(value == "N/A") && (carhire == true))
            {
                throw new ArgumentNullException("You must have a named driver");
            }
            else
            {
               driver_name = value;
            } 
        }
        }

        public string Evening_note
        {
        get{return evening_note;}
        set{evening_note = value;}
        }
        public string Breakfast_note
        {
        get{return breakfast_note;}
        set{breakfast_note = value;}
        }
       
       
        
        public int Customer_ref
        {
            get { return customer_ref; }
            set { customer_ref = value; }
        }
        public int Number_guests
        {
            get { return number_guests; }
            set { number_guests = value; }
        }

        public bool Evening_meal
        {
            get { return evening_meal; }
            set { evening_meal = value; }
        }

        public bool Breakfast
        {
            get { return breakfast; }
            set { breakfast = value; }
        }
        public bool Carhire
        {
            get { return carhire; }
            set { carhire = value; }
        }
        public DateTime Carhire_pickup
        {
            get { return car_pickup; }
            //cant pickup car until arrval date or after departure date
            set
            {
                if ((value >= arrival) && (value <= departure))
                {
                    car_pickup = value;
                }
                else if( carhire == false)
                {
                    car_pickup = value;
                }
                else
                {
                    throw new ArgumentException("you cannont pick up your car until you arrive or after you depart");
                 }
            }
        }
        public DateTime Carhire_dropoff
        {
            get { return car_dropoff; }
            //car cant be dropped off before or on pickup date or after departure date
            set
            {
                if ((value >= car_pickup.AddDays(+1)) && (value <= departure))
                {
                     car_dropoff = value;
                }
                else if (carhire == false)
                {
                    car_pickup = value;
                }
                else
                {
                    throw new ArgumentException("you cannont drop off your car before you arrive or after you depart");
                }
            }
        }
        //constructors
       public Booking()
        { }
    
       public Booking(string B_ref,string A_date ,string D_date ,string Cust_ref ,string Num_G ,string E_Meal ,string E_Note ,string Breakf ,string B_note ,string C_Hire ,string C_driver ,string C_pick ,string C_Drop)
       {
           Booking_ref = int.Parse(B_ref);
           Arrival = DateTime.Parse(A_date);
           Departure = DateTime.Parse(D_date);
           Customer_ref = int.Parse(Cust_ref);
           Number_guests = int.Parse(Num_G);
           Evening_meal = bool.Parse(E_Meal);
           Evening_note = E_Note;
           Breakfast = bool.Parse(Breakf);
           Breakfast_note = B_note;
           Carhire = bool.Parse(C_Hire);
           Driver_name = C_driver;
           Carhire_pickup = DateTime.Parse(C_pick);
           Carhire_dropoff = DateTime.Parse(C_Drop);
       }

       
    }
}
