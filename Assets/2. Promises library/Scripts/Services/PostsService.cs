using System.Linq;
using PromisesLibrary.Responses;
using RSG;

namespace PromisesLibrary
{
    public class PostsService : IPostsService
    {
        private const string PostsListEndpoint 
            = "https://raw.githubusercontent.com/gizmolab/mockserver/master/responses/posts.json";
        
        private readonly INetworkCommunicator 
            _networkCommunicator = new NetworkCommunicator();

        public IPromise<GetAllPostsResponse> GetAllPosts()
        {
            return _networkCommunicator.GetResponseFrom<GetAllPostsResponse>(PostsListEndpoint);
        }

        public IPromise<PostDto> GetRandomUserPost(int userId)
        {
            return GetAllPosts()
                .Then(response => SelectRandomPost(response.Posts, userId));
        }

        private PostDto SelectRandomPost(PostDto[] posts, int userId)
        {
            var usersPosts = posts.Where(post => post.userId == userId).ToArray();
            var randomPost = usersPosts[UnityEngine.Random.Range(0, usersPosts.Length)];
            return randomPost;
        }
    }
}