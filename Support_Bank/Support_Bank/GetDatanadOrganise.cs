using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Support_Bank
{
    class Program
    {
        static void Main(string[] args)
        {

            while (true)
            {
                Console.WriteLine("List All - Returns a list of each person, the amout they are owed and the amout they owe.");
                Console.WriteLine("List [Name] - Returns a list of every transaction for [Name] with date and reason.");

                string userInstruction = Console.ReadLine();//Converts user input to string               
                {
                    string[] CSVFileLoad = System.IO.File.ReadAllLines(@"C:\Work\Training\Support_Bank\Support_Bank\Support_Bank\Transactions2014.csv");
                    //string[] varName = file.readallalines("@"c:\blabla);
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

                        //If name is in EmployeeList[1], add to BalanceOwedFrom
                        if (EmployeeList.Exists(employee => employee.Name == newTransaction.NameFrom))
                        {
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

                        //If name is in EmployeeList[2], add to BalanceOwedTo
                        bool employeeNameAlreadyExists = EmployeeList.Exists(employee => employee.Name == newTransaction.NameTo);
                        if (employeeNameAlreadyExists)
                        {                            
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
                    Regex CheckUserInput = new Regex(@"List\s\b(?<firstname>)");
                    
                    string userNameInput2 = "";

                    if (userInstruction == "List All")
                    {
                        foreach (var employee in EmployeeList)
                        {
                            Console.WriteLine($" {employee.Name} has a balance of £{employee.GetBalanceTotal()}");
                        }
                    }
                    else if (CheckUserInput.IsMatch(userInstruction))
                    {
                        string[] ListName = userInstruction.Split(' ');//Creates array from user input.split string
                        int userNameInputLength = ListName.Length;//Returns ListName array length
                        string userInstruction2 = ListName[0];//String to hold array item[1](Should Always be List)**
                        string userNameInput = ListName[1];//string to hold array item[2](Will be employees first name)**

                        if (userNameInputLength == 3)
                        {
                            userNameInput2 = " " + ListName[2];//String to hold array item[3](will be employees second initial)**
                        }                                     

                        var existingEmployee = EmployeeList.Find(e => e.Name == userNameInput + " " + userNameInput2);
                        var employeeName = userNameInput + userNameInput2;
                        var employeeTransactions = TransactionList.FindAll(e => e.NameFrom == employeeName || e.NameTo == employeeName);

                        foreach (var existingTransaction in employeeTransactions)
                        {
                            Console.WriteLine($" {existingTransaction.Date} \t| {existingTransaction.NameFrom} \t| {existingTransaction.NameTo} \t| {existingTransaction.Reason}");
                            // \t inputs a tab space
                        }
                        }
                        else
                        {
                            Console.WriteLine("Invalid Input!!!");
                        }
                    }                   
                Console.WriteLine("");
            }         
        }
    }
}
    

    
        
    

