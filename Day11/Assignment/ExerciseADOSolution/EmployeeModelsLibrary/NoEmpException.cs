using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeModelsLibrary
{
    public class NoEmpException : Exception
    {
        string message;

        public NoEmpException()
        {
            message = "No employee found.";
        }

        public override string Message => message;
    }
}
