using System;
using System.IO;
using System.Reflection;

namespace AssemblyHasher
{
    class Program
    {
        static void Main(string[] args)
        {
            //var fileToHash1 = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "FileHasher.dll");
            //var fileToHash2 = Assembly.GetExecutingAssembly().Location;
            //var fileToHash3 = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"..\..\Program.cs");
            //var fileToHash4 = @"C:\Users\bchehab\Desktop\AssemblyHasher\ClassLibrary1\bin\Debug\ClassLibrary1.dll";

            //var hash1 = new FileHasher.HashCalculator(fileToHash1).CalculateFileHash();
            //var hash2 = new FileHasher.HashCalculator(fileToHash2).CalculateFileHash();
            //var hash3 = new FileHasher.HashCalculator(fileToHash3).CalculateFileHash();
            //var hash4 = new FileHasher.HashCalculator(fileToHash4).CalculateFileHash();

            var fileToHash = args != null && args.Length > 0 ? args[0] : null;
            if (!string.IsNullOrEmpty(fileToHash))
            {
                var hash = new FileHasher.HashCalculator(fileToHash).CalculateFileHash();
                Console.Write(hash);
            }
        }
    }
}
