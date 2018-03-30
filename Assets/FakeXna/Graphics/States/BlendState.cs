using System;

namespace Microsoft.Xna.Framework.Graphics
{
    public struct BlendState
    {
        public static readonly BlendState Additive;
        public static readonly BlendState AlphaBlend;
        public static readonly BlendState NonPremultiplied;
        public static readonly BlendState Opaque;

        private string mName;
        private Blend mSourceBlend;
        private Blend mDestinationBlend;

        static BlendState()
        {
            Additive = new BlendState("BlendState.Additive", Blend.SourceAlpha, Blend.One);
            AlphaBlend = new BlendState("BlendState.AlphaBlend", Blend.One, Blend.InverseSourceAlpha);
            NonPremultiplied = new BlendState("BlendState.NonPremultiplied", Blend.SourceAlpha, Blend.InverseSourceAlpha);
            Opaque = new BlendState("BlendState.Opaque", Blend.One, Blend.Zero);
        }

        public BlendState(string name, Blend sourceBlend, Blend destinationBlend)
        {
            mName = name;
            mSourceBlend = sourceBlend;
            mDestinationBlend = destinationBlend;
        }
    }
}