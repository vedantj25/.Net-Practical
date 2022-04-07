using System;
using System.Collections.Generic;
using System.Text;

namespace DelegateAndGenericMethods
{
    class BankAccount
    {
        public string accountNo = string.Empty, holderName = string.Empty;
        public double accountBalance;

        public BankAccount(string accountNo, string holderName, double accountBalance)
        {
            this.accountNo = accountNo;
            this.holderName = holderName;
            this.accountBalance = accountBalance;
        }
    }

    class TestClass
    {
        public delegate void del();
        
        public static void Main()
        {
            string acNo, holderName;
            double acBal;

            Console.WriteLine("Enter account number:");
            acNo = String.Empty + Console.ReadLine();

            Console.WriteLine("Enter holder name:");
            holderName = String.Empty + Console.ReadLine();

            Console.WriteLine("Enter account balance:");
            acBal = Convert.ToInt32("0" + Console.ReadLine());

            BankAccount account = new BankAccount(acNo, holderName, acBal);

            del del1;

            if (account.accountBalance <= 0)
            {
                del1 = accOverDrawn;
            }
            else if (account.accountBalance < 10)
            {
                del1 = lowAcc;
            }
            else if (account.accountBalance < 100)
            {
                del1 = carefulSpend;
            }
            else
            {
                del1 = over100;
            }

            del1();

        }

        public static void accOverDrawn()
        {
            Console.WriteLine("You are overdrawn");
        }

        public static void lowAcc()
        {
            Console.WriteLine("Your account is very low");
        }
        public static void carefulSpend()
        {
            Console.WriteLine("Watch your spending carefully");
        }
        public static void over100()
        {
            Console.WriteLine("You have over $100 in your account");
        }
        
    }
}