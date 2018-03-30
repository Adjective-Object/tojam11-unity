﻿using System;

namespace Adventure
{
	public class ChickenGangLeader : CharacterBehavior
	{

		public ChickenGangLeader (SoundFont speech) : base (speech) {
		}

		override public void RespondToInteraction(Character player) {
			// turn to face player
			character.facingLeft = player.position.X < character.position.X;

            if (GameStateDictionary.instance.getState("penguin_racist").Equals("yes"))
            {
                EmitSpeech("I heard you don't like penguins either *high fives*");
                LogEndMessage("Found out the chickens are racist.");
                return;
            }

			// do conversation
			switch (interactionCount) {
			case 0:
				SpeakAndAdvance (player, "We're the chicken gang");
				break;
			default:
				EmitSpeech ("I think we're pretty cool");
				break;
			}
			interactionCount++;
		}
	}
}

