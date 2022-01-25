using System;


namespace Pract1
{
    class Program
    {
        public static void Main(String[] args)
        {
            NumberOperations numberOperations = new NumberOperations();
            BranchesAndLoops branchesAndLoops = new BranchesAndLoops();

            numberOperations.arithmeticOperations();
            Console.WriteLine("\n");
            numberOperations.orderOfOperations();
            Console.WriteLine("\n");
            numberOperations.precisionsAndLimits();
            Console.WriteLine("\n");
            numberOperations.doubleType();
            Console.WriteLine("\n");
            numberOperations.decimalType();
            Console.WriteLine("\n");
            numberOperations.area();
            Console.WriteLine("\n");
            branchesAndLoops.ifCondition();
            Console.WriteLine("\n");
            branchesAndLoops.ifElseCondition();
            Console.WriteLine("\n");
            branchesAndLoops.whileDoWhileloops();
            Console.WriteLine("\n");
            branchesAndLoops.forLoop();
            Console.WriteLine("\n");
            branchesAndLoops.nestedLoops();
            Console.WriteLine("\n");
            branchesAndLoops.additionOfNums();

        }
    }
}