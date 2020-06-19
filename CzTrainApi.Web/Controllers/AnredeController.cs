using CzTrainApi.Services.Contracts;
using CzTrainApi.ViewModels.Test;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CzTrainApi.Web.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("[controller]")]
    public class AnredeController : ControllerBase
    {
        private readonly IAnredeService _anredeService;
        public AnredeController(IAnredeService anredeService)
        {
            _anredeService = anredeService;
        }



        /// <summary>
        /// Authentifizierungs Test für Admin.
        /// </summary>
        /// <remarks>
        /// Beispiel-Request:
        ///
        ///     {
        ///        "id": 5,
        ///     }
        ///
        /// </remarks>
        /// <response code="200">Ok true</response>
        /// <response code="401">Nicht Authentifiziert</response>  
        /// <response code="403">Nicht Autorisiert</response>  
        [Authorize(Policy = "AdminPolicy")]
        [HttpPost("Admin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public Task Admin([FromBody, Required]TestAnredeRequestVM vm)
        {
            return _anredeService.Delete(vm.Id);
        }



        /// <summary>
        /// Authentifizierungs Test für Nutzer.
        /// </summary>
        /// <response code="200">Ok true</response>
        /// <response code="401">Nicht Authentifiziert</response>  
        /// <response code="403">Nicht Autorisiert</response>  
        [Authorize(Policy = "NutzerPolicy")]
        [HttpPost("Nutzer")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public Task<IList<TestAnredeResponseVM>> Nutzer()
        {
            return _anredeService.GetAll();
        }
    }
}
