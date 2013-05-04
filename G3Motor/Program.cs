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
            object[][] result = G3Database.Instance.Read("select * from isolasjon");

            foreach (object[] row in result)
            {
                foreach (object column in row)
                    Console.Write(column + " ");

                Console.WriteLine();
            }

            Console.WriteLine(G3Database.Instance.errMsg);

            Console.ReadKey();
        }
    }
}
