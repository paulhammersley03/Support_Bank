using System;

namespace Support_Bank
{
    class Program
    {
     static void Main(string[] args)
        {
            string[] CSVFileLoad = System.IO.File.ReadAllLines(@"C:\Work\Training\Support_Bank\Support_Bank\Support_Bank\Transactions2014.csv");
            int ArrayLength = CSVFileLoad.Length;

            
            string userInput;
            Console.Write("List All or List [Name] - ");
            userInput = Console.ReadLine();
            Console.WriteLine("You entered '{0}'", userInput);
            

            for (int i = 1; i < ArrayLength; i++)
            {
                string[] TransactionElement = CSVFileLoad[i].Split(',');
                //Console.WriteLine(TransactionElement[2]);
                //Array.ForEach(CSVFileLoad, Console.WriteLine);
                //Console.ReadLine();

                var dateObject = new GetDate();
                var returnValueDate = dateObject.Date(TransactionElement);

                var nameObject = new GetName();
                var returnValueName = nameObject.Name(TransactionElement);

                var owesObject = new GetOwesTo();
                var returnValueOwes = owesObject.Owes(TransactionElement);

                var reasonObject = new GetReason();
                var returnValueReason = reasonObject.Reason(TransactionElement);

                var amountObject = new GetAmount();
                var returnValueAmount = amountObject.Amount(TransactionElement);

                //if (Program.Main.userInput = "List All")
                    //{
                    //Console.WriteLine("test");
                    //}
                //else if (Program.Main.userInput = "List { }");
                    //{
                    //Console.WriteLine("test2");
                    //}
                

                Console.WriteLine(returnValueDate + " " + returnValueName + " " + returnValueOwes + " " + returnValueReason + " £" + returnValueAmount);               
            }
            Console.ReadLine();
            }
    }
}
