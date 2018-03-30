using System;
namespace Microsoft.Xna.Framework
{
    public class GameTime
    {
        private TimeSpan mElapsedGameTime;
        private TimeSpan mTotalGameTime;
        private bool mIsRunningSlowly;
        public TimeSpan ElapsedGameTime
        {
            get
            {
                return mElapsedGameTime;
            }
        }
        public bool IsRunningSlowly
        {
            get
            {
                return mElapsedGameTime.TotalSeconds > UnityEngine.Time.fixedDeltaTime;
            }
        }
        public TimeSpan TotalGameTime
        {
            get
            {
                return mTotalGameTime;
            }
        }

        public GameTime(
            TimeSpan elapsedGameTime,
            TimeSpan totalGameTime
        )
        {
            mElapsedGameTime = elapsedGameTime;
            mTotalGameTime = totalGameTime;
            
        }
    }
}
