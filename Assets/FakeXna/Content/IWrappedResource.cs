using System;
using Microsoft.Xna.Framework;

namespace FakeXna.Content
{
    public interface IWrappedResource
    {
        void setLoadedResource(Game game, Object resource);
    }
}
