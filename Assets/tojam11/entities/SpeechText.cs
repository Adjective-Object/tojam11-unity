﻿using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;

namespace Adventure
{
	public class SpeechText : BaseEntity
	{
		//
		// Singleton 'spawner' interface
		//

		protected static Dictionary<String, SpriteFont> fonts = new Dictionary<String, SpriteFont>();

		public static void LoadFont(ContentManager content, String fontName) {
			LoadFont (fontName, content.Load<SpriteFont> (fontName));
		}

		public static void LoadFont(String fontName, SpriteFont font) {
			if (fonts.Count == 0) SpeechText.fonts ["default"] = font;
			SpeechText.fonts [fontName] = font;
		}

		public static SpeechText Spawn(String fontName, Vector2 position, String text, SpeechMode mode = SpeechMode.AMBIENT) {
			SpeechText e = new SpeechText (fonts [fontName], position, text, mode);
			AdventureGame.SpawnEntity(e);
			e.position -= LETTER_OFFSET * text.Length / 2;
			return e;
		}
		public static SpeechText Spawn(String fontName, Vector2 position, String text, Option[] options) {
			SpeechText e = new SpeechText (fonts [fontName], position, text, options);
			AdventureGame.SpawnEntity(e);
			e.position -= LETTER_OFFSET * text.Length / 2;
			return e;	
		}

		//
		// Instance Methods and Properties
		//
		static Vector2 STARTING_OFFSET = new Vector2(0,10);
		static Vector2 LETTER_OFFSET = new Vector2(15,0);
		static Vector2 LINE_HEIGHT = new Vector2(0,25);
		static Vector2 GRADUAL_RISE = new Vector2(0,-10);
		static double ANIMATION_TIME = 0.4;
		static double LETTER_SPAWN_DELAY = 0.03;
		static double AMBIENT_SPEECH_LIFETIME = 3.0;


		override public int SortingLayer {
			get { return 1; }
		}
		public Boolean DoneEmitting {
			get { return this.ages[this.ages.Length - 1] > ANIMATION_TIME; }
		}
		public Boolean IsDismissed {
			get { return this.dismissedTime >= 0; }
		}

		SpriteFont font;
		SpeechMode mode;
		double [] ages;
		double dismissedTime;
		string text;
		double timeScale = 1;


		private SpeechText(SpriteFont font, Vector2 position, String text) : base (position) {
			this.text = text;
			this.font = font;
			this.mode = mode;
			this.dismissedTime = -1;

			blackRect = new Texture2D(AdventureGame.instance.GraphicsDevice, 1, 1);
			blackRect.SetData(new Color[] { Color.Black });
		}

		protected SpeechText(SpriteFont font, Vector2 position, String text, SpeechMode mode) :
		this(font, position, text){
			this.mode = mode;

			if (mode != SpeechMode.PLAYER_ANSWER_QUESTION) {
				this.ages = new double[text.Length];
				for (int i = 0; i < text.Length; i++) {
					this.ages [i] = i * -LETTER_SPAWN_DELAY;
				}
			} else {
				throw new Exception("SpeechText initialized without option but with mode PLAYER_ANSWER_QUESTION");
			}
		}

		Option[] options = null;
		Func<Boolean> checkWalkAway;
		Action enterCallback;
		int selectionIndex = 0;
		Texture2D blackRect;
		protected SpeechText(SpriteFont font, Vector2 position, String text, Option[] options)
			: this(font, position, text){
			this.options = options;
			this.mode = SpeechMode.PLAYER_ANSWER_QUESTION;

			int totalStringLength = text.Length;
			foreach (Option o in options) {
				totalStringLength += o.text.Length;
			}

			this.ages = new double[totalStringLength];
			for (int i = 0; i < totalStringLength; i++) {
				this.ages [i] = i * -LETTER_SPAWN_DELAY;
			}
		}

		public void AttachWalkawayCallback(Func<Boolean> checkWalkAway) {
			this.checkWalkAway = checkWalkAway;
		}

