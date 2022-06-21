using System;
using UnityEngine;
using Cysharp.Threading.Tasks;

namespace Envy.Main
{
    public class GameManager : MonoBehaviour
    {
        public async UniTaskVoid WhileTest()
        {
            while (true)
            {
                await UniTask.Yield(this.GetCancellationTokenOnDestroy());
                Funcs.WriteLine(Time.realtimeSinceStartup);
            }
        }

        public async UniTask Start()
        {
            WhileTest();
        }

        private void OnDestroy()
        {
            Funcs.WriteLine("삭제됨");
        }
    }
}