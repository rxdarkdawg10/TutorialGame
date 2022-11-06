using Microsoft.Xna.Framework;
using TutorialGame.Source.Engine;
using TutorialGame.Source.GamePlay.World.Projectiles;

namespace TutorialGame.Source.GamePlay.World.Buildings
{
    internal class ArrowTower : Building
    {
        int range;
        clsTimer shotTimer = new clsTimer(1200);
        public ArrowTower(Vector2 POS, int OWNERID)
        : base("2d\\Buildings\\ArrowTower", POS, new Vector2(45, 45), OWNERID)
        {
            range = 220;
            health = 10;
            healthMax = health;

            hitDist = 35.0f;
        }

        public override void Update(Vector2 OFFSET, clsPlayer ENEMY)
        {
            shotTimer.UpdateTimer();
            if(shotTimer.Test())
            {
                FireArrow(ENEMY);
                shotTimer.ResetToZero();
            }
            base.Update(OFFSET);
        }

        public virtual void FireArrow(clsPlayer ENEMY)
        {
            float closestDist = range, currentDist = 0;
            Unit closest = null;

            for(int i = 0; i < ENEMY.units.Count; i++)
            {
                currentDist = Globals.GetDistance(pos, ENEMY.units[i].pos);

                if(closestDist > currentDist)
                {
                    closestDist = currentDist;
                    closest = ENEMY.units[i];
                }
            }

            if(closest != null)
            {
                GameGlobals.PassProjectile(new Arrow(new Vector2(pos.X, pos.Y), this, new Vector2(closest.pos.X, closest.pos.Y)));
            }
        }

        public override void Draw(Vector2 OFFSET)
        {
            base.Draw(OFFSET);
        }
    }
}
