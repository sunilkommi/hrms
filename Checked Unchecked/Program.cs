using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checked_Unchecked
{
    class Program
    {
        static void Main(string[] args)
        {
            if (SearchNumber(5, 10, 4, 3, 6, 9, 11))
            {
                Console.WriteLine("found");
            }
            else
            {
                Console.WriteLine("not found");
            }
            Console.WriteLine(Add(10, 20));
            Console.WriteLine(Add(10, 20, 30, 40, 50));

            checked //will not allow overflow
            {
               // int x = 2147483647 + 100;
            }
            unchecked //will allow overflow
            {
                int x = 2147483647 + 100;
                Console.WriteLine(x);
            }
        }
        static int Add(int a,int b)
        {
            return a + b;
        }
        static int Add(params int[] num) //variable argument
        {
            int sum = 0;
            for(int i=0;i<num.Length;i++)
            {
                sum += num[1];
            }
            return sum;
        }

       static bool SearchNumber(int n, params int[] numbers)
        {
            bool found = false;
            for(int i = 0; i < numbers.Length; i++)
            {
                if(n==numbers[i])
                {
                    found = true;
                    break;
                }
                
            }
            return found;
        }
    }
}
