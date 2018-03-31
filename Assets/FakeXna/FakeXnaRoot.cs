using System;
using UnityEngine;
using Microsoft.Xna.Framework;
using QuickUnityTools;
namespace FakeXna
{
    class FakeXnaRoot : Singleton<FakeXnaRoot>
    {
        protected Game mGame;
        bool isRunning = true;

        public void Start()
        {
            Debug.Log(Resources.Load("tojam11/Content/npc_parts/head_bunny_idle"));
            if (isRunning) {
                try {
                    mGame = new Adventure.AdventureGame();
                    mGame.Content.SetResourcesRootPath("tojam11");
                    mGame.Start();
                } catch (Exception e) {
                    //isRunning = false;
                    throw;
                }
            }
        }

        public void Update()
        {
            if (isRunning) {
                try {
                    mGame.Update();
                } catch (Exception e) {
                    //isRunning = false;
                    throw;
                }
            }
        }

    }
}
