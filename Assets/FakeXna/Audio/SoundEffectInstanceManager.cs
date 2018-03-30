using System;
using System.Collections.Generic;
using UnityEngine;
using QuickUnityTools;
namespace FakeXna.Audio
{
    public class SoundEffectInstanceManager : Singleton<SoundEffectInstanceManager>
    {
        public AudioSource CreateAudioSource()
        {
            return gameObject.AddComponent<AudioSource>();
        }
    }
}
