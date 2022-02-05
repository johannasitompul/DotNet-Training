using EmpDepModelsLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpDepDALEFLibrary
{
    public class EmpDAL
    {
        readonly EmpDepContext _empDepContext;

        public EmpDAL()
        {
            _empDepContext = new EmpDepContext();
        }
        public bool AddNewEmp(Employee employee)
        {
            _empDepContext.Employees.Add(employee);
            _empDepContext.SaveChanges();
            return true;
        }

        public ICollection<Employee> GetAllEmps()
        {
            List<Employee> employees = _empDepContext.Employees.ToList();
            if (employees.Count == 0)
                throw new NoEmpException();
            return employees;
        }

        public bool EditEmpAge(int id, int age)
        {
            Employee employee = _empDepContext.Employees.SingleOrDefault(ep => ep.Id == id);
            if (employee == null)
                return false;
            employee.Age = age;
            _empDepContext.SaveChanges();
            return true;
        }

        public void EditEmpDep(int id, int deptId)
        {
            Employee employee = _empDepContext.Employees.SingleOrDefault(ep => ep.Id == id);
            employee.Department_Id = deptId;
            _empDepContext.SaveChanges();
        }
    }
}
