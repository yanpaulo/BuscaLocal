using System;

namespace BuscaLocal
{
    public class AlgoritmoHillClimbing : IAlgoritmo
    {
        public AlgoritmoHillClimbing(Tabuleiro tabuleiro)
        {
            Tabuleiro = tabuleiro;
        }

        public Tabuleiro Tabuleiro { get; private set; }

        public void Resolve()
        {
            while (Tabuleiro.Custo > 0)
            {
                Tabuleiro.Reset();
                foreach (var rainha in Tabuleiro.Rainhas)
                {
                    int custo = Tabuleiro.Custo;
                    Posicao p = null;
                    for (int i = 0; i < Tabuleiro.Tamanho; i++)
                    {
                        for (int j = 0; j < Tabuleiro.Tamanho; j++)
                        {
                            var posicao = new Posicao(i, j);
                            if (!Tabuleiro.IsPosicaoDisponivel(posicao))
                                continue;

                            int novoCusto = Tabuleiro.SimulaMovimento(rainha, posicao);
                            if (novoCusto < custo)
                            {
                                p = posicao;
                                custo = novoCusto;
                                break;
                            }
                        }
                    }

                    if (p != null)
                    {
                        rainha.Posicao = p;
                    }
                }
            }
        }
    }
}
