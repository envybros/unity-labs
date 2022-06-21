using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Envy.Main
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private Button cancelButton;
        [SerializeField] private Button disposeButton;
        private CancellationTokenSource _cancellationTokenSource;

        private void Awake()
        {
            _cancellationTokenSource = new CancellationTokenSource();
            cancelButton.onClick.AddListener(CancelButton);
            disposeButton.onClick.AddListener(DisposeButton);
        }

        private async UniTaskVoid Start()
        {
            WhileTest();
        }

        private async UniTaskVoid WhileTest()
        {
            while (true)
            {
                await UniTask.Delay(TimeSpan.FromSeconds(0.5f),
                    cancellationToken: _cancellationTokenSource.Token);
                Funcs.WriteLine(Time.realtimeSinceStartup);
            }
        }

        private void CancelButton()
        {
            _cancellationTokenSource.Cancel();
        }

        private void DisposeButton()
        {
            _cancellationTokenSource.Dispose();
        }

        private void OnDestroy()
        {
            Funcs.WriteLine("삭제됨");
        }
    }
}