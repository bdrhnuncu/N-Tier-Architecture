using Autofac.Extensions.DependencyInjection;
using Kirala.com.Business.DependencyResolvers.Autofac;
using Kirala.com.Business.Mapping.AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kirala.com.Business.BusinessServices
{
    public static class BusinessService
    {
        public static void AddBusinessService(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MappingProfile).Assembly);
        }
    }
}
