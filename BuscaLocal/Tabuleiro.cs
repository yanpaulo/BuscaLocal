using System;
using System.Collections.Generic;
using System.Linq;
using static System.Linq.Enumerable;

namespace BuscaLocal
{
    public class Tabuleiro
    {
        private Random rng = new Random();

        public Tabuleiro(int tamanho = 8)
        {
            Tamanho = tamanho;
            Reset();
        }

        public int Tamanho { get; private set; }

        public Rainha[] Rainhas { get; private set; }

        public int Custo => CalculaCusto(Rainhas);

        public void Move(Rainha rainha, Posicao posicao) => rainha.Posicao = posicao;

        public bool IsPosicaoDisponivel(Posicao p, IEnumerable<Rainha> rainhas) => !rainhas.Any(r => r.Posicao.Equals(p));

        public bool IsPosicaoDisponivel(Posicao p) => IsPosicaoDisponivel(p, Rainhas);

        public int SimulaMovimento(Rainha rainha, Posicao posicao)
        {
            var posicaoOriginal = rainha.Posicao;
            try
            {
                rainha.Posicao = posicao;
                return CalculaCusto(Rainhas);
            }
            finally
            {
                rainha.Posicao = posicaoOriginal;
            }
        }
        
        public void Reset()
        {
            var rng = new Random();
            var rainhas = new List<Rainha>();

            for (int i = 0; i < Tamanho; i++)
            {
                Posicao p;
                do
                {
                    p = new Posicao(rng.Next(0, Tamanho), rng.Next(0, Tamanho));
                } while (!IsPosicaoDisponivel(p, rainhas));

                rainhas.Add(new Rainha { Posicao = p });
            }
            Rainhas = rainhas.ToArray();
        }

        public Posicao PosicaoAleatoria()
        {
            Posicao p = null;
            do
            {
                p = new Posicao(rng.Next(Tamanho), rng.Next(Tamanho));
            } while (!IsPosicaoDisponivel(p));
            return p;
        }

        public void Imprime()
        {
            var str =
                string.Join("\n", Range(0, Tamanho).Select(i =>
                    string.Join(" ", Range(0, Tamanho).Select(j => 
                        Rainhas.Any(r => new Posicao(i, j).Equals(r.Posicao)) ? "R" : "*"))
                ));
            Console.WriteLine(str);
        }

        private int CalculaCusto(IEnumerable<Rainha> rainhas)
        {
            int custo = 0;

            foreach (var rainha in rainhas)
            {
                var outras = rainhas.Except(rainha);
                custo += outras.Count(r => rainha.PodeAtacar(r));
            }

            return custo / 2;
        }


    }
}
