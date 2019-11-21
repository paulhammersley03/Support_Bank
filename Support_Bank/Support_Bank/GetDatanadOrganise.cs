using System;
using System.Collections.Generic;
using System.Linq;

namespace Support_Bank
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] CSVFileLoad = System.IO.File.ReadAllLines(@"C:\Work\Training\Support_Bank\Support_Bank\Support_Bank\Transactions2014.csv");
            int ArrayLength = CSVFileLoad.Length;

            List<Employee> EmployeeList = new List<Employee>();//Create a new list to store employee who owes money

            for (int i = 1; i < ArrayLength; i++)//For loop to loop through array
            {
                string[] TransactionElement = CSVFileLoad[i].Split(',');

                Employee newEmployee = new Employee();
                newEmployee.Name = TransactionElement[1];

                if (EmployeeList.Exists(employee => employee.Name == newEmployee.Name))
                {
                    //Console.WriteLine("Not Added to List");
                }
                else
                {
                    EmployeeList.Add(newEmployee);
                    //Console.WriteLine(EmployeeTemp +  " Added To List");
                }                
            }
            foreach (var employee in EmployeeList)
            {
                Console.WriteLine($"Employee with name {employee.Name}");
            }
            Console.ReadLine();
        }
    }
}
    
        
    

