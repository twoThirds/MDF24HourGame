using _24hGame.BaseTypes;
using _24hGame.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _24hGame.Drawable.Smart.Destructable
{
    class VictoryDoor : DestructableEntity
    {
        public bool hacking;


        public void Initialize(Game1 game)
        {
            Position = new Vector2(100, 100);
            Texture = new TexturedQuad();
            Texture.Texture = game.Content.Load<Texture2D>("derp");
            hacking = false;
            Interactable = true;
            InteractDistance = 50;
        }

        public override void Draw(GameTime gameTime)
        {
            Texture.Draw(Position);
        }

        public void interact()
        {
        }
    }
}
