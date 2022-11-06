using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TutorialGame.Source.Engine;

namespace TutorialGame.Source.GamePlay.World.Units
{
    internal class Mob : Unit
    {
        public Mob(string PATH, Vector2 POS, Vector2 DIMS, int OWNERID) : base(PATH, POS, DIMS, OWNERID)
        {
            speed = 2.0f;
        }

        public override void Update(Vector2 OFFSET, clsPlayer ENEMY)
        {
            AI(ENEMY);
            base.Update(OFFSET);
        }

        public virtual void AI(clsPlayer ENEMY)
        {
            pos += Globals.RadialMovement(ENEMY.hero.pos, pos, speed);
            rot = Globals.RotateTowards(pos, ENEMY.hero.pos);

            if (Globals.GetDistance(pos, ENEMY.hero.pos) < 15)
            {
                ENEMY.hero.GetHit(1);
                dead = true;
            }
        }

        public override void Draw(Vector2 OFFSET)
        {
            base.Draw(OFFSET);
        }
    }
}
