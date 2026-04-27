using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 俄罗斯方块
{
    internal class Start : StartEndbase
    {
        public Start()
        {
            title = "俄罗斯方块";
            str1 = "开始游戏";

        }
        public override void Setscene()
        {
            Game.Changescene(E_Scene.play);
        }
    }
}
