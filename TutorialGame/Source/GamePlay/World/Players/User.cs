using Microsoft.Xna.Framework;
using TutorialGame.Source.Engine;
using TutorialGame.Source.GamePlay.World.Buildings;
using TutorialGame.Source.GamePlay.World.Units;

namespace TutorialGame.Source.GamePlay.World.Players
{
    internal class User : clsPlayer
    {
        public User(int ID)
        : base(ID)
        {
            hero = new Hero("2d\\hero", new Vector2(300, 300), new Vector2(48, 48), id);

            buildings.Add(new Tower(new Vector2(Globals.screenWidth / 2, Globals.screenHeight / 2), id));
        }

        public override void Update(clsPlayer ENEMY, Vector2 OFFSET)
        {
            base.Update(ENEMY, OFFSET);
        }
    }
}
