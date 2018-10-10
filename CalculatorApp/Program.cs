using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalculatorLibrary;
using SmartMenuLibrary;

namespace CalculatorApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Program myProgram = new Program();
            myProgram.Run();
        }

        private void Run()
        {
            SmartMenu menu = new SmartMenu();

            string menuLanguage = menu.ChooseLanguage(out string errorPath, out string bindingsPath);

            Bindings bindings = new Bindings(bindingsPath);

            menu.LoadMenu(menuLanguage, errorPath);
            menu.Activate(bindings);
        }

       
    }
}
