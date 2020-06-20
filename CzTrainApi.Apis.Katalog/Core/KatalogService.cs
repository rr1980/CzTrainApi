using CzTrainApi.Common.BaseTypes;
using CzTrainApi.Db;
using CzTrainApi.Services.Contracts;
using CzTrainApi.ViewModels.Katalog;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CzTrainApi.Apis.Katalog.Core
{
    public class KatalogService : IKatalogService
    {
        private readonly DatenbankContext _datenbankContext;
        public KatalogService(DatenbankContext datenbankContext)
        {
            _datenbankContext = datenbankContext;
        }

        public Task<List<KatalogObjektVM>> GetAll<T>() where T : class, IKatalogObjekt
        {
            return _datenbankContext.Set<T>().AsNoTracking().Select(a => new KatalogObjektVM
            {
                Id = a.Id,
                Geloescht = a.Geloescht,
                Erstellungsdatum = a.Erstellungsdatum,
                Aenderungsdatum = a.Aenderungsdatum,
                Bezeichnung = a.Bezeichnung,
                Discriminator = a.Discriminator
            }).ToListAsync();
        }
    }
}
