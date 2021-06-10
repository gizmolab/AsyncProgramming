using System.Linq;
using PromisesLibrary.Responses;
using RSG;

namespace PromisesLibrary
{
    public class CommentsService : ICommentsService
    {
        private const string CommentsListEndpoint 
            = "https://raw.githubusercontent.com/gizmolab/mockserver/master/responses/comments.json";
        
        private readonly INetworkCommunicator 
            _networkCommunicator = new NetworkCommunicator();
        
        public IPromise<GetAllCommentsResponse> GetAllComments()
        {
            return _networkCommunicator.GetResponseFrom<GetAllCommentsResponse>(CommentsListEndpoint);
        }

        public IPromise<CommentDto> GetRandomCommentFromPost(int postId)
        {
            return GetAllComments()
                .Then(response => SelectRandomComment(response.Comments, postId));
        }

        private CommentDto SelectRandomComment(CommentDto[] comments, int postId)
        {
            var commentsUnderPost = comments.Where(comment => comment.postId == postId).ToArray();
            var randomComment = commentsUnderPost[UnityEngine.Random.Range(0, commentsUnderPost.Length)];
            return randomComment;
        }
    }
}