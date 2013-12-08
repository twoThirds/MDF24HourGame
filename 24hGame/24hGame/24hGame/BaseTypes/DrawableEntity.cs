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
		bool remove;
        float interactDistance;
        public virtual void Interact(){}
        public virtual void Load(Game1 game){}
        public virtual void Update(GameTime gameTime) { }
        public virtual void Draw(GameTime gameTime) { }
        public Vector2 Position
        {
            get{return position;}
            set{position = value;}
        }
        public Vector2 Size
        {
            get{return size;}
            set{size = value;}
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
		public bool Remove
		{
			get { return remove; }
			set { remove = value; }
		}
    }
}