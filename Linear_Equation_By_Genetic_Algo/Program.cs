using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linear_Equation_By_Genetic_Algo
{
    class Program
    {
        static int x1, y1, x2, y2, count, m, c, ycalc, error, minerror,start,end;
        static List<class1> list = new List<class1>();


        static void Main(string[] args)
        {
            Console.WriteLine("Enter x1:");
            x1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter y1:");
            y1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter x2:");
            x2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter y2:");
            y2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter No of Chromosomes");
            count = Convert.ToInt32(Console.ReadLine());
            Random rnd = new Random();
            bool found = false;
            start = 0;
            end = 10;
            while (true)
            {
                minerror = count;
                for (int i = 0; i < count; i++)//Create Random Population
                {
                    
                    m = rnd.Next(start, end);
                    c = rnd.Next(start, end);
                    ycalc = (m * x1) + c;
                    error = ycalc - y1;
                    list.Add(new class1() { m = m, c = c, error = error });
                    if (error == 0)//Fittness Test
                    {

                        ycalc = (m * x2) + c;
                        error = ycalc - y2;
                        list.Add(new class1() { m = m, c = c, error = error });
                        if (error == 0)
                        {
                            Console.WriteLine("y = " + m + "x + " + c);//goal found
                            found = true;
                            break;
                        }
                        if (minerror > error)
                        {
                            minerror = error;
                        }

                    }
                    if (minerror > error)
                    {
                        minerror = error;

                    }
                }
                if (!found)//mutation when goal not found
                {
                    class1 obj = list.Find(p => p.error == minerror);
                    start = obj.m;
                    start = obj.c;
                }
                else
                {
                    break;
                }
            }
        }
    }
}