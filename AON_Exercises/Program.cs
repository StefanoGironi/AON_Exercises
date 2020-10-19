using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AON_Exercises
{
    class Program
    {
        internal static Random rnd = new Random(Environment.TickCount);

        static void Main(string[] args)
        {
            Exercise1Worker.Exercise1();
            Exercise2Worker.Exercise2();
            Exercise3Worker.Exercise3();
            Console.Out.Write("Press <ENTER> to end the program");
            Console.In.ReadLine();
        }

    }
}
