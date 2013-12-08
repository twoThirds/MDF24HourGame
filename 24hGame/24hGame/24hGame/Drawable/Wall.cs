using _24hGame.BaseTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using _24hGame.Graphics;
using Microsoft.Xna.Framework.Graphics;

namespace _24hGame.Drawable
{
    class Wall:DumbEntity
    {
		public Wall(Game1 game, Vector2 position)
		{

			Texture = new TexturedQuad();
			Load(game);
			this.Position = position;
			Remove = false;
			//specific to this sprite
			Vector2 mySize = new Vector2(100, 100);
			Size = mySize;
		}

		public void Load(Game1 game)
		{
			Texture.Texture = game.Content.Load<Texture2D>(@"Textures\Location\wood theme\walls\wall 10");

		}

		public override void Draw(GameTime gameTime)
		{
			Texture.Draw(Position);
		}
    }
}
