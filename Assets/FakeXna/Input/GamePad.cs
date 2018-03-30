namespace Microsoft.Xna.Framework.Input
{
    public class GamePad
    {
        public static GamePadState GetState(PlayerIndex index)
        {
            return new GamePadState(index);
        }
    }
}