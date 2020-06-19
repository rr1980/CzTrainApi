using CzTrainApi.ViewModels.Test;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CzTrainApi.Services.Contracts
{
    public interface IAnredeService
    {
        Task Delete(long id);
        Task<IList<TestAnredeResponseVM>> GetAll();
    }
}
