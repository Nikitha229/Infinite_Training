using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_2
{
    class Arrays_Questions
    {
        public static void Question_1_a()
        {
            Console.WriteLine("Enter number of elements into the array");
            int n = Convert.ToInt32(Console.ReadLine());
            int[] arr = new int[n];
            int total = 0;
            Console.WriteLine("Enter Elements");
            for (int i = 0; i < n; i++)
            {
                arr[i] = Convert.ToInt32(Console.ReadLine());

                total += arr[i];
            }
            Console.WriteLine("Average={0}", (float)total / n);

        }

        public static void Question_1_b()
        {
            Console.WriteLine("Enter number of elements into the array");
            int n = Convert.ToInt32(Console.ReadLine());
            int[] arr = new int[n];
            int Min = int.MaxValue, Max = int.MinValue;
            Console.WriteLine("Enter Elements");
            for (int i = 0; i < n; i++)
            {
                arr[i] = Convert.ToInt32(Console.ReadLine());
                if (Min > arr[i])
                    Min = arr[i];
                if (Max < arr[i])
                    Max = arr[i];
            }
            Console.WriteLine("MaxValue={0} MinValue={1}", Min, Max);
        }

        public static void Question_2()
        {
            int n = 10;
            int[] arr = new int[n];
            int Min = int.MaxValue, Max = int.MinValue, total = 0;
            Console.WriteLine("Enter Marks");
            for (int i = 0; i < n; i++)
            {
                arr[i] = Convert.ToInt32(Console.ReadLine());
                if (Min > arr[i])
                    Min = arr[i];
                if (Max < arr[i])
                    Max = arr[i];
                total += arr[i];
            }
            Console.WriteLine("Total={0} Average={1} MaxMarks={2} MinMarks={3}", total, (float)total / n, Max, Min);
            Array.Sort(arr);
            Console.WriteLine("Ascending Order");
            foreach (int i in arr)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
            Console.WriteLine("Descending Order");
            Array.Reverse(arr);
            foreach (int i in arr)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
        }

        public static void Question_3()
        {
            Console.WriteLine("Enter number of Elements:");
            int n = Convert.ToInt32(Console.ReadLine());
            int[] arr1 = new int[n];
            int[] arr2 = new int[n];
            for(int i=0;i<n;i++)
            {
                arr1[i] = Convert.ToInt32(Console.ReadLine());
            }
            for(int i=0;i<n;i++)
            {
                arr2[i] = arr1[i];
            }
            Console.Write("Array1 Elements: ");
            foreach (int i in arr1)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
            Console.Write("Array2 Elements: ");
            foreach (int i in arr2)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
        }
    }
}
