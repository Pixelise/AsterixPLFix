using System;
using System.IO;
using System.Text;

namespace AsterixPLFix
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to AsterixPLFix. This program fixes Polish speech files from Asterix & Obelix XXL and Asterix & Obelix XXL2 for use with foobar2000 etc.");
            Console.WriteLine("Enter the directory ''...\\SPEECH\\1''");
            string Asterix = Console.ReadLine();
            DirectoryInfo di = new DirectoryInfo(Asterix);
            FileInfo[] fiArr = di.GetFiles();
            Console.WriteLine("The directory {0} contains the following files:", di.Name);
            foreach (FileInfo f in fiArr)
            {
                Console.WriteLine("File {0} was fixed", f.Name);
                string path = f.DirectoryName + "\\" + f.Name;
                double rozmiar = f.Length - 12;
                string decimalNumber = rozmiar.ToString();
                Int32 i32 = Int32.Parse(decimalNumber);
                byte[] bytes = ConvertInt32ToByteArray(i32);

                using (var stream = new FileStream(path, FileMode.Open, FileAccess.ReadWrite))
                {
                    for (int i = 0; i < 3; i++)
                    {
                        stream.Position = 4 + i;
                        stream.WriteByte(bytes[i]);
                    }

                }
                double rozmiar2 = f.Length - 2048;
                string decimalNumber2 = rozmiar2.ToString();
                i32 = Int32.Parse(decimalNumber2);
                byte[] bytes2 = ConvertInt32ToByteArray(i32);

                using (var stream = new FileStream(path, FileMode.Open, FileAccess.ReadWrite))
                {
                    for (int i = 0; i < 3; i++)
                    {
                        stream.Position = 2040 + i;
                        stream.WriteByte(bytes2[i]);
                    }

                }
            }
            Console.WriteLine("Press ENTER to exit");
            Console.ReadLine();
        }
        public static byte[] ConvertInt32ToByteArray(Int32 I32)
        {
            return BitConverter.GetBytes(I32);
        }
        public static byte[] ConvertIntToByteArray(Int16 I16)
        {
            return BitConverter.GetBytes(I16);
        }
        public static byte[] ConvertIntToByteArray(Int64 I64)
        {
            return BitConverter.GetBytes(I64);
        }
        public static byte[] ConvertIntToByteArray(int I)
        {
            return BitConverter.GetBytes(I);
        }
        public static double ConvertByteArrayToInt32(byte[] b)
        {
            return BitConverter.ToInt32(b, 0);
        }
    }
}
