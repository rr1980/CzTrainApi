using CzTrainApi.Services.Contracts;
using CzTrainApi.ViewModels.Login;
using CzTrainApi.ViewModels.Test;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CzTrainApi.Apis.Token
{

    [ApiController]
    [Produces("application/json")]
    [Route("[controller]")]
    public class TokenController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ITokenService _tokenService;
        public TokenController(IConfiguration configuration, ITokenService tokenService)
        {
            _configuration = configuration;
            _tokenService = tokenService;
        }


        /// <summary>
        /// Authentifiziert und gibt, bei Erfolg, ein Token zurück.
        /// </summary>
        /// <remarks>
        /// Beispiel-Request:
        ///
        ///     {
        ///        "user": "Max123",
        ///        "password": "12003"
        ///     }
        ///
        /// </remarks>
        /// <response code="200">Authentifikation erfolgreich</response>
        /// <response code="400">Validierungsfehler</response>  
        /// <response code="401">Authentifikation nicht erfolgreich</response>  
        /// <response code="500">Interner Server Fehler</response>  
        [HttpPost("GetToken")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<LoginResponseVM>> GetToken([FromBody, Required]LoginRequestVM vm)
        {
            var loginValidationResult = await _tokenService.Validate(vm.User, vm.Password);
            if (loginValidationResult != null)
            {
                var claims = new List<Claim>()
                {
                    new Claim("UserId", loginValidationResult.Id.ToString()),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(ClaimTypes.Role, loginValidationResult.BenutzerRolle)
                };

                var now = DateTime.UtcNow;
                var key = Encoding.UTF8.GetBytes(_configuration["ApplicationSettings:Secret"]);

                var token = new JwtSecurityToken
                (
                    issuer: _configuration["ApplicationSettings:Issuer"].ToString(),
                    audience: _configuration["ApplicationSettings:Audience"].ToString(),
                    claims: claims.ToArray(),
                    notBefore: now,
                    expires: now.Add(TimeSpan.FromMinutes(120)),
                    signingCredentials: new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
                );

                return new LoginResponseVM
                {
                    Token = new JwtSecurityTokenHandler().WriteToken(token),
                    BenutzerRolle = loginValidationResult.BenutzerRolle
                };
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}
