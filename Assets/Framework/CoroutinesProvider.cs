using System.Collections;
using UnityEngine;

namespace Framework
{
    public static class CoroutinesRunner
    {
        internal class CoroutinesProvider : MonoBehaviour
        {
        }

        private static CoroutinesProvider _providerInstance;

        static CoroutinesRunner()
        {
        }

        public static Coroutine Start(IEnumerator coroutineBody)
        {
            return GetProvider().StartCoroutine(coroutineBody);
        }

        private static CoroutinesProvider GetProvider()
        {
            if (_providerInstance == null)
            {
                var go = new GameObject("CoroutinesRunner");
                Object.DontDestroyOnLoad(go);
                _providerInstance = go.AddComponent<CoroutinesProvider>();
            }

            return _providerInstance;
        }
    }
}