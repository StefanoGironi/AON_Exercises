using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AON_Exercises
{
    internal static class Exercise1Worker
    {
        private interface IExcercise1
        {
            int Value(int level);
        }

        private class IntNumber : IExcercise1
        {
            private int value;

            public IntNumber(int value)
            {
                this.value = value;
            }

            public int Value(int level)
            {
                return value;
            }

            public override string ToString()
            {
                return value.ToString() + ",";
            }
        }

        private class IntNumberList : List<IExcercise1>, IExcercise1
        {
            public int Value(int level)
            {
                return level * this.Sum(e => e.Value(level + 1));
            }

            public override string ToString()
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("[");
                this.ForEach(e =>
                {
                    if (sb[sb.Length - 1] == ']')
                        sb.Append(",");
                    sb.Append(e.ToString());
                }
                );
                if (sb[sb.Length - 1] == ',')
                    sb.Length--;
                sb.Append("]");
                return sb.ToString();
            }
        }

        public static void Exercise1()
        {

            Console.Out.WriteLine("Exercise1\n");
            IntNumberList arrayOfInt = new IntNumberList()
            {
                new IntNumber(1),
                new IntNumber(2),
                new IntNumberList()
                {
                    new IntNumber(3),
                    new IntNumberList()
                    {
                        new IntNumber(4)
                    }
                }
            };
            Console.Out.WriteLine($"Array {arrayOfInt.ToString()}: {arrayOfInt.Value(1)}");

            arrayOfInt = new IntNumberList()
            {
                new IntNumberList()
                {
                    new IntNumberList()
                    {
                        new IntNumber(2)
                    }
                }
            };
            Console.Out.WriteLine($"Array {arrayOfInt.ToString()}: {arrayOfInt.Value(1)}");

            arrayOfInt = new IntNumberList();
            Console.Out.WriteLine($"Array {arrayOfInt.ToString()}: {arrayOfInt.Value(1)}");


            arrayOfInt = new IntNumberList()
            {
                new IntNumber(1),
                new IntNumber(2),
                new IntNumberList()
                {
                    new IntNumber(3),
                    new IntNumberList()
                    {
                        new IntNumber(4)
                    }
                },
                new IntNumber(10)
            };
            Console.Out.WriteLine($"Array {arrayOfInt.ToString()}: {arrayOfInt.Value(1)}\n\n");
        }
    }
}
