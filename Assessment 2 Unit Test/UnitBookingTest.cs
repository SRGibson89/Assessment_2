using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assessment_2;

/*
* Author: Steven Gibson
* Matriculation Number: 40270320
* Class name: UnitBookingTest
* Description: This unit test will test error checking that is part of the Booking class
* Date Last Modified: 09/12/16
* Unit testing for Booking Class

*/

namespace Assessment_2_Unit_Test
{
    [TestClass]
    public class UnitBookingTest
    {
        [TestMethod]
        public void Create_Booking_with_valid_driver_name_data()
        {
            // arrange
            Booking test_booking = new Booking();
            string name = "Steven";     //if the booking has car hire a vaild name is needed
            test_booking.Carhire = true;
            test_booking.Driver_name = name;
            // act
            string ActualName = test_booking.Driver_name;
            // assert
            Assert.AreEqual(name, ActualName, "Driver was not added correctly");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Create_Booking_with_invalid_driver_name_data()
        {
            // arrange
            Booking test_booking = new Booking();
            string name = "N/A";     //if the booking has car hire a vaild name is needed
            test_booking.Carhire = true;
            test_booking.Driver_name = name;
            // act
            string ActualName = test_booking.Driver_name;
            // assert
            Assert.AreEqual(name, ActualName, "Driver was not added correctly");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Create_Booking_with_invalid_driver_name_data_part2()
        {
            // arrange
            Booking test_booking = new Booking();
            string name = "";     //if the booking has car hire a vaild name is needed
            test_booking.Carhire = true;
            test_booking.Driver_name = name;
            // act
            string ActualName = test_booking.Driver_name;
            // assert
            Assert.AreEqual(name, ActualName, "Driver was not added correctly");
        }

        [TestMethod]
        public void Create_Booking_with_valid_arrival_data()
        {
            // arrange
            
            Booking test_booking = new Booking();
            DateTime Arrival = new DateTime(2016, 12, 13);   //bookings have to be made on or after today
            test_booking.Arrival = Arrival;
            // act
            DateTime ActualArrival = test_booking.Arrival;
            // assert
            Assert.AreEqual(Arrival, ActualArrival, "Date was not added correctly");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Create_Booking_with_invalid_arrival_data()
        {
            // arrange          
            Booking test_booking = new Booking();
            DateTime Arrival = new DateTime(2016, 12, 03);  //bookings have to be made on or after today           
            test_booking.Arrival = Arrival;
            // act
            DateTime ActualArrival = test_booking.Arrival;
            // assert
            Assert.AreEqual(Arrival, ActualArrival, "Date was not added correctly");
        }

        [TestMethod]
        public void Create_Booking_with_valid_departue_data()
        {
            // arrange
            Booking test_booking = new Booking();
            DateTime Arrival = new DateTime(2016, 12, 13);   //bookings have to be made on or after today
            DateTime Departure = new DateTime(2016, 12, 14);   //bookings have to depart on or after tomorrow 
            test_booking.Arrival = Arrival;
            test_booking.Departure = Departure;
            // act
            DateTime ActualDeparture = test_booking.Departure;
            // assert
            Assert.AreEqual(Departure, ActualDeparture, "Date was not added correctly");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Create_Booking_with_invalid_departure_data()
        {
            // arrange          
            Booking test_booking = new Booking();
            DateTime Arrival = new DateTime(2016, 12, 13);   //bookings have to be made on or after today
            DateTime Departure = new DateTime(2016, 12, 04);  //bookings have to depart on or after tomorrow  
            test_booking.Arrival = Arrival;
            test_booking.Departure = Departure;
            // act
            DateTime ActualDeaprture = test_booking.Departure;
            // assert
            Assert.AreEqual(Departure, ActualDeaprture, "Date was not added correctly");
        }

        [TestMethod]
        
        public void Create_Booking_with_valid_Carhire_Pickup_data()
        {
            // arrange
            Booking test_booking = new Booking();
            DateTime Pickup = new DateTime(2016, 12, 14);      //car hire can be picked up on or after arrival but not after or on the day of departure
            DateTime Arrival = new DateTime(2016, 12, 13);     //bookings have to be made on or after today
            DateTime Departure = new DateTime(2016, 12, 17);   //bookings have to depart on or after tomorrow 
            test_booking.Carhire = true;
            test_booking.Arrival = Arrival;
            test_booking.Departure = Departure;
            test_booking.Carhire_pickup = Pickup;
            // act
            DateTime ActualPickup = test_booking.Carhire_pickup;
            // assert
            Assert.AreEqual(Pickup, ActualPickup, "Date was not added correctly");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Create_Booking_with_invalid_Carhire_Pickup_data_part_1()
        {
            // arrange          
            Booking test_booking = new Booking();
            DateTime Pickup = new DateTime(2016, 12, 04);      //car hire can be picked up on or after arrival but not after or on the day of departure
            DateTime Arrival = new DateTime(2016, 12, 13);   //bookings have to be made on or after today
            DateTime Departure = new DateTime(2016, 12, 17);  //bookings have to depart on or after tomorrow  
            test_booking.Carhire = true;
            test_booking.Arrival = Arrival;
            test_booking.Departure = Departure;
            test_booking.Carhire_pickup = Pickup;
            // act
            DateTime ActualPickup = test_booking.Carhire_pickup;
            // assert
            Assert.AreEqual(Pickup, ActualPickup, "Date was not added correctly");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Create_Booking_with_invalid_Carhire_Pickup_data_part_2()
        {
            // arrange          
            Booking test_booking = new Booking();
            DateTime Pickup = new DateTime(2016, 12, 12);      //car hire can be picked up on or after arrival but not after or on the day of departure
            DateTime Arrival = new DateTime(2016, 12, 13);   //bookings have to be made on or after today
            DateTime Departure = new DateTime(2016, 12, 17);  //bookings have to depart on or after tomorrow  
            test_booking.Carhire = true;
            test_booking.Arrival = Arrival;
            test_booking.Departure = Departure;
            test_booking.Carhire_pickup = Pickup;
            // act
            DateTime ActualPickup = test_booking.Carhire_pickup;
            // assert
            Assert.AreEqual(Pickup, ActualPickup, "Date was not added correctly");
        }

        [TestMethod]
        public void Create_Booking_with_valid_Carhire_DropOff_data()
        {
            // arrange
            Booking test_booking = new Booking();
            DateTime DropOff = new DateTime(2016, 12, 15);      //car hire can be drop offed one after pickup but not afterthe day of departure
            DateTime Pickup = new DateTime(2016, 12, 13);      //car hire can be picked up on or after arrival but not after or on the day of departure
            DateTime Arrival = new DateTime(2016, 12, 13);   //bookings have to be made on or after today
            DateTime Departure = new DateTime(2016, 12, 17);   //bookings have to depart on or after tomorrow 
            test_booking.Carhire = true;
            test_booking.Arrival = Arrival;
            test_booking.Departure = Departure;
            test_booking.Carhire_pickup = Pickup;
            test_booking.Carhire_dropoff = DropOff;
            
            // act
            DateTime ActualDropoff = test_booking.Carhire_dropoff;
            // assert
            Assert.AreEqual(DropOff, ActualDropoff, "Date was not added correctly");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Create_Booking_with_invalid_carhire_DropOff_data_part1()
        {
            // arrange
            Booking test_booking = new Booking();
            DateTime DropOff = new DateTime(2016, 12, 13);      //car hire can be drop offed one after pickup but not afterthe day of departure
            DateTime Pickup = new DateTime(2016, 12, 13);      //car hire can be picked up on or after arrival but not after or on the day of departure
            DateTime Arrival = new DateTime(2016, 12, 13);   //bookings have to be made on or after today
            DateTime Departure = new DateTime(2016, 12, 17);   //bookings have to depart on or after tomorrow 
            test_booking.Arrival = Arrival;
            test_booking.Departure = Departure;
            test_booking.Carhire = true;
            test_booking.Carhire_pickup = Pickup;
            test_booking.Carhire_dropoff = DropOff;

            // act
            DateTime ActualDropoff = test_booking.Carhire_dropoff;
            // assert
            Assert.AreEqual(DropOff, ActualDropoff, "Date was not added correctly");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Create_Booking_with_invalid_carhire_DropOff_data_part2()
        {
            // arrange
            Booking test_booking = new Booking();
            DateTime DropOff = new DateTime(2016, 12, 04);      //car hire can be drop offed one after pickup but not afterthe day of departure
            DateTime Pickup = new DateTime(2016, 12, 13);      //car hire can be picked up on or after arrival but not after or on the day of departure
            DateTime Arrival = new DateTime(2016, 12, 13);   //bookings have to be made on or after today
            DateTime Departure = new DateTime(2016, 12, 17);   //bookings have to depart on or after tomorrow 
            test_booking.Arrival = Arrival;
            test_booking.Departure = Departure;
            test_booking.Carhire = true;
            test_booking.Carhire_pickup = Pickup;
            test_booking.Carhire_dropoff = DropOff;

            // act
            DateTime ActualDropoff = test_booking.Carhire_dropoff;
            // assert
            Assert.AreEqual(DropOff, ActualDropoff, "Date was not added correctly");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Create_Booking_with_invalid_carhire_DropOff_data_part3()
        {
            // arrange
            Booking test_booking = new Booking();
            DateTime DropOff = new DateTime(2016, 12, 19);      //car hire can be drop offed one after pickup but not afterthe day of departure
            DateTime Pickup = new DateTime(2016, 12, 13);      //car hire can be picked up on or after arrival but not after or on the day of departure
            DateTime Arrival = new DateTime(2016, 12, 13);   //bookings have to be made on or after today
            DateTime Departure = new DateTime(2016, 12, 17);   //bookings have to depart on or after tomorrow 
            test_booking.Arrival = Arrival;
            test_booking.Departure = Departure;
            test_booking.Carhire = true;
            test_booking.Carhire_pickup = Pickup;
            test_booking.Carhire_dropoff = DropOff;

            // act
            DateTime ActualDropoff = test_booking.Carhire_dropoff;
            // assert
            Assert.AreEqual(DropOff, ActualDropoff, "Date was not added correctly");
        }

    }// end of unit test
}
