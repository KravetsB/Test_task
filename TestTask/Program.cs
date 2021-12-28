using System;
using BusinessLogicLayer;


namespace TestTask
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Choose department for report:");
            Console.WriteLine("1 -> Support");
            Console.WriteLine("2 -> Marketing");
            Console.WriteLine("3 -> Accounting");
            Console.WriteLine("4 -> Legal");
            Console.WriteLine("5 -> Engineering");
            Console.WriteLine("6 -> Services");
            Console.WriteLine("7 -> Human Resources");
            Console.WriteLine("8 -> Training");
            Console.Write("\r\nSelect an option: ");


            switch (Console.ReadLine())
            {
                case "1":
                    LogicServiceStarter("Support");
                    break;

                case "2":
                    LogicServiceStarter("Marketing");
                    break;

                case "3":
                    LogicServiceStarter("Accounting");
                    break;
                case "4":
                    LogicServiceStarter("Legal");
                    break;
                case "5":
                    LogicServiceStarter("Engineering");
                    break;
                case "6":
                    LogicServiceStarter("Services");
                    break;
                case "7":
                    LogicServiceStarter("Human Resources");
                    break;
                case "8":
                    LogicServiceStarter("Training");
                    break;

                default:
                    break;
            }
                    

        }
        
          static void LogicServiceStarter(string Department)
        {
            LogicService logic = new LogicService(Department);
            logic.SalarySum();
            logic.HighestPaidEmployee();
            logic.LowestPaidEmployee();
            logic.EmployeesByPosition();
        }

    }
}
