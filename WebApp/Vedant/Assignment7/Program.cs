using System;
using System.Collections.Generic;
using System.Linq;

namespace Assignment7{
    
    public class Customer{
        public string? CustomerID { get; set; }
        public string? City { get; set; }
        public override string ToString(){
            return CustomerID + "\t" + City;
        }
    }

    public class Assignment7{
        public static void Main(){
            List<Customer> customers = new List<Customer>();

            customers.Add(new Customer() { CustomerID = "A1", City = "London" });
            customers.Add(new Customer() { CustomerID = "A2", City = "Paris" });
            customers.Add(new Customer() { CustomerID = "B1", City = "London" });
            customers.Add(new Customer() { CustomerID = "B2", City = "Paris" });
            customers.Add(new Customer() { CustomerID = "C1", City = "Paris" });
            customers.Add(new Customer() { CustomerID = "C2", City = "London" });

            var queryLondonCustomers = from cust in customers
                            where cust.City == "London"
                            select cust;

            Console.WriteLine("\nCustomer(s) from london");
            foreach (var londonCustomer in queryLondonCustomers)
            {
                Console.WriteLine(londonCustomer);

            }


            Console.Write("\nTotal number of customer(s): ");
            int noOfCustomers = (from cust in customers select cust).Count();
            Console.Write(noOfCustomers);

            var querycustIDStartA = from cust in customers
                            where cust.CustomerID.StartsWith('A')
                            select cust;


            Console.WriteLine("\n\nCustomer(s) with ID starting with A:");
            foreach (var custwithIDA in querycustIDStartA)
            {
                Console.WriteLine(custwithIDA);

            }

        }
    }
}