using PromisesLibrary.Responses;
using RSG;

namespace PromisesLibrary
{
    public interface IUsersService
    {
        IPromise<GetAllUsersResponse> GetAllUsers();

        IPromise<UserDto> SelectRandomUser(UserDto[] users);
    }
}