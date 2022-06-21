using System;
using UnityEngine;
using Cysharp.Threading.Tasks;
using UniTasks = Cysharp.Threading.Tasks.UniTask;

namespace Envy.Main
{
    public class GameManager : MonoBehaviour
    {
        public async UniTaskVoid Function()
        {
            Funcs.WriteLine("Entrance");
            await UniTasks.Delay(TimeSpan.FromSeconds(5f)); // 5초
            Funcs.WriteLine(("Exit"));
        }

        public async UniTask<float> FunctionFloat()
        {
            Funcs.WriteLine("Float Entrance");
            await UniTasks.Delay(TimeSpan.FromSeconds(5f)); // 5초
            return 1.0f;
        }

        // 이것도 되나봄
        public async UniTasks Start()
        {
            Function().Forget(); // forget?
            var f = await FunctionFloat();
            Funcs.WriteLine($"Value => {f}");
        }
    }
}