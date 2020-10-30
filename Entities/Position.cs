using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Position
    {
        public int X { get; set; } = -1;
        public int Y { get; set; } = -1;

        public Position()
        {

        }

        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        public bool IsValid()
        {
            return X > -1 && Y > -1;
        }
    }
}
