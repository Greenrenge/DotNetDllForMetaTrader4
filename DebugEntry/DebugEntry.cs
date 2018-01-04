using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace DebugEntry
{
    class DebugEntry
    {
        //https://stackoverflow.com/questions/9003072/unable-to-load-dll-module-could-not-be-found-hresult-0x8007007e
        //https://stackoverflow.com/questions/33743493/why-visual-studio-2015-cant-run-exe-file-ucrtbased-dll
        //https://msdn.microsoft.com/en-us/library/kbaht4dh.aspx //mix debugging mode in c++ , for c# looking for enable native code debugging

        //https://stackoverflow.com/questions/32991274/return-string-from-c-dll-export-function-called-from-c-sharp
        [DllImport("CppStdcallInerfaceWrapper.dll",
              CharSet = CharSet.Ansi, CallingConvention =
                 CallingConvention.StdCall)]
        public static extern string Hello(string name);

        static void Main(string[] args)
        {
            System.Console.WriteLine(Hello("MyName"));//test c++ export function module
            System.Console.ReadLine();
        }
    }
}