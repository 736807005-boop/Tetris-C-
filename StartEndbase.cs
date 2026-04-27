using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 俄罗斯方块
{
    internal abstract class StartEndbase : IUpdate
    {
        public string title;
        public string str1;
        int index = 0;
        public abstract void Setscene();
        public void Update()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(Game.w / 2 - title.Length, 3);
            Console.Write(title);
            Console.SetCursorPosition(Game.w / 2 - str1.Length, 8);
            Console.ForegroundColor = index == 0 ? ConsoleColor.Red : ConsoleColor.White;
            Console.Write(str1);
            Console.SetCursorPosition(Game.w / 2 - 4, 10);
            Console.ForegroundColor = index == 1 ? ConsoleColor.Red : ConsoleColor.White;
            Console.Write("结束游戏");

            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.W:
                    {
                        index--;
                        if (index < 0)
                        {
                            index = 0;
                        }
                        break;
                    }
                case ConsoleKey.S:
                    {
                        index++;
                        if (index > 1)
                        {
                            index = 1;
                        }
                        break;
                    }
                case ConsoleKey.J:
                    {
                        if (index == 0)
                        {
                            Setscene();
                        }
                        else
                        {
                            Environment.Exit(0);
                        }
                        break;
                    }

            }

        }
    }
}
