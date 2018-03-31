using System;
namespace Microsoft.Xna.Framework.Graphics
{
    // TODO updating the size of the graphics device on the texture
    public class GraphicsDeviceManager
    {
        private int mPreferredBackBufferWidth = 800;
        private int mPreferredBackBufferHeight = 600;
        private GraphicsDevice mGraphicsDevice = null;
        private Game mBoundGame;

        public GraphicsDevice GraphicsDevice
        {
            get
            {
                if (mGraphicsDevice == null)
                {
                    ApplyChanges();
                }
                return mGraphicsDevice;
            }
        }

        public int PreferredBackBufferWidth
        {
            get
            {
                return mPreferredBackBufferWidth;
            }
            set
            {
                this.mPreferredBackBufferWidth = value;

            }
        }

        public int PreferredBackBufferHeight
        {
            get
            {
                return mPreferredBackBufferHeight;
            }
            set
            {
                this.mPreferredBackBufferHeight = value;
            }
        }

        public void ApplyChanges()
        {
            mGraphicsDevice = new GraphicsDevice(
                mPreferredBackBufferWidth,
                mPreferredBackBufferHeight
                );
            mBoundGame.GraphicsDevice = mGraphicsDevice;
        }

        public GraphicsDeviceManager(Game game)
        {
            this.mBoundGame = game;
        }
    }
}
