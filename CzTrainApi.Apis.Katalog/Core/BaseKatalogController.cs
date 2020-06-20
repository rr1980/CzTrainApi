using CzTrainApi.Apis.Katalog.Core;
using CzTrainApi.Common.BaseTypes;
using CzTrainApi.Services.Contracts;
using CzTrainApi.ViewModels.Katalog;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CzTrainApi.Apis.Katalog.Core
{
    [ApiController]
    [Produces("application/json")]
    [Route("[controller]")]
    public abstract class BaseKatalogController<T> : ControllerBase where T : class, IKatalogObjekt
    {
       protected IKatalogService _katalogService;
        public BaseKatalogController(IKatalogService katalogService)
        {
            _katalogService = katalogService;
        }

        /// <summary>
        /// Authentifizierungs Test für Nutzer.
        /// </summary>
        /// <response code="200">Ok true</response>
        /// <response code="401">Nicht Authentifiziert</response>  
        /// <response code="403">Nicht Autorisiert</response>  
        //[Authorize(Policy = "KatalogLesenPolicy")]
        [HttpPost("GetAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public Task<List<KatalogObjektVM>> GetAll()
        {
            return _katalogService.GetAll<T>();
        }
    }
}
