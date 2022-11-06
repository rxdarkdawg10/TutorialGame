using Microsoft.Xna.Framework;
using System.Collections.Generic;
using TutorialGame.Source.Engine;
using TutorialGame.Source.GamePlay.World.Projectiles;

namespace TutorialGame.Source.GamePlay.World
{
    internal class Projectile2d : Basic2d
    {
        public float speed;
        public Vector2 direction;
        public bool done;
        public clsTimer timer;
        public AttackableObject owner;

        public Projectile2d(string PATH, Vector2 POS, Vector2 DIMS, AttackableObject OWNER, Vector2 TARGET) : base(PATH, POS, DIMS)
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
            Globals.normalEffect.Parameters["xSize"].SetValue((float)myModel.Bounds.Width);
            Globals.normalEffect.Parameters["ySize"].SetValue((float)myModel.Bounds.Height);
            Globals.normalEffect.Parameters["xDraw"].SetValue((float)((int)dims.X));
            Globals.normalEffect.Parameters["yDraw"].SetValue((float)((int)dims.Y));
            Globals.normalEffect.Parameters["filterColor"].SetValue(Color.White.ToVector4());
            Globals.normalEffect.CurrentTechnique.Passes[0].Apply();

            base.Draw(OFFSET);
        }
    }
}
