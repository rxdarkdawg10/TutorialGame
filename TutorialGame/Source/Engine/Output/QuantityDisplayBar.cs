using Microsoft.Xna.Framework;


namespace TutorialGame.Source.Engine.Output
{
    internal class QuantityDisplayBar
    {
        public int border;
        public clsBasic2d bar, barBKG;
        public Color color;

        public QuantityDisplayBar(Vector2 DIMS, int BORDER, Color COLOR)
        {
            border = BORDER;
            color = COLOR;

            bar = new clsBasic2d(
                "2d\\Misc\\Solid",
                new Vector2(0, 0),
                new Vector2(DIMS.X - border * 2, DIMS.Y - border * 2));

            barBKG = new clsBasic2d(
                "2d\\Misc\\Shade",
                new Vector2(0, 0),
                new Vector2(DIMS.X, DIMS.Y));
        }

        public virtual void Update(float CURRENT, float MAX)
        {
            bar.dims = new Vector2(CURRENT / MAX * (barBKG.dims.X - border * 2), bar.dims.Y);
        }

        public virtual void Draw(Vector2 OFFSET)
        {
            Globals.normalEffect.Parameters["xSize"].SetValue(1.0f);
            Globals.normalEffect.Parameters["ySize"].SetValue(1.0f);
            Globals.normalEffect.Parameters["xDraw"].SetValue(1.0f);
            Globals.normalEffect.Parameters["yDraw"].SetValue(1.0f);
            Globals.normalEffect.Parameters["filterColor"].SetValue(Color.Black.ToVector4());
            Globals.normalEffect.CurrentTechnique.Passes[0].Apply();

            barBKG.Draw(
                OFFSET,
                new Vector2(0, 0),
                Color.Black
            );

            Globals.normalEffect.Parameters["filterColor"].SetValue(color.ToVector4());
            Globals.normalEffect.CurrentTechnique.Passes[0].Apply();

            bar.Draw(
                OFFSET + new Vector2(border, border),
                new Vector2(0, 0),
                color
            );
        }
    }
}
