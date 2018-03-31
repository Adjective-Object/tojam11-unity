using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System;

namespace FakeXna.Input
{
    class XnaKeysToUnityKeyCode
    {
        private static Dictionary<Keys, Nullable<UnityEngine.KeyCode>> mKeycodeMap = new Dictionary<Keys, Nullable<UnityEngine.KeyCode>>
        {
            {Keys.Space, UnityEngine.KeyCode.Space},
            {Keys.Up, UnityEngine.KeyCode.UpArrow},
            {Keys.Down, UnityEngine.KeyCode.DownArrow},
            {Keys.Left, UnityEngine.KeyCode.LeftArrow},
            {Keys.Right, UnityEngine.KeyCode.RightArrow},
            {Keys.Back, UnityEngine.KeyCode.Backspace},
            {Keys.Tab, UnityEngine.KeyCode.Tab},
            {Keys.Enter, UnityEngine.KeyCode.Return},
            {Keys.CapsLock, UnityEngine.KeyCode.CapsLock},
            {Keys.Escape, UnityEngine.KeyCode.Escape},
            {Keys.Space, UnityEngine.KeyCode.Space},
            {Keys.PageUp, UnityEngine.KeyCode.PageUp},
            {Keys.PageDown, UnityEngine.KeyCode.PageDown},
            {Keys.End, UnityEngine.KeyCode.End},
            {Keys.Home, UnityEngine.KeyCode.Home},
            {Keys.Left, UnityEngine.KeyCode.LeftArrow},
            {Keys.Up, UnityEngine.KeyCode.UpArrow},
            {Keys.Right, UnityEngine.KeyCode.RightArrow},
            {Keys.Down, UnityEngine.KeyCode.DownArrow},
            {Keys.Select, null},
            {Keys.Print, UnityEngine.KeyCode.Print},
            {Keys.Execute, null},
            {Keys.PrintScreen, UnityEngine.KeyCode.Print},
            {Keys.Insert, UnityEngine.KeyCode.Insert},
            {Keys.Delete, UnityEngine.KeyCode.Delete},
            {Keys.Help, UnityEngine.KeyCode.Help},
            {Keys.D0, null},
            {Keys.D1, null},
            {Keys.D2, null},
            {Keys.D3, null},
            {Keys.D4, null},
            {Keys.D5, null},
            {Keys.D6, null},
            {Keys.D7, null},
            {Keys.D8, null},
            {Keys.D9, null},
            {Keys.A, UnityEngine.KeyCode.A},
            {Keys.B, UnityEngine.KeyCode.B},
            {Keys.C, UnityEngine.KeyCode.C},
            {Keys.D, UnityEngine.KeyCode.D},
            {Keys.E, UnityEngine.KeyCode.E},
            {Keys.F, UnityEngine.KeyCode.F},
            {Keys.G, UnityEngine.KeyCode.G},
            {Keys.H, UnityEngine.KeyCode.H},
            {Keys.I, UnityEngine.KeyCode.I},
            {Keys.J, UnityEngine.KeyCode.J},
            {Keys.K, UnityEngine.KeyCode.K},
            {Keys.L, UnityEngine.KeyCode.L},
            {Keys.M, UnityEngine.KeyCode.M},
            {Keys.N, UnityEngine.KeyCode.N},
            {Keys.O, UnityEngine.KeyCode.O},
            {Keys.P, UnityEngine.KeyCode.P},
            {Keys.Q, UnityEngine.KeyCode.Q},
            {Keys.R, UnityEngine.KeyCode.R},
            {Keys.S, UnityEngine.KeyCode.S},
            {Keys.T, UnityEngine.KeyCode.T},
            {Keys.U, UnityEngine.KeyCode.U},
            {Keys.V, UnityEngine.KeyCode.V},
            {Keys.W, UnityEngine.KeyCode.W},
            {Keys.X, UnityEngine.KeyCode.X},
            {Keys.Y, UnityEngine.KeyCode.Y},
            {Keys.Z, UnityEngine.KeyCode.Z},
            {Keys.LeftWindows, UnityEngine.KeyCode.LeftWindows},
            {Keys.RightWindows, UnityEngine.KeyCode.RightWindows},
            {Keys.Apps, null},
            {Keys.Sleep, null},
            {Keys.NumPad0, UnityEngine.KeyCode.Keypad0},
            {Keys.NumPad1, UnityEngine.KeyCode.Keypad1},
            {Keys.NumPad2, UnityEngine.KeyCode.Keypad2},
            {Keys.NumPad3, UnityEngine.KeyCode.Keypad3},
            {Keys.NumPad4, UnityEngine.KeyCode.Keypad4},
            {Keys.NumPad5, UnityEngine.KeyCode.Keypad5},
            {Keys.NumPad6, UnityEngine.KeyCode.Keypad6},
            {Keys.NumPad7, UnityEngine.KeyCode.Keypad7},
            {Keys.NumPad8, UnityEngine.KeyCode.Keypad8},
            {Keys.NumPad9, UnityEngine.KeyCode.Keypad9},
            {Keys.Multiply, UnityEngine.KeyCode.KeypadMultiply},
            {Keys.Add, UnityEngine.KeyCode.KeypadPlus},
            {Keys.Separator, null},
            {Keys.Subtract, UnityEngine.KeyCode.KeypadMinus},
            {Keys.Decimal, UnityEngine.KeyCode.KeypadPeriod},
            {Keys.Divide, UnityEngine.KeyCode.KeypadDivide},
            {Keys.F1, UnityEngine.KeyCode.F1},
            {Keys.F2, UnityEngine.KeyCode.F2},
            {Keys.F3, UnityEngine.KeyCode.F3},
            {Keys.F4, UnityEngine.KeyCode.F4},
            {Keys.F5, UnityEngine.KeyCode.F5},
            {Keys.F6, UnityEngine.KeyCode.F6},
            {Keys.F7, UnityEngine.KeyCode.F7},
            {Keys.F8, UnityEngine.KeyCode.F8},
            {Keys.F9, UnityEngine.KeyCode.F9},
            {Keys.F10, UnityEngine.KeyCode.F10},
            {Keys.F11, UnityEngine.KeyCode.F11},
            {Keys.F12, UnityEngine.KeyCode.F12},
            {Keys.F13, UnityEngine.KeyCode.F13},
            {Keys.F14, UnityEngine.KeyCode.F14},
            {Keys.F15, UnityEngine.KeyCode.F15},
            {Keys.F16, null},
            {Keys.F17, null},
            {Keys.F18, null},
            {Keys.F19, null},
            {Keys.F20, null},
            {Keys.F21, null},
            {Keys.F22, null},
            {Keys.F23, null},
            {Keys.F24, null},
            {Keys.NumLock, UnityEngine.KeyCode.Numlock},
            {Keys.Scroll, UnityEngine.KeyCode.ScrollLock},
            {Keys.LeftShift, UnityEngine.KeyCode.LeftShift},
            {Keys.RightShift, UnityEngine.KeyCode.RightShift},
            {Keys.LeftControl, UnityEngine.KeyCode.LeftControl},
            {Keys.RightControl, UnityEngine.KeyCode.RightControl},
            {Keys.LeftAlt, UnityEngine.KeyCode.LeftAlt},
            {Keys.RightAlt, UnityEngine.KeyCode.RightAlt},
            {Keys.BrowserBack, null},
            {Keys.BrowserForward, null},
            {Keys.BrowserRefresh, null},
            {Keys.BrowserStop, null},
            {Keys.BrowserSearch, null},
            {Keys.BrowserFavorites, null},
            {Keys.BrowserHome, null},
            {Keys.VolumeMute, null},
            {Keys.VolumeDown, null},
            {Keys.VolumeUp, null},
            {Keys.MediaNextTrack, null},
            {Keys.MediaPreviousTrack, null},
            {Keys.MediaStop, null},
            {Keys.MediaPlayPause, null},
            {Keys.LaunchMail, null},
            {Keys.SelectMedia, null},
            {Keys.LaunchApplication1, null},
            {Keys.LaunchApplication2, null},
            {Keys.OemSemicolon, null},
            {Keys.OemPlus, null},
            {Keys.OemComma, null},
            {Keys.OemMinus, null},
            {Keys.OemPeriod, null},
            {Keys.OemQuestion, null},
            {Keys.OemTilde, null},
            {Keys.OemOpenBrackets, null},
            {Keys.OemPipe, null},
            {Keys.OemCloseBrackets, null},
            {Keys.OemQuotes, null},
            {Keys.Oem8, null},
            {Keys.OemBackslash, null},
            {Keys.ProcessKey, null},
            {Keys.Attn, null},
            {Keys.Crsel, null},
            {Keys.Exsel, null},
            {Keys.EraseEof, null},
            {Keys.Play, null},
            {Keys.Zoom, null},
            {Keys.Pa1, null},
            {Keys.OemClear, null},
            {Keys.ChatPadGreen, null},
            {Keys.ChatPadOrange, null},
            {Keys.Pause, null},
            {Keys.ImeConvert, null},
            {Keys.ImeNoConvert, null},
            {Keys.Kana, null},
            {Keys.Kanji, null},
            {Keys.OemAuto, null},
            {Keys.OemCopy, null},
            {Keys.OemEnlW, null},
        };

