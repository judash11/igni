using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace library
{

    internal class Program
    {
        static void Main(string[] args)
        {

          //  StopStart stopStart = new StopStart();
           // stopStart.start();

        }
    }

    
    public class Methods : StopStart
    {
        //[Controller("задание1")]

        
      //  public void zadanie1()
      //  {
       //     Console.WriteLine("zadanie1");
       //     stop();
       // }
       // public void zadanie2()
       // {
       //     Console.WriteLine("zadanie2");
       //     stop();
       // }
       // public void zadanie3()
       // {
        //    Console.WriteLine("zadanie3");
         //   stop();
       // }
    }



    public class Core
    {

        protected void Start()
        {
            MethodInfo[] methods = getMethods();
            menu(methods);
            

        }

        protected void stop()
        {
            Console.WriteLine("нажмите любую клавишу...");
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            Console.Clear();
            MethodInfo[] methods = getMethods();
            menu(methods);
        }
        private MethodInfo[] getMethods()
        {
            Type type = typeof(Methods);
            MethodInfo[] methods = type.GetMethods(BindingFlags.DeclaredOnly
            | BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);

            return methods;
        }
        

        private void menu(MethodInfo[] methods)
        {

            Console.WriteLine("введите номер задания");
            int index = 1;
            foreach (MethodInfo method in methods)
            {
                Console.WriteLine(index+" "+method.Name);
                index++;
            }




           
            
            
               
                Console.Write("введите номер или слово stop: ");

                try
                {
                    string stop = Convert.ToString(Console.ReadLine());
                    if (stop == "stop") { 
                        Environment.Exit(0); 
                    }
                    else
                    {
                    int index_num = Convert.ToInt32(stop);
                    Console.WriteLine(index_num);
                        Methods zadanie = new Methods();
                        MethodInfo method = methods[index_num - 1];
                        Console.Clear();
                        method.Invoke(zadanie, new object[0]);
                    }
                    
                }
                catch (FormatException)
                {
                Console.Clear();
                Console.WriteLine("неверный формат");
                menu(methods);
            }
                catch (ArgumentException)
                {
                Console.Clear();
                Console.WriteLine("невеный аргумент");
                menu(methods);
            }
                catch (IndexOutOfRangeException)
                {
                    Console.Clear();
                    Console.WriteLine("не существующее задание");
                    menu(methods);
                    
                }
                
           

            




        }

    }



    


    public class StopStart : Core
    {
        protected void Stop()
        {
            stop();
        }

        public void start()
        {
            Start();
        }
    }


//public interface Num
//{
 //   void Run();
  //  void Stop();
//}

//[AttributeUsage(AttributeTargets.Method | AttributeTargets.Method, AllowMultiple = false)]
//public class Controller : Attribute
//{
   // public string Name { get; }
    //public Controller(string name)
   // {
       // Name = name;
    //}
//}
    


}