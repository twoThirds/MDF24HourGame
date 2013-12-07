using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using _24hGame.Graphics;
using _24hGame.Drawable.Smart.Destructable.Contrelled;
using _24hGame.GameEngine;

namespace _24hGame
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
		Player tmpPlayer;
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Engine engine;

        public Matrix View
        {
            get;
            set;
        }

        public Matrix Projection
        {
            get;
            set;
        }

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
			graphics.PreferredBackBufferHeight = 600;
			graphics.PreferredBackBufferWidth = 800;
        }

        static Game1()
        {
            random = new Random();
        }
        static Random random;
        static public Random Random
        {
            get
            {
                return random;
            }
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            View = Matrix.CreateLookAt(new Vector3(0, 0, -10), Vector3.Zero, Vector3.Up);
			Projection = Matrix.CreateOrthographic(GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height, 1.0f, 100.0f);
            engine = new Engine();
			//Projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.PiOver4, 4.0f / 3.0f, 1, 500);

			TexturedQuad.Initialize(this);
			tmpPlayer = new Player();
			tmpPlayer.Initialize(this);
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();
			tmpPlayer.Update(gameTime);
            // TODO: Add your update logic here
            
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
			spriteBatch.Begin();
			//spriteBatch.Draw(tq.Texture, new Rectangle(0, 0, 50, 50), Color.White);
			spriteBatch.End();
			tmpPlayer.Draw(gameTime);
            // TODO: Add your drawing code here
            engine.RenderWorld(gameTime);
            base.Draw(gameTime);
        }
    }
}
