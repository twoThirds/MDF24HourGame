using _24hGame.BaseTypes;
using _24hGame.Drawable;
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

        public float RateOfFire
        {
            get;
            set;
        }
        /// <summary>
        /// Returns the time per attack, calculated from RateOfFire / 60
        /// </summary>
        public float TimePerAttack
        {
            get
            {
                return RateOfFire / 60f;
            }
        }
        public float TimeUntilNextAttack
        {
            get;
            set;
        }
        public float Damage
        {
            get;
            set;
        }
        public float Range
        {
            get;
            set;
        }
        public SoundEffectCollection AttackSounds
        {
            get;
            set;
        }
        public float ProjectileVelocity
        {
            get;
            set;
        }
        /// <summary>
        /// Radian saying how much the shooting will jump around
        /// </summary>
        public float WeaponInaccuracy
        {
            get;
            set;
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
            if (isShooting || shootingAnimation.CurrentFrame != 0f)
                shootingAnimation.Draw(game.Engine.Player.Position + playerOffset);
        }

        public virtual void Update(GameTime gameTime)
        {
            isShooting = false;
            if (TimeUntilNextAttack > 0)
                TimeUntilNextAttack -= (float)gameTime.ElapsedGameTime.TotalSeconds;


        }

        public virtual void Fire(GameTime gameTime, List<Projectile> ProjectilesCollection)
        {

            if(TimeUntilNextAttack <= 0)
            {
                int shotsPerFrame = (int)(gameTime.ElapsedGameTime.TotalSeconds / TimePerAttack);
                while (shotsPerFrame > 0)
                {
                    SpawnProjectile(shotsPerFrame * TimePerAttack, ProjectilesCollection);
                    shotsPerFrame--;
                }
                AttackSounds.PlayRandom();

                TimeUntilNextAttack = TimePerAttack;
            }

        }

        private void SpawnProjectile(float headStart, List<Projectile> ProjectilesCollection)
        {
            float shootingAngle = Utility.V2ToAngle(game.Engine.Player.AimingDirection);
            if(WeaponInaccuracy != 0f)
            {
                // Make your aim jump around when you shoot
                float aimJump = (float)(Game1.Random.NextDouble() * WeaponInaccuracy * 2);
                aimJump -= WeaponInaccuracy;
                shootingAngle += aimJump;
            }
            Vector2 direction = Utility.AngleToV2(shootingAngle, 1);
            direction.Normalize();
            //Projectile projectile = new Projectile(direction, game, game.Engine.Player.Room, ProjectileVelocity);
            Projectile projectile = new Projectile(direction, game, game.Engine.Player.Room);

            //ProjectilesCollection.Add(projectile);
        }
    }
}
