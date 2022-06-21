// 전역에서 쓸 수 있도록 함
namespace Envy
{
    public readonly struct Funcs
    {
        public static void WriteLine(object obj)
        {
#if UNITY_EDITOR
            UnityEngine.Debug.Log(obj);
#endif
        }
    }
}