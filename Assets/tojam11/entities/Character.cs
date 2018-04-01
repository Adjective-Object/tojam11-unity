﻿using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Adventure
{
	// class that handles assembling and animating sprites
	public class Character : InteractableEntity
	{
		string headName, bodyName;
		Texture2D head, body;
		CharacterBehavior charBehavior;
		public Boolean facingLeft = true;

		public ItemID? heldItem = null;

		override public Boolean hasShadow {
			get { return true; }
		}

		Color [] headColors, bodyColors;
		static Color [] referenceColors = {
			new Color(255,0,0),
			new Color(0,255,0),
			new Color(0,0,255),
			new Color(255,255,0),
			new Color(255,0,255),
			new Color(0,255,255),
		};

		Animation currentHeadAnimation, currentBodyAnimation;
		Dictionary<String, Animation> headAnimations, bodyAnimations;

		public Character (
			Vector2 position,
			String headName, Color[] headColors,
			String bodyName, Color[] bodyColors,
			CharacterBehavior behavior) : base(position, behavior)
		{
            SetCharacterSprites(headName, bodyName);
			this.headColors = headColors;
			this.bodyColors = bodyColors;
			this.charBehavior = behavior;
			charBehavior.BindToEntity (this);

			this.headAnimations = new Dictionary<String, Animation> ();
			this.bodyAnimations = new Dictionary<String, Animation> ();
		}

        public void SetCharacterSprites(String headName, String bodyName)
        {
            this.headName = headName;
            this.bodyName = bodyName;
        }

        public void SetCharacterColor(Color[] color)
        {
            this.bodyColors = color;
            this.headColors = color;
        }

		// load and set the colors of the sprites
		override public void Load(ContentManager content, SpriteBatch batch) {
			// load head textures
			Texture2D headTextureIdle = ApplyPallette (content.Load<Texture2D> ("npc_parts/head_" + headName + "_idle"), headColors);
			Texture2D headTextureTalk = ApplyPallette (content.Load<Texture2D> ("npc_parts/head_" + headName + "_talk_1"), headColors);

			// load body textures
			Texture2D bodyTextureIdle = ApplyPallette (content.Load<Texture2D> ("npc_parts/body_" + bodyName + "_idle"), bodyColors);
			Texture2D bodyTextureW1 = ApplyPallette (content.Load<Texture2D> ("npc_parts/body_" + bodyName + "_walk_1"), bodyColors);


			// create head animations
			Frame[] headIdleFrames = {
				new Frame(10, headTextureIdle)
			};
            headAnimations.Clear();
			headAnimations.Add("idle", new Animation(headIdleFrames));

			Frame[] headTalkFrames = {
				new Frame(0.2, headTextureTalk),
				new Frame(0.2, headTextureIdle)
			};
			headAnimations.Add("talk", new Animation(headTalkFrames));

			// create body animations
			Frame[] bodyIdleFrames = {
				new Frame(10, bodyTextureIdle)
			};
            bodyAnimations.Clear();
			bodyAnimations.Add("idle", new Animation(bodyIdleFrames));

			Frame[] bodyWalkFrames = new Frame[]{
				new Frame(0.2, bodyTextureW1),
				new Frame(0.2, bodyTextureIdle),
			};
			bodyAnimations.Add("walk", new Animation(bodyWalkFrames));

			currentHeadAnimation = headAnimations["idle"];
			currentBodyAnimation = bodyAnimations["idle"];
            head = currentHeadAnimation.GetFrame(0);
            body = currentBodyAnimation.GetFrame(0);

			base.Load (content, batch);
		}


		// apply some color pallette to a texture using reference colors
		private Texture2D ApplyPallette(Texture2D texture, Color [] palette) {
            if (true) {
                return texture;
            }
			Texture2D newTexture = new Texture2D(
				texture.GraphicsDevice, texture.Width, texture.Height);

			Color[] data = new Color[texture.Width * texture.Height];
			texture.GetData(data);

			for (int i=0; i< palette.Length ; i++) {
				for (int j = 0; j < data.Length; j++) {
					if (data [j] == referenceColors [i]) {
						data [j] = palette [i];
					}
				}
			}

			newTexture.SetData (data);
			return newTexture;
		}
			
		override public void Update(GameTime time) {
			// Perform the behaviors specified by this Character's CharacterBehavior
			base.Update (time);

			head = currentHeadAnimation.GetFrame(time.ElapsedGameTime.TotalSeconds);
			body = currentBodyAnimation.GetFrame(time.ElapsedGameTime.TotalSeconds);
		}

		const int ITEM_SIZE = 42;

		override public void Draw(SpriteBatch batch, GameTime time) {
			SpriteEffects flipEffect = this.facingLeft ? SpriteEffects.None : SpriteEffects.FlipHorizontally;
			batch.Draw(
				body, new Vector2 (position.X - 64, position.Y - 105), 
				null, null, null, 0, null, null, flipEffect);
			batch.Draw(
				head, new Vector2 (position.X - 64, position.Y - 175),
				null, null, null, 0, null, null, flipEffect);

            // Texture2D dummyTexture = new Texture2D(batch.GraphicsDevice, 1, 1);
            // dummyTexture.SetData(new Color[] { Color.White });
            // batch.Draw(dummyTexture, position, Color.Red);

			if (this.heldItem != null) {
				Vector2 offset = new Vector2 ((this.facingLeft ? -30 : 30) - ITEM_SIZE / 2, -32 - ITEM_SIZE / 2);
				offset += this.position;
				batch.Draw (Item.Get (heldItem.Value).texture, null,
					new Rectangle((int) offset.X, (int) offset.Y,ITEM_SIZE,ITEM_SIZE), null, null, 0, null, null, flipEffect);
			}

			base.DrawFocusIndicator(batch, new Vector2(0, - 150));
		}

		public void PlayAnimHead(String name) {
			if (this.currentHeadAnimation != this.headAnimations[name])
				this.currentHeadAnimation = this.headAnimations [name].Reset();
		}

		public void PlayAnimBody(String name) {
			if (this.currentBodyAnimation != this.bodyAnimations[name])
				this.currentBodyAnimation = this.bodyAnimations [name].Reset();
		}


		private static Random r = new Random();
		public static Color[] MakeRandomPallete(int length) {
			Color[] c = new Color[length];
			for (int i = 0; i < length; i++) {
				c[i] = new Color(r.Next(0, 255), r.Next(0,255), r.Next(0,255));
			}
			return c;
		}
	}

}

