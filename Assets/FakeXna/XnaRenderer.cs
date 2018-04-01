using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XnaRenderer : Singleton<XnaRenderer> {
    public RenderTexture renderTexture;
    public Texture2D whiteTexture;

    public void Draw(Microsoft.Xna.Framework.Graphics.Texture2D texture, Microsoft.Xna.Framework.Rectangle rectangle) {
        var unityTexture = texture.ToUnity();
        Graphics.SetRenderTarget(renderTexture);
        GL.PushMatrix();
        GL.LoadPixelMatrix(0, renderTexture.width, renderTexture.height, 0);
        Graphics.DrawTexture(rectangle.ToUnity(), unityTexture);
        GL.PopMatrix();
        Graphics.SetRenderTarget(null);
    }

    internal void Clear() {
        Graphics.SetRenderTarget(renderTexture);
        GL.PushMatrix();
        GL.LoadPixelMatrix(0, renderTexture.width, renderTexture.height, 0);
        Graphics.DrawTexture(new Rect(0,0,renderTexture.width, renderTexture.height), whiteTexture);
        GL.PopMatrix();
        Graphics.SetRenderTarget(null);
    }
}
