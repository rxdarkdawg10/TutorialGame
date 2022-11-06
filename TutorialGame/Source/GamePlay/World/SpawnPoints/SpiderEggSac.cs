using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TutorialGame.Source.Engine;
using TutorialGame.Source.GamePlay.World.Units;
using TutorialGame.Source.GamePlay.World.Units.Mobs;

namespace TutorialGame.Source.GamePlay.World.SpawnPoints
{
    internal class SpiderEggSac : SpawnPoint
    {
        int maxSpawns, totalSpawns;
        public SpiderEggSac(Vector2 POS, int OWNERID)
            : base("2d\\SpawnPoints\\EggSac", POS, new Vector2(45, 45), OWNERID)
        {
            totalSpawns = 0;
            maxSpawns = 3;

            health = 3;
            healthMax = health;

            spawnTimer = new clsTimer(3000);
        }

        public override void Update(Vector2 OFFSET)
        {
            base.Update(OFFSET);
        }

        public override void SpawnMob()
        {
            Mob tempMob = new Spiderling(new Vector2(pos.X, pos.Y), ownerId);

            if (tempMob != null)
            {
                GameGlobals.PassMob(tempMob);

                totalSpawns++;
                if (totalSpawns >= maxSpawns)
                {
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
