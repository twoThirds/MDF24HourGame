using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _24hGame.BaseTypes
{
    public class ControlledEntity : DestructableEntity
    {
        int attackRange;
        int damage;
        public int AttackRange
        {
            get
            {
                return attackRange;
            }
            set
            {
                attackRange = value;
            }
        }
        public int Damage
        {
            get
            {
                return damage;
            }
            set
            {
                damage = value;
            }
        }
        protected Vector2 velocity;
        public virtual Vector2 Velocity
        {
            get
            {
                return velocity;
            }
            set
            {
                velocity = value;
            }
        }
        protected Vector2 heading;
        public virtual Vector2 Heading
        {
            get
            {
                return heading;
            }
            set
            {
                heading = value;
            }
        }
    }
}
