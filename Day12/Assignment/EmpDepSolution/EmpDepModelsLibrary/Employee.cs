using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpDepModelsLibrary
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int Department_Id { get; set; }

        [ForeignKey("Department_Id")]
        public Department Department { get; set; }

        public override string ToString()
        {
            return "--\nEmployee ID : " + Id
                + "\nName        : " + Name
                + "\nAge         : " + Age
                + "\nDepartment  : " + Department_Id;
        }
    }
}
