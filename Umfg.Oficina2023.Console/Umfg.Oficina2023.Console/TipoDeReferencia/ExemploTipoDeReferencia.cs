using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Umfg.Oficina2023.TipoDeReferencia
{
    internal class ExemploTipoDeReferencia
    {
        internal static void Executar()
        {
            var usuarioUm = new Usuario();
            var usuarioDois = usuarioUm;

            usuarioUm.Login = "GUSTAVO";
            usuarioDois.Login = "GABRIEL";

            Console.WriteLine(usuarioUm.Login);
            Console.WriteLine(usuarioDois.Login);
        }
    }
}