using System;
using System.Linq;

namespace MarioProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            int t = Convert.ToInt32(Console.ReadLine());

            string[] problems = new string[t];

            for (int i = 0; i < t; i++)
            {
                int length = Convert.ToInt32(Console.ReadLine());

                problems[i] = Console.ReadLine();
            }

            for (int i = 0; i < t; i++)
            {
                int output =  MarioFunction(Array.ConvertAll(problems[i].Split(), s => int.Parse(s)));

                Console.WriteLine(output);
            }
        }

        private static int MarioFunction(int[] arr)
        {
            var len = arr.Length;

            if (len > 0)
            {
                int[] modified = new int[len];
                modified[0] = 1;

                for (int i = 1; i < len; i++)
                {
                    if(arr[i - 1] < arr[i])
                    {
                        modified[i] = modified[i-1] + 1;
                    }
                    else
                    {
                        modified[i] = 1;
                    }
                }

                return modified.Max();
            }

            return 0;

        }
    }
}
