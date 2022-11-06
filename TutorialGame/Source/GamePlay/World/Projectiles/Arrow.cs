using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutorialGame.Source.GamePlay.World.Projectiles
{
    internal class Arrow : Projectile2d
    {
        public Arrow(Vector2 POS, AttackableObject OWNER, Vector2 TARGET)
        : base("2d\\Projectiles\\Arrow", POS, new Vector2(20, 20), OWNER, TARGET)
        {
            speed = 10.0f;
            timer = new Engine.clsTimer(800);
        }

        public override void Update(Vector2 OFFSET, List<AttackableObject> UNITS)
        {
            base.Update(OFFSET, UNITS);
        }

        public override void Draw(Vector2 OFFSET)
        {
            base.Draw(OFFSET);
        }
    }
}
