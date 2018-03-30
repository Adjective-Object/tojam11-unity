using System;
namespace Microsoft.Xna.Framework.Graphics
{
    public class Texture2D : FakeXna.Content.IWrappedResource
    {
        UnityEngine.Texture2D mTexture;
        GraphicsDevice mDevice;

        /// <summary>
        /// Empty constructor for use by ContentManager loading, later initialized in SetLoadedResource
        /// </summary>
        public Texture2D(GraphicsDevice device, int width, int height)
        {
            this.mTexture = new UnityEngine.Texture2D(width, height);
            this.mDevice = device;
        }

        /// <summary>
        /// </summary>
        public Texture2D()
        {
        }


        public void setLoadedResource(Game game, Object o)
        {
            mDevice = game.GraphicsDevice;
            mTexture = (UnityEngine.Texture2D)o;
        }

        public Rectangle Bounds
        {
            get
            {
                return new Rectangle(0, 0, mTexture.width, mTexture.height);
            }
        }

        public void GetData<T>(Color[] outColorArray) {
            GetData(outColorArray);
        }

        public void GetData(Color[] outColorArray)
        {
            UnityEngine.Color[] colors = this.mTexture.GetPixels();
            int minLength = Math.Min(colors.Length, outColorArray.Length);
            for (int i = 0; i < minLength; i++)
            {
                outColorArray[i] = new Color(colors[i].r, colors[i].g, colors[i].b, colors[i].a);
            }
        }


        public void SetData(Color[] intendedTextureColors)
        {
            UnityEngine.Color[] textureColors = this.mTexture.GetPixels();
            int minLength = Math.Min(textureColors.Length, intendedTextureColors.Length);
            for (int i = 0; i < minLength; i++)
            {
                textureColors[i] = new UnityEngine.Color(intendedTextureColors[i].R, intendedTextureColors[i].G, intendedTextureColors[i].B, intendedTextureColors[i].A);
            }
            this.mTexture.SetPixels(textureColors);
            this.mTexture.Apply();
        }

        public int Width
        {
            get
            {
                return this.mTexture.width;
            }
        }

        public int Height
        {
            get
            {
                return this.mTexture.height;
            }
        }

        public GraphicsDevice GraphicsDevice
        {
            get
            {
                return this.mDevice;
            }
        }
    }
}

