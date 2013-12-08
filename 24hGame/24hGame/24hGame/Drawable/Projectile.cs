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
        float projectileWidth; // Used for finding hits
        TexturedQuad texture;

		public Projectile(Vector2 direction, Game1 game, Room containingRoom)
        {
			this.direction = direction;
			this.game = game;
			this.containingRoom = containingRoom;
			Position = new Vector2(50, 50);
			Texture = new TexturedQuad();
			Texture.Texture = game.Content.Load<Texture2D>(@"Textures\ui\pistol bullet");
        }
        public override void Update(GameTime gameTime)
		{
			float distance = (float)gameTime.ElapsedGameTime.TotalMilliseconds / 1000.0f;
			Vector2 traveled = new Vector2(direction.X, direction.Y);
			traveled.X *= distance;
			traveled.Y *= distance;
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
    }

}
