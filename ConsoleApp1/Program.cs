using Microsoft.CSharp;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

using ConsoleApp1;
using jAC;
using System.ComponentModel.Design;
namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
              Lib lib = new Lib();
              lib.Menu();
        }



    }
    public class Table : Tub
    {
        public void Run(int i)
        {
            switch (i)
            {
                case 1: Number1 number1 = new Number1();
                    number1.Start();
                    break;
                case 2: Number2 number2 = new Number2();    
                    number2.Start();
                    break;
            }
        }
    }
    
    public class Number1 : Numbers
    {
        public void Start()
        {
            Console.WriteLine("ex1");
            Stop();
        }
        public void Stop()
        {
            Lib lib = new Lib();
            lib.ToMenu();
        }
    }

    public class Number2 : Numbers
    {
        public void Start()
        {
            Console.WriteLine("ex2");
            Stop();
        }
        public void Stop()
        {
            Lib lib = new Lib();
            lib.ToMenu();
        }
    }   
}










namespace jAC
{
    public interface Tub
    {
        void Run(int i);
    }
    public interface Numbers
    {
        void Start();
        void Stop();
        // public void Stop()
        //{
        //    Lib lib = new Lib();
        //lib.ToMenu();
        //}
}
    
   
    public class Lib
    {
        public void Menu()
        {
            try
            {
                Console.Clear();

                int num;

                Console.WriteLine("если хотите остановить программу введите stop");
                Console.Write("введите номер задания: ");
                String j = Convert.ToString(Console.ReadLine());



                if (j == "stop")
                {

                    Break();
                }
                else
                {
                    num = Convert.ToInt32(j);
                    Run(num);
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("введите число или stop");
                Menu();
            }

        }
        
        private void Run(int num)
        {
            Console.Clear();
            Table table = new Table();
            table.Run(num);

        }
        public void ToMenu()
        {

            ConsoleKeyInfo i = Console.ReadKey(true);
            Menu();
        }
        private void Break()
        {
            Environment.Exit(0);
        }

    }
    public class DI
    {
        public String build(int num)
        {
            String exis = "ConsoleApp1.Number" + num;
            return exis;
        }
    }

}





