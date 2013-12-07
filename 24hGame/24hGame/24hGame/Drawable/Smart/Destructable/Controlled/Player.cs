using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using _24hGame.BaseTypes;
using _24hGame.Graphics;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace _24hGame.Drawable.Smart.Destructable.Contrelled
{
	public class Player : ControlledEntity
	{
		TexturedQuad texture;
		Vector2 position;

		public void Initialize(Game1 game)
		{
			position = new Vector2(100, 100);
			texture = new TexturedQuad();
			texture.Texture = game.Content.Load<Texture2D>("derp");
		}

		public void Draw(GameTime gameTime)
		{
			texture.Draw(position);
		}
        public void Update(){
        }
		public void Update(GameTime gameTime)
		{
			Vector2 direction = Vector2.Zero;
			if (Keyboard.GetState().IsKeyDown(Keys.W))
				direction.Y += -1;
			if (Keyboard.GetState().IsKeyDown(Keys.A))
				direction.X += -1;
			if (Keyboard.GetState().IsKeyDown(Keys.S))
				direction.Y += 1;
			if (Keyboard.GetState().IsKeyDown(Keys.D))
				direction.X += 1;

			//dev
			position += direction;
			// /dev
		}
	}
}
