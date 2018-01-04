// CppStdcallInerfaceWrapper.cpp : Defines the exported functions for the DLL application.
//

#include "stdafx.h"
//1.To call the CSharpAssembly.dll,  go to project properties -> Configuration Properties -> General and add Common Language Runtime Support. //https://stackoverflow.com/questions/4969325/intellisense-using-requires-c-cli-to-be-enabled 
//2.To enable the compiler to locate the CSharpAssembly.dll, go to project properties->C / C++->General->Resolve #using References and add "$(SolutionDir)\debug".
//3.To make the Hello function visible in the CppStdcallInerfaceWrapper.dll through the Stdcall calling convention, add a new Module Definition file called CppStdcallInerfaceWrapper.def in the project source files. This will automatically set the project properties -> Linker -> Input -> Module Definition file.

#ifdef _MANAGED
#pragma managed(push, off)
#endif

#ifdef _MANAGED
#pragma managed(pop)
#endif

#using "CSharpAssembly.dll"
using namespace CSharpAssembly;

__declspec(dllexport) char* __stdcall Hello(char* name)
{
	int i = 0;
	while (*name != '\0')
	{
		i++;
		name++;
	}
	array<unsigned char>^ nameManArr =
		gcnew array<unsigned char>(i);
	name -= i;
	i = 0;
	while (*name != '\0')
	{
		nameManArr[i] = *name;
		name++;
		i++;
	}
	array<unsigned char>^ char8ManArr =
		CSharpClass::Hello(nameManArr);
	char*  char8UnmanArr = new char[char8ManArr->Length + 1];
	for (int i = 0; i < char8ManArr->Length; i++)
	{
		char8UnmanArr[i] = char8ManArr[i];
	}
	char8UnmanArr[char8ManArr->Length] = '\0';
	return char8UnmanArr;
}
