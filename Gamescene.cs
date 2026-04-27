using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 俄罗斯方块
{
    internal class Gamescene : IUpdate
    {
        public Map map;
        public BlockMover blockMover;
        Thread thread;
        bool isrunning;
        public Gamescene()
        {
            isrunning = true;
            map = new Map(this);
            blockMover = new BlockMover();
            thread = new Thread(Line);
            thread.IsBackground = true;
            thread.Start();
        }
        public void Update()
        {
            lock (blockMover)
            {
                map.Draw();
                blockMover.Draw();
                if (blockMover.CanDown(map))
                {
                    blockMover.AutoMove();
                }
            }
            Thread.Sleep(100);
        }
        public void threadend()
        {
            isrunning = false;
            thread = null;
        }
        public void Line()
        {
            while (isrunning)
            {
                if (Console.KeyAvailable)
                {
                    lock (blockMover)

                    {
                        switch (Console.ReadKey(true).Key)
                        {
                            case ConsoleKey.LeftArrow:
                                if (blockMover.CanChange(E_Change.left, map))
                                {
                                    blockMover.Change(E_Change.left);
                                }
                                break;
                            case ConsoleKey.RightArrow:
                                if (blockMover.CanChange(E_Change.right, map))
                                {
                                    blockMover.Change(E_Change.right);
                                }
                                break;
                            case ConsoleKey.A:
                                if (blockMover.CanMove(E_Change.left, map))
                                {
                                    blockMover.MoveLR(E_Change.left);
                                }
                                break;
                            case ConsoleKey.D:
                                if (blockMover.CanMove(E_Change.right, map))
                                {
                                    blockMover.MoveLR(E_Change.right);
                                }
                                break;
                            case ConsoleKey.S:
                                if (blockMover.CanDown(map))
                                {
                                    blockMover.AutoMove();
                                }
                                break;
                        }
                    }
                }
            }
        }
    }
}
