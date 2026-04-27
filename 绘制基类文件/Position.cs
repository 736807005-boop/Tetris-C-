using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 俄罗斯方块
{
    internal struct Position
    {
        public int x;
        public int y;

        public Position(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public static bool operator ==(Position a, Position b)
        {
            if (a.x == b.x && a.y == b.y)
            {
                return true;
            }
            return false;
        }
        public static bool operator !=(Position a, Position b)
        {
            if (a.x == b.x && a.y == b.y)
            {
                return false;
            }
            return true;
        }
        public static Position operator +(Position a, Position b)
        {
            Position pos = new Position(a.x + b.x, a.y + b.y);
            return pos;

        }
    }
}
