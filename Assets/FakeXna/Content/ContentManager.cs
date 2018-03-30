using System;
namespace Microsoft.Xna.Framework.Content
{
    public class ContentManager
    {
        string mRootDirectory = "";
        Game mGame;

        public ContentManager(Game game) {
            this.mGame = game;
        }

        public T Load<T>(string filename) where T : FakeXna.Content.IWrappedResource
        {
            T result = default(T);
            Object loadedResource = UnityEngine.Resources.Load(
                System.IO.Path.Combine(mRootDirectory, filename)
            );
            result.setLoadedResource(mGame, loadedResource);
            return result;
        }

        public string RootDirectory {
            set
            {
                this.mRootDirectory = value;
            }
        }
    }

}
