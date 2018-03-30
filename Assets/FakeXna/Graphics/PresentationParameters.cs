using System;
using FakeXna;
namespace Microsoft.Xna.Framework.Graphics
{
    // A dummy object not used for anything. Whoops!
    public class PresentationParameters
    {
        private int mBackBufferWidth;
        private int mBackBufferHeight;
        public PresentationParameters(int backbufferWidth, int backBufferHeight)
        {
            this.mBackBufferWidth = backbufferWidth;
            this.mBackBufferHeight = backBufferHeight;
        }

        public Rectangle Bounds
        {
            // TODO tie to initialization of FakeXna Object
            get {
                return new Rectangle(0, 0, mBackBufferWidth, mBackBufferHeight);
            }
        }

        public int BackBufferWidth
        {
            get
            {
                return mBackBufferWidth;
            }
        }

        public int BackBufferHeight
        {
            get
            {
                return mBackBufferHeight;
            }
        }

    }
}
