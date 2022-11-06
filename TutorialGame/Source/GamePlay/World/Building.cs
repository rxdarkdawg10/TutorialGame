using Microsoft.Xna.Framework;


namespace TutorialGame.Source.GamePlay.World
{
    internal class Building : AttackableObject
    {
        public Building(string PATH, Vector2 POS, Vector2 DIMS, int OWNERID)
        : base(PATH, POS, DIMS, OWNERID)
        {

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
