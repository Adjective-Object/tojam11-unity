using System;
using FakeXna.Audio;
namespace Microsoft.Xna.Framework.Audio
{
    public class SoundEffectInstance
    {
        UnityEngine.AudioClip mAudioClip;
        UnityEngine.AudioSource mAudioSource;
        internal SoundEffectInstance(Object o)
        {
            mAudioClip = (UnityEngine.AudioClip)o;
            mAudioSource = SoundEffectInstanceManager.instance.CreateAudioSource();
        }

        /// <summary>Enables or Disables whether the SoundEffectInstance should repeat after playback.</summary>
        /// <remarks>This value has no effect on an already playing sound.</remarks>
        public virtual bool IsLooped
        {
            get { return mAudioSource.loop; }
            set { mAudioSource.loop = value; }
        }

        /// <summary>Gets or sets the pan, or speaker balance..</summary>
        /// <value>Pan value ranging from -1.0 (left speaker) to 0.0 (centered), 1.0 (right speaker). Values outside of this range will throw an exception.</value>
        public float Pan
        {
            get { return mAudioSource.panStereo; }
            set { mAudioSource.panStereo = value; }
        }

        /// <summary>Gets or sets the pitch adjustment.</summary>
        /// <value>Pitch adjustment, ranging from -1.0 (down an octave) to 0.0 (no change) to 1.0 (up an octave). Values outside of this range will throw an Exception.</value>
        public float Pitch
        {
            get { return mAudioSource.pitch; }
            set { mAudioSource.pitch = value; }
        }

        /// <summary>Gets or sets the volume of the SoundEffectInstance.</summary>
        /// <value>Volume, ranging from 0.0 (silence) to 1.0 (full volume). Volume during playback is scaled by SoundEffect.MasterVolume.</value>
        /// <remarks>
        /// This is the volume relative to SoundEffect.MasterVolume. Before playback, this Volume property is multiplied by SoundEffect.MasterVolume when determining the final mix volume.
        /// </remarks>
        public float Volume
        {
            get { return mAudioSource.volume; }
            set { mAudioSource.volume = value; }
        }

        /// <summary>Gets the SoundEffectInstance's current playback state.</summary>
        public virtual SoundState State {
            get {
                if (mAudioSource.isPlaying)
                {
                    return SoundState.Playing;
                }
                // epsilon because floats
                else if (mAudioSource.time <= 0.00001)
                {
                    return SoundState.Paused;
                }
                else
                {
                    return SoundState.Stopped;
                }
            }
        }

        // TODO maybe clean up audio sources or something
        /// <summary>Indicates whether the object is disposed.</summary>
        public bool IsDisposed {
            get { return false; }
        }

        public void Play()
        {
            mAudioSource.Play();
        }
    }
}
