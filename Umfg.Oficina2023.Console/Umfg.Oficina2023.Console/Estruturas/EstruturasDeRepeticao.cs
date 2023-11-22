using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Umfg.Oficina2023.Estruturas
{
    internal class EstruturasDeRepeticao
    {
        public static void Executar()
        {
            for (var i = 1; i < "JULIANO".Length; i++)
                Console.WriteLine("JULIANO"[i]);
            
            foreach(var caractere in "JULIANO")
                Console.WriteLine(caractere);

            "JULIANO".ToArray().ToList().ForEach(Console.WriteLine);

            var countWhile = 0;

            while (countWhile < "JULIANO".Length)
            {
                Console.WriteLine("JULIANO"[countWhile]);
                countWhile++;
            }

            var countDoWhile = 0;
            do
            {
                Console.WriteLine("JULIANO"[countDoWhile]);
                countDoWhile++;
            } while (countDoWhile < "JULIANO".Length);
        }
    }
}