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
        //https://msdn.microsoft.com/en-us/library/kbaht4dh.aspx //mix debugging mode in c++ , for c# looking for enable native code debugging option

        //https://stackoverflow.com/questions/32991274/return-string-from-c-dll-export-function-called-from-c-sharp
        [DllImport("CppStdcallInerfaceWrapper.dll",
              CharSet = CharSet.Ansi, CallingConvention =
                 CallingConvention.StdCall)]
        public static extern IntPtr Hello(IntPtr name);

        static void Main(string[] args)
        {
            //ไม่สามารส่ง string ของ .net ที่เป็น managed code's memory (heap) ไปให้ unmanaged code ของ C++ ได้
            //ต้องอาศัย IntPtr (pointer) เข้ามา copy string to unmanaged memory ก่อน แล้วค่อยส่งเข้าไป (C++ รับเป็น char*)
            string passedString = "MyName";
            IntPtr sent = Marshal.StringToHGlobalAnsi(passedString);

            // C++ return char* 
            // .Net ต้องรับด้วย IntPtr คือรับเป็น pointer แล้วมา convert เป็น string ใน .net อีกที
            IntPtr intPtr = Hello(sent);
            string returnedString = System.Runtime.InteropServices.Marshal.PtrToStringAnsi(intPtr);
            System.Console.WriteLine(returnedString);
            //System.Console.WriteLine(Hello("MyName"));//test c++ export function module , error = The pointer passed in as a String must not be in the bottom 64K of the process's address space.
            //https://stackoverflow.com/questions/3563870/difference-between-managed-and-unmanaged
            //https://stackoverflow.com/questions/6514454/how-to-send-a-string-by-reference-to-an-unmanaged-c-library-that-modifies-that-s
            System.Console.ReadLine();
            Marshal.FreeHGlobal(sent);//free the copied unmanaged memory
            //Marshal.FreeHGlobal(intPtr);

        }
    }
}