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
            CeazarCode ceazarCode = new CeazarCode();
            StringBuilder textReadFile = HelperData.ReadFile(@"../../Text.txt");
            HelperData.WriteConsole(textReadFile);
            StringBuilder res = ceazarCode.EncodingUA(textReadFile, 3);
            Console.WriteLine(res);

            Console.WriteLine(ceazarCode.DecodingUA(res,3));
            HelperData.WriteFile(@"../../TextResult.txt", ceazarCode.DecodingUA(res, 3));
            Console.ReadKey();
        }
    }
}
