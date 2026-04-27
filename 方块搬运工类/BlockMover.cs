using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 俄罗斯方块
{
    internal enum E_Change
    {
        left, right,
    }

    internal class BlockMover : IDraw
    {
        private int index;
        public List<Drawobject> list;

        private Dictionary<E_Drawtype, BlockInfo> dic;
        private BlockInfo Nowblockinfo;
        public BlockMover()
        {
            list = new List<Drawobject>();
            dic = new Dictionary<E_Drawtype, BlockInfo>
            {
                {E_Drawtype.cube,new BlockInfo(E_Drawtype.cube) },
                {E_Drawtype.line,new BlockInfo(E_Drawtype.line) },
                {E_Drawtype.left_ladder,new BlockInfo(E_Drawtype.left_ladder) },
                {E_Drawtype.right_ladder,new BlockInfo(E_Drawtype.right_ladder) },
                {E_Drawtype.left_longladder,new BlockInfo(E_Drawtype.left_longladder) },
                {E_Drawtype.right_longladder,new BlockInfo(E_Drawtype.right_longladder) },
                {E_Drawtype.tank,new BlockInfo(E_Drawtype.tank) },
            };
            RandomCreateBlock();
        }

        public void Draw()
        {
            for (int i = 0; i < list.Count; i++)
            {
                list[i].Draw();
            }
        }

        public void RandomCreateBlock()
        {
            Random r = new Random();
            E_Drawtype e_Drawtype = (E_Drawtype)r.Next(1, 8);
            list = new List<Drawobject>
            {
                new Drawobject(e_Drawtype),
                new Drawobject(e_Drawtype),
                new Drawobject(e_Drawtype),
                new Drawobject(e_Drawtype),

            };
            list[0].pos = new Position(24, -5);
            Nowblockinfo = dic[e_Drawtype];
            Random a = new Random();
            index = a.Next(0, Nowblockinfo.Count);
            Position[] pos = Nowblockinfo[index];
            for (int i = 0; i < pos.Length; i++)
            {
                list[i + 1].pos = list[0].pos + pos[i];
            }
        }
        public void Clearblock()
        {
            for (int i = 0; i < list.Count; i++)
            {
                list[i].ClearDraw();
            }
        }
        public void Change(E_Change e_Change)
        {
            Clearblock();
            switch (e_Change)
            {
                case E_Change.left:
                    --index;
                    if (index < 0)
                    {
                        index = Nowblockinfo.Count - 1;
                    }
                    break;
                case E_Change.right:
                    ++index;
                    if (index >= Nowblockinfo.Count)
                    {
                        index = 0;
                    }
                    break;

            }
            Position[] pos = Nowblockinfo[index];
            for (int i = 0; i < pos.Length; i++)
            {
                list[i + 1].pos = list[0].pos + pos[i];
            }
            Draw();
        }
        public bool CanChange(E_Change e_Change, Map map)
        {
            int nowindex = index;
            switch (e_Change)
            {
                case E_Change.left:
                    --nowindex;
                    if (nowindex < 0)
                    {
                        nowindex = Nowblockinfo.Count - 1;
                    }

                    break;
                case E_Change.right:
                    ++nowindex;
                    if (nowindex >= Nowblockinfo.Count)
                    {
                        nowindex = 0;
                    }
                    break;

            }
            Position[] pos = Nowblockinfo[nowindex];
            Position temp;
            for (int i = 0; i < pos.Length; i++)
            {
                temp = list[0].pos + pos[i];
                if (temp.x < 2 ||
                    temp.x >= Game.w - 2 ||
                    temp.y >= Game.h - 6)
                {
                    return false;
                }
            }
            for (int i = 0; i < pos.Length; i++)
            {
                temp = list[0].pos + pos[i];
                for (int j = 0; j < map.dynamicwalls.Count; j++)
                {
                    if (temp == map.dynamicwalls[j].pos)
                    {
                        return false;
                    }
                }

            }
            return true;
        }

        public void MoveLR(E_Change e_Change)
        {
            Clearblock();
            Position pos = new Position(e_Change == E_Change.left ? -2 : 2, 0);
            for (int i = 0; i < list.Count; i++)
            {
                list[i].pos += pos;

            }
            Draw();

        }
        public bool CanMove(E_Change e_Change, Map map)
        {
            Position pos = new Position(e_Change == E_Change.left ? -2 : 2, 0);
            Position temp;
            for (int i = 0; i < list.Count; i++)
            {
                temp = list[i].pos + pos;
                if (temp.x < 2 || temp.x >= Game.w - 2)
                {
                    return false;
                }
            }
            for (int j = 0; j < list.Count; j++)
            {
                temp = list[j].pos + pos;
                for (int k = 0; k < map.dynamicwalls.Count; k++)
                {
                    if (temp == map.dynamicwalls[k].pos)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        public void AutoMove()
        {

            Clearblock();
            Position down = new Position(0, 1);
            for (int i = 0; i < list.Count; i++)
            {
                list[i].pos += down;
            }
            Draw();
        }
        public bool CanDown(Map map)
        {
            Position down = new Position(0, 1);
            Position temp;
            for (int i = 0; i < list.Count; i++)
            {
                temp = list[i].pos + down;
                if (temp.y >= Game.h - 6)
                {
                    map.Adddynamicwalls(list);
                    RandomCreateBlock();
                    return false;
                }
            }
            for (int i = 0; i < list.Count; i++)
            {
                temp = list[i].pos + down;
                for (int j = 0; j < map.dynamicwalls.Count; j++)
                {
                    if (temp == map.dynamicwalls[j].pos)
                    {
                        map.Adddynamicwalls(list);
                        RandomCreateBlock();
                        return false;
                    }
                }
            }
            return true;
        }

    }
}
