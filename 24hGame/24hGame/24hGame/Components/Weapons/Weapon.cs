using _24hGame.Drawable.Smart.Destructable.Controlled;
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
        public enum GripType
        {
            Unarmed,
            Pistol,
            Rifle,
            Swingable,
            Heavy,
            Shoulder,
            Gadget
        }

        TexturedQuad idleTexture;
        SimpleAnimation shootingAnimation;
        bool isShooting;
        Game1 game;
        GripType gripType;
        public GripType Grip
        {
            get
            {
                return gripType;
            }
            set
            {
                gripType = value;
            }
        }
        Vector2 playerOffset;
        public Vector2 PlayerOffset
        {
            get
            {
                return playerOffset;
            }
            set
            {
                playerOffset = value;
            }
        }


        public Weapon(Game1 game)
        {
            this.game = game;
            isShooting = false;
        }

        public virtual void Initialize(string idleTextureName, string shootingAnimationName, int shootingAnimationWidth)
        {
            idleTexture = new TexturedQuad(game.Content.Load<Texture2D>(idleTextureName));
            shootingAnimation = new SimpleAnimation(game.Content.Load<Texture2D>(shootingAnimationName), shootingAnimationWidth);
        }

        public virtual void Draw(GameTime gameTime)
        {
            if (isShooting || shootingAnimation.CurrentFrame != 0)
                shootingAnimation.Draw(game.Engine.Player.Position + playerOffset);
        }

        public virtual void Update(GameTime gameTime)
        {
            //if(!isShooting)
        }
    }
}
