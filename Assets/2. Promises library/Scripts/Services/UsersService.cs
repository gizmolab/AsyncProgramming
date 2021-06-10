using System;
using PromisesLibrary.Responses;
using RSG;

namespace PromisesLibrary
{
    public class UsersService : IUsersService
    {
        private const string UsersListEndpoint 
            = "https://raw.githubusercontent.com/gizmolab/mockserver/master/responses/users.json";
        
        private readonly INetworkCommunicator 
            _networkCommunicator = new NetworkCommunicator();
        
        public IPromise<GetAllUsersResponse> GetAllUsers()
        {
            return _networkCommunicator.GetResponseFrom<GetAllUsersResponse>(UsersListEndpoint);
        }

        public IPromise<UserDto> SelectRandomUser(UserDto[] users)
        {
            if (users == null || users.Length <= 0)
            {
                throw new ArgumentException("Users list is empty");
            }
            var randomUser = users[UnityEngine.Random.Range(0, users.Length)];
            return Promise<UserDto>.Resolved(randomUser);
        }
    }
}