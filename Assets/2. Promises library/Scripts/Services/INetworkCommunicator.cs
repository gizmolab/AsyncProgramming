using RSG;

namespace PromisesLibrary
{
    public interface INetworkCommunicator
    {
        IPromise<TResponse> GetResponseFrom<TResponse>(string apiAddress);
    }
}