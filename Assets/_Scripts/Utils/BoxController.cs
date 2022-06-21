using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
using DG.Tweening;

namespace Envy.Main.Module
{
    public class BoxController : MonoBehaviour
    {
        private Material mat;
        private Transform tr;

        private void Awake()
        {
            mat = this.GetComponent<MeshRenderer>().material;
            tr = this.GetComponent<Transform>();
        }

        public async UniTask<int> ScaleElastic(float duration)
        {
            await UniTask.Delay(TimeSpan.FromSeconds(.1f));

            Funcs.WriteLine("Act1 - ShakeScale");
            tr.localScale = Vector3.one;

            await tr.DOShakeScale(duration)
                .SetEase(Ease.InOutQuad);

            Funcs.WriteLine("Act2 - Color To Magenta");
            await UniTask.Delay(TimeSpan.FromSeconds(1f));
            await mat.DOColor(Color.magenta, duration)
                .SetEase(Ease.OutFlash)
                .SetLoops(2, LoopType.Yoyo);

            Funcs.WriteLine("Act3 - Scale Zero");
            await tr.DOScale(Vector3.zero, duration)
                .SetEase(Ease.InBack);

            Funcs.WriteLine("Act4 - Scale One");
            await tr.DOScale(Vector3.one, duration)
                .SetEase(Ease.OutBack);

            Funcs.WriteLine("Act5 - Rotation And Color Tuple Acting");
            tr.DOShakeRotation(duration)
                .SetEase(Ease.OutCirc);
            await mat.DOColor(Color.cyan, duration * 2)
                .SetEase(Ease.OutBack);

            Funcs.WriteLine("All Act End");
            return 0;
        }
    }
}