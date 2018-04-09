using System;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuscaLocal
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                //Hill Climbing por padrão.
                args = new[] { "hc" };
            }

            var tabuleiro = new Tabuleiro(8);
            var sw = new Stopwatch();
            IAlgoritmo algoritmo;

            switch (args[0])
            {
                case "hc":
                    Console.WriteLine("Hill Climbing");
                    algoritmo = new AlgoritmoHillClimbing(tabuleiro);
                    break;
                case "sa":
                    Console.WriteLine("Simulated Annealing");
                    algoritmo = new AlgoritmoSimulatedAnnealing(tabuleiro);
                    break;
                default:
                    Console.WriteLine(@"Uso: busca.exe hc ou busca.exe sa");
                    return;
            }
            Console.WriteLine();

            Console.WriteLine("Estado Inicial: ");
            tabuleiro.Imprime();

            sw.Start();
            algoritmo.Resolve();
            sw.Stop();

            Console.WriteLine("\n\nEstado Final: ");
            tabuleiro.Imprime();

            Console.WriteLine($"Tempo gasto: {sw.ElapsedMilliseconds}ms");
            if (Debugger.IsAttached)
            {
                Console.ReadKey();
            }

        }
    }
}
