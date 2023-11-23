using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Umfg.Oficina2023.Enumeracoes
{
    internal class EnumeracoesExemplo
    {
        public static void Executar()
        {
            var diasTrabalho = TipoDiasDaSemana.Segunda
                | TipoDiasDaSemana.Terca
                | TipoDiasDaSemana.Quarta
                | TipoDiasDaSemana.Quinta
                | TipoDiasDaSemana.Sexta;

            Console.WriteLine(diasTrabalho);
            Console.WriteLine(TipoDiasDaSemana.Quarta.GetDescription());
        }
    }
}
