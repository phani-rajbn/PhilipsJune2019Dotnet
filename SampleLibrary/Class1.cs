using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * Dlls are precompiled units that allow a code to be reused across multiple projects. 
 * Dlls are available only in the Windows OS.
 * Dlls provide layering and modular coding in ur Application. 
 * Dlls are created using a project type of Class LIbrary.
 * Classes in the DLLS are usually public as they are intended to be used/consumed in other projects.
 * Applications will add the reference of the DLL either thro project reference or location(by Browsing to the location of the DLL) and use the namespace in the code before creating objects of the class. 
 * DLLs can be C Style Win32 
 */
namespace SampleLibrary
{
    public class MathClass
    {
        public double AddFunc(double v1, double v2) => v1 + v2;

        public double SubFunc(double v1, double v2) => v1 - v2;

        public double MulFunc(double v1, double v2) => v1 * v2;

        public double DivFunc(double v1, double v2) => v1 / v2;

        public double Sqr(double v1) => MulFunc(v1, v1);

        public double Sqrt(double v1) => Math.Sqrt(v1);
    }
}//When U build this project, a dll would be created in the bin/Debug directory which is the executing directory of any project. 
