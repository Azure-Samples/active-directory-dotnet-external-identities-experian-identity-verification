namespace CrossCoreExtIdApi.Services
{
    using System.Threading.Tasks;
    using Models;

    public interface IService
    {
        Task<string> ServiceCall(ICrossCoreInput input);
    }
}