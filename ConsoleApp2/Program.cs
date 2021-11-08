using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            Parser parser = new Parser();
            Console.WriteLine("Ingrese la ruta de su archivo .y");
            string ruta = Console.ReadLine();
            string text = System.IO.File.ReadAllText(ruta);
            Console.WriteLine(parser.initializeGrammar(text));
            Console.ReadLine();
        }
    }
}
