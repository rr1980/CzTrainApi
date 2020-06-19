using CzTrainApi.Entities;
using CzTrainApi.Repository.Contracts;
using CzTrainApi.Services.Contracts;
using CzTrainApi.ViewModels.Login;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.Extensions.Configuration;
using System;
using System.Text;
using System.Threading.Tasks;

namespace CzTrainApi.Apis.Token
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;
        private readonly IDbRepository _dbRepository;
        public TokenService(IConfiguration configuration, IDbRepository dbRepository)
        {
            _configuration = configuration;
            _dbRepository = dbRepository;
        }

        public async Task<LoginInternVM> Validate(string username, string password)
        {
            LoginInternVM result = null;
            var hash = HashPasswort(password);
            var benutzer = await _dbRepository.Get<Benutzer>(x => x.Benutzername == username && x.Passwort == hash);

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
