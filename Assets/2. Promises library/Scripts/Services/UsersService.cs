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
    }
}