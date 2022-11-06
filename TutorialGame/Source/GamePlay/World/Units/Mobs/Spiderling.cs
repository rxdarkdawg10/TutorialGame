using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TutorialGame.Source.Engine;
using TutorialGame.Source.GamePlay.World.Buildings;

namespace TutorialGame.Source.GamePlay.World.Units.Mobs
{
    internal class Spiderling : Mob
    {
        public Spiderling(Vector2 POS, int OWNERID)
        : base("2d\\Units\\Mobs\\Spider", POS, new Vector2(25, 25), OWNERID)
        {
            speed = 2.5f;
        }

        public override void Update(Vector2 OFFSET, clsPlayer ENEMY)
        {
            base.Update(OFFSET, ENEMY);
        }

        public override void AI(clsPlayer ENEMY)
        {
            Building temp = null;
            for (int i = 0; i < ENEMY.buildings.Count; i++)
            {
                if (ENEMY.buildings[i].GetType() == typeof(Tower))
                {
                    temp = ENEMY.buildings[i];
                }
            }

            if (temp != null)
            {
                pos += Globals.RadialMovement(temp.pos, pos, speed);
                rot = Globals.RotateTowards(pos, temp.pos);

                if (Globals.GetDistance(pos, temp.pos) < 15)
                {
                    temp.GetHit(1);
                    dead = true;
                }
            }
        }

        public override void Draw(Vector2 OFFSET)
        {
            base.Draw(OFFSET);
        }
    }
}
