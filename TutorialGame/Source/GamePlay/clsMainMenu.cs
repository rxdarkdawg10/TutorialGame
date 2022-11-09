using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TutorialGame.Source.Engine;
using TutorialGame.Source.Engine.Basic2d;

namespace TutorialGame.Source.GamePlay
{
    internal class clsMainMenu
    {
        public clsBasic2d bkg;
        public clsBasic2d btn_bkg;
        public PassObject PlayClickDel, ExitClickDel;
        public List<Button2d> buttons = new List<Button2d>();

        public clsMainMenu(PassObject PLAYCLICKDEL, PassObject EXITCLICKDEL)
        {
            PlayClickDel = PLAYCLICKDEL;
            ExitClickDel = EXITCLICKDEL;

            bkg = new clsBasic2d(
                "2d\\Misc\\Solid",
                new Vector2(Globals.screenWidth / 2, Globals.screenHeight / 2),
                new Vector2(Globals.screenWidth, Globals.screenHeight)
                );

            btn_bkg = new clsBasic2d(
                "2d\\UI\\Backgrounds\\MainMenuBkg",
                new Vector2(325, 625),
                new Vector2(300, 216)
                );

            buttons.Add(new Button2d(
                "2d\\Misc\\SimpleBtn",
                new Vector2(0,0),
                new Vector2(96,64),
                "Fonts\\Arial16",
                "Play",
                PlayClickDel,
                1
                ));

            buttons.Add(new Button2d(
                "2d\\Misc\\SimpleBtn",
                new Vector2(0, 0),
                new Vector2(96, 64),
                "Fonts\\Arial16",
                "Exit",
                ExitClickDel,
                null
                ));
        }

        public virtual void Update()
        {
            for(int i = 0; i < buttons.Count; i++)
            {
                buttons[i].Update(new Vector2(340, 600 + 72 * i));
            }
        }

        public virtual void Draw()
        {
            bkg.Draw(Vector2.Zero);
            btn_bkg.Draw(Vector2.Zero);
            for (int i = 0; i < buttons.Count; i++)
            {
                buttons[i].Draw(new Vector2(340, 600 + 72 * i));
            }
        }
    }
}
