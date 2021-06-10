using UnityEngine;

namespace PromisesLibrary
{
    public class GetRandomCommentBehaviour : MonoBehaviour
    {
        private readonly IUsersService _usersService
            = new UsersService();
        public void GetRandomComment()
        {
            _usersService
                .GetAllUsers()
                .Then(allUsers => Debug.Log(allUsers.Users));
        }
    }
}