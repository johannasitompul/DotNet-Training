using EmpDepModelsLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpDepDALEFLibrary
{
    public class DepDAL
    {
        readonly EmpDepContext _empDepContext;

        public DepDAL()
        {
            _empDepContext = new EmpDepContext();
        }

        public bool AddNewDep(Department department)
        {
            _empDepContext.Departments.Add(department);
            _empDepContext.SaveChanges();
            return true;
        }

        public ICollection<Department> GetAllDeps()
        {
            List<Department> departments = _empDepContext.Departments.ToList();
            if (departments.Count == 0)
            {
                Console.WriteLine("No departments found.");
            }
            return departments;
        }

        public void RemoveDepById(int id)
        {
            _empDepContext.Departments.Remove(_empDepContext.Departments.Single(d => d.Id == id));
            _empDepContext.SaveChanges();
        }

        public bool EditDepName(string name, int id)
        {
            Department department = _empDepContext.Departments.SingleOrDefault(dp => dp.Id == id);
            if (department == null)
                return false;
            department.Name = name;
            _empDepContext.SaveChanges();
            return true;
        }
    }
}
