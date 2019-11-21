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
            decimal BalanceOwedFrom;
            decimal BalanceOwedTo;
            List<Employee> EmployeeList = new List<Employee>();
            List<Transaction> TransactionList = new List<Transaction>();
            for (int i = 1; i < ArrayLength; i++)
            {
                string[] TransactionElement = CSVFileLoad[i].Split(',');
                Transaction newTransaction = new Transaction();
                newTransaction.Date = TransactionElement[0];//Date
                newTransaction.NameFrom = TransactionElement[1];//[name] of person owes
                newTransaction.NameTo = TransactionElement[2];//[name] of person owed
                newTransaction.Reason = TransactionElement[3];//Reason
                TransactionList.Add(newTransaction);

                BalanceOwedFrom = decimal.Parse(TransactionElement[4]);
                BalanceOwedTo = decimal.Parse(TransactionElement[4]);

                if (EmployeeList.Exists(employee => employee.Name == newTransaction.NameFrom))
                {
                    //var existingEmployee = the one from the employeeList
                    var existingEmployee = EmployeeList.Find(e => e.Name == newTransaction.NameFrom);
                    existingEmployee.BalanceOwedFrom = existingEmployee.BalanceOwedFrom + BalanceOwedFrom;                    
                }
                else
                {
                    Employee newEmployee = new Employee();
                    newEmployee.Name = newTransaction.NameFrom;//Name
                    newEmployee.BalanceOwedFrom = decimal.Parse(TransactionElement[4]);
                    EmployeeList.Add(newEmployee);
                }
                if (EmployeeList.Exists(employee => employee.Name == newTransaction.NameTo))
                {
                    //var existingEmployee = the one from the employeeList
                    var existingEmployee = EmployeeList.Find(e => e.Name == newTransaction.NameTo);
                    existingEmployee.BalanceOwedTo = existingEmployee.BalanceOwedTo + BalanceOwedTo;
                }
                else
                {
                    Employee newEmployee = new Employee();
                    newEmployee.Name = newTransaction.NameTo;//Name
                    newEmployee.BalanceOwedTo = decimal.Parse(TransactionElement[4]);
                    EmployeeList.Add(newEmployee);
                }    
            }
            foreach (var employee in EmployeeList)
            {
                Console.WriteLine($" {employee.Name} has a balance of £{employee.GetBalanceTotal()}");
            }
            Console.ReadLine();
        }
    }
}
    
        
    

