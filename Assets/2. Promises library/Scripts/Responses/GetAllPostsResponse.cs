using System;
using Newtonsoft.Json;

namespace PromisesLibrary.Responses
{
    [Serializable]
    public class GetAllPostsResponse
    {
        [JsonProperty("posts")]
        public PostDto[] Posts;
    }
}