using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Umfg.Oficina2023.Estruturas
{
    internal class EstruturasCondicionais
    {
        internal static void Executar()
        {
            var valor = 10;

            if (valor % 2 == 0)
                Console.WriteLine("PAR");
            else
                Console.WriteLine("IMPAR");

            switch (valor)
            {
                case 10:
                    Console.WriteLine("DEZ");
                    break;
                default:
                    Console.WriteLine("NÃO IDENTIFICADO");
                    break;
            }

            Console.WriteLine(GetValueExtension(valor));
        }

        private static string GetValueExtension(int valor) 
            => valor switch
            {
                10 => "DEZ",
                _ => "NÃO IDENTIFICADO"
            };
    }
}