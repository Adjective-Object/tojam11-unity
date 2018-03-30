using System;
using UnityEngine;
namespace Microsoft.Xna.Framework.Graphics
{
    // TODO this will hold the texture which is rendered to the quad, I think?
    public class GraphicsDevice : IDisposable
    {
        public Viewport Viewport;

        public PresentationParameters PresentationParameters
        {
            get
            {
                return new PresentationParameters(this.mTexture.width, this.mTexture.height);
            }
        }

        private RenderTexture mTexture;
        public GraphicsDevice(int width, int height)
        {
            this.mTexture = new RenderTexture(
                width,
                height,
                24, // depth (bits in depth buffer)
                RenderTextureFormat.ARGB32
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
            RenderTexture.active = mTexture;
            // TODO abstract accross different rendering backends. Maybe use blit here with a
            // 1 px texture so that untiy handles that abstraction for us?
            GL.Begin(GL.TRIANGLES);
            GL.Clear(true, true, fillColor);
            GL.End();
        }

        // Perform cleanup on garbage collect
        public void Dispose()
        {
            mTexture.Release();
        }
    }
}
