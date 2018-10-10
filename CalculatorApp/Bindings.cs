using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartMenuLibrary;

namespace CalculatorApp
{
    class Bindings : IBindings
    {
        // TODO: Implement different languages. Maybe load the explaining text from files?
        // Or have twice as many switch statements and have the switches be language dependant.
        private double GetInput()
        {
            double v;
            while (!double.TryParse(Console.ReadLine(), out v))
            {
                Console.WriteLine("Indtast venligst et gyldigt tal.");
            }

            return v;
        }
        private void GetTwoInputs(out double v1, out double v2)
        { 
            Console.WriteLine("Skriv første tal");
            v1 = GetInput();
            Console.WriteLine("Skriv andet tal");
            v2 = GetInput();
        }
        private double[] GetInputArray()
        {
            double[] numberArray;
            string[] inputArray;
            bool isNumber = false;
            do
            {
                Console.WriteLine("Indtast værdier, adskil med mellemrum.");
                inputArray = Console.ReadLine().Split(' ');
                numberArray = new double[inputArray.Length];
                for (int i = 0; i < inputArray.Length; i++)
                {
                    isNumber = double.TryParse(inputArray[i], out double number);

                    if (!isNumber)
                    {
                        Console.WriteLine("Indtast kun tal.");
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
                    Console.WriteLine("Resultat: {0}", CalculatorLibrary.Calculator.Add(v, v2));
                    break;
                case "subtract":
                    GetTwoInputs(out v, out v2);
                    Console.WriteLine("Resultat: {0}", CalculatorLibrary.Calculator.Subtract(v, v2));
                    break;
                case "multiply":
                    GetTwoInputs(out v, out v2);
                    Console.WriteLine("Resultat: {0}", CalculatorLibrary.Calculator.Multiply(v, v2));
                    break;
                case "divide":
                    GetTwoInputs(out v, out v2);
                    Console.WriteLine("Resultat: {0}", CalculatorLibrary.Calculator.Divide(v, v2));
                    break;
                case "sum":
                    Console.WriteLine("Summen er: {0}", CalculatorLibrary.Calculator.Sum(GetInputArray()));
                    break;
                case "minimum":
                    Console.WriteLine("Det mindste tal er: {0}", CalculatorLibrary.Calculator.Minimum(GetInputArray()));
                    break;
                case "maximum":
                    Console.WriteLine("Det største tal er: {0}", CalculatorLibrary.Calculator.Maximum(GetInputArray()));
                    break;
                case "average":
                    Console.WriteLine("Gennemsnittet er: {0}", CalculatorLibrary.Calculator.Average(GetInputArray()));
                    break;
                default:
                    break;
            }
        }
    }
}