		public void AttachEnterCallback(Action enterCallback) {
			this.enterCallback = enterCallback;
		}

		SoundFont sounds;
		public void AttachSoundFont(SoundFont sounds) {
			this.sounds = sounds;
		}

		public override void Load(ContentManager content, SpriteBatch batch) {}
		public override void Update(GameTime time) {
			// update the ages of each letter
			for (int i = 0; i < this.ages.Length; i++) {
				double old_age = this.ages [i];
				this.ages [i] = this.ages[i] + time.ElapsedGameTime.TotalSeconds * timeScale;
				if (this.sounds != null && old_age < 0 && this.ages [i] > 0) {
					this.sounds.FetchRandomInstance ().Play ();
				}
			}

			// update depending on mode
			switch (mode) {
			case SpeechMode.AMBIENT:
				if (ages [ages.Length - 1] > AMBIENT_SPEECH_LIFETIME) {
					this.dismissedTime = AMBIENT_SPEECH_LIFETIME;
				}
				break;
			case SpeechMode.PLAYER_CONTROLLED:
				if (!this.IsDismissed) {
					if (Input.KeyPressed (Key.ENTER)) {
						// if it's still animating in and the enter button is pressed, speed up the animation
						if (ages [ages.Length - 1] < ANIMATION_TIME) {
							this.timeScale = 3.0;
						} else if (!this.IsDismissed) {
							this.dismissedTime = ages [ages.Length - 1];
							this.timeScale = 1.0;
							if (enterCallback != null) enterCallback ();
						}
					}
					if (this.ages [ages.Length - 1] >= ANIMATION_TIME && checkWalkAway != null && checkWalkAway ()) {
						this.dismissedTime = ages [ages.Length - 1];
						this.timeScale = 1.0;
					}
				}
				break;
			case SpeechMode.PLAYER_ANSWER_QUESTION:
				if (! this.IsDismissed) {
					if (Input.KeyPressed (Key.ENTER)) {
						if (ages [ages.Length - 1] < ANIMATION_TIME) {
							// if it's still animating in and the enter button is pressed, speed up the animation
							this.timeScale = 3.0;
							if (enterCallback != null) enterCallback ();
						} else {
							// otherwise, select the currently selected option
							this.options [this.selectionIndex].callback ();
							this.dismissedTime = this.ages [this.ages.Length - 1];
							this.timeScale = 1.0;
						}
					}

					// toggling between options
					if (Input.KeyPressed (Key.TAB)) {
						if (Input.KeyDown (Key.SHIFT)) {
							this.selectionIndex = (selectionIndex + this.options.Length - 1) % this.options.Length;
						} else {
							this.selectionIndex = (selectionIndex + 1) % this.options.Length;
						}
					}

					// check for walk away
					if (this.ages[ages.Length -1] >= ANIMATION_TIME &&
						checkWalkAway != null &&
						checkWalkAway ()) {

						this.dismissedTime = this.ages [this.ages.Length - 1];
						this.timeScale = 1.0;
					}
				}
				break;
			}
			

			if (dismissedTime >= 0 && ages [ages.Length - 1] > dismissedTime + ANIMATION_TIME) {
				this._alive = false;	
			}
		}

		public override void Draw(SpriteBatch batch, GameTime time) {
			if (mode != SpeechMode.PLAYER_ANSWER_QUESTION) {
				if (mode != SpeechMode.AMBIENT) {
					DrawStringBkg (batch, this.position, this.text, this.ages);
				}
				DrawString (batch, this.position, this.text, this.ages);
			} else {
				DrawStringBkg (batch, this.position, this.text, this.ages);
				int ageOffset = this.text.Length;
				for (int i=0; i<this.options.Length; i++) {
					DrawStringBkg (
						batch, this.position + LINE_HEIGHT * (i + 1), this.options [i].text, 
									this.ages, ageOffset);
					ageOffset += this.options[i].text.Length;
				}


				DrawString (batch, this.position, this.text, this.ages);
				ageOffset = this.text.Length;
				for (int i=0; i<this.options.Length; i++) {
					DrawString (
						batch, this.position + LINE_HEIGHT * (i + 1), this.options[i].text, 
						this.ages, ageOffset,
						i == this.selectionIndex ? new Color(255,255,0) : Color.White);
					ageOffset += this.options[i].text.Length;
				}
			}
		}

