using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CeazarCode
{
    class Program
    {
        static void Main(string[] args)
        {
            CeazarCode ceazarCode = new CeazarCode(3);

            StringBuilder res = ceazarCode.EncodingUA(new StringBuilder("Лну"));
            Console.WriteLine(res);

            Console.WriteLine(ceazarCode.DecodingUA(res));
            
            Console.ReadKey();
            CharUA.bdfshvbsdf();
        }
    }
}
