using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace directories
{
    class Program
    {
        static void Main(string[] args)
        {
            //Directory.CreateDirectory(@"D:\my programs\c#prgms\photos");
            //Console.WriteLine("directory created");

            //File.Copy(@"D:\my programs\c#prgms\product.txt", @"D:\my programs\c#prgms\photos\product.txt");
            //Console.WriteLine("file copied");

          string[] folders=  Directory.GetDirectories(@"D:\my programs");
            foreach(string folder in folders)
            {
                Console.WriteLine(folder);
            }

            IEnumerable<string> ien_Files = Directory.EnumerateFiles(@"D:\my programs\c#prgms");
            foreach (string file in ien_Files)
            {
                //Console.WriteLine(file);
            }
        }
    }
}
