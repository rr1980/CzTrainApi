using CzTrainApi.Apis.Katalog.Core;
using CzTrainApi.Entities;
using CzTrainApi.Services.Contracts;

namespace CzTrainApi.Apis.Katalog
{
    public class TitelKatalogController : BaseKatalogController<Titel>
    {
        public TitelKatalogController(IKatalogService katalogService): base (katalogService)
        {
        }
    }
}
