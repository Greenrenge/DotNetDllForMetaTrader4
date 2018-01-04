using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpAssembly
{
    public class CSharpClass
    {
        //https://www.codeguru.com/csharp/.net/cpp_managed/windowsservices/article.php/c14735/Exporting-NET-DLLs-with-Visual-Studio-2005-to-be-Consumed-by-Native-Applications.htm
        public static byte[] Hello(byte[] name)//must be static
        {
            string s = ", hello from .NET!";
            byte[] helloPart = Encoding.ASCII.GetBytes(s);
            byte[] whole =
               new byte[name.Length + helloPart.Length];
            int i = 0;
            foreach (byte b in name)
            {
                whole[i++] = b;
            }
            foreach (byte b in helloPart)
            {
                whole[i++] = b;
            }
            return whole;
        }
    }
}