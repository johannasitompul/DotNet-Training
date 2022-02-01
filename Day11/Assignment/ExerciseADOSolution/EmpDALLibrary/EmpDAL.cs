using EmployeeModelsLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpDALLibrary
{
    public class EmpDAL
    {
        SqlConnection conn;

        public EmpDAL()
        {
            conn = MyConnection.GetConnection();
        }

        public ICollection<Employee> GetAllEmp()
        {
            List<Employee> emps = new List<Employee>();
            DataSet ds = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter("proc_GetAllEmp", conn);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.Fill(ds);
            Employee emp;
            if (ds.Tables[0].Rows.Count == 0)
                throw new NoEmpException();
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                emp = new Employee();
                emp.EmpId = Convert.ToInt32(item[0]);
                emp.Name = item[1].ToString();
                emp.Age = Convert.ToInt32(item[2]);
                emps.Add(emp);
            }
            return emps;
        }
        public bool InsertNewEmp(Employee emp)
        {
            conn.Close();
            SqlCommand cmd = new SqlCommand("proc_AddEmp", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@name", emp.Name);
            cmd.Parameters.AddWithValue("@age", emp.Age);
            conn.Open();
            if (cmd.ExecuteNonQuery() > 0)
                return true;
            return false;
        }
        public bool UpdateEmp(int id, int age)
        {
            conn.Close();
            SqlCommand cmd = new SqlCommand("proc_UpdateEmp", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@age", age);
            conn.Open();
            if (cmd.ExecuteNonQuery() > 0)
                return true;
            return false;
        }

        public bool RemoveEmp(int id)
        {
            conn.Close();
            SqlCommand cmd = new SqlCommand("proc_RemoveEmp", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);
            conn.Open();
            if (cmd.ExecuteNonQuery() > 0)
                return true;
            return false;
        }
    }
}
