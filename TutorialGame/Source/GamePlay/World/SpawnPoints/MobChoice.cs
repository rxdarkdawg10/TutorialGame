using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutorialGame.Source.GamePlay.World.SpawnPoints
{
    internal class MobChoice
    {
        public int rate;
        public string mobType;
        public MobChoice(int RATE, string MOBTYPE)
        {
            rate = RATE;
            mobType = MOBTYPE;
        }
    }
}
