// NAME: Kenneth Boorom
//
// FILE: GraphBackplaneResultsForm.cs
//
// Date: June 29, 2017
//
// Narrative:   (Needs comments!)
//
//  

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

using System.Numerics;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Threading;


namespace EyeDiagramWithGraph
{

    public partial class GraphBackplaneResultsForm : Form
    {
        public GraphBackplaneResultsForm()
        {
            InitializeComponent();
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void graphEyeDiagram_Click(object sender, EventArgs e)
        {
            GraphTimeSeries.Enabled = false;
            graphEyeDiagram.Enabled = false;

            double[] signalAfterBackplane;

            //ConsoleTraceListener listener = new ConsoleTraceListener();
            //Debug.Listeners.Add(listener);

            int numberLevels = (int) numberLevelsNumeric.Value;
            BackplaneResponseAsRationalFunctionClass backPlane = new BackplaneResponseAsRationalFunctionClass(numberLevels, progressBar1);

            signalAfterBackplane = backPlane.CalculateResponse();
            double allOutputsSum = signalAfterBackplane.Sum();

            /* TEST CODE BELOW - Note that chart auto-scales 
            Random rdn = new Random();
            for (int i = 0; i < 50; i++)
            {
                eyeDiagram.Series["EyeDiagramData"].Points.AddXY
                                (rdn.Next(0, 20), rdn.Next(0, 20));
            }
            */

            eyeDiagram.Series["EyeDiagramData"].Points.Clear();

            // for (int cnt = 0; cnt <= 131072; cnt++)
            for (int cnt = 500; cnt <= 5000; cnt++)
            {
                eyeDiagram.Series["EyeDiagramData"].Points.AddXY((cnt+50) % 100, signalAfterBackplane[cnt]);

            }
            eyeDiagram.Series["EyeDiagramData"].ChartType = SeriesChartType.Point;
            eyeDiagram.Series["EyeDiagramData"].Color = Color.Red;

            GraphTimeSeries.Enabled = true;
            graphEyeDiagram.Enabled = true;

        }

        private void GraphTimeSeries_Click(object sender, EventArgs e)
        {
            GraphTimeSeries.Enabled = false;
            graphEyeDiagram.Enabled = false;

            double[] signalAfterBackplane;

            //ConsoleTraceListener listener = new ConsoleTraceListener();
            //Debug.Listeners.Add(listener);

            int numberLevels = (int)numberLevelsNumeric.Value;
            BackplaneResponseAsRationalFunctionClass backPlane = new BackplaneResponseAsRationalFunctionClass(numberLevels, progressBar1);

            signalAfterBackplane = backPlane.CalculateResponse();
            double allOutputsSum = signalAfterBackplane.Sum();

            /* TEST CODE BELOW - Note that chart auto-scales 
            Random rdn = new Random();
            for (int i = 0; i < 50; i++)
            {
                eyeDiagram.Series["EyeDiagramData"].Points.AddXY
                                (rdn.Next(0, 20), rdn.Next(0, 20));
            }
            */

            // for (int cnt = 0; cnt <= 131072; cnt++)
            eyeDiagram.Series["EyeDiagramData"].Points.Clear();

            for (int cnt = 0; cnt <= 5000; cnt++)
            {
                eyeDiagram.Series["EyeDiagramData"].Points.AddXY(cnt, signalAfterBackplane[cnt]);

            }
            eyeDiagram.Series["EyeDiagramData"].ChartType = SeriesChartType.FastLine;
            eyeDiagram.Series["EyeDiagramData"].Color = Color.Red;

            GraphTimeSeries.Enabled = true;
            graphEyeDiagram.Enabled = true;


        }
    }
}
