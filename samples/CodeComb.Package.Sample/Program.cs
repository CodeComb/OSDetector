using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeComb.Package.Sample
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            Download.DownloadAndExtractAll("https://github.com/CodeCombResources/Test/archive/master.zip","c:\\test\\package\\").Wait();
            Console.Read();
        }
    }
}
