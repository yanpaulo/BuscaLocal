using System;

namespace BuscaLocal
{
    public class Posicao : IEquatable<Posicao>
    {
        public Posicao(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; set; }

        public int Y { get; set; }

        public bool Equals(Posicao other) =>
            X == other.X && Y == other.Y;
    }
}
