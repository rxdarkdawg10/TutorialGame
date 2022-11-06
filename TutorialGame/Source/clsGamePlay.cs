
using Microsoft.Xna.Framework;
using TutorialGame.Source.GamePlay;

namespace TutorialGame.Source
{
    internal class clsGamePlay
    {
        int playState;
        clsWorld world;

        public clsGamePlay()
        {
            playState = 0;
            ResetWorld(null);
        }

        public virtual void Update()
        {
            if (playState == 0)
            {
                world.Update();
            }
        }

        public virtual void ResetWorld(object INFO)
        {
            world = new clsWorld(ResetWorld);
        }

        public virtual void Draw()
        {
            if (playState == 0)
            {
                world.Draw(Vector2.Zero);
            }
        }
    }
}
