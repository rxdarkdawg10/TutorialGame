using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using TutorialGame.Source.Engine.Input.CustomKeyboard;

namespace TutorialGame.Source.Engine.Input
{
    internal class clsKeyboard
    {
        public KeyboardState newKeyboard, oldKeyboard;
        public List<clsKey> pressedKeys = new List<clsKey>(), previousPressedKeys = new List<clsKey>();
        public clsKeyboard()
        {
        }

        public virtual void Update()
        {
            newKeyboard = Keyboard.GetState();

            GetPressedKeys();
        }

        public void UpdateOld()
        {
            oldKeyboard = newKeyboard;
            previousPressedKeys = new List<clsKey>();
            for (int i = 0; i < pressedKeys.Count; i++)
            {
                previousPressedKeys.Add(pressedKeys[i]);
            }
        }

        public bool GetPress(string KEY)
        {
            for (int i = 0; i < pressedKeys.Count; i++)
            {
                if (pressedKeys[i].key == KEY)
                {
                    return true;
                }
            }

            return false;
        }

        public virtual void GetPressedKeys()
        {
            bool found = false;
            pressedKeys.Clear();
            for (int i = 0; i < newKeyboard.GetPressedKeys().Length; i++)
            {
                pressedKeys.Add(new clsKey(newKeyboard.GetPressedKeys()[i].ToString(), 1));
            }
        }
    }
}
