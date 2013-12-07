using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _24hGame.Graphics
{
    public struct Quad
    {
        public Vector3 Origin;
        public Vector3 UpperLeft;
        public Vector3 LowerLeft;
        public Vector3 UpperRight;
        public Vector3 LowerRight;
        public Vector3 Normal;
        public Vector3 Up;
        public Vector3 Left;

        public VertexPositionNormalTexture[] Vertices;
        public short[] Indexes;


        public Quad(Vector3 origin, Vector3 normal, Vector3 up,
            float width, float height)
        {
            Vertices = new VertexPositionNormalTexture[4];
            Indexes = new short[6];
            Origin = origin;
            Normal = normal;
            Up = up;

            // Calculate the quad corners
            Left = Vector3.Cross(normal, Up);
            Vector3 uppercenter = (Up * height / 2) + origin;
            UpperLeft = uppercenter + (Left * width / 2);
            UpperRight = uppercenter - (Left * width / 2);
            LowerLeft = UpperLeft - (Up * height);
            LowerRight = UpperRight - (Up * height);

            FillVertices();
        }

        private void FillVertices()
        {
            // Fill in texture coordinates to display full texture
            // on quad
            Vector2 textureUpperLeft = new Vector2(0.0f, 1.0f);
            Vector2 textureUpperRight = new Vector2(1.0f, 1.0f);
            Vector2 textureLowerLeft = new Vector2(0.0f, 0.0f);
            Vector2 textureLowerRight = new Vector2(1.0f, 0.0f);

            // Provide a normal for each vertex
            for (int i = 0; i < Vertices.Length; i++)
            {
                Vertices[i].Normal = Normal;
            }

            // Set the position and texture coordinate for each
            // vertex
            Vertices[0].Position = LowerLeft;
            Vertices[0].TextureCoordinate = textureLowerLeft;
            Vertices[1].Position = UpperLeft;
            Vertices[1].TextureCoordinate = textureUpperLeft;
            Vertices[2].Position = LowerRight;
            Vertices[2].TextureCoordinate = textureLowerRight;
            Vertices[3].Position = UpperRight;
            Vertices[3].TextureCoordinate = textureUpperRight;

            // Set the index buffer for each vertex, using
            // clockwise winding
            Indexes[0] = 0;
            Indexes[1] = 1;
            Indexes[2] = 2;
            Indexes[3] = 2;
            Indexes[4] = 1;
            Indexes[5] = 3;
        }
    }

    public class TexturedQuad
    {
        static Quad quad;
        static BasicEffect quadEffect;
		static VertexDeclaration vertexDeclaration;
		static Game1 game;
		static public void Initialize(Game1 game)
        {
            quad = new Quad(Vector3.Zero, Vector3.Backward, Vector3.Up, 1, 1);

            quadEffect = new BasicEffect(game.GraphicsDevice);
            //quadEffect.EnableDefaultLighting();
            quadEffect.View = game.View;
            quadEffect.Projection = game.Projection;
            quadEffect.TextureEnabled = true;

			vertexDeclaration = new VertexDeclaration(new VertexElement[]
                {
                    new VertexElement(0, VertexElementFormat.Vector3, VertexElementUsage.Position, 0),
                    new VertexElement(12, VertexElementFormat.Vector3, VertexElementUsage.Normal, 0),
                    new VertexElement(24, VertexElementFormat.Vector2, VertexElementUsage.TextureCoordinate, 0)
                }
			);

			TexturedQuad.game = game;
        }

		Texture2D texture;
		public Texture2D Texture
		{
			get
			{
				return texture;
			}
			set
			{
				texture = value;
			}
		}
        public TexturedQuad()
        {
			texture = null;
        }

		public void Draw(Vector2 location)
		{
			if (texture != null)
			{
				quadEffect.Texture = texture;
				quadEffect.World = Matrix.CreateScale(Texture.Width, Texture.Height, 1) * Matrix.CreateTranslation(new Vector3(location, 0));

				//RasterizerState raster = new RasterizerState(); raster.CullMode = CullMode.None; game.GraphicsDevice.RasterizerState = raster;

				foreach (EffectPass pass in quadEffect.CurrentTechnique.Passes)
				{
					pass.Apply();
					game.GraphicsDevice.DrawUserIndexedPrimitives<VertexPositionNormalTexture>(PrimitiveType.TriangleList, quad.Vertices, 0, 4, quad.Indexes, 0, 2);
				}
			}
		}

		public void Draw(Vector2 location, float radians)
		{
			if (texture != null)
			{
				quadEffect.Texture = texture;
				quadEffect.World = Matrix.CreateScale(Texture.Width, Texture.Height, 1) * Matrix.CreateRotationZ(radians) * Matrix.CreateTranslation(new Vector3(location, 0));
				foreach (EffectPass pass in quadEffect.CurrentTechnique.Passes)
				{
					pass.Apply();
					game.GraphicsDevice.DrawUserIndexedPrimitives<VertexPositionNormalTexture>(PrimitiveType.TriangleList, quad.Vertices, 0, 4, quad.Indexes, 0, 2);
				}
			}
		}

    }
}
