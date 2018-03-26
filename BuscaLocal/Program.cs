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
            var sw = new Stopwatch();
            var tabuleiro = new Tabuleiro(8);

            Console.WriteLine("Estado Inicial: ");
            tabuleiro.Imprime();

            var algoritmo = new AlgoritmoHillClimbing(tabuleiro);
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
