using _24hGame.BaseTypes;
using _24hGame.Components.Rooms;
using _24hGame.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _24hGame.Drawable
{
    public class Projectile : SmartEntity
    {
		Vector2 direction;
		Game1 game;
		Room containingRoom;
		float velocity;
        float projectileWidth; // Used for finding hits

		public Projectile(Vector2 direction, Game1 game, Room containingRoom, float velocity)
        {
			this.direction = direction;
			this.direction.Normalize();
			this.game = game;
			this.containingRoom = containingRoom;
			this.velocity = velocity;
			Position = new Vector2(50, 50);
			Texture = new TexturedQuad();
			Texture.Texture = game.Content.Load<Texture2D>(@"Textures\ui\pistol bullet");
        }
        public override void Update(GameTime gameTime)
		{
			float distance = (float)gameTime.ElapsedGameTime.TotalMilliseconds / 1000.0f;
			Vector2 traveled = new Vector2(direction.X, direction.Y);
			traveled.X *= distance*velocity;
			traveled.Y *= distance*velocity;
			Position += traveled;
			//dev
			if(Position.X > containingRoom.RoomSize.X || Position.Y > containingRoom.RoomSize.Y)
			{
				this.Remove = true;
			}
			//dev
        }
		public override void Draw(GameTime gameTime)
		{
			Texture.Draw(Position);
		}

		public float Velocity
		{
			get{return velocity;}
            set { velocity = value; }
		}
    }

}
