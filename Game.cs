using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 俄罗斯方块
{
    internal enum E_Scene
    {
        start, play, end
    }

    internal class Game
    {
        public const int w = 50;
        public const int h = 35;
        public static IUpdate update;
        public Game()
        {
            Console.SetWindowSize(w, h);
            Console.SetBufferSize(w, h);
            Console.CursorVisible = false;
            Changescene(E_Scene.start);

        }
        public void Start()
        {
            while (true)
            {
                if (update != null)
                {
                    update.Update();
                }
            }
        }
        public static void Changescene(E_Scene scene)
        {
            Console.Clear();
            switch (scene)
            {
                case E_Scene.start:
                    update = new Start();
                    break;
                case E_Scene.play:
                    update = new Gamescene();
                    break;
                case E_Scene.end:
                    update = new End();
                    break;
            }
        }
    }
}
