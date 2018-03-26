using System;

namespace BuscaLocal
{
    public class Rainha
    {
        public Posicao Posicao { get; set; }

        public bool PodeAtacar(Rainha r) => 
                r.Posicao.X == Posicao.X ||
                r.Posicao.Y == Posicao.Y ||
                Math.Abs(r.Posicao.X - Posicao.X) == Math.Abs(r.Posicao.Y - Posicao.Y);
    }
}
