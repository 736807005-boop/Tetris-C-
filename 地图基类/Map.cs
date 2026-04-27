using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace 俄罗斯方块
{
    internal class Map : IDraw
    {
        public List<Drawobject> walls = new List<Drawobject>();
        public int[] listint;
        public List<Drawobject> dynamicwalls = new List<Drawobject>();
        public List<Drawobject> dellist = new List<Drawobject>();
        public int w = -2;
        private Gamescene scene;
        public Map(Gamescene scene)
        {
            this.scene = scene;
            listint = new int[Game.h - 6];
            for (int i = 0; i < Game.w; i += 2)
            {
                walls.Add(new Drawobject(i, Game.h - 6, E_Drawtype.wall));
                w++;
            }
            for (int i = 0; i < Game.h - 6; i++)
            {
                walls.Add(new Drawobject(0, i, E_Drawtype.wall));
                walls.Add(new Drawobject(Game.w - 2, i, E_Drawtype.wall));
            }
        }
        public void Cleardraw()
        {
            for (int i = 0; i < dynamicwalls.Count; i++)
            {
                dynamicwalls[i].ClearDraw();
            }
        }

        public void Draw()
        {
            for (int i = 0; i < walls.Count; i++)
            {
                walls[i].Draw();

            }
            for (int i = 0; i < dynamicwalls.Count; i++)
            {
                dynamicwalls[i].Draw();
            }
        }
        public void Adddynamicwalls(List<Drawobject> dynamics)
        {
            for (int i = 0; i < dynamics.Count; i++)
            {
                dynamics[i].Changetype(E_Drawtype.wall);
                dynamicwalls.Add((dynamics[i]));
                if (dynamics[i].pos.y <= 0)
                {
                    this.scene.threadend();
                    Game.Changescene(E_Scene.end);
                    return;
                }
                listint[Game.h - 6 - dynamics[i].pos.y] += 1;
            }
            Cleardraw();
            Remove();
            Draw();

        }
        public void Remove()
        {
            for (int i = 0; i < listint.Length; i++)
            {
                if (listint[i] == w)
                {
                    for (int j = 0; j < dynamicwalls.Count; j++)
                    {
                        if (i == Game.h - 6 - dynamicwalls[j].pos.y)
                        {
                            dellist.Add(dynamicwalls[j]);
                        }
                        else if (Game.h - 6 - dynamicwalls[j].pos.y > i)
                        {
                            ++dynamicwalls[j].pos.y;
                        }
                    }
                    for (int k = 0; k < dellist.Count; k++)
                    {
                        dynamicwalls.Remove(dellist[k]);
                    }
                    for (int j = i; j < listint.Length - 1; j++)
                    {
                        listint[j] = listint[j + 1];
                    }
                    listint[listint.Length - 1] = 0;

                    Remove();
                    break;
                }
            }

        }
    }
}
