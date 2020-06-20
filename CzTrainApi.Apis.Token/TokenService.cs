using CzTrainApi.Db;
using CzTrainApi.Entities;
using CzTrainApi.Services.Contracts;
using CzTrainApi.ViewModels.Login;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Text;
using System.Threading.Tasks;

namespace CzTrainApi.Apis.Token
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;
        private readonly DatenbankContext _datenbankContext;
        public TokenService(IConfiguration configuration, DatenbankContext datenbankContext)
        {
            _configuration = configuration;
            _datenbankContext = datenbankContext;
        }

        public async Task<LoginInternVM> Validate(string username, string password)
        {
            LoginInternVM result = null;
            var hash = HashPasswort(password);
            var benutzer = await _datenbankContext.Benutzer.SingleOrDefaultAsync(x => x.Benutzername == username && x.Passwort == hash);

            if (benutzer != null)
            {
                result = new LoginInternVM
                {
                    Id = benutzer.Id,
                    BenutzerRolle = benutzer.BenutzerRolle
                };
            }

            return result;
        }

        private string HashPasswort(string passwort)
        {
            byte[] saltBytes = Encoding.UTF8.GetBytes(_configuration["ApplicationSettings:Salt"]);
            string hash = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: passwort,
                salt: saltBytes,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8
                ));

            return hash;
        }
    }
}
