using System;
using System.Collections;
using UnityEngine;

namespace CoroutinesAndMultithreading
{
    public class AllOnMainThreadBehaviour : MonoBehaviour
    {
        private float _delayTime = 3f;
    
        public void RunCoroutines()
        {
            StartCoroutine(DelayCoroutine(_delayTime, () => Debug.Log("Coroutine ended")));
            StartCoroutine(DelayCoroutine(_delayTime, () => Debug.Log("Coroutine ended")));
            StartCoroutine(DelayCoroutine(_delayTime, () => Debug.Log("Coroutine ended")));
        }

        private IEnumerator DelayCoroutine(float delayTime, Action endCallback )
        {
            var endTime = Time.time + delayTime;
            while (Time.time < endTime)
            {
                yield return null;
            }
            endCallback?.Invoke();
        }
    }
}

