using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _24hGame.Graphics
{
    class SimpleAnimation
    {
        Animation animation;
        int spriteWidth;
        public SimpleAnimation(Texture2D spriteSheet, int spriteWidth)
        {
            animation = new Animation(spriteSheet);
            this.spriteWidth = spriteWidth;
            CurrentFrame = 0;
        }

        public float CurrentFrame
        {
            get;
            set;
        }

        public void Draw(Vector2 location)
        {
            animation.Draw(location, spriteWidth, animation.Texture.Height, spriteWidth * ((int)CurrentFrame % (animation.Texture.Width / spriteWidth)), 0);
        }

        public void Draw(Vector2 location, float radians)
        {
            animation.Draw(location, spriteWidth, animation.Texture.Height, spriteWidth * ((int)CurrentFrame % (animation.Texture.Width / spriteWidth)), 0, radians);
        }

    }
}
