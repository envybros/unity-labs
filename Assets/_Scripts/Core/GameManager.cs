using System;
using System.Threading;
using UnityEngine;

namespace Envy.Core
{
    class Counter
    {
        private const int LOOP_COUNT = 1000;

        private readonly object thisLock;
        private bool lockedCount = false;

        private int count;

        public int Count
        {
            get { return count; }
        }

        public Counter()
        {
            thisLock = new object();
            count = 0;
        }

        public void Increase()
        {
            int loopCount = LOOP_COUNT;

            while (loopCount-- > 0)
            {
                lock (thisLock)
                {
                    while (count > 0 || lockedCount == true)
                    {
                        Monitor.Wait(thisLock);
                    }
                    
                    
                }
            }
        }
    }
    
    public class GameManager : MonoBehaviour
    {
        void Start()
        {
        }
    }
}