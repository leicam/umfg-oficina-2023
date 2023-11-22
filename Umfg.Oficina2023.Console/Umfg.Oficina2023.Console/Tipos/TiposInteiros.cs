using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Umfg.Oficina2023.Tipos
{
    internal class TiposInteiros
    {
        internal static void Executar()
        {
            Console.WriteLine("byte min value:" + byte.MinValue);
            Console.WriteLine("byte max value:" + byte.MaxValue);

            Console.WriteLine("ushort min value:" + ushort.MinValue);
            Console.WriteLine("ushort max value:" + ushort.MaxValue);

            Console.WriteLine("short min value: " + short.MinValue);
            Console.WriteLine("short max value: " + short.MaxValue);

            Console.WriteLine("uint min value: " + uint.MinValue);
            Console.WriteLine("uint max value: " + uint.MaxValue);

            Console.WriteLine("int min value: " + int.MinValue);
            Console.WriteLine("int max value: " + int.MaxValue);

            Console.WriteLine("ulong  min value: " + ulong.MinValue);
            Console.WriteLine("ulong  max value: " + ulong.MaxValue);

            Console.WriteLine("long min value: " + long.MinValue);
            Console.WriteLine("long max value: " + long.MaxValue);
        }
    }
}