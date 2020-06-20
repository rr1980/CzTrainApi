using CzTrainApi.Apis.Katalog.Core;
using CzTrainApi.Entities;
using CzTrainApi.Services.Contracts;

namespace CzTrainApi.Apis.Katalog
{
    public class AnredeKatalogController : BaseKatalogController<Anrede>
    {
        public AnredeKatalogController(IKatalogService katalogService) : base(katalogService)
        {
        }
    }
}
