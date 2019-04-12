using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace delegates
{
    class Program
    {
        static void Main(string[] args)
        {
           India india = new India();
           india.SendMsg("lets have peaceful relationship");
        }
    }
    class India
    {
        //declare delegate
        delegate void MsgDelegate(string msg);
        public void SendMsg(string msg)
        {
            //bind the method china
            MsgDelegate msgdel= new MsgDelegate(china.MsgToChina);
            msgdel += new MsgDelegate(Pak.MsgToPak);
            //invoke china method
            msgdel(msg);
            msgdel += new MsgDelegate(delegate (string m){
                Console.WriteLine(m);
            });
            //bind to pak 
            //msgdel= new MsgDelegate(Pak.MsgToPak);
            //invoke pak method
            //msgdel(msg);
        }
    }
    class china
    {
        public static void MsgToChina(string msg)
        {
            Console.WriteLine("msg to china");
        }
    }
    class Pak
    {
        public static void MsgToPak(string msg)
        {
            Console.WriteLine("msg to pak");
        }
    }
}
