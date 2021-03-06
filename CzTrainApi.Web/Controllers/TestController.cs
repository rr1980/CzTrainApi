﻿using CzTrainApi.Services.Contracts;
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
    public class TestController : ControllerBase
    {
        private readonly ITestService _testService;
        public TestController(ITestService testService)
        {
            _testService = testService;
        }



        ///// <summary>
        ///// Authentifizierungs Test für Admin.
        ///// </summary>
        ///// <remarks>
        ///// Beispiel-Request:
        /////
        /////     {
        /////        "id": 5,
        /////     }
        /////
        ///// </remarks>
        ///// <response code="200">Ok true</response>
        ///// <response code="401">Nicht Authentifiziert</response>  
        ///// <response code="403">Nicht Autorisiert</response>  
        //[Authorize(Policy = "AdminPolicy")]
        //[HttpPost("DeleteAnrede")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //public Task DeleteAnrede([FromBody, Required]TestRequestVM vm)
        //{
        //    return _testService.Delete(vm.Id);
        //}



        ///// <summary>
        ///// Authentifizierungs Test für Nutzer.
        ///// </summary>
        ///// <response code="200">Ok true</response>
        ///// <response code="401">Nicht Authentifiziert</response>  
        ///// <response code="403">Nicht Autorisiert</response>  
        //[Authorize(Policy = "NutzerPolicy")]
        //[HttpPost("GetAnrede")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //public Task<List<TestAnredeResponseVM>> GetAnrede()
        //{
        //    return _testService.GetAllAnrede();
        //}

        ///// <summary>
        ///// Authentifizierungs Test für Nutzer.
        ///// </summary>
        ///// <response code="200">Ok true</response>
        ///// <response code="401">Nicht Authentifiziert</response>  
        ///// <response code="403">Nicht Autorisiert</response>  
        ////[Authorize(Policy = "NutzerPolicy")]
        //[HttpPost("GetKatalogObekte")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //public Task<List<TestKatalogObjekteResponseVM>> GetKatalogObekte()
        //{
        //    return _testService.GetAllKatalogObekte();
        //}

        ///// <summary>
        ///// Authentifizierungs Test für Nutzer.
        ///// </summary>
        ///// <response code="200">Ok true</response>
        ///// <response code="401">Nicht Authentifiziert</response>  
        ///// <response code="403">Nicht Autorisiert</response>  
        ////[Authorize(Policy = "NutzerPolicy")]
        //[HttpPost("GetKatalogObekteWithDeleted")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //public Task<List<TestKatalogObjekteResponseVM>> GetKatalogObekteWithDeleted()
        //{
        //    return _testService.GetAllKatalogObekteWithDeleted();
        //}
    }
}
