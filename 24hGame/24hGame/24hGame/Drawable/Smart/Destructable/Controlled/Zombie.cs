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
    class Zombie: ControlledEntity
    {
        public DestructableEntity target;
        public void setTarget(DestructableEntity target)
        {
            this.target = target;
        }
        public void Load(Game1 game)
        {
            Position = new Vector2(500, 200);
            Texture = new TexturedQuad();
            Texture.Texture = game.Content.Load<Texture2D>("derp");
            HitPoints = 10;
            attackRange = 10;
        }
        public void Draw(GameTime gameTime)
        {
            Texture.Draw(Position);
        }

        //returns wether or not its dead
        public bool Update(GameTime gameTime)
        {
            return true;
        }
    }
}
