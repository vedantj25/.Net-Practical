using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pract3
{
    public class Employee
    {
        private string _firstName, _lastName;
        private double _monthlySalary = 0.0, _yearlySalary = 0.0;

        public Employee(string firstName, string lastName, double monthlySalary)
        {
            this._firstName = firstName;
            this._lastName = lastName;
            if (monthlySalary < 0) this._monthlySalary = 0.0;
            else
            {
                this._monthlySalary = monthlySalary;
                _yearlySalary = monthlySalary * 12;
            }
        }

        public string FirstName 
        { 
            get 
            { 
                return this._firstName; 
            } 
            set 
            { 
                this._firstName = value; 
            } 
        }
        public string LastName 
        { 
            get 
            { 
                return this._lastName; 
            } 
            set 
            { 
                this._lastName = value; 
            } 
        }
        public double MonthlySalary 
        { 
            get 
            { 
                return this._monthlySalary; 
            }
            set
            {
                if (value < 0)
                {
                    this._monthlySalary = 0.0;
                    this._yearlySalary = 0.0;
                }
                else
                {
                    this._monthlySalary = value;
                    this._yearlySalary = value*12;
                }
            } 
        }

        public double YearlySalary
        {
            get => this._yearlySalary;
        }

        public virtual void giveRaise(double percentage)
        {
            this.MonthlySalary += (percentage/100) * this.MonthlySalary;
        }

        public override string ToString()
        {
            return $"----- Employee Details -----\nEmployee Name: {this._firstName} {this._lastName}\nMonthly Salary: {this._monthlySalary}\nYearly Salary: {this._yearlySalary}\n\n";
        }

    }

    public class PermanentEmployee : Employee
    {
        private double _hra, _da, _pf;
        private DateOnly _joiningDate, _retirementDate;
        public PermanentEmployee(string firstName, string lastName, double monthlySalary, double hra, double da, double pf) : base(firstName, lastName, (monthlySalary+da+hra+pf))
        {
            _hra = hra;
            _da = da;
            _pf = pf;
        }


        public string getAllowances()
        {
            return $"Housing Rent Allowance: {this._hra}\nDearness Allowance: {this._da}";
        }

        public override void giveRaise(double percentage)
        {
            this.MonthlySalary += (percentage / 100) * (this.MonthlySalary+this._da+this._hra+this._pf);
        }

        public override string ToString()
        {
            return $"----- Employee Details -----\nEmployee Name: {this.FirstName} {this.LastName}\n{this.getAllowances()}\nProvident Fund: {this._pf}\nMonthly Salary: {this.MonthlySalary}\nYearly Salary: {this.YearlySalary}\n\n";
        }

        public string JoiningDate
        {
            get
            {
                return this._joiningDate.ToString();
            }
            set
            {
                this._joiningDate = DateOnly.ParseExact(value,"dd/mm/yyyy");
            }
        }

        public string RetirementDate
        {
            get 
            { 
                return this._retirementDate.ToString(); 
            }
            set 
            { 
                this._retirementDate = DateOnly.ParseExact(value, "dd/mm/yyyy");
            }
        }

        public double HRA { get => this._hra; }

        public double DA { get => this._da; }

        public double PF { get => this._pf; }

    }

        public class EmployeeTest
    {
        public static void Main()
        {

            Console.WriteLine("Vedant Joshi                                      {0}\n\n", DateTime.Now);

            Employee employee1 = new Employee("Emp", "A", 10000);
            Employee employee2 = new Employee("Empl", "B", 15000);

            Console.WriteLine(employee1);
            Console.WriteLine(employee2);

            employee1.giveRaise(10);
            employee2.giveRaise(10);
            Console.WriteLine("\nAfter giving 10% raise\n");

            Console.WriteLine(employee1);
            Console.WriteLine(employee2);


            PermanentEmployee perEmp1 = new PermanentEmployee("PerEmp", "A", 17000, 3000, 2000, 5000);
            PermanentEmployee perEmp2 = new PermanentEmployee("PerEmpl", "B", 20000, 3500, 3000, 7000);

            Console.WriteLine(perEmp1);
            Console.WriteLine(perEmp2);

            perEmp1.giveRaise(10);
            perEmp2.giveRaise(10);
            Console.WriteLine("\nAfter giving 10% raise\n");

            Console.WriteLine(perEmp1);
            Console.WriteLine(perEmp2);

        }
    }
}