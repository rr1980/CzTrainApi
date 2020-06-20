using CzTrainApi.Common.BaseTypes;
using CzTrainApi.ViewModels.Katalog;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CzTrainApi.Services.Contracts
{
    public interface IKatalogService
    {
        Task<List<KatalogObjektVM>> GetAll<T>() where T : class, IKatalogObjekt;
    }
}
