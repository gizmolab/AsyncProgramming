using System;
using UnityEngine;

namespace PromisesLibrary
{
    public class GetRandomCommentBehaviour : MonoBehaviour
    {
        #region Fields
        
        private readonly IUsersService _usersService
            = new UsersService();
        
        private readonly ICommentsService _commentsService
            = new CommentsService();
        
        private readonly IPostsService _postsService
            = new PostsService();
        
        #endregion
        
        public void GetRandomComment()
        {
            _usersService
                .GetAllUsers()
                .Then(response => _usersService.SelectRandomUser(response.Users))
                .Then(randomUser => _postsService.GetRandomUserPost(randomUser.id))
                .Then(randomPost => _commentsService.GetRandomCommentFromPost(randomPost.id))
                .Then(comment => PrintComment(comment))
                .Catch(error => OnError(error))
                .Done();
        }

        
        
        private void OnError(Exception e)
        {
            Debug.LogError(e);
        }

        private void PrintComment(CommentDto comment)
        {
            Debug.Log($"Id: {comment.id}, Name: {comment.name}, Email: {comment.email}");
            Debug.Log($"Body{comment.body}");
        }
    }
}


