using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp12
{
    class Program
    {
        public static int pyramidrefs = 0;
        public static int pyramidcompares = 0;
        public static int countrefs = 0;
        public static int countcompares = 0;
        static int add2pyramid(int[] arr, int i, int N)
        {
            int imax;
            int buf;
            if ((2 * i + 2) < N)
            {
                if (arr[2 * i + 1] < arr[2 * i + 2])
                {
                    imax = 2 * i + 2;
                    pyramidcompares++;
                }
                else imax = 2 * i + 1;
            }
            else imax = 2 * i + 1;
            if (imax >= N) return i;
            if (arr[i] < arr[imax])
            {
                pyramidcompares++;
                pyramidrefs++;
                buf = arr[i];
                arr[i] = arr[imax];
                arr[imax] = buf;
                if (imax < N / 2) i = imax;
            }
            return i;
        }

        static void Pyramid_Sort(int[] arr, int len)
        {
            for (int i = len / 2 - 1; i >= 0; --i)
            {
                long prev_i = i;
                i = add2pyramid(arr, i, len);
                if (prev_i != i) ++i;
            }
            int buf;
            for (int k = len - 1; k > 0; --k)
            {
                pyramidrefs++;
                buf = arr[0];
                arr[0] = arr[k];
                arr[k] = buf;
                int i = 0, prev_i = -1;
                while (i != prev_i)
                {
                    prev_i = i;
                    i = add2pyramid(arr, i, k);
                }
            }
        }
        static void NumberSort(int[] arr)
        {
            int[] helparr = new int[1000];
            for(int i = 0; i < arr.Length; i++)
            {
                countcompares++;
                helparr[arr[i]]++;
            }
            int k = 0;
            for(int i = 0; i < helparr.Length; i++)
            {
                for(int j = 0; j < helparr[i]; j++)
                {
                    countrefs++;
                    arr[k] = i;
                    k++;
                }
            }
        }

        static void Main(string[] args)
        {
            int[] parr1 = new int[100];
            int[] carr1 = new int[100];
            int[] parr2 = new int[100];
            int[] carr2 = new int[100];
            int[] parr3 = new int[100];
            int[] carr3 = new int[100];
            Random rd = new Random();
            for (int i = 0; i < parr1.Length; ++i)
            {
                parr1[i] = i;
                carr1[i] = parr1[i];
                parr2[i] = 100-i;
                carr2[i] = parr2[i];
                parr3[i] = rd.Next(1, 1000);
                carr3[i] = parr3[i];
            }
            for (int i = 0; i < parr1.Length; ++i)
            {
                Console.Write(parr1[i] + " ");
            }
            Console.WriteLine();
            for (int i = 0; i < parr1.Length; ++i)
            {
                Console.Write(parr2[i] + " ");
            }
            Console.WriteLine();
            for (int i = 0; i < parr1.Length; ++i)
            {
                Console.Write(parr3[i] + " ");
            }
            Console.WriteLine();
            NumberSort(carr1);
            Pyramid_Sort(parr1,parr1.Length);
            Console.WriteLine("Количество сравнений в пирамидальной сортировке для упорядоченного по возрастанию массива");
            Console.WriteLine(pyramidcompares);
            Console.WriteLine("Количество пересылок в пирамидальной сортировке для упорядоченного по возрастанию массива");
            Console.WriteLine(pyramidrefs);
            Console.WriteLine("Количество сравнений в сортировке подсчётом для упорядоченного по возрастанию массива");
            Console.WriteLine(countcompares);
            Console.WriteLine("Количество пересылок в сортировке подсчётом для упорядоченного по возрастанию массива");
            Console.WriteLine(countrefs);
            pyramidrefs = 0;
            pyramidcompares = 0;
            countrefs = 0;
            countcompares = 0;
            Console.WriteLine();
            NumberSort(carr2);
            Pyramid_Sort(parr2, parr2.Length);
            Console.WriteLine("Количество сравнений в пирамидальной сортировке для упорядоченного по убыванию массива");
            Console.WriteLine(pyramidcompares);
            Console.WriteLine("Количество пересылок в пирамидальной сортировке для упорядоченного по убыванию массива");
            Console.WriteLine(pyramidrefs);
            Console.WriteLine("Количество сравнений в сортировке подсчётом для упорядоченного по убыванию массива");
            Console.WriteLine(countcompares);
            Console.WriteLine("Количество пересылок в сортировке подсчётом для упорядоченного по убыванию массива");
            Console.WriteLine(countrefs);
            pyramidrefs = 0;
            pyramidcompares = 0;
            countrefs = 0;
            countcompares = 0;
            Console.WriteLine();
            NumberSort(carr3);
            Pyramid_Sort(parr3, parr3.Length);
            Console.WriteLine("Количество сравнений в пирамидальной сортировке для неупорядоченного массива");
            Console.WriteLine(pyramidcompares);
            Console.WriteLine("Количество пересылок в пирамидальной сортировке для неупорядоченного массива");
            Console.WriteLine(pyramidrefs);
            Console.WriteLine("Количество сравнений в сортировке подсчётом для неупорядоченного массива");
            Console.WriteLine(countcompares);
            Console.WriteLine("Количество пересылок в сортировке подсчётом для неупорядоченного массива");
            Console.WriteLine(countrefs);
            pyramidrefs = 0;
            pyramidcompares = 0;
            countrefs = 0;
            countcompares = 0;
            Console.ReadLine();
            
        }
    }
}
