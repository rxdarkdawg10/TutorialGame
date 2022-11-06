using Microsoft.Xna.Framework;


namespace TutorialGame.Source.GamePlay.World.Buildings
{
    internal class Tower : Building
    {
        public Tower(Vector2 POS, int OWNERID)
        : base("2d\\Buildings\\Tower", POS, new Vector2(45, 45), OWNERID)
        {
            health = 20;
            healthMax = health;

            hitDist = 35.0f;
        }

        public override void Update(Vector2 OFFSET, clsPlayer ENEMY)
        {
            base.Update(OFFSET);
        }

        public override void Draw(Vector2 OFFSET)
        {
            base.Draw(OFFSET);
        }
    }
}
