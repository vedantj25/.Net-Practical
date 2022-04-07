using System;

namespace Pract3{
    public class A
    {
        public int getSum(int x, int y) {
            return x + y;
        }

        public int getProduct(int x, int y)
        {
            return x * y;
        }
    }
    public class B : A
    {
        public int getSum(int x, int y, int z)
        {
            return x + y + z;
        }

        new public int getProduct(int x, int y, int z)
        {
            return x * y * z;
        }
    }

    public class Pract3
    {
        public static void Main()
        {
            Console.WriteLine("Vedant Joshi                                      {0}\n\n", DateTime.Now);
            
            A a = new A();
            B b = new B();
            Console.WriteLine("Printing from base class");
            Console.WriteLine("A + B = {0}", a.getSum(10,20));
            Console.WriteLine("A * B = {0}", a.getProduct(10, 20));
            Console.WriteLine("Calling base class method from child class");
            Console.WriteLine("A + B = {0}", b.getSum(10, 20));
            Console.WriteLine("Printing from child class");
            Console.WriteLine("A + B + C = {0}", b.getSum(10, 20, 30));
            Console.WriteLine("A * B * C = {0}", b.getProduct(10, 20, 30));

        }
    }
}