        private static Dictionary<UnityEngine.KeyCode, Keys> mKeycodeReverseMap = null;

        public static Nullable<UnityEngine.KeyCode> XnaToUnity(Keys xnaKey)
        {
            if (!mKeycodeMap.ContainsKey(xnaKey)) {
                UnityEngine.Debug.LogWarning(string.Format(
                    "Requested XNA keycode {0} is not defined in map",
                    xnaKey
                ));
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
                UnityEngine.Debug.LogWarning(string.Format(
                    "Requested unity keycode {0} is not defined in map",
                    unityKeyCode
                ));
                return Keys.Escape;
            }
            return mKeycodeReverseMap[unityKeyCode];
        }

        private static void InitKeycodeReverseMap()
        {
            mKeycodeReverseMap = new Dictionary<UnityEngine.KeyCode, Keys>();
            foreach (KeyValuePair<Keys, Nullable<UnityEngine.KeyCode>> entry in mKeycodeMap) {
                if (entry.Value == null) continue;
                UnityEngine.KeyCode code = entry.Value.Value;
                if (mKeycodeReverseMap.ContainsKey(code))
                {
                    UnityEngine.Debug.LogWarning(string.Format(
                        "Unity Keycode {0} is duplicated for XNA Key {1} and {2} ",
                        entry.Value,
                        mKeycodeReverseMap[code],
                        entry.Key
                        ));
                }
                mKeycodeReverseMap[code] = entry.Key;
            }
        }
    }
}