// NAME: Kenneth Boorom
//
// FILE: BackplaneResponseAsRationalFunctionClass.cs
//
// Date: June 29, 2017
//
// Narrative:   (Needs comments!)
//
//  
// For comments, see GraphBackplaneResults.cs

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Numerics;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Threading;

using System.Windows.Forms;

namespace EyeDiagramWithGraph
{
    public class BackplaneResponseAsRationalFunctionClass
    {

        const int numberPoles = 31;
        const int samplesPerSymbol = 100;
        const int numberSamples = 131072;       // = 2^17

        // Poles taken from Matlab output
        private Complex[] poles =
            ComplexImport.InitializeComplexFromMatlabText(numberPoles,
                @"   -6.450250642504456e+09 + 5.377378232990338e+10i
                     -6.450250642504456e+09 - 5.377378232990338e+10i
                     -6.959935757270790e+09 + 3.613795332508782e+10i
                     -6.959935757270790e+09 - 3.613795332508782e+10i
                     -2.062356832178175e+08 + 2.508099488675428e+10i
                     -2.062356832178175e+08 - 2.508099488675428e+10i
                     -1.026692512330065e+10 + 1.239842929015708e+10i
                     -1.026692512330065e+10 - 1.239842929015708e+10i
                     -6.089498597243603e+09 + 0.000000000000000e+00i
                     -1.465774362462587e+08 + 2.141920471214960e+10i
                     -1.465774362462587e+08 - 2.141920471214960e+10i
                     -3.059587074304113e+08 + 1.971814172978049e+10i
                     -3.059587074304113e+08 - 1.971814172978049e+10i
                     -2.231210087066259e+08 + 1.765178021279712e+10i
                     -2.231210087066259e+08 - 1.765178021279712e+10i
                     -5.354527761361928e+08 + 1.580168706995403e+10i
                     -5.354527761361928e+08 - 1.580168706995403e+10i
                     -1.201741432097837e+09 + 1.489203153195216e+10i
                     -1.201741432097837e+09 - 1.489203153195216e+10i
                     -2.356529779305534e+08 + 1.332414424017283e+10i
                     -2.356529779305534e+08 - 1.332414424017283e+10i
                     -1.846164805825747e+09 + 0.000000000000000e+00i
                     -2.626297113727901e+08 + 8.404238820153362e+09i
                     -2.626297113727901e+08 - 8.404238820153362e+09i
                     -2.497859747312386e+08 + 6.490445697067395e+09i
                     -2.497859747312386e+08 - 6.490445697067395e+09i
                     -2.470180164217020e+08 + 4.574185935937586e+09i
                     -2.470180164217020e+08 - 4.574185935937586e+09i
                     -2.877078351549583e+08 + 2.583293302588099e+09i
                     -2.877078351549583e+08 - 2.583293302588099e+09i
                     -4.061322248807115e+08 + 0.000000000000000e+00i");


        // c Values taken from measured s-parameters of xxx backplane, converted into rational function by Matlab
        private Complex[] cValues =
            ComplexImport.InitializeComplexFromMatlabText(numberPoles,
                   @"-4.455502595414160e+07 - 7.565016003022024e+07i
                 -4.455502595414160e+07 + 7.565016003022024e+07i
                  1.921320171264636e+08 - 3.854329715151367e+08i
                  1.921320171264636e+08 + 3.854329715151367e+08i
                 -7.200967619539230e+05 - 3.167177302366053e+06i
                 -7.200967619539230e+05 + 3.167177302366053e+06i
                 -3.670147897624634e+09 + 3.400048386911525e+09i
                 -3.670147897624634e+09 - 3.400048386911525e+09i
                  6.569791264298219e+09 + 0.000000000000000e+00i
                 -1.082290106157433e+06 - 1.652401325115942e+06i
                 -1.082290106157433e+06 + 1.652401325115942e+06i
                 -4.566551458070952e+06 - 2.413498468597611e+06i
                 -4.566551458070952e+06 + 2.413498468597611e+06i
                 -1.580836245232334e+06 - 2.974017510899099e+06i
                 -1.580836245232334e+06 + 2.974017510899099e+06i
                 -2.983285797310383e+06 - 1.539862871644747e+07i
                 -2.983285797310383e+06 + 1.539862871644747e+07i
                 -3.267426277204034e+07 + 1.268597762606852e+07i
                 -3.267426277204034e+07 - 1.268597762606852e+07i
                  9.577423889948270e+02 + 2.133934057958581e+06i
                  9.577423889948270e+02 - 2.133934057958581e+06i
                  5.986689550081549e+08 + 0.000000000000000e+00i
                  1.921962589026159e+06 + 3.420113846791518e+06i
                  1.921962589026159e+06 - 3.420113846791518e+06i
                  4.755688476251583e+05 + 4.319563532817612e+06i
                  4.755688476251583e+05 - 4.319563532817612e+06i
                 -1.735959237371929e+06 + 4.315759164108888e+06i
                 -1.735959237371929e+06 - 4.315759164108888e+06i
                 -1.561481911306579e+06 - 1.046629461397913e+05i
                 -1.561481911306579e+06 + 1.046629461397913e+05i
                  4.438308947804702e+07 + 0.000000000000000e+00i");


        // c Values taken from measured s-parameters of xxx backplane, converted into rational function by Matlab
        private Complex[] fValues =
            ComplexImport.InitializeComplexFromMatlabText(numberPoles,
               @"     9.334754867700276e-01 + 2.572105752111637e-01i
                      9.334754867700276e-01 - 2.572105752111637e-01i
                      9.500756324783869e-01 + 1.735619308524515e-01i
                      9.500756324783869e-01 - 1.735619308524515e-01i
                      9.911245424261387e-01 + 1.249476280888444e-01i
                      9.911245424261387e-01 - 1.249476280888444e-01i
                      9.481359586359706e-01 + 5.885239295502513e-02i
                      9.481359586359706e-01 - 5.885239295502513e-02i
                      9.700113631300924e-01 + 0.000000000000000e+00i
                      9.935422787626921e-01 + 1.068131062704359e-01i
                      9.935422787626921e-01 - 1.068131062704359e-01i
                      9.936226707073830e-01 + 9.828060311527441e-02i
                      9.936226707073830e-01 - 9.828060311527441e-02i
                      9.949970676501013e-01 + 8.804608213668803e-02i
                      9.949970676501013e-01 - 8.804608213668803e-02i
                      9.942151143115193e-01 + 7.871523768989562e-02i
                      9.942151143115193e-01 - 7.871523768989562e-02i
                      9.912550315188584e-01 + 7.394571591606845e-02i
                      9.912550315188584e-01 - 7.394571591606845e-02i
                      9.966067016548755e-01 + 6.649305883932077e-02i
                      9.966067016548755e-01 - 6.649305883932077e-02i
                      9.908116492387780e-01 + 0.000000000000000e+00i
                      9.978061112117358e-01 + 4.195370086073166e-02i
                      9.978061112117358e-01 - 4.195370086073166e-02i
                      9.982259795447752e-01 + 3.240603447442087e-02i
                      9.982259795447752e-01 - 3.240603447442087e-02i
                      9.985044668274636e-01 + 2.284070808602938e-02i
                      9.985044668274636e-01 - 2.284070808602938e-02i
                      9.984791985433655e-01 + 1.289754039400871e-02i
                      9.984791985433655e-01 - 1.289754039400871e-02i
                      9.979713992730053e-01 + 0.000000000000000e+00i");


        private Complex[] gValues =
         ComplexImport.InitializeComplexFromMatlabText(numberPoles,
                @"      4.861639774223470e-12 + 6.539565682198027e-13i
                  4.861639774223470e-12 - 6.539565682198027e-13i
                  4.887537365688439e-12 + 4.401860089325467e-13i
                  4.887537365688439e-12 - 4.401860089325467e-13i
                  4.984338023729810e-12 + 3.128866797980678e-13i
                  4.984338023729810e-12 - 3.128866797980678e-13i
                  4.870750447953469e-12 + 1.497295485712748e-13i
                  4.870750447953469e-12 - 1.497295485712748e-13i
                  4.924647964198873e-12 + 0.000000000000000e+00i
                  4.988620992931690e-12 + 2.673536220750293e-13i
                  4.988620992931690e-12 - 2.673536220750293e-13i
                  4.988090577820393e-12 + 2.460262033492998e-13i
                  4.988090577820393e-12 - 2.460262033492998e-13i
                  4.990728617272207e-12 + 2.203401526499952e-13i
                  4.990728617272207e-12 - 2.203401526499952e-13i
                  4.988122919183264e-12 + 1.970663898044456e-13i
                  4.988122919183264e-12 - 1.970663898044456e-13i
                  4.980410057163791e-12 + 1.853208113808857e-13i
                  4.980410057163791e-12 - 1.853208113808857e-13i
                  4.993360980742387e-12 + 1.663594989798422e-13i
                  4.993360980742387e-12 - 1.663594989798422e-13i
                  4.976993783126695e-12 + 0.000000000000000e+00i
                  4.995248659356002e-12 + 1.049456225003052e-13i
                  4.995248659356002e-12 - 1.049456225003052e-13i
                  4.996002219973916e-12 + 8.105593906854162e-14i
                  4.996002219973916e-12 - 8.105593906854162e-14i
                  4.996478061058829e-12 + 5.712777671454705e-14i
                  4.996478061058829e-12 - 5.712777671454705e-14i
                  4.996266497751719e-12 + 3.225976648705927e-14i
                  4.996266497751719e-12 - 3.225976648705927e-14i
                  4.994926781765645e-12 + 0.000000000000000e+00i");

        const int inputSignalLength = 393300;
        double[] inputSignalArray = new double[inputSignalLength];

        ProgressBar myProgressBar;

        public BackplaneResponseAsRationalFunctionClass(int numberLevels, ProgressBar passedReportMyProgress)
        {
            // Constructor operations:

            int numberSymbols = (int)Math.Ceiling((double)numberSamples / (double)samplesPerSymbol);
            int lastPercentageProgress = 0;
            double[] inputSymbolArray = new double[numberSymbols];
            myProgressBar = passedReportMyProgress;

            // Load up input signals with same sequence from Matlab
            System.UInt64 seed = 512606243;
            int sampleValue;

            // Park-Miller Random Number Generator - used to verify comparison with Matlab results
            for (int symbolArrayIndex = 0; symbolArrayIndex < numberSymbols; symbolArrayIndex++)
            {
                seed = (seed * 16807) % 2147483647;
                int justSomeBits = (int) (seed & 0xFFFF);               // Apparently must convert to int to use modululs function
                sampleValue = (justSomeBits % numberLevels);
                // sampleValue = (int)(seed & 3);
                // sampleValue = (int)(seed & 1);
                inputSymbolArray[symbolArrayIndex] = sampleValue;
            }

            //Debug.WriteLine("");

            double checkSum = inputSymbolArray.Sum();
            Trace.WriteLine($"C#: Input Symbols: Number elements={numberSymbols}, Final Random  seed ={seed}, Sum of symbols = {checkSum}");

            // Duplicate inputSumbols into inputSignal, with each element repeated samplesPerSymbol times
            int signalArrayIndex = 0;


            // Simulation was setup for 2 Ghz, 393300 samples.  
            //
            // For simplicity, we will scale samplesPerSymbol accordingly (more samplesPerSymbol at lower frequencies)
            //
            // To keep simulation same length, we will also scale numberSymbols (fewer symbols at lower frequencies)


            int totalIterations = numberSymbols * samplesPerSymbol;
            int currentIteration = 0;

            for (int symbolArrayIndex = 0; symbolArrayIndex < numberSymbols; symbolArrayIndex++)
                for (int cnt = 1; cnt <= samplesPerSymbol; cnt++)
                {
                    inputSignalArray[signalArrayIndex++] = inputSymbolArray[symbolArrayIndex];

                    // Computations to update progress bar - integer+double arithmetic is tricky!
                    currentIteration++;
                    double currentPercentageProgress = ((double) currentIteration / (double)totalIterations) * 100.0;
                    int intCurrentPercentageProgress = (int)currentPercentageProgress;

                    if (lastPercentageProgress != intCurrentPercentageProgress)
                    {
                        myProgressBar.Value = intCurrentPercentageProgress;
                        lastPercentageProgress = intCurrentPercentageProgress;
                    }

                }

            double signalSum = inputSignalArray.Sum();

            Trace.WriteLine($"C#: Input Signal: Number elements={inputSignalArray.Length}, Sum of signals = {signalSum}");

        }

        const int padding = 1310;

        public static string sumComplexArray(Complex[] targetArray)
        {
            double realSum = 0;
            double imaginarySum = 0;

            for (int targetArrayIndex = 0; targetArrayIndex < targetArray.Length; targetArrayIndex++)
            {
                realSum += targetArray[targetArrayIndex].Real;
                imaginarySum += targetArray[targetArrayIndex].Imaginary;
            }

            return $"{realSum:E}+{imaginarySum:E}i";
        }


        public double[] CalculateResponse()
        {
            Complex[] systemState = new Complex[numberPoles];                         // Was X in Matlab
            double[] outputSignal = new double[inputSignalLength + padding];        // Was Y in Matlab

            int lastPercentageProgress = 0;

            for (int sampleNumber = 0; sampleNumber < inputSignalLength; sampleNumber++)
            {
                // IMPLEMENT THE FOLLOWING MATLAB EQUATION (d=0)
                // MATLAB: y(k) = sum(c.*x) + d*u(k);           
                Complex matrixSum = 0;

                // Computations to update progress bar - integer+double arithmetic is tricky!
                double currentPercentageProgress = ((double) sampleNumber / (double) inputSignalLength) * 100.0;
                int intCurrentPercentageProgress = (int)currentPercentageProgress;

                if (lastPercentageProgress != intCurrentPercentageProgress)
                {
                    myProgressBar.Value = intCurrentPercentageProgress;
                    lastPercentageProgress = intCurrentPercentageProgress;
                }
                
                // Calculate temporary matrix for debugging
                Complex[] tempMatrix = new Complex[numberPoles];
                for (int poleNumber = 0; poleNumber < numberPoles; poleNumber++)
                {
                    tempMatrix[poleNumber] = cValues[poleNumber] * systemState[poleNumber];
                    matrixSum += tempMatrix[poleNumber];
                }

                double currentOutputResult = matrixSum.Real;
                outputSignal[sampleNumber] = currentOutputResult;

                // IMPLEMENTS THE FOLLOWING MATLAB EQUATION:
                // x = f.*x + g*u(k);

                Complex prevState = systemState[0];

                for (int poleNumber = 0; poleNumber < numberPoles; poleNumber++)
                {
                    systemState[poleNumber] = systemState[poleNumber] * fValues[poleNumber] +
                        gValues[poleNumber] * inputSignalArray[sampleNumber];
                }

                Complex newState = systemState[0];

                if (sampleNumber < 133)
                {
                    /*
                    Debug.Write($"Sample#={sampleNumber}, 1st 5 real are ");
                    for (int dbgCnt = 0; dbgCnt < 5; dbgCnt++)
                    {
                        double d = systemState[dbgCnt].Real * 1E10;
                        string r = string.Format("{0:#.###E+00}", d);
                        Debug.Write(r + "  ");
                    }
                    Debug.WriteLine("");
                    */

                    // Sum eleemnts in fValues, gValues, and systemState
                    /*
                    string fValuesSum = sumComplexArray(fValues);
                    string gValuesSum = sumComplexArray(gValues);
                    string cValuesSum = sumComplexArray(cValues);
                    string stateValuesSum = sumComplexArray(systemState);

                    Debug.WriteLine($"Sample# = {sampleNumber},  fsum={fValuesSum}, csum={cValuesSum}, gsum={gValuesSum}, state={stateValuesSum}, out={matrixSum.Real:E}");
                    */

                    Debug.Write($"Sample# {sampleNumber}, Pole 0 f={fValues[0].Real:0.##E+00} {fValues[0].Imaginary:0.##E+00}i, ");
                    Debug.Write($"g={gValues[0].Real:0.##E+00} {gValues[0].Imaginary:0.##E+00}i, ");
                    Debug.Write($"u(k)={inputSignalArray[sampleNumber]}, ");
                    Debug.Write($"PrevX={prevState.Real:0.##E+00} {prevState.Imaginary:0.##E+00}i, ");
                    Debug.Write($"NewX={newState.Real:0.##E+00} {newState.Imaginary:0.##E+00}i, ");
                    Complex pole0Contrib = tempMatrix[0];
                    Debug.Write($"Pole 0 cont={pole0Contrib.Real:0.##E+00}  {pole0Contrib.Imaginary:0.##E+00}, result={currentOutputResult:0.##E+00}");
                    Debug.WriteLine("");
                    if (sampleNumber == 101)
                    {
                        int j = 0;                  // Breakpoint location for debugging
                    }

                }

            }
            myProgressBar.Value = 0;
            return outputSignal;
        }
    }

}
