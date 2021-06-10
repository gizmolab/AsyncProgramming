using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

namespace CoroutinesAndMultithreading
{
    public class NetworkCallsBehaviour : MonoBehaviour
    {
        private const string GoogleAddress = "google.com";
        private const string IgnAddress = "ign.com";
        private const string WjsAddress = "wjs.com";

        public void RunCoroutines()
        {
            StartCoroutine(GetContentLength(GoogleAddress, l => Debug.Log($"{GoogleAddress} : {l}")));
            StartCoroutine(GetContentLength(IgnAddress, l => Debug.Log($"{IgnAddress} : {l}")));
            StartCoroutine(GetContentLength(WjsAddress, l => Debug.Log($"{WjsAddress} : {l}")));
        }

        private IEnumerator GetContentLength(string webAddress, Action<int> endCallback)
        {
            using (var request = UnityWebRequest.Get(webAddress))
            {
                yield return request.SendWebRequest();
                var contentLength = request.downloadHandler.text.Length;
                endCallback?.Invoke(contentLength);
            }
        }
    }
}

