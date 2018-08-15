using InvitesUser.LIB.Modul;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SortHumans
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                try
                {
                    Thread.Sleep(1000);
                    WorkUser.SortHuman();
                    Console.Write("*");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
