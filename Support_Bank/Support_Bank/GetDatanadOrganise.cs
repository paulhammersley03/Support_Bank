using System;

namespace Support_Bank
{
    class Program
    {
     static void Main(string[] args)
        {
            string[] CSVFileLoad = System.IO.File.ReadAllLines(@"C:\Work\Training\Support_Bank\Support_Bank\Support_Bank\Transactions2014.csv");
            int ArrayLength = CSVFileLoad.Length;
            for (int i = 1; i < ArrayLength; i++)
            {
                string[] TransactionElement = CSVFileLoad[i].Split(',');

                Employee newEmployee = new Employee();
                newEmployee.NameFrom = TransactionElement[1];
                newEmployee.NameTo = TransactionElement[2];
                newEmployee.Balance = TransactionElement[4];

                Console.WriteLine($"{newEmployee.NameFrom} owes {newEmployee.NameTo}, {newEmployee.Balance}");
            }
            Console.ReadLine();
            }
    }
}
