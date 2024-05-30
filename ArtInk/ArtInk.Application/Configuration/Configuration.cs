﻿using ArtInk.Application.Profiles;
using ArtInk.Application.Services.Implementations;
using ArtInk.Application.Services.Interfaces;
using ArtInk.Infraestructure.Repository.Implementations;
using ArtInk.Infraestructure.Repository.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtInk.Application.Configuration
{
    public static class Configuration
    {
        public static void ConfigureApplication(this IServiceCollection services)
        {
            services.AddTransient<IServiceUsuario, ServiceUsuario>();
            //se agrega
        }

        public static void ConfigureAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(config =>
            {
                config.AddProfile<ApplicationProfile>();
            });
        }
    }
}
