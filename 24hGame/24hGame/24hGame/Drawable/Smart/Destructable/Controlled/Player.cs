using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using _24hGame.BaseTypes;
using _24hGame.Graphics;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using _24hGame.Components.Rooms;

namespace _24hGame.Drawable.Smart.Destructable.Controlled
{
	public class Player : ControlledEntity
	{
        Room room;
        public Player() {
            Position = new Vector2(100, 100);
            Texture = new TexturedQuad();
        }

        bool qDown, eDown;

		public void Initialize(Game1 game)
		{
			Position = new Vector2(100, 100);
			Texture = new TexturedQuad();
            Texture.Texture = game.Content.Load<Texture2D>(@"Textures\Player\animation upper part of the body\unarmed\unarmed1");
            HitPoints = 10;
            qDown = false;
		}

        public void Reset()
        {
            Position = new Vector2(100, 100);
            HitPoints = 10;
        }


		public void Draw(GameTime gameTime)
		{
			Texture.Draw(Position);
		}

		public bool Update(GameTime gameTime)
		{
            bool dead = false;
			Vector2 direction = Vector2.Zero;
			if (Keyboard.GetState().IsKeyDown(Keys.W))
				direction.Y += -1;
			if (Keyboard.GetState().IsKeyDown(Keys.A))
				direction.X += -1;
			if (Keyboard.GetState().IsKeyDown(Keys.S))
                direction.Y += 1;
            if (Keyboard.GetState().IsKeyDown(Keys.D))
                direction.X += 1;
            if (Keyboard.GetState().IsKeyDown(Keys.Q))
            {
                qDown = true;
            }
            else if (qDown)
            {
                qDown = false;
                HitPoints -= 2;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.E))
            {
                eDown = true;
            }
            else if (eDown)
            {
                eDown = false;
                room.Interact();
            }

			//dev
			Position += direction;
            // /dev
            if (HitPoints <= 0)
            {
                dead = true;
            }
            return dead;
		}

        public Room Room
        {
            get { return room; }
            set { room = value; }
        }
	}
}
