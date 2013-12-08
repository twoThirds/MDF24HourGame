using _24hGame.BaseTypes;
using _24hGame.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _24hGame.Drawable.Smart
{
    class TreasureChest:SmartEntity
	{
		bool open;
		public override void Load(Game1 game)
		{
			Position = new Vector2(400, 200);
			Texture = new TexturedQuad();
			Texture.Texture = game.Content.Load<Texture2D>(@"Textures\items\ammo");
			Interactable = true;
			Remove = false;
			InteractDistance = 20;
		}

		public override void Draw(GameTime gameTime)
		{
			Texture.Draw(Position);
		}

		public override void Update(GameTime gameTime)
		{
		}

		public override void Interact()
		{
			Remove = true;
		}
    }
}
