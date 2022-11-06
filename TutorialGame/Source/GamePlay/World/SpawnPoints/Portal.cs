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
    internal class Portal : SpawnPoint
    {
        public Portal(Vector2 POS, int OWNERID)
        : base("2d\\SpawnPoints\\Portal", POS, new Vector2(45, 45), OWNERID)
        {
            health = 15;
            healthMax = health;
        }

        public override void Update(Vector2 OFFSET)
        {
            base.Update(OFFSET);
        }

        public override void SpawnMob()
        {
            int num = Globals.rand.Next(0, 10 + 1);
            Mob tempMob = null;
            if (num < 5)
            {
                tempMob = new Imp(new Vector2(pos.X, pos.Y), ownerId);
            }
            else if (num < 8)
            {
                tempMob = new Spider(new Vector2(pos.X, pos.Y), ownerId);
            }

            if (tempMob != null)
            {
                GameGlobals.PassMob(tempMob);
            }
        }

        public override void Draw(Vector2 OFFSET)
        {
            base.Draw(OFFSET);
        }
    }
}
