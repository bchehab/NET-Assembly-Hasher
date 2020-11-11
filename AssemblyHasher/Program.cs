using System;
using System.IO;
using System.Reflection;

namespace AssemblyHasher
{
    class Program
    {
        static void Main(string[] args)
        {
            var fileToHash = args != null && args.Length > 0 ? args[0] : null;
            if (!string.IsNullOrEmpty(fileToHash))
            {
                var hash = new FileHasher.HashCalculator(fileToHash).CalculateFileHash();
                Console.Write(hash);
            }
        }
    }
}
