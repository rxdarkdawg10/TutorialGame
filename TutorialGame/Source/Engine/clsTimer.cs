﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TutorialGame.Source.Engine
{
    internal class clsTimer
    {
        public bool goodToGo;
        protected int mSec;
        protected TimeSpan timer = new TimeSpan();

        public clsTimer(int M)
        {
            goodToGo = false;
            mSec = M;
        }

        public clsTimer(int M, bool STARTLOADED)
        {
            goodToGo = STARTLOADED;
            mSec = M;
        }

        public int MSec
        {
            get { return mSec; }
            set { mSec = value; }
        }

        public int Timer
        {
            get { return (int)timer.TotalMilliseconds; }
        }

        public void UpdateTimer()
        {
            timer += Globals.gameTime.ElapsedGameTime;
        }

        public void UpdateTimer(float SPEED)
        {
            timer += TimeSpan.FromTicks((long)(Globals.gameTime.ElapsedGameTime.Ticks * SPEED));
        }

        public virtual void AddToTimer(int MSEC)
        {
            timer += TimeSpan.FromMilliseconds((long)(MSEC));
        }

        public bool Test()
        {
            if (timer.TotalMilliseconds >= mSec || goodToGo)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Reset()
        {
            timer = timer.Subtract(new TimeSpan(0, 0, mSec / 60000, mSec / 1000, mSec % 1000));
            if (timer.TotalMilliseconds < 0)
            {
                timer = TimeSpan.Zero;
            }

            goodToGo = false;
        }

        public void Reset(int NEWTIMER)
        {
            timer = TimeSpan.Zero;
            MSec = NEWTIMER;
            goodToGo = false;
        }

        public void ResetToZero()
        {
            timer = TimeSpan.Zero;
            goodToGo = false;
        }

        public virtual XElement ReturnXML()
        {
            XElement xml = new XElement("Timer",
                new XElement("mSec", mSec),
                new XElement("timer", Timer));

            return xml;
        }

        public void SetTimer(TimeSpan TIME)
        {
            timer = TIME;
        }

        public virtual void SetTimer(int MSEC)
        {
            timer = TimeSpan.FromMilliseconds((long)(MSEC));
        }
    }
}
