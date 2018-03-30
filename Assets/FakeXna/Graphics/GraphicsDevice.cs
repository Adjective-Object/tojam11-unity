using System;
using UnityEngine;
namespace Microsoft.Xna.Framework.Graphics
{
    // TODO this will hold the texture which is rendered to the quad, I think?
    public class GraphicsDevice
    {
        public Viewport Viewport;

        public PresentationParameters PresentationParameters
        {
            get
            {
                return new PresentationParameters(this.mTexture.width, this.mTexture.height);
            }
        }

        private UnityEngine.Texture2D mTexture;
        public GraphicsDevice(int width, int height)
        {
            this.mTexture = new UnityEngine.Texture2D(
                width,
                height,
                TextureFormat.RGB24,
                false // mipmap
            );
            Viewport = new Viewport(0, 0, this.mTexture.width, this.mTexture.height);
        }

        public static Rectangle GetTitleSafeArea(int x, int y, int width, int height)
        {
            return new Rectangle(x, y, width, height);
        }

        public void Clear(Color color)
        {
            UnityEngine.Color fillColor = new UnityEngine.Color(color.R, color.G, color.B);
            UnityEngine.Color[] fillColorArray = mTexture.GetPixels();

            for (var i = 0; i < fillColorArray.Length; ++i)
            {
                fillColorArray[i] = fillColor;
            }

            mTexture.SetPixels(fillColorArray);
            mTexture.Apply();
        }
    }
}
