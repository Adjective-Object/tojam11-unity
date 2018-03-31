using System;
namespace Microsoft.Xna.Framework.Graphics
{
    public class SpriteFont : FakeXna.Content.IWrappedResource
    {
        UnityEngine.GUIStyle style = new UnityEngine.GUIStyle();

        // TODO
        public int spacing {
            get { return 0; }
        }

        UnityEngine.Font font;
        public void setLoadedResource(Game game, Object o)
        {
            font = (UnityEngine.Font)o;
            style.font = font;
        }

        public Vector2 MeasureString(string body)
        {
            UnityEngine.Vector2 size = style.CalcSize(new UnityEngine.GUIContent(body));
            return new Vector2(
                size.x,
                size.y
                );
        }
    }
}

