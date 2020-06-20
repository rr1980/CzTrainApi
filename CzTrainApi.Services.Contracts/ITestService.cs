using CzTrainApi.ViewModels.Test;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CzTrainApi.Services.Contracts
{
    public interface ITestService
    {
        Task Delete(long id);
        Task<List<TestAnredeResponseVM>> GetAllAnrede();
        Task<List<TestKatalogObjekteResponseVM>> GetAllKatalogObekte();
        Task<List<TestKatalogObjekteResponseVM>> GetAllKatalogObekteWithDeleted();
    }
}
