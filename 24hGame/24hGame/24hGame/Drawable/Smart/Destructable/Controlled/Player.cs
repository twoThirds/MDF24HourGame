﻿using System;
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
		Vector2 cursorPosition;
        Vector2 AimingDirection;
        public Player() 
        {
            Position = new Vector2(100, 100);
            //Texture = new TexturedQuad();
            velocity = Vector2.Zero;
            heading = new Vector2(0, 1);
            AimingDirection = Vector2.Zero;
        }

		SimpleAnimation unarmedTorso;
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
            legs = new SimpleAnimation(game.Content.Load<Texture2D>(@"Textures\Player\animation legs\legAnimation"), 32);
            legs.CurrentFrame += 4;

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
			float aimRadian = V2ToRadian(cursorPosition);
			aimRadian -= (float)Math.PI / 2.0f;
            legs.Draw(Position, headingRadian);
			//
			unarmedTorso.Draw(Position, aimRadian);
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

            //AimingDirection

            Position += velocity;

            legs.CurrentFrame += velocity.Length() * 14f * (float)gameTime.ElapsedGameTime.TotalSeconds;
            unarmedTorso.CurrentFrame += velocity.Length() * 14f * (float)gameTime.ElapsedGameTime.TotalSeconds;
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
