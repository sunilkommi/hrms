using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using hrms_entities_lib;
using System.Runtime.Serialization.Formatters.Binary;


namespace file_operations
{
    class Program
    {
        static void Main(string[] args)
        {
           // FileWriteTextMode();
             FileReadTextMode();
            //FileWriteBinaryCode();
            // FileReadBinaryCode();
            //BinarySerialize();
           
        }
        static void FileReadBinaryCode()
        {
            FileStream fs = null;
            try
            {
                fs = new FileStream(@"D:\my programs\c#prgms\employee.txt", FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                Employee emp = new Employee()
                {
                    Ecode = br.ReadInt32(),
                    Ename = br.ReadString(),
                    salary = br.ReadInt32(),
                    deptid = br.ReadInt32()

                };
                Console.WriteLine(emp.Ecode + "\t" + emp.Ename + "\t" + emp.salary + "\t" + emp.deptid);
                br.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                fs.Close();
            }

        }
        static void FileWriteBinaryCode()
        {
            FileStream fs = null;
            try
            {
                fs = new FileStream(@"D:\my programs\c#prgms\employee.txt", FileMode.Create, FileAccess.Write);
                BinaryWriter bw = new BinaryWriter(fs);
                Employee emp = new Employee()
                {
                    Ecode = 101,
                    Ename = "sunil",
                    salary = 1111,
                    deptid = 201
                };

                //write to file
                bw.Write(emp.Ecode);
                bw.Write(emp.Ename);
                bw.Write(emp.salary);
                bw.Write(emp.deptid);
                Console.WriteLine("record written into file");
                bw.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                fs.Close();
            }
        }

        static void FileReadTextMode()
        {
            FileStream fs1 = null,fs2=null;
            try
            {
                //create file stream
                fs1 = new FileStream(@"D:\my programs\c#prgms\product.txt", FileMode.Open, FileAccess.Read);
                fs2=new FileStream(@"D:\my programs\c#prgms\updated_product.txt", FileMode.Create, FileAccess.Write);
                StreamReader sr = new StreamReader(fs1);
                StreamWriter sw=new StreamWriter(fs2);
                string s = "";
                s = sr.ReadLine();
                while (s != null)
                {
                    string[] cols = s.Split(',');
                    double price = int.Parse(cols[2]);
                    price *= 0.1;
                    sw.WriteLine(cols[0] + "," + cols[1] + ","+string.Format( "{0:.00}")+ price);
                    s = sr.ReadLine();
                }
                sr.Close();
                sw.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                fs1.Close();
            }

        }
        static void FileWriteTextMode()
        {
            FileStream fs = null;
            try
            {
                //create file stream
                fs = new FileStream(@"D:\my programs\c#prgms\product.txt", FileMode.Append, FileAccess.Write);

                //create stream writer for the file
                StreamWriter sw = new StreamWriter(fs);
                Console.Write("enter the product id");
                int Pid = int.Parse(Console.ReadLine());
                Console.Write("enter the product name");
                string Pname = Console.ReadLine();
                Console.Write("enter the price");
                int Price = int.Parse(Console.ReadLine());

                string s = Pid + "\t" + Pname + "\t" + Price;
                sw.WriteLine(s);
                //Console.WriteLine("enter data,press enter to finish:");
                //s = Console.ReadLine();
                //while (s != "")
                //{
                //    //write the data to the file using stream writer
                //   sw.WriteLine(s);
                //    s = Console.ReadLine();
                //}
                sw.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            //close the file stream and writer
            finally
            {
                fs.Close();
            }
        }
        static void BinarySerialize()
        {
            Employee emp = new Employee()
            {
                Ecode = 101,
                Ename = "sunil",
                salary = 1111,
                deptid = 201
            };
            FileStream fs = new FileStream(@"D:\my programs\c#prgms\notes.txt", FileMode.Create, FileAccess.Read); ;
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, emp);
            Console.WriteLine("employee data serialize");
            fs.Close();
        }
    }
}

       