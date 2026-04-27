using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 俄罗斯方块
{
    internal class End : StartEndbase
    {
        public End()
        {
            title = "结束界面";
            str1 = "继续游戏";

        }
        public override void Setscene()
        {
            Game.Changescene(E_Scene.play);
        }
    }
}
