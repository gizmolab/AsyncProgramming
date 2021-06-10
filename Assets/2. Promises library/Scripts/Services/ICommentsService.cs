using PromisesLibrary.Responses;
using RSG;

namespace PromisesLibrary
{
    public interface ICommentsService
    {
        IPromise<GetAllCommentsResponse> GetAllComments();

        IPromise<CommentDto> GetRandomCommentFromPost(int postId);
    }
}