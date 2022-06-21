using UnityEngine;
using Envy.Main.Module;
using Cysharp.Threading.Tasks;

namespace Envy.Main
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private BoxController boxController;

        private async UniTaskVoid Start()
        {
            Funcs.WriteLine("Entrance");
            var result = await boxController.ScaleElastic(1);
            Funcs.WriteLine($"Exit: {result}");
        }
    }
}