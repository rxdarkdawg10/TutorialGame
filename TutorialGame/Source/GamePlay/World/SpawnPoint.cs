using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TutorialGame.Source.Engine;
using TutorialGame.Source.GamePlay.World.SpawnPoints;
using TutorialGame.Source.GamePlay.World.Units.Mobs;

namespace TutorialGame.Source.GamePlay.World
{
    internal class SpawnPoint : AttackableObject
    {
        public clsTimer spawnTimer = new clsTimer(2400);
        public List<MobChoice> mobChoices = new List<MobChoice>();
        public SpawnPoint(string PATH, Vector2 POS, Vector2 DIMS, int OWNERID, XElement DATA) : base(PATH, POS, DIMS, OWNERID)
        {
            dead = false;

            health = 3;
            healthMax = health;

            hitDist = 35;

            LoadData(DATA);
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

        public virtual void LoadData(XElement DATA)
        {
            if(DATA != null)
            {
                spawnTimer.AddToTimer(
                    Convert.ToInt32(DATA.Element("timerAdd").Value, Globals.culture)
                    );

                List<XElement> mobList = DATA.Descendants("mob").Select(s => s).ToList<XElement>();

                for (int i = 0; i < mobList.Count; i++)
                {
                    mobChoices.Add(new MobChoice(Convert.ToInt32(mobList[i].Attribute("rate").Value, Globals.culture), mobList[i].Value));
                }
            }
        }

        public virtual void SpawnMob()
        {
            GameGlobals.PassMob(new Imp(new Vector2(pos.X, pos.Y), ownerId));
        }

        public override void Draw(Vector2 OFFSET)
        {
            Globals.normalEffect.Parameters["xSize"].SetValue((float)myModel.Bounds.Width);
            Globals.normalEffect.Parameters["ySize"].SetValue((float)myModel.Bounds.Height);
            Globals.normalEffect.Parameters["xDraw"].SetValue((float)((int)dims.X));
            Globals.normalEffect.Parameters["yDraw"].SetValue((float)((int)dims.Y));
            Globals.normalEffect.Parameters["filterColor"].SetValue(Color.White.ToVector4());
            Globals.normalEffect.CurrentTechnique.Passes[0].Apply();

            base.Draw(OFFSET);
        }
    }
}
