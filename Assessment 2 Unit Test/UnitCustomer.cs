using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assessment_2;

/*
 * Author: Steven Gibson
 * Matriculation Number: 40270320
 * Class name: UnitCustomer
 * Description: This unit test will test error checking that is part of the Customer class
 * Date Last Modified:09/12/16
 * Unit testing for Customer Class

*/


namespace Assessment_2_Unit_Test
{
    [TestClass]
    public class UnitCustomer
    {
        [TestMethod]
        public void Create_customer_with_valid_name_data()
        {
            // arrange 
            string name = "Steven";
            string address = "Falkirk";
            
            Customer test_cust = new Customer();
            
            
            // act
            test_cust.Name = name;
            test_cust.Address = address;
            // assert
            
            string actualName = test_cust.Name;
            string actualAddress = test_cust.Address;



            Assert.AreEqual(name, actualName, "Customers name was added correctly");

        }

        [TestMethod]
        public void Create_customer_with_valid_address_data()
        {
            // arrange 
            string name = "Steven";
            string address = "Falkirk";

            Customer test_cust = new Customer();


            // act
            test_cust.Name = name;
            test_cust.Address = address;
            // assert

            string actualName = test_cust.Name;
            string actualAddress = test_cust.Address;



            Assert.AreEqual(address, actualAddress, "Customers address was added correctly");

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Create_customer_with_invalid_address_data()
        {
            // arrange 
            string name = "Steven";
            string address = "";

            Customer test_cust = new Customer();


            // act
            test_cust.Name = name;
            test_cust.Address = address;
            // assert

            string actualName = test_cust.Name;
            string actualAddress = test_cust.Address;

            

            Assert.AreEqual(address, actualAddress, "Customers address was not added correctly");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Create_customer_with_invalid_name_data()
        {
            // arrange 
            string name = "";
            string address = "Falkirk";

            Customer test_cust = new Customer();


            // act
            test_cust.Name = name;
            test_cust.Address = address;
            // assert

            string actualName = test_cust.Name;
            string actualAddress = test_cust.Address;



            Assert.AreEqual(name, actualName, "Customers name was added correctly");
        }
    }
}
