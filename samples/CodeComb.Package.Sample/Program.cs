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
            Console.WriteLine(OS.Current.ToString());
            var result = GitClone.Clone("https://github.com/aspnet/Home", @"C:\Pool\test");
            Console.WriteLine(result.Error);
            Console.WriteLine(result.Output);
            Download.DownloadAndExtractAll("https://github.com/CodeCombResources/Test/archive/master.zip","c:\\test\\package\\").Wait();
            Console.Read();
        }
    }
}
