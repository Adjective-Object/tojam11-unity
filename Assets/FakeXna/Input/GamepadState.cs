using FakeXna.Input;
using System;
using System.Collections.Generic;

namespace Microsoft.Xna.Framework.Input
{
    public class GamePadState
    {
        private GamepadButtonState mGamepadButtonState;
        public GamepadButtonState Buttons {
            get { return this.mGamepadButtonState; }
        }

        private GamepadThumbstickState mGamepadThumbstickState;
        public GamepadThumbstickState ThumbSticks {
            get { return this.mGamepadThumbstickState; }
        }

        // DPadState
        public struct DPadState
        {
            public ButtonState Up;
            public ButtonState Down;
            public ButtonState Left;
            public ButtonState Right;
        }

        public DPadState DPad
        {
            get
            {
                return new DPadState()
                       {
                           Up = mGamepadButtonState.DPadUp,
                           Down = mGamepadButtonState.DPadDown,
                           Left = mGamepadButtonState.DPadLeft,
                           Right = mGamepadButtonState.DPadRight
                       };
            }
        }

        public GamePadState(PlayerIndex index)
        {
            mGamepadButtonState = new GamepadButtonState(index);
            mGamepadThumbstickState = new GamepadThumbstickState(index);
        }
    }
}