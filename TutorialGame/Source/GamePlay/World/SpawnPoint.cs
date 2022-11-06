using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TutorialGame.Source.Engine;
using TutorialGame.Source.GamePlay.World.Units.Mobs;

namespace TutorialGame.Source.GamePlay.World
{
    internal class SpawnPoint : AttackableObject
    {
        public clsTimer spawnTimer = new clsTimer(2400);
        public SpawnPoint(string PATH, Vector2 POS, Vector2 DIMS, int OWNERID) : base(PATH, POS, DIMS, OWNERID)
        {
            dead = false;

            health = 3;
            healthMax = health;

            hitDist = 35;
        }

        public override void Update(Vector2 OFFSET)
        {
            spawnTimer.UpdateTimer();
            if (spawnTimer.Test())
            {
                SpawnMob();
                spawnTimer.ResetToZero();
            }

            base.Update(OFFSET);
        }

        public virtual void SpawnMob()
        {
            GameGlobals.PassMob(new Imp(new Vector2(pos.X, pos.Y), ownerId));
        }

        public override void Draw(Vector2 OFFSET)
        {
            base.Draw(OFFSET);
        }
    }
}
