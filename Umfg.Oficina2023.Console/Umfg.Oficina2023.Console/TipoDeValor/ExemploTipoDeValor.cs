using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Umfg.Oficina2023.TipoDeValor
{
    internal class ExemploTipoDeValor
    {
        public static void Executar()
        {
            string nomeUm = "JULIANO";
            string nomeDois = nomeUm;

            nomeUm = "JOÃO";

            Console.WriteLine(nomeUm);
            Console.WriteLine(nomeDois);
        }
    }
}
