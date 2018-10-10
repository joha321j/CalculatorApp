using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartMenuLibrary;
using System.IO;

namespace CalculatorApp
{
    class Bindings : IBindings
    {
        private List<string> printList = new List<string>();

        public Bindings(string printFile)
        {
            string line;
            try
            {
                using (StreamReader sr = new StreamReader(printFile))
                {
                    while ((line = sr.ReadLine()) != null )
                    {
                        printList.Add(line);
                    }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read.");
                Console.WriteLine(e.Message);
            }
        }
        

        private double GetInput()
        {
            double v;
            while (!double.TryParse(Console.ReadLine(), out v))
            {
                Console.WriteLine(printList[1]);
            }

            return v;
        }
        private void GetTwoInputs(out double v1, out double v2)
        { 
            Console.WriteLine(printList[2]);
            v1 = GetInput();
            Console.WriteLine(printList[3]);
            v2 = GetInput();
        }
        private double[] GetInputArray()
        {
            double[] numberArray;
            string[] inputArray;
            bool isNumber = false;
            char[] charSplit = { ' ' };
            do
            {
                Console.WriteLine(printList[4]);
                inputArray = Console.ReadLine().Split(charSplit, StringSplitOptions.RemoveEmptyEntries);
                numberArray = new double[inputArray.Length];
                for (int i = 0; i < inputArray.Length; i++)
                {
                    isNumber = double.TryParse(inputArray[i], out double number);

                    if (!isNumber)
                    {
                        Console.WriteLine(printList[5]);
                        break;
                    }
                    numberArray[i] = number;
                }
            } while (!isNumber);
            

            return numberArray;
        }
        public void Call(string callId)
        {
            
            double v, v2;
            switch (callId)
            {
                case "add":
                    GetTwoInputs(out v, out v2);
                    Console.WriteLine(printList[0] + " " + CalculatorLibrary.Calculator.Add(v, v2));
                    break;
                case "subtract":
                    GetTwoInputs(out v, out v2);
                    Console.WriteLine(printList[0] + " " + CalculatorLibrary.Calculator.Subtract(v, v2));
                    break;
                case "multiply":
                    GetTwoInputs(out v, out v2);
                    Console.WriteLine(printList[0] + " " + CalculatorLibrary.Calculator.Multiply(v, v2));
                    break;
                case "divide":
                    GetTwoInputs(out v, out v2);
                    Console.WriteLine(printList[0] + " " + CalculatorLibrary.Calculator.Divide(v, v2));
                    break;
                case "sum":
                    Console.WriteLine(printList[6] + " " + CalculatorLibrary.Calculator.Sum(GetInputArray()));
                    break;
                case "minimum":
                    Console.WriteLine(printList[7] + " " + CalculatorLibrary.Calculator.Minimum(GetInputArray()));
                    break;
                case "maximum":
                    Console.WriteLine(printList[8] + " " + CalculatorLibrary.Calculator.Maximum(GetInputArray()));
                    break;
                case "average":
                    Console.WriteLine(printList[9] + " " + CalculatorLibrary.Calculator.Average(GetInputArray()));
                    break;
                default:
                    break;
            }
        }
    }
}
