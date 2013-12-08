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
using _24hGame.Drawable.Smart.Destructable.Controlled;
using _24hGame.GameEngine;

namespace _24hGame
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
		Texture2D gameGuiBackground;
        SpriteBatch spriteBatch;
		Texture2D cursorTexture;
		Vector2 cursorPosition;
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
			engine = new Engine(this);
			//Takes path to an XML file and loads a level

			engine.Load("D:/placeholder.xml");
			//Projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.PiOver4, 4.0f / 3.0f, 1, 500);

            View = Matrix.CreateLookAt(new Vector3(0, 0, -10), Vector3.Zero, Vector3.Down);
			Projection = Matrix.CreateOrthographicOffCenter(0, GraphicsDevice.Viewport.Width, -GraphicsDevice.Viewport.Height, 0, 1.0f, 100.0f);


			TexturedQuad.Initialize(this);
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
			cursorTexture = Content.Load<Texture2D>(@"Textures\ui\aim");
			gameGuiBackground = Content.Load<Texture2D>("gameGuiBackground");
			debugTexturedQuad = new TexturedQuad(Content.Load<Texture2D>("debug"));
            animationTest = new SimpleAnimation(Content.Load<Texture2D>("animationtest"), 32);
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

			if (Keyboard.GetState().IsKeyDown(Keys.Escape))
				this.Exit();

            // TODO: Add your update logic here
			cursorPosition = new Vector2(Mouse.GetState().X, Mouse.GetState().Y);
			engine.UpdateWorld(gameTime);
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
			// Remove back-face culling, this is not really a great thing to do
			RasterizerState raster = new RasterizerState();
			raster.CullMode = CullMode.None;
			//GraphicsDevice.RasterizerState = raster;

			// Render game graphics (NOT Gui here)

            DrawDebugGraphics(gameTime);
			engine.RenderWorld(gameTime);
			// Do not draw anu more game graphics after this point

			// Spritebatch MUST be placed after all other rendering is done, or raster needs to be set again
			spriteBatch.Begin();
				spriteBatch.Draw(gameGuiBackground, new Vector2(0, 0), Color.White);
				// Render GUI AFTER this line
				spriteBatch.Draw(cursorTexture, cursorPosition, Color.White);

				// Render GUI BEFORE this line
			spriteBatch.End();
            base.Draw(gameTime);
        }

        TexturedQuad debugTexturedQuad;
        SimpleAnimation animationTest;
        Vector2 debugTexturedQuadLocation = new Vector2(100, 50);
		float debugTexturedQuadRotation = 0;
		private void DrawDebugGraphics(GameTime gameTime)
		{
			debugTexturedQuadLocation.Y += 1f;
			debugTexturedQuad.Draw(debugTexturedQuadLocation);
			debugTexturedQuad.Draw(new Vector2(0, 0), 0);
			debugTexturedQuadRotation += 1f;
            debugTexturedQuad.Draw(new Vector2(0, 50), MathHelper.ToRadians(debugTexturedQuadRotation));


            //debugTexturedQuad.Draw(new Vector2(300, 300), new Vector4(0, 0, 25, 25), MathHelper.ToRadians(debugTexturedQuadRotation));
            debugTexturedQuad.Draw(new Vector2(300, 300), new Rectangle(25, 25, 75, 75), MathHelper.ToRadians(debugTexturedQuadRotation));


            animationTest.Draw(new Vector2(500, 300));
            animationTest.CurrentFrame += 1f * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }
    }
}
