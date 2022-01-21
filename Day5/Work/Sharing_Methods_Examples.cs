using System;
class Program
    {
        // two int params
        void FindProduct(int num1, int num2)
        {
            Console.WriteLine(num1 * num2);
        }
        
        // one int, one double
        void FindProduct(int num1, double num2)
        {
            Console.WriteLine(num1 * num2);
        }

        // two int, one double
        void FindProduct(int num1, int num2, double num3)
        {
            Console.WriteLine(num1 * num2 * num3);
        }
        
        // by ref
        static void ModifyValue(ref int i)
        {
          i = 30;
          Console.WriteLine("In ModifyValue, parameter value = {0}", i);
          return;
        }
        
        // optional params
        public void AddTwoByDefault(int required, int optionalInt = 2)
        {
            var msg = $"{required} + {optionalInt} = {required + optionalInt}";
            Console.WriteLine(msg);
        }
        
        
        // MAIN
        static void Main(string[] args)
        {
            int a = 2;
            int b = 3;
            double c = 1.5;

            Program p = new Program();
    
            // all using same method name
            p.FindProduct(a, b);
            p.FindProduct(a, c);
            p.FindProduct(a, b, c);
            
            // passing parameters by reference
            int value = 20;
            Console.WriteLine("In Main, value = {0}", value);
            ModifyValue(ref value);
            Console.WriteLine("Back in Main, value = {0}", value);
            
            // optional param
            p.AddTwoByDefault(10);
            p.AddTwoByDefault(10, 4);

            Console.ReadKey();
        }
    }
