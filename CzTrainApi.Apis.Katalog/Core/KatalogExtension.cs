using CzTrainApi.Services.Contracts;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace CzTrainApi.Apis.Katalog.Core
{
    public static class KatalogExtension
    {
        public static void AddKatalog(this IServiceCollection services)
        {
            var katalogControllerAssembly = typeof(KatalogExtension).Assembly;
            services.AddControllers().PartManager.ApplicationParts.Add(new AssemblyPart(katalogControllerAssembly));

            services.AddScoped<IKatalogService, KatalogService>();
        }
    }

}
