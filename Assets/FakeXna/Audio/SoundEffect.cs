using System;
namespace Microsoft.Xna.Framework.Audio
{
    public class SoundEffect : FakeXna.Content.IWrappedResource
    {
        UnityEngine.AudioClip mAudioClip;
        public void setLoadedResource(Game game, Object o)
        {
            mAudioClip = (UnityEngine.AudioClip)o;
        }

        public SoundEffectInstance CreateInstance()
        {
            return new SoundEffectInstance(mAudioClip);
        }
    }
}
