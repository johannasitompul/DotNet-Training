using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseADOApplication
{
    class Program
    {
        void Options()
        {
            Console.WriteLine("\nWhat would you like to do?\n--");
            Console.WriteLine("1. Add employee");
            Console.WriteLine("2. Edit employee");
            Console.WriteLine("3. Delete employee");
            Console.WriteLine("4. Search employee");
            Console.WriteLine("5. Display employees");
            Console.WriteLine("0. Exit\n--");
        }

        void ManageMenu()
        {
            int choice = 0;

            ManageEmp me = new ManageEmp();

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
                            me.AddEmp();
                            break;
                        case 2:
                            me.UpdateEmp();
                            break;
                        case 3:
                            me.RemoveEmp();
                            break;
                        case 4:
                            me.PrintSingleEmpByID();
                            break;
                        case 5:
                            me.PrintEmps();
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
