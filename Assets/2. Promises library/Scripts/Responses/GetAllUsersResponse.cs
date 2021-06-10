using System;
using Newtonsoft.Json;

namespace PromisesLibrary.Responses
{
    [Serializable]
    public class GetAllUsersResponse
    {
        [JsonProperty("users")]
        public UserDto[] Users;
    }
}