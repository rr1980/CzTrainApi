using CzTrainApi.ViewModels.Login;
using System.Threading.Tasks;

namespace CzTrainApi.Services.Contracts
{
    public interface ITokenService
    {
        Task<LoginInternVM> Validate(string username, string password);
    }
}
