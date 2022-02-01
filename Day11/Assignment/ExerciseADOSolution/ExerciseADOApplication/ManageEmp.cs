using EmpDALLibrary;
using EmployeeModelsLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseADOApplication
{
    class ManageEmp
    {
        List<Employee> emps;
        EmpDAL empDAL;

        public Employee this[int index]
        {
            get { return emps[index]; }
            set { emps[index] = value; }
        }
        public ManageEmp()
        {
            empDAL = new EmpDAL();

        }
        void GetAllEmps()
        {
            emps = null;
            try
            {
                emps = empDAL.GetAllEmp().ToList();
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
        
        public void AddEmp()
        {
            Employee emp = new Employee();
            emp.GetEmpDetails();

            try
            {
                empDAL.InsertNewEmp(emp);
                Console.WriteLine("Employee inserted.");
            }
            catch (Exception e)
            {
                Console.WriteLine("Could not add employee.");
                Console.WriteLine(e.Message);
            }
        }

        //private int GenerateId()
        //{
        //    //if(pizzas[0]==null)
        //    //    return 101;
        //    //else
        //    //{
        //    //    for (int i = 0; i < pizzas.Length; i++)
        //    //    {
        //    //        if (pizzas[i] == null)
        //    //            return 101 + i;
        //    //    }
        //    //}
        //    if(pizzas.Count == 0)
        //        return 101;
        //    return pizzas.Count+101;
        //}

        public Employee GetEmpById(int id)
        {
            GetAllEmps();
            Employee emp = emps.SingleOrDefault(e => e.EmpId == id);
            return emp;
        }
        public void UpdateEmp()
        {
            int id = GetIdFromUser();
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
            if (empDAL.UpdateEmp(id, age))
                Console.WriteLine("Updated details :");
            Console.WriteLine(emp);
        }
        public void RemoveEmp()
        {
            int id = GetIdFromUser();
            Employee emp = GetEmpById(id);
            if (emp == null)
            {
                Console.WriteLine("Invalid Id. Unable to remove.");
                return;
            }
            Console.WriteLine("Employee to be removed :");
            Console.WriteLine(emp);
            Console.Write("\nRemove employee? (Y/n) ");
            string check = Console.ReadLine();
            if (check == "Y" || check == "y")
            {
                if(empDAL.RemoveEmp(id))
                    Console.WriteLine("Employee deleted.");
            }
            else
            {
                Console.WriteLine("Deletion cancelled.");
                return;
            }
        }

        int GetIdFromUser()
        {
            Console.Write("Enter employee ID : ");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.Write("Invalid input for ID. Re-enter ID : ");
            }
            return id;
        }

        public void PrintEmps()
        {
            GetAllEmps();
            var sortedEmps = emps.OrderBy(e => e.EmpId);
            foreach (var item in sortedEmps)
            {
                if (item != null)
                    Console.WriteLine(item);
            }
        }
        public void PrintSingleEmpByID()
        {
            int id = GetIdFromUser();
            Employee emp = GetEmpById(id);
            if (emp != null)
            {
                Console.WriteLine(emp);
            }
            else
                Console.WriteLine("No such employee.");
        }
    }
}
