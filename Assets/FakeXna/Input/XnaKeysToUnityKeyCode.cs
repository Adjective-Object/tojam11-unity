using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace FakeXna.Input
{
    class XnaKeysToUnityKeyCode
    {
        private static Dictionary<Keys, UnityEngine.KeyCode> mKeycodeMap = new Dictionary<Keys, UnityEngine.KeyCode>
        {
            {Keys.Space, UnityEngine.KeyCode.Space},
            {Keys.Up, UnityEngine.KeyCode.UpArrow},
            {Keys.Down, UnityEngine.KeyCode.DownArrow},
            {Keys.Left, UnityEngine.KeyCode.LeftArrow},
            {Keys.Right, UnityEngine.KeyCode.RightArrow},
        };

        private static Dictionary<UnityEngine.KeyCode, Keys> mKeycodeReverseMap = null;

        public static UnityEngine.KeyCode XnaToUnity(Keys xnaKey)
        {
            if (!mKeycodeMap.ContainsKey(xnaKey)) {
                /*UnityEngine.Debug.LogWarning(string.Format(
                    "Requested XNA keycode {0} is not defined in map",
                    xnaKey
                ));*/
                return UnityEngine.KeyCode.Escape;
            }
            return mKeycodeMap[xnaKey];
        }

        public static Keys UnityToXna(UnityEngine.KeyCode unityKeyCode)
        {
            if (mKeycodeReverseMap == null)
            {
                InitKeycodeReverseMap();
            }
            if (!mKeycodeReverseMap.ContainsKey(unityKeyCode)) {
                /*UnityEngine.Debug.LogWarning(string.Format(
                    "Requested unity keycode {0} is not defined in map",
                    unityKeyCode
                ));*/
                return Keys.Escape;
            }
            return mKeycodeReverseMap[unityKeyCode];
        }

        private static void InitKeycodeReverseMap()
        {
            mKeycodeReverseMap = new Dictionary<UnityEngine.KeyCode, Keys>();
            foreach (KeyValuePair<Keys, UnityEngine.KeyCode> entry in mKeycodeMap) {
                if (mKeycodeReverseMap.ContainsKey(entry.Value))
                {
                    /*UnityEngine.Debug.LogWarning(string.Format(
                        "Unity Keycode {0} is duplicated for XNA Key {1} and {2} ",
                        entry.Value,
                        mKeycodeReverseMap[entry.Value],
                        entry.Key
                        ));*/
                }
                mKeycodeReverseMap[entry.Value] = entry.Key;
            }
        }
    }
}