using Microsoft.Xna.Framework;
using System.Collections.Generic;
using TutorialGame.Source.Engine;

namespace TutorialGame.Source.GamePlay.World
{
    internal class Projectile2d : Basic2d
    {
        public float speed;
        public Vector2 direction;
        public bool done;
        public clsTimer timer;
        public Unit owner;

        public Projectile2d(string PATH, Vector2 POS, Vector2 DIMS, Unit OWNER, Vector2 TARGET) : base(PATH, POS, DIMS)
        {
            done = false;
            speed = 5.0f;
            owner = OWNER;

            direction = TARGET - owner.pos;
            direction.Normalize();

            rot = Globals.RotateTowards(pos, new Vector2(TARGET.X, TARGET.Y));

            timer = new clsTimer(1500);
        }

        public virtual void Update(Vector2 OFFSET, List<AttackableObject> UNITS)
        {
            pos += direction * speed;



            timer.UpdateTimer();
            if (timer.Test())
            {
                done = true;
            }

            if (HitSomething(UNITS))
            {
                done = true;
            }
        }

        public virtual bool HitSomething(List<AttackableObject> UNITS)
        {
            for (int i = 0; i < UNITS.Count; i++)
            {
                if (owner.ownerId != UNITS[i].ownerId && Globals.GetDistance(pos, UNITS[i].pos) < UNITS[i].hitDist)
                {
                    UNITS[i].GetHit(1);
                    return true;
                }
            }
            return false;
        }

        public override void Draw(Vector2 OFFSET)
        {
            base.Draw(OFFSET);
        }
    }
}
