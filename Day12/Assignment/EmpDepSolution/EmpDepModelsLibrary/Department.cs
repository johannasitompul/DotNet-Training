using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpDepModelsLibrary
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Employee> Employees { get; set; }

        public void GetDepDetails()
        {
            Console.Write("Enter new department name : ");
            string name = Console.ReadLine();
            while (string.IsNullOrEmpty(name))
            {
                Console.Write("Input cannot be null. Enter department name : ");
            }
            Name = name;
        }

        public override string ToString()
        {
            return "--\nDepartment ID : " + Id 
                + "\nDepartment Name : " + Name;
        }
    }
}
