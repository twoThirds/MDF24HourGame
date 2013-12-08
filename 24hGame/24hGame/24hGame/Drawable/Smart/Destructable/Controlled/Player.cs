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
using _24hGame.Components.Weapons;

namespace _24hGame.Drawable.Smart.Destructable.Controlled
{
	public class Player : ControlledEntity
	{
        Room room;
		Vector2 cursorPosition;
        Vector2 aimingDirection;
        public Player() 
        {
            Position = new Vector2(100, 100);
            //Texture = new TexturedQuad();
            velocity = Vector2.Zero;
            heading = new Vector2(0, 1);
            aimingDirection = Vector2.Zero;
            weapons = new List<Weapon>();
            currentWeapon = null;
        }

        List<Weapon> weapons;
        Weapon currentWeapon;

        public Vector2 AimingDirection
        {
            get
            {
                return aimingDirection;
            }
            set
            {
                aimingDirection = value;
            }
        }

        SimpleAnimation unarmedTorso;
        SimpleAnimation pistolTorso;
        SimpleAnimation legs;
		SimpleAnimation cursorTexture;

        bool qDown, eDown;

		public void Initialize(Game1 game)
		{
			Position = new Vector2(100, 100);
			Texture = new TexturedQuad();
			cursorPosition = new Vector2(0, 0);
			cursorTexture = new SimpleAnimation(game.Content.Load<Texture2D>(@"Textures\ui\aim"), 13);
            unarmedTorso = new SimpleAnimation(game.Content.Load<Texture2D>(@"Textures\Player\animation upper part of the body\unarmed\UnarmedAnimation"), 32);
            pistolTorso = new SimpleAnimation(game.Content.Load<Texture2D>(@"Textures\Player\animation upper part of the body\pistol\PistolAnimation"), 32);
            legs = new SimpleAnimation(game.Content.Load<Texture2D>(@"Textures\Player\animation legs\legAnimation"), 32);
            legs.CurrentFrame += 4;

            weapons.Add(DummyWeaponFactory.GeneratePistol(game));
            currentWeapon = weapons[0];

            HitPoints = 10;
            qDown = false;
		}

        public void Reset()
        {
            Position = new Vector2(100, 100);
            HitPoints = 10;
        }


		public override void Draw(GameTime gameTime)
		{
			float headingRadian = V2ToRadian(heading);
			headingRadian -= (float)Math.PI / 2.0f;
            float aimRadian = V2ToRadian(AimingDirection);
			aimRadian -= (float)Math.PI / 2.0f;
            legs.Draw(Position, headingRadian);
			//
            if (currentWeapon == null)
                unarmedTorso.Draw(Position, aimRadian);
            else
            {
                switch(currentWeapon.Grip)
                {
                    case Weapon.GripType.Pistol:
                        pistolTorso.Draw(Position, aimRadian);
                        break;
                    default:
                        unarmedTorso.Draw(Position, aimRadian);
                        break;
                }
                Game1.RenderDebugText(currentWeapon.Description, new Vector2(10, 10), true);
                currentWeapon.Draw(gameTime);
            }
			cursorTexture.Draw(cursorPosition);
		}

        private float V2ToRadian(Vector2 direction)
        {
            return (float)Math.Atan2(direction.Y, direction.X);
        }

		public bool Update(GameTime gameTime)
		{
            bool dead = false;
			Vector2 direction = Vector2.Zero;
            direction += (GamePad.GetState(PlayerIndex.One).ThumbSticks.Left);
            direction.Y *= -1;

			//position modification
			if (Keyboard.GetState().IsKeyDown(Keys.W))
				direction.Y += -1;
			if (Keyboard.GetState().IsKeyDown(Keys.A))
				direction.X += -1;
			if (Keyboard.GetState().IsKeyDown(Keys.S))
                direction.Y += 1;
            if (Keyboard.GetState().IsKeyDown(Keys.D))
                direction.X += 1;

            if (direction.Length() > 0.1)
                direction.Normalize();

			//interaction and attacking
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

			cursorPosition.X = Mouse.GetState().X;
			cursorPosition.Y = Mouse.GetState().Y;
			//dev
            direction *= 3;
            float targetVelocityDiff = direction.Length() / velocity.Length();
            if(direction.Length() > 0 && velocity.Length() > 0)
            {
                float directionAngle = (float)Math.Atan2(direction.Y, direction.X);
                float velocityAngle = (float)Math.Atan2(velocity.Y, velocity.X);
                float targetAngleDiff;
                if (velocityAngle == 0)
                    velocityAngle = 0.00000001f;
                targetAngleDiff = directionAngle / velocityAngle;
            }


            velocity = direction;

            if (velocity.Length() > 0)
            {
                heading = velocity;
                heading.Normalize();
            }
            else
            { 
                legs.CurrentFrame = 0;
                unarmedTorso.CurrentFrame = 4;
            }

            Vector2 aim = cursorPosition - Position;
            if (aim.Length() > 0)
            {
                AimingDirection = aim;
                AimingDirection.Normalize();
            }

            Position += velocity;

            legs.CurrentFrame += velocity.Length() * 14f * (float)gameTime.ElapsedGameTime.TotalSeconds;
            unarmedTorso.CurrentFrame += velocity.Length() * 14f * (float)gameTime.ElapsedGameTime.TotalSeconds;
            // /dev
            if (HitPoints <= 0)
            {
                dead = true;
            }

            int i;
            for (i = 0; i < weapons.Count; i++)
                weapons[i].Update(gameTime);

                return dead;
		}

        public Room Room
        {
            get { return room; }
            set { room = value; }
        }
	}
}
