using Newtonsoft.Json;

namespace PromisesLibrary.Responses
{
    public class GetAllCommentsResponse
    {
        [JsonProperty("comments")]
        public CommentDto[] Comments;
    }
}