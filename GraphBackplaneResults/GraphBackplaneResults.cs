// -------------------------------------------------------------------------------------------------
// Name of Program: GraphBackplaneResults
//
// Author: Ken Boorom
//
// Release Date: June 29, 2017
//
// https://github.com/kenboorom/GraphBackplaneResults
// 
// NOTES: Needs comments (sorry!)
//
// PURPOSE: Performs a time-domain simulation of the following backplane when stimulated with either a PAM2 or PAM4 signal:
//
//  Manufacturer: Kaparel
//  Name: Full Mesh ATCA Backplane
//  Length: 20.5" (520.7mm)
//  Trace Width: 0.00475" (0.12065mm)
//  Material - 4000-13SI
//
//
// METHODOLOGY:
//
// The performance of the backplane was measured with an S-parameter Test Set from a major test equipment manufacturer.
//
// The s-parameters were then fitted to rational functions with Matlab, and poles/zeroes exported to GraphBackplaneResults source code.
//
// Credits and for additional information:  S parameters and rational function fitting were performed by the Matlab example which can be invoked 
// with the following command:
//
//   edit rational_differential
//       
// -------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EyeDiagramWithGraph
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new GraphBackplaneResultsForm());
        }
    }
}
