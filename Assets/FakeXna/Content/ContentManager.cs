using System;
namespace Microsoft.Xna.Framework.Content
{
    public class ContentManager
    {
        string mRootDirectory = "";
        string mXnaResourcesRootPath = "";
        Game mGame;

        public ContentManager(Game game) {
            this.mGame = game;
        }

        public void SetResourcesRootPath(String xnaRootPath) {
            mXnaResourcesRootPath = xnaRootPath;
        }

        public T Load<T>(string filename) where T : FakeXna.Content.IWrappedResource, new()
        {
            T result = new T();
            string loadedPath = System.IO.Path.Combine(System.IO.Path.Combine(mXnaResourcesRootPath, mRootDirectory), filename);
            Object loadedResource = UnityEngine.Resources.Load(
                loadedPath
                );
            if (loadedResource == null) {
                UnityEngine.Debug.LogWarning(
                    "Failed to load resource at path " + loadedPath
                    );
            }
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
