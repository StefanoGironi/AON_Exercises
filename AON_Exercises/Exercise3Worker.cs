using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace AON_Exercises
{
    internal static class Exercise3Worker
    {
        public static void Exercise3()
        {

            Console.Out.WriteLine("Exercise3\n");

            DoExercise(new int[] { 2,1,6,9,4,3 });

            DoExercise(GenerateRandomIntArray());
            DoExercise(GenerateRandomIntArray());
            DoExercise(GenerateRandomIntArray());
            DoExercise(GenerateRandomIntArray());
            DoExercise(new int [0]);
            Console.Out.WriteLine("\n");
        }

        private static void DoExercise(int[] intArray)
        {
            HashSet<int> values = new HashSet<int>(intArray);

            int bestLength = 0;
            int bestStart = 0;
            // Can't use foreach as we're modifying it in-place
            while (values.Count > 0)
            {
                int value = values.First();
                values.Remove(value);
                int start = value;
                while (values.Remove(start - 1))
                    start--;
                
                int end = value;
                while (values.Remove(end + 1))
                    end++;

                int length = end - start + 1;
                if (length > bestLength)
                {
                    bestLength = length;
                    bestStart = start;
                }
            }
            Console.Out.WriteLine($"Array [{string.Join(",", intArray)}]\n\t Sorted Array [{string.Join(",", intArray.OrderBy(i => i).ToArray())}]: Start number {bestStart}, Length {bestLength}");
        }

        private static int [] GenerateRandomIntArray()
        {
            int[] data = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };
            int length = Program.rnd.Next(10, 20);
            int[] array = new int[length];
            for (int i= 0; i < length; i++)
            {
                int idx = Program.rnd.Next(0, 19-i);
                array[i] = data[idx];

                (data[idx], data[19 - i]) = (data[19 - i], data[idx]);
            }
            return array;
        }
    }
}
