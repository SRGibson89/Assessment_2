using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * Author: Steven Gibson
 * Matriculation Number: 40270320
 * Class name: Customer
 * Description: This is where the customer objects will be made and error checked to make sure all
 * 	            information is entered correctly.
 * Date Last Modified: 09/12/16

 */

namespace Assessment_2
{
    public class Customer
    {
        private string name, address;
        private int refnumber;
        // this is the list where bookings will be stored so that each customer can access their own bookings
        public List<Booking> BookingList = new List<Booking>();

        public string Name
        {
            get { return name; }
         //nmae cannont be blank   
            set 
            {
                if (value != "")
                {
                    name = value;
                }
                else
                {
                    throw new ArgumentException("Please enter name");
                }
            }

        }

        public string Address
        {
            get { return address; }
            //address cannot be blank
            set 
            {
                if (value != "")
                {
                    address = value;
                }
                else
                {
                    throw new ArgumentException("Please enter address");
                }
            }
        }

        public int Refnumber
        {
            get { return refnumber; }
            //referance number will be auto generated in the facade
            set
            {refnumber = value;}
            
        }
        //constructors
        public Customer()
        {

        }

        public Customer(string C_ref, string C_name, string C_address)
        {
            Refnumber = int.Parse(C_ref);
            Name = C_name;
            Address = C_address;
        }
    }
}
