using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _24hGame.Graphics
{
    class Animation
    {
        TexturedQuad texturedQuad;

        public Animation(Texture2D animationSheet)
        {
            texturedQuad = new TexturedQuad();
            texturedQuad.Texture = animationSheet;
        }

        public Texture2D Texture
        {
            get
            {
                return texturedQuad.Texture;
            }
            set
            {
                texturedQuad.Texture = value;
            }
        }

        public void Draw(Vector2 location, int width, int height, int x, int y)
        {
            texturedQuad.Draw(location, new Rectangle(x, y, width, height));
        }

        public void Draw(Vector2 location, int width, int height, int x, int y, float radians)
        {
            texturedQuad.Draw(location, new Rectangle(x, y, width, height), radians);
        }
    }
}
