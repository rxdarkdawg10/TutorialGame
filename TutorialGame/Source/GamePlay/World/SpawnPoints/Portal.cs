using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TutorialGame.Source.Engine;
using TutorialGame.Source.GamePlay.World.Units;
using TutorialGame.Source.GamePlay.World.Units.Mobs;

namespace TutorialGame.Source.GamePlay.World.SpawnPoints
{
    internal class Portal : SpawnPoint
    {
        public Portal(Vector2 POS, int OWNERID, XElement DATA)
        : base("2d\\SpawnPoints\\Portal", POS, new Vector2(45, 45), OWNERID, DATA)
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
            int num = Globals.rand.Next(0, 100 + 1);
            Mob tempMob = null;
            int total = 0;

            for(var i = 0; i < mobChoices.Count; i++)
            {
                total += mobChoices[i].rate;

                if (num < total)
                {

                    // Can Be Expensive using Activator Methods
                    Type sType = Type.GetType(typeof(clsPlayer).Namespace + "." + mobChoices[i].mobType, true);
                    tempMob = (Mob)(Activator.CreateInstance(sType, new Vector2(pos.X, pos.Y), ownerId));

                    break;
                }
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
