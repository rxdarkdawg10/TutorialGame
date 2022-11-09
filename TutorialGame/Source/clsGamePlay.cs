
using Microsoft.Xna.Framework;
using TutorialGame.Source.Engine;
using TutorialGame.Source.GamePlay;

namespace TutorialGame.Source
{
    internal class clsGamePlay
    {
        int playState;
        clsWorld world;
        PassObject ChangeGameState;

        public clsGamePlay(PassObject CHANGEGAMESTATE)
        {
            playState = 0;
            ChangeGameState = CHANGEGAMESTATE;
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
            world = new clsWorld(ResetWorld, ChangeGameState);
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
