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

        #region UnityInterop
        public void Start()
        {
            this.Initialize();
        }

        public void Update()
        {
            GameTime time = new GameTime(
                new TimeSpan(0, 0, 0, (int)(UnityEngine.Time.deltaTime * 1000)),
                new TimeSpan(0, 0, 0, (int)(UnityEngine.Time.realtimeSinceStartup * 1000))
            );
            this.Update(time);
            this.Draw(time);
        }
        #endregion

        // TODO implement IsMouseVisible
        protected bool IsMouseVisible { get { return false; } set { } }

        protected virtual void Initialize() {
            // subclass inits in override, then we load content
            this.LoadContent();
        }
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
