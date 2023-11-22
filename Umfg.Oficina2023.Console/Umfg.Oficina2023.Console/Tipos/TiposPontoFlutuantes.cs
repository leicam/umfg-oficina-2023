using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Umfg.Oficina2023.Tipos
{
    internal class TiposPontoFlutuantes
    {
        internal static void Executar()
        {
            Console.WriteLine("float min value: " + float.MinValue);
            Console.WriteLine("float max value: " + float.MaxValue);

            Console.WriteLine("double min value: " + double.MinValue);
            Console.WriteLine("double max value: " + double.MaxValue);

            Console.WriteLine("decimal min value: " + decimal.MinValue);
            Console.WriteLine("decimal max value: " + decimal.MaxValue);

            float variavelFloatUm = 10.01f;
            var variavelFloatDois = 11.01f;

            var variavelDoubleUm = 12.01d;

            var variavelDecimalUm = 21.02m;

            Console.WriteLine((variavelFloatUm + variavelFloatDois) == 21.02);
            Console.WriteLine(10.10 + 20.20);
            Console.WriteLine(10.10m + 20.20m);
        }
    }
}
