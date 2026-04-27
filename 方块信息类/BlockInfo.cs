using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 俄罗斯方块
{
    internal class BlockInfo
    {
        public List<Position[]> list;
        public Position[] this[int index]
        {
            get
            {
                if (index < 0)
                {
                    return list[0];
                }
                else if (index > list.Count - 1)
                {
                    return list[list.Count];
                }
                else
                {
                    return list[index];
                }
            }
        }
        public BlockInfo(E_Drawtype e_Drawtype)
        {
            list = new List<Position[]>();
            switch (e_Drawtype)
            {
                case E_Drawtype.cube:
                    list.Add(new Position[3] { new Position(2, 0), new Position(0, 1), new Position(2, 1) });
                    break;
                case E_Drawtype.line:
                    list.Add(new Position[3] { new Position(0, -1), new Position(0, 1), new Position(0, 2) });
                    list.Add(new Position[3] { new Position(-4, 0), new Position(-2, 0), new Position(2, 0) });
                    list.Add(new Position[3] { new Position(0, -2), new Position(0, -1), new Position(0, 1) });
                    list.Add(new Position[3] { new Position(-2, 0), new Position(2, 0), new Position(4, 0) });
                    break;
                case E_Drawtype.tank:
                    list.Add(new Position[3] { new Position(-2, 0), new Position(2, 0), new Position(0, 1) });
                    list.Add(new Position[3] { new Position(-2, 0), new Position(0, 1), new Position(0, -1) });
                    list.Add(new Position[3] { new Position(-2, 0), new Position(2, 0), new Position(0, -1) });
                    list.Add(new Position[3] { new Position(2, 0), new Position(0, 1), new Position(0, -1) });
                    break;
                case E_Drawtype.left_ladder:
                    list.Add(new Position[3]{
                        new Position(0,-1),
                        new Position(2,0),
                        new Position(2,1)
                    });
                    list.Add(new Position[3]{
                        new Position(2,0),
                        new Position(0,1),
                        new Position(-2,1)
                    });
                    list.Add(new Position[3]{
                       new Position(-2,-1),
                        new Position(-2,0),
                        new Position(0,1)
                    });
                    list.Add(new Position[3]{
                        new Position(0,-1),
                        new Position(2,-1),
                        new Position(-2,0)
                    });
                    break;
                case E_Drawtype.right_ladder:
                    list.Add(new Position[3]{
                        new Position(0,-1),
                        new Position(-2,0),
                        new Position(-2,1)
                    });
                    list.Add(new Position[3]{
                        new Position(-2,-1),
                        new Position(0,-1),
                        new Position(2,0)
                    });
                    list.Add(new Position[3]{
                        new Position(2,-1),
                        new Position(2,0),
                        new Position(0,1)
                    });
                    list.Add(new Position[3]{
                        new Position(0,1),
                        new Position(2,1),
                        new Position(-2,0)
                    });
                    break;
                case E_Drawtype.left_longladder:
                    list.Add(new Position[3]{
                        new Position(-2,-1),
                        new Position(0,-1),
                        new Position(0,1)
                    });
                    list.Add(new Position[3]{
                        new Position(2,-1),
                        new Position(-2,0),
                        new Position(2,0)
                    });
                    list.Add(new Position[3]{
                        new Position(0,-1),
                        new Position(2,1),
                        new Position(0,1)
                    });
                    list.Add(new Position[3]{
                        new Position(2,0),
                        new Position(-2,0),
                        new Position(-2,1)
                    });
                    break;
                case E_Drawtype.right_longladder:
                    list.Add(new Position[3]{
                        new Position(0,-1),
                        new Position(0,1),
                        new Position(2,-1)
                    });
                    list.Add(new Position[3]{
                        new Position(2,0),
                        new Position(-2,0),
                        new Position(2,1)
                    });
                    list.Add(new Position[3]{
                        new Position(0,-1),
                        new Position(-2,1),
                        new Position(0,1)
                    });
                    list.Add(new Position[3]{
                        new Position(-2,-1),
                        new Position(-2,0),
                        new Position(2,0)
                    });
                    break;
                default:
                    break;
            }
        }
        public int Count { get => list.Count; }
    }
}
