
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TutorialGame.Source.Engine
{
    internal class Basic2d
    {
        public float rot;
        public Vector2 pos, dims;
        public Texture2D myModel;

        public Basic2d(string PATH, Vector2 POS, Vector2 DIMS)
        {
            pos = POS;
            dims = DIMS;

            myModel = Globals.content.Load<Texture2D>(PATH);
        }

        public virtual void Update(Vector2 OFFSET)
        {

        }

        public virtual void Draw(Vector2 OFFSET)
        {
            if (myModel != null)
            {
                Globals.spriteBatch.Draw(
                    myModel,
                    new Rectangle((int)(pos.X + OFFSET.X), (int)(pos.Y + OFFSET.Y), (int)dims.X, (int)dims.Y),
                    null,
                    Color.White,
                    rot,
                    new Vector2(myModel.Bounds.Width / 2, myModel.Bounds.Height / 2),
                    new SpriteEffects(),
                    0);
            }
        }

        public virtual void Draw(Vector2 OFFSET, Vector2 ORIGIN, Color COLOR)
        {
            if (myModel != null)
            {
                Globals.spriteBatch.Draw(
                    myModel,
                    new Rectangle((int)(pos.X + OFFSET.X), (int)(pos.Y + OFFSET.Y), (int)dims.X, (int)dims.Y),
                    null,
                    COLOR,
                    rot,
                    new Vector2(ORIGIN.X, ORIGIN.Y),
                    new SpriteEffects(),
                    0);
            }
        }
    }
}
