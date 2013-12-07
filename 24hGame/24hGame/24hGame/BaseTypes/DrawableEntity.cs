using _24hGame.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _24hGame.BaseTypes
{
    public class DrawableEntity : Entity
    {
        Vector2 position;
        Vector2 originOffset;
        Vector2 size;
        TexturedQuad texture;
        bool interactable;
        float interactDistance;
        public Vector2 Position
        {
            get{return position;}
            set{position = value;}
        }
        public Vector2 Size
        {
            get
            {
                return size;
            }
            set
            {
                size = value;
            }
        }
        public Vector2 OriginOffset
        {
            get{return originOffset;}
            set{originOffset = value;}
        }

        public TexturedQuad Texture
        {
            get{return texture;}
            set{texture = value;}
        }
        public bool Interactable
        {
            get{return interactable;}
            set{interactable = value;}
        }
        public float InteractDistance
        {
            get{return interactDistance;}
            set{interactDistance = value;}
        }
    }
}