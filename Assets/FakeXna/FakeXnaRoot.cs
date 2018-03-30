using UnityEngine;
using Microsoft.Xna.Framework;
using QuickUnityTools;
namespace FakeXna
{
    class FakeXnaRoot : Singleton<FakeXnaRoot>
    {
        public MeshRenderer renderTarget;
        protected Game mGame;
        bool isRunning = true;

        public void Start()
        {
            mGame = new Adventure.AdventureGame();
            mGame.Start();
        }

        public void Update()
        {
            mGame.Update();
        }

    }
}
