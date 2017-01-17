using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assessment_2;

/*
* Author: Steven Gibson
* Matriculation Number: 40270320
* Class name: UnitGuestTest
* Description: This unit test will test error checking that is part of the Guest class
* Date Last Modified: 09/12/16
* Unit testing for Guest Class
*/

namespace Assessment_2_Unit_Test
{
    [TestClass]
   public class UnitGuestTest
    {
        [TestMethod]
        public void create_guest_with_valid_passport_data()
        {
            // arrange 
            string passport = "SG280289";   //passport can only have a maximum of 10 characters
            Guest test_guest = new Guest();
            test_guest.Passport = passport;
            // act
            string ActualPassport = test_guest.Passport;
            // assert    
            Assert.AreEqual(passport, ActualPassport, "guests passport was added correctly");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        
        public void create_guest_with_invalid_passport_data()
        {
            // arrange 
            string passport = "SRG28021989";    //passport can only have a maximum of 10 characters
            Guest test_guest = new Guest();
            test_guest.Passport = passport;
            // act
            string ActualPassport = test_guest.Passport;
            // assert 
            Assert.AreEqual(passport, ActualPassport, "guests passport not was added correctly");
        }
         [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        
        public void create_guest_with_invalid_passport_data_part2()
        {
            // arrange 
            string passport = "";    //passport cannot be blank
            Guest test_guest = new Guest();
            test_guest.Passport = passport;
            // act
            string ActualPassport = test_guest.Passport;
            // assert 
            Assert.AreEqual(passport, ActualPassport, "guests passport not was added correctly");
        }

         [TestMethod]
         public void create_guest_with_valid_age_data_within_range()
         {
             // arrange 
             int age = 27;    //age range 0 to 101
             Guest test_guest = new Guest();
             test_guest.Age = age;
             // act
             int ActualAge = test_guest.Age;
             // assert 
             Assert.AreEqual(age, ActualAge, "guests age was added correctly");
         }

         [TestMethod]
         public void create_guest_with_valid_age_data_max_range()
         {
             // arrange 
             int age = 101;    //age range 0 to 101
             Guest test_guest = new Guest();
             test_guest.Age = age;
             // act
             int ActualAge = test_guest.Age;
             // assert 
             Assert.AreEqual(age, ActualAge, "guests age was added correctly");
         }

         [TestMethod]
         public void create_guest_with_valid_age_data_min_range()
         {
             // arrange 
             int age = 0;    //age range 0 to 101
             Guest test_guest = new Guest();
             test_guest.Age = age;
             // act
             int ActualAge = test_guest.Age;
             // assert 
             Assert.AreEqual(age, ActualAge, "guests age was added correctly");
         }

         [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
         public void create_guest_with_invalid_age_data_postive_int()
         {
             // arrange 
             int age = 127;    //age range 0 to 101
             Guest test_guest = new Guest();
             test_guest.Age = age;
             // act
             int ActualAge = test_guest.Age;
             // assert 
             Assert.AreEqual(age, ActualAge, "guests age was added correctly");
         }


         [TestMethod]
         [ExpectedException(typeof(ArgumentOutOfRangeException))]
         public void create_guest_with_invalid_age_data_negitive_int()
         {
             // arrange 
             int age = -27;    //age range 0 to 101
             Guest test_guest = new Guest();
             test_guest.Age = age;
             // act
             int ActualAge = test_guest.Age;
             // assert 
              Assert.AreEqual(age, ActualAge, "guests age was added correctly");
         }

         [TestMethod]
         public void create_guest_with_valid_name_data()
         {
             // arrange 
            string name = "Steven";    //name cannont be blank
             Guest test_guest = new Guest();
             test_guest.Name = name;
             // act
             string ActualName = test_guest.Name;
             // assert 
             Assert.AreEqual(name, ActualName, "guests name was added correctly");
         }

         [TestMethod]
         [ExpectedException(typeof(ArgumentNullException))]
         public void create_guest_with_invalid_name_data()
         {
             // arrange 
             string name = "";    //name cannont be blank
             Guest test_guest = new Guest();
             test_guest.Name = name;
             // act
             string ActualName = test_guest.Name;
             // assert 
             Assert.AreEqual(name, ActualName, "guests name was added correctly");
         }
    }//end of testing
}
