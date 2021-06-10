using PromisesLibrary.Responses;
using RSG;

namespace PromisesLibrary
{
    public interface IPostsService
    {
        IPromise<GetAllPostsResponse> GetAllPosts();

        IPromise<PostDto> GetRandomUserPost(int userId);
    }
}