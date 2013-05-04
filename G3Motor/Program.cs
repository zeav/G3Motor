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
            List<string[]> result = new List<string[]>();
            result = G3Database.Instance.Read("select * from isolasjon");

            foreach (string[] s in result)
            {
                foreach (string st in s)
                {
                    Console.Write(s + " ");
                }

                Console.WriteLine();
            }

            Console.WriteLine(G3Database.Instance.errMsg);

            Console.ReadKey();
        }
    }
}
