﻿using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Adventure
{
	public class PlayerBehavior : CharacterBehavior
	{
		double speedx = 300;
		double speedy = 190;
		double interactionRadius = 100;

		public SpeechText triggeredText;

		public PlayerBehavior (SoundFont s = null) : base(s)
		{
		}

		public override void Update(GameTime time) {
			// apply motion
			UpdateMotion(time);
	
			// update highlights
			if (triggeredText != null && !triggeredText.alive) {
				triggeredText = null;
			}
			if (triggeredText == null) {
				UpdateHighlights ();
			}

			if (Inventory.SelectedItemID != ItemID.NO_ITEM) {
				this.character.heldItem = Inventory.SelectedItemID;
			} else {
				this.character.heldItem = null;
			}

			base.Update(time);
		}

		protected void UpdateMotion(GameTime time) {
			int incline = GroundIncline (character.position);
			Vector2 movement = new Vector2 (0, 0);
			if (Input.KeyDown(Key.LEFT)) {
				movement.X -= (float) (time.ElapsedGameTime.TotalSeconds);
				character.facingLeft = true;
			}
			if (Input.KeyDown (Key.RIGHT)) {
				movement.X += (float) (time.ElapsedGameTime.TotalSeconds);	
				character.facingLeft = false;
			}
			if (movement.X == 0 || incline == 0) {
				if (Input.KeyDown (Key.UP)) {
					movement.Y -= (float)(time.ElapsedGameTime.TotalSeconds);
				}
				if (Input.KeyDown (Key.DOWN)) {
					movement.Y += (float)(time.ElapsedGameTime.TotalSeconds);
				}
			}

			if (movement.LengthSquared () != 0) {
				character.PlayAnimBody ("walk");
				
				movement.Normalize ();
				movement = movement * (float)time.ElapsedGameTime.TotalSeconds;
				movement.X *= (float)speedx;
				movement.Y *= (float)speedy;

                Vector2 newPosition = character.position + movement;

				if (movement.X != 0) {
					int playerWalk = (int)(movement.X / Math.Abs(movement.X));
					if (playerWalk == incline || playerWalk == -incline) {
						newPosition.Y -= movement.X * 0.67f * incline;
					}
				}

                MoveCharacter(newPosition);

			} else {
				character.PlayAnimBody("idle");
			}
		}

		protected int GroundIncline(Vector2 pos) {
			byte ground = AdventureGame.instance.collisionMap [(int)pos.Y, (int)pos.X];
			switch (ground) {
			case 2: // up to the left
				return -1;
			case 3: // up to the right
				return 1;

			case 0: // normal
			case 1: // wall
			default:
				return 0;
			}
		}



		HighlightManager highlights = new HighlightManager();
		protected void UpdateHighlights() {
			// find neighbors within a certain radius and mark them as interactable
			IList<InteractableEntity> nearby = GetNearbyInteractable();
			this.highlights.ClearHighlights ();
			foreach (InteractableEntity e in nearby) {
				this.highlights.Highlight(e);
			}
			this.highlights.AssignFocus ();

			// advance the focus on tab / shift + tab
			if (Input.KeyPressed(Key.TAB)) {
				if (Input.KeyDown(Key.SHIFT)) {
					this.highlights.AdvanceFocus(-1);
				} else {
					this.highlights.AdvanceFocus(1);
				}
			}

			// if enter is just pressed, call the interaction of the thing
			if (Input.KeyPressed (Key.ENTER) && 
				this.highlights.focus != null && 
				!this.highlights.focus.behavior.IsDisabled()) {

				this.highlights.focus.behavior.RespondToInteraction (this.character);
			}
		}

		protected IList<InteractableEntity> GetNearbyInteractable() {
			List<InteractableEntity> interactables = new List<InteractableEntity> ();
			foreach (BaseEntity e in AdventureGame.Entities) {
				if (e.GetType().IsSubclassOf(typeof(InteractableEntity)) &&
					e != this.character && 
					(e.position - this.character.position).Length() < interactionRadius ) {
					interactables.Add ((InteractableEntity)e);
				}
			}
			return interactables;
		}
	}

	class HighlightManager {
		protected List<InteractableEntity> entities = new List<InteractableEntity> ();
		InteractableEntity _focus;
		public InteractableEntity focus {
			get { return _focus; }
		}

		int focusIndex;
		public void ClearHighlights() {
			foreach (InteractableEntity e in entities) {
				e.highlighted = false;
			}
			this.entities.Clear();
		}

		public void Highlight(InteractableEntity entity) {
			this.entities.Add (entity);
			entity.highlighted = true;
		}

		public void AssignFocus() {
			if (this._focus != null)
				this._focus.focused = false;
			if (entities.Count > 0) {
				// if the focus entity is no longer in range, assign focus randomly
				if (!entities.Contains (_focus)) {
					if (this._focus != null) this._focus.focused = false;
					focusIndex = 0;
					_focus = entities [0];
				}

				// otherwise, repair focusIndex
				else {
					focusIndex = entities.IndexOf (_focus);
				}

			} else {
				if (this._focus != null) this._focus.focused = false;
				focusIndex = -1;
				_focus = null;
			}

			if (this._focus != null)
				this._focus.focused = true;
		}

		public void AdvanceFocus(int amt) {
			if (this._focus != null) {
				this._focus.focused = false;
				focusIndex = (focusIndex + amt + this.entities.Count) % this.entities.Count;
				this._focus = this.entities [focusIndex];
				this._focus.focused = true;
			}
		}
	}
}

