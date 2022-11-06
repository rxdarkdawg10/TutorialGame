using Microsoft.Xna.Framework;
using System.Xml.Linq;
using TutorialGame.Source.Engine;
using TutorialGame.Source.GamePlay.World.SpawnPoints;

namespace TutorialGame.Source.GamePlay.World.Players
{
    internal class AIPlayer : clsPlayer
    {
        public AIPlayer(int ID, XElement DATA)
        : base(ID, DATA)
        {
            //spawnPoints.Add(new Portal(new Vector2(50, 50), id));


            //spawnPoints.Add(new Portal(new Vector2(Globals.screenWidth / 2, 50), id));
            //spawnPoints[spawnPoints.Count - 1].spawnTimer.AddToTimer(500);

            //spawnPoints.Add(new Portal(new Vector2(Globals.screenWidth - 50, 50), id));
            //spawnPoints[spawnPoints.Count - 1].spawnTimer.AddToTimer(1000);
        }

        public override void Update(clsPlayer ENEMY, Vector2 OFFSET)
        {
            base.Update(ENEMY, OFFSET);
        }

        public override void ChangeScore(int SCORE)
        {
            GameGlobals.score += SCORE;
        }
    }
}
