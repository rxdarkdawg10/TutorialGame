using Microsoft.Xna.Framework;
using TutorialGame.Source.Engine;

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
