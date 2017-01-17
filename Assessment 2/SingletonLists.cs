using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Author: Steven Gibson
 * Matriculation Number: 40270320
 * Class name: SingletonLists
 * Description: This is where the customer list will be stored but because I only want one list I used
 *	            the singleton pattern. The flow of the lists is as follows:  Customer -> Booking -> Guest
 *	            this allows one customer to have many bookings and one booking to have many
 *	            guests. 
 * Date Last Modified: 09/12/16
 * Design Pattern: Singleton

 */

namespace Assessment_2
{
    public class SingletonLists
    {
        //makes a new list for customer to be stored but will only make it once.
        private static SingletonLists instance;
        public List<Customer> CustomerList = new List<Customer>();
        
        private SingletonLists()
        {
        
        }

        public static SingletonLists Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SingletonLists();
                }
                return instance;
            }
        }
    }
}
