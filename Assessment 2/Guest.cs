using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * Author: Steven Gibson
 * Matriculation Number: 40270320
 * Class name: Guest
 * Description: This is where the guest objects will be made and error checked to make sure all
 * 	            information is entered correctly.
 * Date Last Modified: 09/12/16

 */
namespace Assessment_2
{
    public class Guest
    {
        private string name, passport;
        private int age,booking_ref,guest_id;

        public string Name
        {
            get { return name; }
            //name cannot be blank
            set {
                if (value != "")
                {
                    name = value;
                }
                else
                {
                    throw new ArgumentNullException("Name must be filled in");
                }
            }
        }

        public string Passport
        {
            get { return passport; }
            //passport must contain between 1 and  10 characters
            set {
                if ((value.Length < 11) && (value.Length >= 1))
                {
                passport = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Passport Number must be between 1 and 10 characters long");
                }

            }
        }

        public int Age
        {
            get { return age; }
            //age must be more than 0 and less than 101
            set {
                if ((value >= 0) && (value <= 101))
                {
                    age = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("age entered is out of range");
                }
            }
        }

        public int Booking_ref
        {
            get { return booking_ref; }
            set { booking_ref = value; }
        }

        public int Guest_id
        {
            get { return guest_id; }
            set { guest_id = value; }
        }

        //contructors
        public Guest()
        { }

        public Guest(string P, string N , string A,string B,string ID)
        {
            Passport = P;
            Name = N;
            Age = int.Parse(A);
            Booking_ref = int.Parse(B);
            Guest_id = int.Parse(ID);
        }
    }
}
