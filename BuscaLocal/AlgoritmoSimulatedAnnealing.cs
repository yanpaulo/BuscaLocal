using System;

namespace BuscaLocal
{
    public class AlgoritmoSimulatedAnnealing : IAlgoritmo
    {
        public AlgoritmoSimulatedAnnealing(Tabuleiro tabuleiro)
        {
            Tabuleiro = tabuleiro;
        }

        public Tabuleiro Tabuleiro { get; private set; }

        public double Temteratura { get; set; } = 50;

        public double FatorResfriamento { get; set; } = 0.99;

        public void Resolve()
        {
            var rng = new Random();

            while (Temteratura > 0 && Tabuleiro.Custo > 0)
            {
                var rainha = Tabuleiro.Rainhas[rng.Next(Tabuleiro.Tamanho)];
                var posicao = Tabuleiro.PosicaoAleatoria();

                var delta = Tabuleiro.Custo - Tabuleiro.SimulaMovimento(rainha, posicao);
                if (delta > 0)
                {
                    Tabuleiro.Move(rainha, posicao);
                }
                else
                {
                    var probabilidade = Math.Exp(delta / Temteratura);
                    if (probabilidade > rng.NextDouble())
                    {
                        Tabuleiro.Move(rainha, posicao);
                    }
                }

                Temteratura *= FatorResfriamento;
            }
        }
    }
}
