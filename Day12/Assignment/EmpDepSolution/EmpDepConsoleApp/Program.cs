using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpDepConsoleApp
{
    class Program
    {
        void Options()
        {
            Console.WriteLine("\nWhat would you like to do?\n--");
            Console.WriteLine("1. Add department");
            Console.WriteLine("2. Edit department name");
            Console.WriteLine("3. Print all departments");
            Console.WriteLine("4. Add employee");
            Console.WriteLine("5. Edit employee age");
            Console.WriteLine("6. Edit employee department");
            Console.WriteLine("7. Print all employees");
            Console.WriteLine("0. Exit\n--");
        }

        void ManageMenu()
        {
            int choice = 0;

            ManageEmp me = new ManageEmp();
            ManageDep md = new ManageDep();

            do
            {
                Options();
                Console.Write("Your choice : ");
                while (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.Write("Invalid input. Re-enter your choice : ");
                }

                try
                {
                    switch (choice)
                    {
                        case 1:
                            md.AddDep();
                            break;
                        case 2:
                            md.EditDepName();
                            break;
                        case 3:
                            md.PrintAllDeps();
                            break;
                        case 4:
                            me.AddEmp();
                            break;
                        case 5:
                            me.EditEmpAge();
                            break;
                        case 6:
                            me.EditEmpDep();
                            break;
                        case 7:
                            me.PrintAllEmps();
                            break;
                        case 0:
                            Console.WriteLine("Exiting application. Bye bye...");
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                }

                catch (Exception e)
                {
                    Console.WriteLine("Something went wrong.");
                    Console.WriteLine(e.Message);
                }
            } while (choice != 0);
        }

        static void Main(string[] args)
        {
            Program program = new Program();
            program.ManageMenu();
            Console.ReadKey();
        }
    }
}
