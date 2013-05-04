using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace G3Motor
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Banana");
            Console.WriteLine("Split");

            G3Database.Instance.Query("INSERT INTO isolasjon (tykkelse) values('40');");

            Console.ReadKey();
        }
    }
}
