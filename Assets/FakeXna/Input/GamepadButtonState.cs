using FakeXna.Input;
using System;
using System.Collections.Generic;

namespace Microsoft.Xna.Framework.Input
{
    public class GamepadButtonState
    {
        private Dictionary<Buttons, ButtonState> mDownButtons = new Dictionary<Buttons, ButtonState>();
        public ButtonState DPadUp { get { return this.mDownButtons[Buttons.DPadUp]; } }
        public ButtonState DPadDown { get { return this.mDownButtons[Buttons.DPadDown]; } }
        public ButtonState DPadLeft { get { return this.mDownButtons[Buttons.DPadLeft]; } }
        public ButtonState DPadRight { get { return this.mDownButtons[Buttons.DPadRight]; } }
        public ButtonState Start { get { return this.mDownButtons[Buttons.Start]; } }
        public ButtonState Back { get { return this.mDownButtons[Buttons.Back]; } }
        public ButtonState LeftStick { get { return this.mDownButtons[Buttons.LeftStick]; } }
        public ButtonState RightStick { get { return this.mDownButtons[Buttons.RightStick]; } }
        public ButtonState LeftShoulder { get { return this.mDownButtons[Buttons.LeftShoulder]; } }
        public ButtonState RightShoulder { get { return this.mDownButtons[Buttons.RightShoulder]; } }
        public ButtonState BigButton { get { return this.mDownButtons[Buttons.BigButton]; } }
        public ButtonState A { get { return this.mDownButtons[Buttons.A]; } }
        public ButtonState B { get { return this.mDownButtons[Buttons.B]; } }
        public ButtonState X { get { return this.mDownButtons[Buttons.X]; } }
        public ButtonState Y { get { return this.mDownButtons[Buttons.Y]; } }
        public ButtonState LeftThumbstickLeft { get { return this.mDownButtons[Buttons.LeftThumbstickLeft]; } }
        public ButtonState RightTrigger { get { return this.mDownButtons[Buttons.RightTrigger]; } }
        public ButtonState LeftTrigger { get { return this.mDownButtons[Buttons.LeftTrigger]; } }
        public ButtonState RightThumbstickUp { get { return this.mDownButtons[Buttons.RightThumbstickUp]; } }
        public ButtonState RightThumbstickDown { get { return this.mDownButtons[Buttons.RightThumbstickDown]; } }
        public ButtonState RightThumbstickRight { get { return this.mDownButtons[Buttons.RightThumbstickRight]; } }
        public ButtonState RightThumbstickLeft { get { return this.mDownButtons[Buttons.RightThumbstickLeft]; } }
        public ButtonState LeftThumbstickUp { get { return this.mDownButtons[Buttons.LeftThumbstickUp]; } }
        public ButtonState LeftThumbstickDown { get { return this.mDownButtons[Buttons.LeftThumbstickDown]; } }
        public ButtonState LeftThumbstickRight { get { return this.mDownButtons[Buttons.LeftThumbstickRight]; } }

        public GamepadButtonState(PlayerIndex playerIndex)
        {
            Array buttonValues = Buttons.GetValues(typeof(Buttons));
            foreach (Buttons button in buttonValues)
            {
                string name = XnaGamePadToUnityInput.XnaButtonToUnityButtonName(playerIndex, button);
                mDownButtons[button] = name == null || UnityEngine.Input.GetButton(name)
                                                  ? ButtonState.Pressed
                                                  : ButtonState.Released;
            }
        }
    }
}