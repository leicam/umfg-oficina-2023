using Umfg.Oficina2023.Enumeracoes;
using Umfg.Oficina2023.Estruturas;
using Umfg.Oficina2023.TipoDeReferencia;
using Umfg.Oficina2023.TipoDeValor;
using Umfg.Oficina2023.Tipos;

namespace Umfg.Oficina2023.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TiposInteiros.Executar();
            TiposPontoFlutuantes.Executar();
            OutrosTipos.Executar();
            EstruturasDeRepeticao.Executar();
            EstruturasCondicionais.Executar();
            EnumeracoesExemplo.Executar();
            ExemploTipoDeValor.Executar();
            ExemploTipoDeReferencia.Executar();
        }
    }
}