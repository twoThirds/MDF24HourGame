using _24hGame.BaseTypes;
using _24hGame.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _24hGame.Drawable.Smart
{
    class DangerDoor:DestructableEntity
    {
        bool open;
        TexturedQuad openTexture, closedTexture;
        public override void Load(Game1 game)
        {
            Position = new Vector2(300, 300);
            openTexture = new TexturedQuad();
            closedTexture = new TexturedQuad();
            openTexture.Texture = game.Content.Load<Texture2D>(@"Textures\Location\wood theme\doors\door frame opened 50");
            closedTexture.Texture = game.Content.Load<Texture2D>(@"Textures\Location\wood theme\doors\door frame closed 50");
            Texture = closedTexture;
            open = false;
            Interactable = true;
            InteractDistance = 20;
        }

        public override void Draw(GameTime gameTime)
        {
            Texture.Draw(Position);
        }

        public override void Update(GameTime gameTime)
        {
        }

        public override void Interact()
        {
            if(open)
            {
                open = false;
                Texture = closedTexture;
            }
            else
            {
                open = true;
                Texture = openTexture;
            }
        }
    }
}
