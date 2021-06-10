using System;
using System.Collections;
using Framework;
using Newtonsoft.Json;
using RSG;
using UnityEngine;
using UnityEngine.Networking;

namespace PromisesLibrary
{
    public class NetworkCommunicator : INetworkCommunicator
    {
        public IPromise<TResponse> GetResponseFrom<TResponse>(string apiAddress)
        {
            var p = new Promise<TResponse>();
            CoroutinesRunner.Start(SendRequestTo(apiAddress, (success, responseText) =>
            {
                if (success)
                {
                    try
                    {
                        var response = JsonConvert.DeserializeObject<TResponse>(responseText);
                        p.Resolve(response);
                    }
                    catch (Exception x)
                    {
                        p.Reject(x);
                    }
                }
                else
                {
                    p.Reject(new Exception(responseText));
                }
            }));
            return p;
        }
        
        private IEnumerator SendRequestTo(string apiAddress, Action<bool, string> endCallback)
        {
            using(var request = UnityWebRequest.Get(apiAddress))
            {
                yield return request.SendWebRequest();
                var success = string.IsNullOrEmpty(request.error);
                var resultText = success
                    ? request.downloadHandler.text
                    : request.error;
                
                endCallback?.Invoke(success, resultText);
            }
        }
    }
}