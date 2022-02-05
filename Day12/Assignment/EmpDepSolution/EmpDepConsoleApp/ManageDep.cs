using EmpDepDALEFLibrary;
using EmpDepModelsLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpDepConsoleApp
{
    class ManageDep
    {
        List<Department> deps;
        DepDAL depDAL;

        public ManageDep()
        {
            depDAL = new DepDAL();
        }

        public void AddDep()
        {
            Department department = new Department();
            department.GetDepDetails();
            depDAL.AddNewDep(department);
        }


        private int GetDepIdFromUser()
        {
            int id = 0;
            Console.Write("Enter department ID : ");
            if (!Int32.TryParse(Console.ReadLine(), out id))
            {
                Console.Write("Invalid input. Enter department ID number : ");
            }
            return id;
        }

        public void EditDepName()
        {
            int id = GetDepIdFromUser();
            Department department = GetDepById(id);
            if (department == null)
            {
                Console.WriteLine("Invalid Id. Unable to update.");
                return;
            }
            Console.Write("Enter the new department name : ");
            string name = Console.ReadLine();
            while (string.IsNullOrEmpty(name))
            {
                Console.Write("Input cannot be null. Enter new department name : ");
            }
            depDAL.EditDepName(name, id);
        }

        private Department GetDepById(int id)
        {
            deps = GetAllDeps();
            Department department = deps.SingleOrDefault(dp => dp.Id == id);
            return department;
        }

        public List<Department> GetAllDeps()
        {
            deps = null;
            try
            {
                deps = depDAL.GetAllDeps().ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return deps;
        }

        public void PrintAllDeps()
        {
            deps = GetAllDeps();
            foreach (var dep in deps)
            {
                Console.WriteLine(dep);
            }
        }

        public void RemoveDep()
        {
            deps = GetAllDeps();
            int id = GetDepIdFromUser();
            Department department = deps.SingleOrDefault(dp => dp.Id == id);
            if (department == null)
            {
                Console.WriteLine("Invalid department ID.");
                return;
            }
            depDAL.RemoveDepById(department.Id);
        }
    }
}
