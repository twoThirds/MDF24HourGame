using _24hGame.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _24hGame.BaseTypes
{
    class DrawableEntity : Entity
    {
        Vector2 position;
        Vector2 originOffset;
        TexturedQuad texture;

        public Vector2 Position
        {
            get
            {
                return position;
            }
            set
            {
                position = value;
            }
        }

        public Vector2 OriginOffset
        {
            get
            {
                return originOffset;
            }
            set
            {
                originOffset = value;
            }
        }

        public TexturedQuad Texture
        {
            get
            {
                return texture;
            }
            set
            {
                texture = value;
            }
        }
    }   
}