using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AON_Exercises
{
    internal static class Exercise2Worker
    {
        public static void Exercise2()
        {

            Console.Out.WriteLine("Exercise2\n");
            DoExercise(new int [] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 21 });
            DoExercise(new int[] { 4, 14, 15, 16, 5, 6, 7, 8, 9, 10, 11, 12, 13, 1, 2, 3, 17, 18, 19, 21 });
            DoExercise(GenerateRandomIntArray());
            DoExercise(GenerateRandomIntArray());
            DoExercise(GenerateRandomIntArray());
            DoExercise(new int[0]);
            Console.Out.WriteLine("\n");
        }

        private static void DoExercise(int[] intArray)
        {
            int prevDiff = CalcDiff(1, intArray);
            int prevP = intArray.Length > 0 ? 1 : 0;
            for (int p = 2; p < intArray.Length; p++)
            {
                int diff = prevDiff + intArray[p-1] * 2;
                if (Math.Abs(diff) < Math.Abs(prevDiff))
                {
                    prevDiff = diff;
                    prevP = p;
                }
            }

            Console.Out.WriteLine($"Array [{string.Join(",", intArray)}]: Index {prevP}, Difference {prevDiff}");
        }

        private static int CalcDiff(int p, int [] values)
        {
            int op1 = 0, op2 = 0;
            for(int i = 0; i < values.Length; i++)
            {
                if (i < p)
                    op1 += values[i];
                else
                    op2 += values[i];
            }
            return op1 - op2;
        }

        private static int[] GenerateRandomIntArray()
        {
            int length = Program.rnd.Next(10, 20);
            int[] array = new int[length];
            for (int i = 0; i < length; i++)
                array[i] = Program.rnd.Next(-21, 21);
            
            return array;
        }

    }
}
