using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using TutorialGame.Source.Engine.Input;

namespace TutorialGame.Source.Engine
{
    public delegate void PassObject(object obj);
    public delegate object PassObjectAndReturn(object obj);

    internal class Globals
    {
        public static System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("en-US");
        public static int screenHeight, screenWidth;
        public static Random rand = new Random();
        public static ContentManager content;
        public static SpriteBatch spriteBatch;

        public static Effect normalEffect;

        public static clsKeyboard keyboard;
        public static clsMouseControl mouse;

        public static GameTime gameTime;

        public static float GetDistance(Vector2 POS, Vector2 TARGET)
        {
            return (float)Math.Sqrt(Math.Pow(POS.X - TARGET.X, 2) + Math.Pow(POS.Y - TARGET.Y, 2));
        }

        public static Vector2 RadialMovement(Vector2 FOCUS, Vector2 POS, float SPEED)
        {
            float dist = Globals.GetDistance(POS, FOCUS);
            if (dist <= SPEED)
            {
                return FOCUS - POS;
            }
            else
            {
                return (FOCUS - POS) * SPEED / dist;
            }
        }

        public static float RotateTowards(Vector2 POS, Vector2 FOCUS)
        {
            float h, sineTheta, angle;
            if (POS.Y - FOCUS.Y != 0)
            {
                h = (float)Math.Sqrt(Math.Pow(POS.X - FOCUS.X, 2) + Math.Pow(POS.Y - FOCUS.Y, 2));
                sineTheta = (float)(Math.Abs(POS.Y - FOCUS.Y) / h); // * ((item.Pos.Y - FOCUS.Y) / Math.Abs(item.Pos.Y - FOCUS.Y))));
            }
            else
            {
                h = POS.X - FOCUS.X;
                sineTheta = 0;
            }

            angle = (float)Math.Asin(sineTheta);

            // Drawing diagnal lines here
            // Quadrant 2
            if (POS.X - FOCUS.X > 0 && POS.Y - FOCUS.Y > 0)
            {
                angle = (float)(Math.PI * 3 / 2 + angle);
            }

            // Quadrant 3
            else if (POS.X - FOCUS.X > 0 && POS.Y - FOCUS.Y < 0)
            {
                angle = (float)(Math.PI * 3 / 2 - angle);
            }

            // Quadrant 1
            else if (POS.X - FOCUS.X < 0 && POS.Y - FOCUS.Y > 0)
            {
                angle = (float)(Math.PI / 2 - angle);
            }
            else if (POS.X - FOCUS.X < 0 && POS.Y - FOCUS.Y < 0)
            {
                angle = (float)(Math.PI / 2 + angle);
            }
            else if (POS.X - FOCUS.X > 0 && POS.Y - FOCUS.Y == 0)
            {
                angle = (float)(Math.PI * 3 / 2);
            }
            else if (POS.X - FOCUS.X < 0 && POS.Y - FOCUS.Y == 0)
            {
                angle = (float)(Math.PI / 2);
            }
            else if (POS.X - FOCUS.X == 0 && POS.Y - FOCUS.Y > 0)
            {
                angle = (float)0;
            }
            else if (POS.X - FOCUS.X == 0 && POS.Y - FOCUS.Y < 0)
            {
                angle = (float)(Math.PI);
            }

            return angle;
        }
    }
}
