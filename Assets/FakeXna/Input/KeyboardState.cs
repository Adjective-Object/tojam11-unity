using FakeXna.Input;
using System;
using System.Collections.Generic;

namespace Microsoft.Xna.Framework.Input
{
    public class KeyboardState
    {
        Dictionary<Keys, bool> downKeys = new Dictionary<Keys, bool>();
        Dictionary<Keys, bool> upKeys = new Dictionary<Keys, bool>();
        public KeyboardState()
        {
            Array values = Keys.GetValues(typeof(Keys));
            foreach (Keys xnaKey in values)
            {
                if (xnaKey == Keys.None) continue;
                UnityEngine.KeyCode? unityKeyCode = XnaKeysToUnityKeyCode.XnaToUnity(xnaKey);
                if (unityKeyCode.HasValue)
                {
                    downKeys[xnaKey] = UnityEngine.Input.GetKeyDown(unityKeyCode.Value);
                    upKeys[xnaKey] = UnityEngine.Input.GetKeyUp(unityKeyCode.Value);
                }
                else
                {
                    downKeys[xnaKey] = false;
                    upKeys[xnaKey] = false;
                }
            }
        }

        public bool IsKeyDown(Keys xnaKey)
        {
            if (!downKeys.ContainsKey(xnaKey))
            {
                UnityEngine.Debug.LogWarning(string.Format(
                        "Requested XNA keycode {0} not present in down keyboard state",
                        xnaKey
                        ));
            }
            return downKeys.GetValueOrDefault(xnaKey, false);
        }

        public bool IsKeyUp(Keys xnaKey)
        {
            if (!upKeys.ContainsKey(xnaKey))
            {
                UnityEngine.Debug.LogWarning(string.Format(
                        "Requested XNA keycode {0} not present in up keyboard state",
                        xnaKey
                        ));
            }
            return upKeys.GetValueOrDefault(xnaKey, false);
        }

    }
}