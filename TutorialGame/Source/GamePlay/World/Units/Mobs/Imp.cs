using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutorialGame.Source.GamePlay.World.Units.Mobs
{
    internal class Imp : Mob
    {
        public Imp(Vector2 POS, int OWNERID)
        : base("2d\\Units\\Mobs\\Imp", POS, new Vector2(40, 40), OWNERID)
        {
            speed = 2.0f;
        }

        public override void Update(Vector2 OFFSET, clsPlayer ENEMY)
        {
            base.Update(OFFSET, ENEMY);
        }

        public override void Draw(Vector2 OFFSET)
        {
            base.Draw(OFFSET);
        }
    }
}
