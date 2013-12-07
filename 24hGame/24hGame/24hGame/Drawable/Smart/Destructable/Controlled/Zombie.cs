using _24hGame.BaseTypes;
using _24hGame.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _24hGame.Drawable.Smart.Destructable.Controlled
{
    class Zombie: Enemy
    {
        public override void Load(Game1 game)
        {
            Position = new Vector2(200, 200);
            Texture = new TexturedQuad();
            Texture.Texture = game.Content.Load<Texture2D>("derp");
            HitPoints = 10;
            AttackRange = 10;
            Damage = 3;
        }
    }
}
