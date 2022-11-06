using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TutorialGame.Source.Engine;
using TutorialGame.Source.GamePlay.World.SpawnPoints;

namespace TutorialGame.Source.GamePlay.World.Units.Mobs
{
    internal class Spider : Mob
    {
        public clsTimer spawnTimer;
        public Spider(Vector2 POS, int OWNERID)
            : base("2d\\Units\\Mobs\\Spider", POS, new Vector2(45, 45), OWNERID)
        {
            speed = 1.5f;
            health = 3;
            healthMax = health;

            spawnTimer = new clsTimer(8000);
            spawnTimer.AddToTimer(4000);
        }

        public override void Update(Vector2 OFFSET, clsPlayer ENEMY)
        {
            spawnTimer.UpdateTimer();
            if (spawnTimer.Test())
            {
                SpawnEggSac();
                spawnTimer.ResetToZero();
            }

            base.Update(OFFSET, ENEMY);
        }

        public virtual void SpawnEggSac()
        {
            GameGlobals.PassSpawnPoint(new SpiderEggSac(new Vector2(pos.X, pos.Y), ownerId, null));
        }

        public override void Draw(Vector2 OFFSET)
        {
            base.Draw(OFFSET);
        }
    }
}
