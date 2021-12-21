// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections.Generic;
using System.Globalization;
using CsvHelper;
using HtmlAgilityPack;
using System.Numerics;

namespace Numbers
{
    class PieToN
    {
        public static void Main()
        {
            var pie1 = new PieToN();
            int n;
            int a;
            decimal x;
            int k = 5;
            //Console.WriteLine("Enter n");
            //n = Convert.ToInt32(Console.ReadLine());

            //x = (-1)^k(6k)!(13591409+545140134*k)  /   ((3k)!(k!)^3*640320^3k+3/2);

            decimal C = Convert.ToDecimal(426880*Math.Sqrt(10005));
            decimal Mq;
            decimal Lq;
            decimal Xq;



            //x = decimal.Divide(42698672,13591409);      //(42698672/13591409);

            //Console.WriteLine(ParallelPi(1000000000));
            //Console.WriteLine(SerialPi());
            Console.WriteLine(SpigotPi(70));
            Console.ReadLine();
            //Console.WriteLine(pie1.Factorial(k));
        }
        public int Factorial(int f)
        {
            if (f == 0)
                return 1;
            else
                return f * Factorial(f - 1);
        }
        public static string PiWebScrub()
        {
        
            HtmlWeb web = new HtmlWeb();

            HtmlDocument doc = web.Load("http://www.geom.uiuc.edu/~huberty/math5337/groupe/digits.html");
            HtmlNodeCollection piNode = doc.DocumentNode.SelectNodes("/html/body/br");
            
            return "0";
            
        }
        static double ParallelPi(int steps)
        {
            double sum = 0;
            double step = 1 / (double)steps;
            object obj = new object();

            Parallel.For(0,steps,
                    () => 0.0,
                    (i, state, partial) =>
                    {
                        double x = (i + 0.5) * step;
                        return partial + 4.0 / (1.0 + x * x);
                    },
                    partial => { lock (obj) sum += partial; });
             return step * sum;
        }
        static double SerialPi()
        {
            const int NUM_STEPS = 1000000000;
            double sum = 0;
            double step = 1 / (double)NUM_STEPS;
            for (int i = 0; i < NUM_STEPS; i++)
            {
                double x = (i + 0.5) * step;
                double partial = 4.0 / (1.0 + x * x);
                sum += partial;
            }
            return step * sum;
        }
        public static string SpigotPi(int digits)
        {
            digits++;
            
            uint[] x = new uint[digits*10/3+2];
            uint[] r = new uint[digits*10/3+2];
            uint[] pi = new uint[digits];
            for (int j = 0; j < x.Length; j++)
                x[j] = 20;
            for (int i = 0; i < digits; i++)
            {
                uint carry = 0;
                for (int j = 0; j < x.Length; j++)
                {
                    uint num = (uint)(x.Length - j - 1);
                    uint dem = num * 2 + 1;
                    x[j] += carry;
                    uint q = x[j] / dem;
                    r[j] = x[j] % dem;
                    carry = q * num;
                }
                    pi[i] = (x[x.Length - 1] / 10);
                    r[x.Length - 1] = x[x.Length - 1] % 10; ;
                    for (int j = 0; j < x.Length; j++)
                        x[j] = r[j] * 10;
                }
                var result = "";
                uint c = 0;
                for (int i = pi.Length - 1; i >= 0; i--)
                {
                    pi[i] += c;
                    c = pi[i] / 10;
                    result = (pi[i] % 10).ToString() + result;
                }
                return result;
            }
            
    }
}
