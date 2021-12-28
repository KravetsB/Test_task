using DataAccessLayer.Serializers.Entities;
using DataAccessLayer.Serializers.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLogicLayer
{
    public class LogicService
    {

        public string Department { get; set; }
        List<Employee> employees { get; set; }

        public LogicService(string department)  //initialization of initial values in the constructor
        {
            Department = department; 
           
            JSONSerializerService<List<Employee>> service = new JSONSerializerService<List<Employee>>();

            employees = service.Read();     //read .json file
        }



        public void SalarySum()     //method of calculating the sum of salary in the department
        {
            double salary = 0;
            foreach (Employee emp in employees) 
            {                
                if (emp.department.Equals(Department))      //compare the selected department with the list from the file to select the required
                    salary += emp.salary;
            }

            Console.WriteLine("\n--------------------- Salary sum ---------------------");
            Console.WriteLine($"Salary sum in {Department} department is {Math.Round(salary,2)}\n"); //output result with rounded values to 0,00
        }


        public void HighestPaidEmployee()    // method finde who got max salary in the department
        {
            List<Employee> employersFromDep = new List<Employee>();    //list for temporary storage of objects of choosen department
            foreach (Employee emp in employees)
            {
                if (emp.department.Equals(Department))       //finde objects with choosen department
                    employersFromDep.Add(emp);       // add objects to temporary list
            }
            double MaxSalary = employersFromDep.Max(e => e.salary);     //using linq for finde max salary on the department

            int index = employersFromDep.FindIndex(e => e.salary == MaxSalary);      //finde and keep list inex of the objec with biggest salary


            Console.WriteLine("--------------------- Employee with max salary ---------------------");
            Console.WriteLine($"Max salary in {Department} department got: Name -> {employersFromDep[index].first_name}, " +  //select data from the list by index of the object
             $"Last Name -> {employersFromDep[index].last_name}, Salary -> {employersFromDep[index].salary}\n");

        }



        public void LowestPaidEmployee()        // method finde who got min salary in the department
        {
            List<Employee> employersFromDep = new List<Employee>();      //list for temporary storage of objects of choosen department
            foreach (Employee emp in employees)
            {
                if (emp.department.Equals(Department))      //finde objects with choosen department
                    employersFromDep.Add(emp);      // add objects to temporary list
            }

            double MaxSalary = employersFromDep.Min(e => e.salary);      //using linq for finde min salary on the department

            int index = employersFromDep.FindIndex(e => e.salary == MaxSalary);         //finde and keep list inex of the objec with lowest salary

            Console.WriteLine("--------------------- Employee with min salary ---------------------");
            Console.WriteLine($"Min salary in {Department} department got: Name -> {employersFromDep[index].first_name}, " +    //select data from the list by index of the object
             $"Last Name -> {employersFromDep[index].last_name}, Salary -> {employersFromDep[index].salary}\n");
        }


        public void EmployeesByPosition()       // method for group objeccts by positions
        {
            var employeeGroups = from Employee emp in employees   //goroup objects
                                 group emp by emp.position;

            foreach (IGrouping<string, Employee> g in employeeGroups)   //walk through the all objects 
            {
                Console.WriteLine(g.Key);
                foreach (var t in g)
                    Console.WriteLine($"     Name-> { t.first_name}, Last Name -> {t.last_name}, Salary -> {t.salary}");
                Console.WriteLine();
            }

        }


    }
}