		Vector2 LINE_MARGIN = new Vector2(10,10);

		public void DrawStringBkg(SpriteBatch batch, Vector2 lineOrigin, String str, Double[] ages, int ageArrayOffset = 0) {
			float targetWidth = LETTER_OFFSET.X * str.Length + LINE_MARGIN.X * 2;
			if (!this.IsDismissed) {
				float t = (float) (Math.Min(1, ages [ageArrayOffset] / ANIMATION_TIME));
				t = (1 - (1-t) * (1-t));
				batch.Draw (blackRect, null, new Rectangle (
					(int)(lineOrigin.X - LINE_MARGIN.X),
					(int)(lineOrigin.Y - LINE_MARGIN.Y),
					(int)(t * targetWidth),
					(int)(LINE_HEIGHT.Y + LINE_MARGIN.Y * 2)
				));
			} else {
				float t = Math.Min(1, (float) ((this.ages[this.ages.Length - 1] - dismissedTime) / ANIMATION_TIME));
				t = (1 - (1-t) * (1-t));
				batch.Draw (blackRect, null, new Rectangle (
					(int)(lineOrigin.X - LINE_MARGIN.X + t * targetWidth),
					(int)(lineOrigin.Y - LINE_MARGIN.Y),
					(int)((1 - t) * targetWidth),
					(int)(LINE_HEIGHT.Y + LINE_MARGIN.Y * 2)
				));
			}
		}

		public void DrawString(SpriteBatch batch, Vector2 lineOrigin, String str, Double[] ages, 
			int ageArrayOffset = 0, Color? textColorNullable = null) {
			Color textColor = textColorNullable.GetValueOrDefault(Color.White);

			for  (int i = 0; i < str.Length; i++) {
				// calculate the animation time for this letter
				double age = ages [i + ageArrayOffset];

				Vector2 offset;
				float opacity;

				// text is appearing still
				if (dismissedTime < 0) {
					float t = (float)Math.Max (0, Math.Min (1, age / ANIMATION_TIME));
					offset = 
						LETTER_OFFSET * i +
						STARTING_OFFSET * (float)Math.Pow ((1 - t), 3);
					opacity = t;
				}

				// text has been dismissed
				else {
					float t = Math.Min(1, (float) ((this.ages[this.ages.Length - 1] - dismissedTime) / ANIMATION_TIME));
					offset =
						LETTER_OFFSET * i +
						STARTING_OFFSET * (float) Math.Pow(t, 3);
					opacity = (1 - t);
				}

				if (this.mode == SpeechMode.AMBIENT) {
					offset = offset + GRADUAL_RISE * (float)ages [0];
				}

				// apply the calculated opacity and offset
				foreach (Vector2 microOff in new Vector2[]{
					new Vector2(-1, 0), new Vector2(0, -1), 
					new Vector2(1, 0), new Vector2(0, 1)}) {
					batch.DrawString (
						font, 
						str [i].ToString (), 
						lineOrigin + offset + microOff,
						Color.Black * (float) Math.Pow(opacity, 2));
				}

				batch.DrawString (
					font, 
					str [i].ToString (), 
					lineOrigin + offset,
					textColor * opacity);
			}
		}

		public enum SpeechMode {
			AMBIENT, PLAYER_CONTROLLED, PLAYER_ANSWER_QUESTION
		}

		public class Option {
			public String text;
			public Action callback;
			public Option(String text, Action callback) {
				this.text = text;
				this.callback = callback;
			}
		}

	}
}

