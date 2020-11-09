using System;
using System.IO;
using System.Reflection;

namespace FileHasher
{
    public class HashCalculator
    {
        public string FileName { get; private set; }

        public HashCalculator(string fileName)
        {
            this.FileName = fileName;
        }

        public string CalculateFileHash()
        {
            if (Path.GetExtension(this.FileName).Equals(".dll", System.StringComparison.InvariantCultureIgnoreCase)
                || Path.GetExtension(this.FileName).Equals(".exe", System.StringComparison.InvariantCultureIgnoreCase))
            {
                return GetAssemblyFileHash();
            }
            else
            {
                return GetFileHash();
            }
        }

        private string GetFileHash()
        {
            return CalculateHashFromStream(File.OpenRead(this.FileName));
        }

        private string GetAssemblyFileHash()
        {
            string tempFileName = null;
            try
            {
                //try to open the assembly to check if this is a .NET one
                //var assembly = Assembly.LoadFile(this.FileName);
                tempFileName = Disassembler.GetDisassembledFile(this.FileName);
                return CalculateHashFromStream(File.OpenRead(tempFileName));
            }
            catch (BadImageFormatException)
            {
                return GetFileHash();
            }
            finally
            {
                if (File.Exists(tempFileName))
                {
                    File.Delete(tempFileName);
                }
            }
        }

        private string CalculateHashFromStream(Stream stream)
        {
            using (var readerSource = new System.IO.BufferedStream(stream, 1200000))
            {
                using (var md51 = new System.Security.Cryptography.MD5CryptoServiceProvider())
                {
                    md51.ComputeHash(readerSource);
                    return Convert.ToBase64String(md51.Hash);
                }
            }
        }
    }
}
