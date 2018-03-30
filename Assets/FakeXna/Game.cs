using System;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
namespace Microsoft.Xna.Framework
{
    public abstract class Game
    {
        public ContentManager Content;

        public GraphicsDevice GraphicsDevice;

        public Game()
        {
            Content = new ContentManager(this);
        }

        // TODO implement IsMouseVisible
        protected bool IsMouseVisible { get { return false; } set { } }

        protected virtual void Initialize() { }
        protected virtual void LoadContent() { }
        protected virtual void Update(GameTime time) { }
        protected virtual void Draw(GameTime gameTime) { }

        public void Exit() {
            // TODO kill game in unity context? might not even be needed
        }


        /// Unused. Signature provided so Monogame entrypoiny does not throw compilation 
        public void Run() {}

        /// Unused. Signature provided so Monogame entrypoiny does not throw compilation errors
        public void Dispose() {}
    }
}
