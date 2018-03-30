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
        public Vector2 Left { get { return mLeft; } }
        public Vector2 Right { get { return mRight; } }

        public GamepadThumbstickState(PlayerIndex index)
        {

            mLeft = new Vector2(
                UnityEngine.Input.GetAxis(
                    XnaGamePadToUnityInput.XnaJoystickToUnityJoystickName(
                        index,
                        ControllerJoystick.Left,
                        AxisDirection.X
                    )
                ),
                UnityEngine.Input.GetAxis(
                    XnaGamePadToUnityInput.XnaJoystickToUnityJoystickName(
                        index,
                        ControllerJoystick.Left,
                        AxisDirection.Y
                    )
                )
            );

            mRight = new Vector2(
                UnityEngine.Input.GetAxis(
                    XnaGamePadToUnityInput.XnaJoystickToUnityJoystickName(
                        index,
                        ControllerJoystick.Right,
                        AxisDirection.X
                    )
                ),
                UnityEngine.Input.GetAxis(
                    XnaGamePadToUnityInput.XnaJoystickToUnityJoystickName(
                        index,
                        ControllerJoystick.Right,
                        AxisDirection.Y
                    )
                )
            );
        }
    }
}
