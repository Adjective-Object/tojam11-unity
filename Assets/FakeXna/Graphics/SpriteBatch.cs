using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
namespace Microsoft.Xna.Framework.Graphics
{
    public class SpriteBatch
    {
        SpriteSortMode _sortMode;
        Matrix _matrix;
        GraphicsDevice _graphicsDevice;

        XnaRenderer renderer {
            get { return XnaRenderer.instance; }
        }

        public GraphicsDevice GraphicsDevice
        {
            get
            {
                return _graphicsDevice;
            }
        }

        public SpriteBatch(GraphicsDevice graphicsDevice)
        {
            if (graphicsDevice == null)
            {
                throw new ArgumentException("graphicsDevice");
            }

            _graphicsDevice = graphicsDevice;
        }

        public void Begin()
        {
            _sortMode = SpriteSortMode.Deferred;
            _matrix = Matrix.Identity;
        }

        #region Begin
        public void Begin(SpriteSortMode sortMode, Nullable<BlendState> blendMode) {
            Begin(sortMode, null, null, null, null, null, Matrix.Identity);
        }
        public void Begin(SpriteSortMode sortMode, Nullable<BlendState> blendMode, Nullable<SamplerState> samplerState, Nullable<DepthStencilState> depthStencilState, Nullable<RasterizerState> rasterizerState) {
            Begin(sortMode, null, null, null, null, null, Matrix.Identity);
        }
        public void Begin(SpriteSortMode sortMode, Nullable<BlendState> blendMode, Nullable<SamplerState> samplerState, Nullable<DepthStencilState> depthStencilState, Nullable<RasterizerState> rasterizerState, Nullable<Unsupported> effect) {
            Begin(sortMode, null, null, null, null, null, Matrix.Identity);
        }
        public void Begin(SpriteSortMode sortMode, Nullable<BlendState> blendMode, Nullable<SamplerState> samplerState, Nullable<DepthStencilState> depthStencilState, Nullable<RasterizerState> rasterizerState, Nullable<Unsupported> effect, Nullable<Matrix> matrix) {
            _sortMode = sortMode;
            _matrix = matrix == null ? Matrix.Identity : matrix.Value;
        }

        #endregion

        public void End()
        {
            // TODO actually draw things
        }

        #region DrawString
        public void DrawString(SpriteFont font, StringBuilder text, Vector2 position, Color color) {
            DrawString(font, text.ToString(), position, color);
        }
        public void DrawString(SpriteFont font, StringBuilder text, Vector2 position, Color color, Single rotation, Vector2 rotationOrigin, Single scale, SpriteEffects effects, Single layer) {
            DrawString(font, text.ToString(), position, color, rotation, rotationOrigin, scale, effects, layer);
        }
        public void DrawString(SpriteFont font, StringBuilder text, Vector2 position, Color color, Single rotation, Vector2 rotationOrigin, Vector2 scale, SpriteEffects effects, Single layer) {
            DrawString(font, text.ToString(), position, color, rotation, rotationOrigin, scale, effects, layer);
        }
        public void DrawString(SpriteFont font, String text, Vector2 position, Color color) {
            DrawString(font, text, position, color, 0, new Vector2(0, 0), new Vector2(1, 1), SpriteEffects.None, 1);
        }
        public void DrawString(SpriteFont font, String text, Vector2 position, Color color, Single rotation, Vector2 rotationOrigin, Single scale, SpriteEffects effects, Single layer) {
            DrawString(font, text, position, color, rotation, rotationOrigin, new Vector2(scale, scale), effects, layer);
        }
        public void DrawString(SpriteFont font, String text, Vector2 position, Color color, Single rotation, Vector2 rotationOrigin, Vector2 scale, SpriteEffects effects, Single layer) {
            // TODO
        }
        #endregion

        #region Draw

        public void Draw(Texture2D texture,
            Vector2? position = null,
            Rectangle? destinationRectangle = null,
            Rectangle? sourceRectangle = null,
            Vector2? origin = null,
            float rotation = 0f,
            Vector2? scale = null,
            Color? color = null,
            SpriteEffects effects = SpriteEffects.None,
            float layerDepth = 0f)
        {
            Vector2 offsetPosition = position == null ? new Vector2(0, 0) : position.Value;
            Color realColor = color == null ? Color.White : color.Value;
            Vector2 realScale = scale == null ? new Vector2(1, 1) : scale.Value;
            Vector2 realOrigin = origin == null ? new Vector2(0, 0) : origin.Value;
            Rectangle realRectangle = destinationRectangle == null ? new Rectangle((int)offsetPosition.X, (int)offsetPosition.Y, texture.Width, texture.Height) : destinationRectangle.Value;

            renderer.Draw(texture, realRectangle);
        }

        public void Draw(Texture2D texture,
            Vector2 position,
            Rectangle? sourceRectangle,
            Color color,
            float rotation,
            Vector2 origin,
            Vector2 scale,
            SpriteEffects effects,
            float layerDepth)
        {
            Draw(texture, position, null, sourceRectangle, origin, rotation, scale, color, effects, layerDepth);
        }
        public void Draw(Texture2D texture,
            Vector2 position,
            Rectangle? sourceRectangle,
            Color color,
            float rotation,
            Vector2 origin,
            float scale,
            SpriteEffects effects,
            float layerDepth)
        {
            Draw(texture, position, null, sourceRectangle, origin, rotation, new Vector2(scale, scale), color, effects, layerDepth);
        }
        public void Draw(Texture2D texture,
            Rectangle destinationRectangle,
            Rectangle? sourceRectangle,
            Color color,
            float rotation,
            Vector2 origin,
            SpriteEffects effects,
            float layerDepth)
        {
            Draw(texture, null, destinationRectangle, sourceRectangle, origin, rotation, null, color, effects, layerDepth);
        }
        public void Draw(Texture2D texture, Vector2 position, Rectangle? sourceRectangle, Color color)
        {
            Draw(texture, new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height), sourceRectangle, color);
        }
        public void Draw(Texture2D texture, Rectangle destinationRectangle, Rectangle? sourceRectangle, Color color)
        {
            Draw(texture, destinationRectangle, sourceRectangle, color, 0, new Vector2(0, 0), SpriteEffects.None, 1);
        }
        public void Draw(Texture2D texture, Vector2 position, Color color)
        {
            Draw(texture, new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height), color);
        }
        public void Draw(Texture2D texture, Rectangle destinationRectangle, Color color)
        {
            Draw(texture, destinationRectangle, new Rectangle(0, 0, texture.Width, texture.Height), color);
        }

        #endregion

    }
}
