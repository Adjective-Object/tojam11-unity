using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XnaRenderer : Singleton<XnaRenderer> {
    public RenderTexture renderTexture;

    public void Draw(Microsoft.Xna.Framework.Graphics.Texture2D texture, Microsoft.Xna.Framework.Rectangle rectangle) {
        var unityTexture = texture.ToUnity();
        Graphics.SetRenderTarget(renderTexture);
        Graphics.DrawTexture(rectangle.ToUnity(), unityTexture);
        Graphics.SetRenderTarget(null);
    }
}
