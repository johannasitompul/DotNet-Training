using EmpDepDALEFLibrary;
using EmpDepModelsLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpDepConsoleApp
{
    class ManageEmp
    {
        List<Employee> emps;
        EmpDAL empDAL;

        public ManageEmp()
        {
            empDAL = new EmpDAL();
        }

        public void AddEmp()
        {
            Employee emp = new Employee();
            emp = GetEmpDetails();

            try
            {
                empDAL.AddNewEmp(emp);
                Console.WriteLine("Employee inserted.");
            }
            catch (Exception e)
            {
                Console.WriteLine("Could not add employee.");
                Console.WriteLine(e.StackTrace);
                Console.WriteLine(e.Message);
            }
        }

        public Employee GetEmpDetails()
        {
            Employee emp = new Employee();
            Console.Write("Enter name of employee : ");
            emp.Name = Console.ReadLine();

            Console.Write("Enter age of employee : ");
            int age;
            while (!int.TryParse(Console.ReadLine(), out age))
            {
                Console.Write("Invalid input for age. Re-enter age : ");
            }
            emp.Age = age;

            ManageDep md = new ManageDep();
            md.PrintAllDeps();
            Console.Write("Enter department ID : ");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.Write("Invalid input. Enter department ID number : ");
            }
            emp.Department_Id = id;
            return emp;
        }

        public void EditEmpAge()
        {
            int id = GetEmpIdFromUser();
            Employee emp = GetEmpById(id);
            if (emp == null)
            {
                Console.WriteLine("Invalid Id. Unable to update.");
                return;
            }
            Console.WriteLine("Employee to be updated :");
            Console.WriteLine(emp);

            int age;
            Console.Write("\nEnter new age : ");
            while (!int.TryParse(Console.ReadLine(), out age))
            {
                Console.Write("Invalid input for age. Re-enter age : ");
            }
            emp.Age = age;
            if (empDAL.EditEmpAge(id, age))
                Console.WriteLine("Updated details :");
            Console.WriteLine(emp);
        }

        internal void PrintAllEmps()
        {
            emps = null;
            try
            {
                emps = empDAL.GetAllEmps().ToList();
            }
            catch (NoEmpException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Something went wrong.");
                Console.WriteLine(e.Message);
            }

        }

        public Employee GetEmpById(int id)
        {
            GetAllEmps();
            Employee emp = emps.SingleOrDefault(e => e.Id == id);
            return emp;
        }

        public List<Employee> GetAllEmps()
        {
            emps = null;
            try
            {
                emps = empDAL.GetAllEmps().ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return emps;
        }

        int GetEmpIdFromUser()
        {
            Console.Write("Enter employee ID : ");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.Write("Invalid input for ID. Re-enter ID : ");
            }
            return id;
        }

        public void EditEmpDep()
        {
            int id = GetEmpIdFromUser();
            Employee emp = GetEmpById(id);
            if (emp == null)
            {
                Console.WriteLine("Invalid Id. Unable to update.");
                return;
            }
            Console.WriteLine("Employee to be updated :");
            Console.WriteLine(emp);
           
            ManageDep md = new ManageDep();
            md.PrintAllDeps();
            Console.Write("Enter new department ID : ");
            int did;
            while (!Int32.TryParse(Console.ReadLine(), out did))
            {
                Console.WriteLine("Invalid input. Enter department ID number : ");
            }
            empDAL.EditEmpDep(id, did);
        }
    }
}
