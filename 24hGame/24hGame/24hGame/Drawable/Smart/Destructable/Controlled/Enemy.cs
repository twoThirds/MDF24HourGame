using _24hGame.BaseTypes;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _24hGame.Drawable.Smart.Destructable.Controlled
{
    public class Enemy : ControlledEntity
    {
        public DestructableEntity target;
        public void setTarget(DestructableEntity target)
        {
            this.target = target;
        }
        public void Draw(GameTime gameTime)
        {
            Texture.Draw(Position);
        }

        //returns wether or not its dead
        public void Update(GameTime gameTime)
        {
            if (target != null)
            {
                if (Vector2.Distance(Position, target.Position) < AttackRange)
                {
                    target.HitPoints -= Damage;
                }
            }
        }
    }
}
