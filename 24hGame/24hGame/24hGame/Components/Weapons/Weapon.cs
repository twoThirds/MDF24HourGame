using _24hGame.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _24hGame.Components.Weapons
{
    class Weapon
    {
        TexturedQuad idleTexture;
        SimpleAnimation shootingAnimation;
        bool isShooting;
        Game1 game;

        string idleResource;
        string shootintResource;

        public Weapon(Game1 game)
        {
            this.game = game;
            isShooting = false;
        }

        public virtual void Initialize()
        {
            //idleTexture = new TexturedQuad(game.Content.Load<Texture2D>(idleResource));
            //idleTexture = ;
            //shootingAnimation = game.Content.Load<Texture2D>(shootingResource);
        }

        public virtual void Draw(GameTime gameTime)
        {

        }
    }
}
