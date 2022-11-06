using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TutorialGame.Source.Engine.Output;
using TutorialGame.Source.Engine;
using Microsoft.Xna.Framework;

namespace TutorialGame.Source.GamePlay.World
{
    internal class UI
    {
        public SpriteFont font;
        public QuantityDisplayBar healthBar;
        public UI()
        {
            font = Globals.content.Load<SpriteFont>("Fonts\\Arial16");
            healthBar = new QuantityDisplayBar(
                new Vector2(104, 16),
                2,
                Color.Red
            );
        }

        public void Update(clsWorld WORLD)
        {
            healthBar.Update(WORLD.user.hero.health, WORLD.user.hero.healthMax);
        }

        public void Draw(clsWorld WORLD)
        {
            string tempStr = "Score = " + GameGlobals.score;
            Vector2 strDims = font.MeasureString(tempStr);

            Globals.spriteBatch.DrawString(
                font,
                tempStr,
                new Vector2(Globals.screenWidth / 2 - strDims.X / 2,
                Globals.screenHeight - 40),
                Color.Black
            );

            healthBar.Draw(new Vector2(20, Globals.screenHeight - 40));

            if (WORLD.user.hero.dead || WORLD.user.buildings.Count <= 0)
            {
                tempStr = "Press Enter to Restart";
                strDims = font.MeasureString(tempStr);

                Globals.spriteBatch.DrawString(
                    font,
                    tempStr,
                    new Vector2(Globals.screenWidth / 2 - strDims.X / 2,
                    Globals.screenHeight / 2),
                    Color.Black
                );
            }
        }
    }
}
