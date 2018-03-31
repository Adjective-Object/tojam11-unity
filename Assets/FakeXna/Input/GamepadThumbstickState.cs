using FakeXna.Input;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Microsoft.Xna.Framework.Input
{
    public class GamepadThumbstickState
    {
        public Vector2 mLeft;
        public Vector2 mRight;
        public Vector2 Left {
            get { return mLeft; }
        }
        public Vector2 Right {
            get { return mRight; }
        }

        public GamepadThumbstickState(PlayerIndex index)
        {
            string leftHorizontal = XnaGamePadToUnityInput.XnaJoystickToUnityJoystickName(
                index,
                ControllerJoystick.Left,
                AxisDirection.X
                );
            string leftVertical = XnaGamePadToUnityInput.XnaJoystickToUnityJoystickName(
                index,
                ControllerJoystick.Left,
                AxisDirection.Y
                );

            string rightHorizontal = XnaGamePadToUnityInput.XnaJoystickToUnityJoystickName(
                index,
                ControllerJoystick.Right,
                AxisDirection.X
                );
            string rightVertical = XnaGamePadToUnityInput.XnaJoystickToUnityJoystickName(
                index,
                ControllerJoystick.Right,
                AxisDirection.Y
                );

            Func<String, float> axisOrZero = (String axis) => axis != null ? UnityEngine.Input.GetAxis(axis) : 0f;

            mLeft = new Vector2(
                axisOrZero(leftHorizontal),
                axisOrZero(leftVertical)
                );
            mRight = new Vector2(
                axisOrZero(rightHorizontal),
                axisOrZero(rightVertical)
                );
        }
    }
}
