using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pract3
{
    class TimePeriod
    {
        private double _seconds;

        public double Hours
        {
            get { return _seconds / 3600; }
            set
            {
                if (value < 0 || value > 24)
                    throw new ArgumentOutOfRangeException(
                          $"{nameof(value)} must be between 0 and 24.");

                _seconds = value * 3600;
            }
        }
    }

    internal class Person
    {
        private string _firstName;
        private string _lastName;

        public Person(string first, string last)
        {
            _firstName = first;
            _lastName = last;
        }

        public string Name => $"{_firstName} {_lastName}";
    }

    public class SaleItem
    {
        string _name;
        decimal _cost;

        public SaleItem(string name, decimal cost)
        {
            _name = name;
            _cost = cost;
        }

        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public decimal Price
        {
            get => _cost;
            set => _cost = value;
        }

        public int Quantity { get; set; }
    }

    internal class Properties
    {
        public static void Main()
        {
            Console.WriteLine("Vedant Joshi                                      {0}\n\n",DateTime.Now);

            TimePeriod t = new TimePeriod();
            t.Hours = 24;

            Console.WriteLine($"Time in hours: {t.Hours}\n");


            var person = new Person("Vedant", "Joshi");
            Console.WriteLine(person.Name);

            var item = new SaleItem("Shoes", 19.95m);
            Console.WriteLine($"\n{item.Name}: sells for Rs.{item.Price}\n");

            item.Quantity = 10;

            Console.WriteLine($"\nItem: {item.Name} | Cost: Rs.{item.Price} | Quantity: {item.Quantity} | Total Cost: {item.Quantity*item.Price}");

        }

    }
}
