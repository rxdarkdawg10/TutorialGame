using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TutorialGame.Source.Engine.Output;
using TutorialGame.Source.Engine;
using Microsoft.Xna.Framework;
using TutorialGame.Source.Engine.Basic2d;

namespace TutorialGame.Source.GamePlay.World
{
    internal class UI
    {
        public clsBasic2d pauseOverlay;
        public SpriteFont font;
        public QuantityDisplayBar healthBar;
        public Button2d resetBtn;
        public UI(PassObject RESET)
        {
            pauseOverlay = new clsBasic2d("2d\\Misc\\PauseOverlay", new Vector2(Globals.screenWidth/2, Globals.screenHeight/2), new(300,300));
            font = Globals.content.Load<SpriteFont>("Fonts\\Arial16");
            healthBar = new QuantityDisplayBar(
                new Vector2(104, 16),
                2,
                Color.Red
            );

            resetBtn = new Button2d(
                "2d\\Misc\\SimpleBtn",
                new Vector2(0,0),
                new Vector2(96,64),
                "Fonts\\Arial16",
                "Reset",
                RESET,
                null
                );
        }

        public void Update(clsWorld WORLD)
        {
            healthBar.Update(WORLD.user.hero.health, WORLD.user.hero.healthMax);

            if (WORLD.user.hero.dead || WORLD.user.buildings.Count <= 0)
            {
                resetBtn.Update(new Vector2(Globals.screenWidth / 2,
                    Globals.screenHeight / 2 + 100));
            }
        }

        public void Draw(clsWorld WORLD)
        {
            Globals.normalEffect.Parameters["xSize"].SetValue(1.0f);
            Globals.normalEffect.Parameters["ySize"].SetValue(1.0f);
            Globals.normalEffect.Parameters["xDraw"].SetValue(1.0f);
            Globals.normalEffect.Parameters["yDraw"].SetValue(1.0f);
            Globals.normalEffect.Parameters["filterColor"].SetValue(Color.White.ToVector4());
            Globals.normalEffect.CurrentTechnique.Passes[0].Apply();

            string tempStr = "Score = " + GameGlobals.score;
            Vector2 strDims = font.MeasureString(tempStr);

            Globals.spriteBatch.DrawString(
                font,
                tempStr,
                new Vector2(Globals.screenWidth / 2 - strDims.X / 2,
                Globals.screenHeight - 40),
                Color.Black
            );

            Globals.normalEffect.Parameters["filterColor"].SetValue(Color.White.ToVector4());
            Globals.normalEffect.CurrentTechnique.Passes[0].Apply();


            if (WORLD.user.hero.dead || WORLD.user.buildings.Count <= 0)
            {
                tempStr = "Press Enter or click the button to Restart!";
                strDims = font.MeasureString(tempStr);

                Globals.spriteBatch.DrawString(
                    font,
                    tempStr,
                    new Vector2(Globals.screenWidth / 2 - strDims.X / 2,
                    Globals.screenHeight / 2),
                    Color.Black
                );

                resetBtn.Draw(new Vector2(Globals.screenWidth / 2,
                    Globals.screenHeight / 2 + 100));
            }

            healthBar.Draw(new Vector2(20, Globals.screenHeight - 40));

            if(GameGlobals.paused)
            {
                pauseOverlay.Draw(Vector2.Zero);
            }
        }
    }
}
