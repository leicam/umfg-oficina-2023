using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Umfg.Oficina2023.Tipos
{
    internal class OutrosTipos
    {
        internal static void Executar()
        {
            Console.WriteLine("bool: " + true);
            Console.WriteLine("bool: " + false);

            Console.WriteLine("string: isso é uma string");
            Console.WriteLine(string.Concat("string: ", "isso também é uma string"));

            var stringUm = "outra forma de string";
            Console.WriteLine($"string: {stringUm}");

            Console.WriteLine("char: " + 'c');
        }
    }
}
