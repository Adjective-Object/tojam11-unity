using System;
using UnityEngine;
namespace Microsoft.Xna.Framework.Input
{
    public class Mouse
    {
        private const int mouseButtonLeft = 0;
        private const int mouseButtonRight = 1;
        private const int mouseButtonMiddle = 2;

        public static MouseState GetState()
        {
            // TODO do some kind of raycast from camera to mouse to
            // determine how to report these inputs to the xna like game
            return new MouseState(
                (int)UnityEngine.Input.mousePosition.x,
                (int)UnityEngine.Input.mousePosition.y,
                (int)UnityEngine.Input.mouseScrollDelta.y,
                UnityEngine.Input.GetMouseButton(mouseButtonLeft) ? ButtonState.Pressed : ButtonState.Released,
                UnityEngine.Input.GetMouseButton(mouseButtonRight) ? ButtonState.Pressed : ButtonState.Released,
                UnityEngine.Input.GetMouseButton(mouseButtonMiddle) ? ButtonState.Pressed : ButtonState.Released,
                ButtonState.Released, // XButton1
                ButtonState.Released, // XButton2
                (int)UnityEngine.Input.mouseScrollDelta.x // horizontazlScrollWheel
                );
        }
    }
}
