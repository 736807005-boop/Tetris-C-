using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 俄罗斯方块
{
    internal enum E_Drawtype
    {
        wall,
        cube,
        line,
        tank,
        left_ladder,
        right_ladder,
        left_longladder,
        right_longladder,
    }

    internal class Drawobject : IDraw
    {
        public Position pos;
        public E_Drawtype type;
        public Drawobject(E_Drawtype e_Drawtype)
        {
            this.type = e_Drawtype;
        }
        public Drawobject(int x, int y, E_Drawtype e_Drawtype) : this(e_Drawtype)
        {
            pos = new Position(x, y);
        }
        public void Changetype(E_Drawtype e_Drawtype)
        {
            this.type = e_Drawtype;
        }
        public void Draw()
        {
            if (pos.y < 0)
                return;
            Console.SetCursorPosition(pos.x, pos.y);
            switch (type)
            {
                case E_Drawtype.wall:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case E_Drawtype.cube:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;
                case E_Drawtype.line:
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case E_Drawtype.tank:
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    break;
                case E_Drawtype.left_ladder:
                case E_Drawtype.right_ladder:
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    break;
                case E_Drawtype.left_longladder:
                case E_Drawtype.right_longladder:
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;
            }
            Console.Write("■");
        }
        public void ClearDraw()
        {
            if (pos.y < 0)
                return;
            Console.SetCursorPosition(pos.x, pos.y);
            Console.Write("  ");
        }

    }
}
