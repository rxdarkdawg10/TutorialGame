﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TutorialGame.Source.Engine;

namespace TutorialGame.Source.Engine.Basic2d
{
    internal class Button2d : clsBasic2d
    {
        public bool isPressed, isHovered;
        public string text;
        public Color hoverColor;
        public SpriteFont font;
        public object info;

        PassObject ButtonClicked;

        public Button2d(string PATH, Vector2 POS, Vector2 DIMS,
            string FONTPATH, string TEXT, PassObject BUTTONCLICKED,
            object INFO) : base(PATH, POS, DIMS)
        {
            info = INFO;
            text = TEXT;
            ButtonClicked = BUTTONCLICKED;

            if(FONTPATH != "")
            {
                font = Globals.content.Load<SpriteFont>(FONTPATH);
            }

            isPressed = false;
            hoverColor = new Color(200, 230, 255);
        }

        public virtual void Update(Vector2 OFFSET)
        {

            if(Hover(OFFSET))
            {
                isHovered = true;
                if (Globals.mouse.LeftClick())
                {
                    isPressed = true;
                    isHovered = false;
                }
                else if(Globals.mouse.LeftClickRelease())
                {
                    RunBtnClick();
                }
            }
            else
            {
                isHovered = false;
            }

            if(!Globals.mouse.LeftClick() && !Globals.mouse.LeftClickHold())
            {
                isPressed = false;
            }

            base.Update(OFFSET);
        }

        public virtual void Reset()
        {
            isPressed = false;
            isHovered = false;
        }

        public virtual void RunBtnClick()
        {
            if(ButtonClicked != null)
            {
                ButtonClicked(info);
            }

            Reset();
        }

        public override void Draw(Vector2 OFFSET)
        {
            Color tempColor = Color.White;

            if(isPressed)
            {
                tempColor = Color.Gray;
            }
            else if(isHovered)
            {
                tempColor = hoverColor;
            }


            Globals.normalEffect.Parameters["xSize"].SetValue((float)myModel.Bounds.Width);
            Globals.normalEffect.Parameters["ySize"].SetValue((float)myModel.Bounds.Height);
            Globals.normalEffect.Parameters["xDraw"].SetValue((float)((int)dims.X));
            Globals.normalEffect.Parameters["yDraw"].SetValue((float)((int)dims.Y));
            Globals.normalEffect.Parameters["filterColor"].SetValue(tempColor.ToVector4());
            Globals.normalEffect.CurrentTechnique.Passes[0].Apply();

            base.Draw(OFFSET);

            Vector2 strDims = font.MeasureString(text);

            Globals.spriteBatch.DrawString(
                font,
                text,
                pos + OFFSET + new Vector2(-strDims.X / 2,
                -strDims.Y/2),
                Color.Black
            );
        }
    }
}
