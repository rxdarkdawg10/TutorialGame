using Microsoft.Xna.Framework;
using TutorialGame.Source.Engine;

namespace TutorialGame.Source.GamePlay.World
{
    internal class AttackableObject : clsBasic2d
    {
        public int ownerId;
        public bool dead;
        public float speed, hitDist, health, healthMax;
        public AttackableObject(string PATH, Vector2 POS, Vector2 DIMS, int OWNERID) : base(PATH, POS, DIMS)
        {
            ownerId = OWNERID;
            dead = false;
            speed = 2.0f;
            health = 1;
            healthMax = health;
            hitDist = 35;
        }

        public virtual void Update(Vector2 OFFSET, clsPlayer ENEMY)
        {
            base.Update(OFFSET);
        }

        public virtual void GetHit(float DAMAGE)
        {
            health -= DAMAGE;

            if (health <= 0)
            {
                dead = true;
            }
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
