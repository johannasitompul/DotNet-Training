using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeModelsLibrary
{
    public class Employee
    {
        public int EmpId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public void GetEmpDetails()
        {
            Console.Write("Enter name of employee : ");
            Name = Console.ReadLine();

            Console.Write("Enter age of employee : ");
            int age;
            while (!int.TryParse(Console.ReadLine(), out age))
            {
                Console.Write("Invalid input for age. Re-enter age : ");
            }
            Age = age;
        }

        public override string ToString()
        {
            return "--\nEmployee ID : " + EmpId
                + "\nName        : " + Name
                + "\nAge         : " + Age;
        }
    }
}
