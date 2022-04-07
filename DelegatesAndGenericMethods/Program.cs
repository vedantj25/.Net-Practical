using System;
using System.Collections.Generic;
using System.Text;

namespace DelegateAndGenericMethods
{
    class QuickSort
    {
        static public void Sort<T>(IList<T> sortArray, int left, int right, Func<T, T, bool> comparision)
        {
            int pivot;
            if (left < right)
            {
                pivot = Partition(sortArray, left, right, comparision);
                if (pivot > 1)
                {
                    Sort(sortArray, left, pivot - 1, comparision);
                }
                if (pivot + 1 < right)
                {
                    Sort(sortArray, pivot + 1, right, comparision);
                }
            }
        }

        static public int Partition<T>(IList<T> sortArray, int left, int right, Func<T, T, bool> comparision)
        {

            var pivot = sortArray[left];
            while (true)
            {
                while (comparision(sortArray[left], pivot))
                {
                    left++;
                }
                while (!comparision(sortArray[right], pivot))
                {
                    right--;
                    //if (right < 0) break;
                }
                if (left < right)
                {
                    var temp = sortArray[right];
                    sortArray[right] = sortArray[left];
                    sortArray[left] = temp;
                }
                else
                {
                    return right;
                }
            }
        }
    }

    public enum Designations
    {
        CEO = 5,
        CFO = 4,
        sde = 2,
        ba = 1,
        pm = 3
    }

    class Employee
    {
        public int empid;
        public float salary;
        public string name;
        public Designations designation;

        public Employee(int EmpId, float Salary, string Name, Designations design)
        {
            this.empid = EmpId;
            this.salary = Salary;
            this.name = Name;
            this.designation = design;

        }

        internal static bool CompareSalary(Employee e1, Employee e2)
        {
            return e1.salary < e2.salary;
        }

        internal static bool CompareEmpID(Employee e1, Employee e2)
        {
            return e1.empid < e2.empid;
        }

        internal static bool CompareNames(Employee e1, Employee e2)
        {
            if (e1.name.CompareTo(e2.name) == 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        internal static bool CompareDesignations(Employee e1, Employee e2)
        {
            return e1.designation < e2.designation;
        }
    }


    public class TestGenericMethods
    {
        public static void Main(string[] args)
        {
            List<Employee> emplist = new List<Employee>(30);
            emplist.Add(new Employee(5, 500000, "ABCD", Designations.CFO));

            emplist.Add(new Employee(8, 12000000, "EFGH", Designations.CEO));

            emplist.Add(new Employee(1, 25000, "JKLM", Designations.sde));

            Console.WriteLine("Before Sorting");
            foreach (Employee e1 in emplist)
            {
                Console.WriteLine(e1.name);
            }

            QuickSort.Sort<Employee>(emplist, 0, emplist.Count - 1, Employee.CompareEmpID);

            Console.WriteLine("\nAfter Sorting according to Employee ID");
            foreach (Employee e1 in emplist)
            {
                Console.WriteLine(e1.name + " - " + e1.empid);
            }

            QuickSort.Sort<Employee>(emplist, 0, emplist.Count - 1, Employee.CompareSalary);
            Console.WriteLine("\nAfter Sorting according to Employee Salary");
            foreach (Employee e1 in emplist)
            {
                Console.WriteLine(e1.name + " - " + e1.salary);
            }

            QuickSort.Sort<Employee>(emplist, 0, emplist.Count - 1, Employee.CompareNames);
            Console.WriteLine("\nAfter Sorting according to Employee Names");
            foreach (Employee e1 in emplist)
            {
                Console.WriteLine(e1.name);
            }

            QuickSort.Sort<Employee>(emplist, 0, emplist.Count - 1, Employee.CompareDesignations);
            Console.WriteLine("\nAfter Sorting according to Employee Designations");
            foreach (Employee e1 in emplist)
            {
                Console.WriteLine(e1.name + " - " + e1.designation);
            }
        }
    }
}
