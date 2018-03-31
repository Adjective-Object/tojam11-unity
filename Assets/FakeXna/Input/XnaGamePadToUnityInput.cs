using System;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
namespace FakeXna.Input 
{
    public class XnaGamePadToUnityInput : Singleton<XnaGamePadToUnityInput>
    {
        #region EditorParameters

        [Serializable]
        public struct ButtonMapping
        {
            public PlayerIndex xnaControllerNumber;
            public Buttons xnaButton;
            public string unityButtonName;
        }

        [Serializable]
        public struct ButtonKey
        {
            public PlayerIndex xnaControllerNumber;
            public Buttons xnaButton;
        }

        // For XNA button names See Buttons.cs
        public ButtonMapping[] buttonMappings;


        [Serializable]
        public struct JoystickMapping
        {
            public PlayerIndex xnaControllerNumber;
            public AxisDirection xnaAxisDirection;
            public ControllerJoystick xnaJoystickAxis;
            public string unityAxisName;
        }

        [Serializable]
        public struct JoystickKey
        {
            public PlayerIndex xnaControllerNumber;
            public AxisDirection xnaAxisDirection;
            public ControllerJoystick xnaJoystickAxis;
        }
        public JoystickMapping[] joystickMappings;

        #endregion EditorParameters
        #region Implementation
        private Dictionary<ButtonKey, string> mXnaButtonsToUnityNames = new Dictionary<ButtonKey, string>();
        private Dictionary<JoystickKey, string> mXnaAxisToUnityNames = new Dictionary<JoystickKey, string>();

        public void Start() {
            foreach (ButtonMapping mapping in buttonMappings)
            {
                ButtonKey key = new ButtonKey {
                    xnaControllerNumber = mapping.xnaControllerNumber,
                    xnaButton = mapping.xnaButton,
                };
                mXnaButtonsToUnityNames[key] = mapping.unityButtonName;
            }
            foreach (JoystickMapping mapping in joystickMappings)
            {
                JoystickKey key = new JoystickKey
                {
                    xnaControllerNumber = mapping.xnaControllerNumber,
                    xnaJoystickAxis = mapping.xnaJoystickAxis,
                    xnaAxisDirection = mapping.xnaAxisDirection,
                };
                mXnaAxisToUnityNames[key] = mapping.unityAxisName;
            }
        }

        public static string XnaButtonToUnityButtonName(PlayerIndex xnaControllerNumber, Buttons xnaButton)
        {
            XnaGamePadToUnityInput mapperInstance = XnaGamePadToUnityInput.instance;
            ButtonKey buttonKey = new ButtonKey
            {
                xnaControllerNumber = xnaControllerNumber,
                xnaButton = xnaButton,
            };
            if (!mapperInstance.mXnaButtonsToUnityNames.ContainsKey(buttonKey))
            {
                /*UnityEngine.Debug.LogWarning(String.Format(
                    "no mapping defined for xna button {0}:{1}",
                    xnaControllerNumber,
                    xnaButton
                ));*/ 
                return null;
            }
            return mapperInstance.mXnaButtonsToUnityNames[buttonKey];
        }

        public static string XnaJoystickToUnityJoystickName(PlayerIndex xnaControllerNumber, ControllerJoystick xnaJoystickAxis, AxisDirection xnaAxisDirection)
        {
            XnaGamePadToUnityInput mapperInstance = XnaGamePadToUnityInput.instance;
            JoystickKey axisKey = new JoystickKey
            {
                xnaControllerNumber = xnaControllerNumber,
                xnaJoystickAxis = xnaJoystickAxis,
                xnaAxisDirection = xnaAxisDirection,
            };
            if (!mapperInstance.mXnaAxisToUnityNames.ContainsKey(axisKey))
            {
                /*UnityEngine.Debug.LogWarning(String.Format(
                    "no mapping defined for xna joystick {0}:{1}:{2}",
                    xnaControllerNumber,
                    xnaJoystickAxis,
                    xnaAxisDirection
                ));*/
                return null;
            }
            return mapperInstance.mXnaAxisToUnityNames[axisKey];
        }
    }
    #endregion Implementation
}
