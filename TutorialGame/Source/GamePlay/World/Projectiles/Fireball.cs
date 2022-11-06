using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutorialGame.Source.GamePlay.World.Projectiles
{
    internal class Fireball : Projectile2d
    {
        public Fireball(Vector2 POS, Unit OWNER, Vector2 TARGET)
        : base("2d\\Projectiles\\Fireball", POS, new Vector2(20, 20), OWNER, TARGET)
        {

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
