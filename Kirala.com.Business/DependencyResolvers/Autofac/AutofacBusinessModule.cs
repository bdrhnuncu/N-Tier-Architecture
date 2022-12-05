using Autofac;
using Autofac.Extras.DynamicProxy;
using AutoMapper;
using Castle.DynamicProxy;
using Kirala.com.Business.Abstract;
using Kirala.com.Business.Concrete.Managers;
using Kirala.com.Business.Utilities.BusinessRules.AutoMobileAdverts;
using Kirala.com.Business.Utilities.BusinessRules.AutoMobileAdverts.Abstract;
using Kirala.com.Business.Utilities.BusinessRules.User;
using Kirala.com.Business.Utilities.BusinessRules.User.Abstract;
using Kirala.com.Business.Utilities.Interceptors;
using Kirala.com.DataAccess.Abstract;
using Kirala.com.DataAccess.Concrete.Repositories.EfCore;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kirala.com.Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserRepository>().As<IUserRepository>();
            builder.RegisterType<AddressRepository>().As<IAddressRepository>();
            builder.RegisterType<AutoMobileAdvertsRepository>().As<IAutoMobileAdvertsRepository>();
            builder.RegisterType<UserManager>().As<IUserManager>();
            builder.RegisterType<AddressManager>().As<IAddressManager>();
            builder.RegisterType<AutoMobileAdvertsManager>().As<IAutoMobileAdvertsManager>();
            builder.RegisterType<UserBusinessRule>().As<IUserBusinessRule>();
            builder.RegisterType<AutoMobileAdvertsBusinessRule>().As<IAutoMobileAdvertsBusinessRule>();
            builder.RegisterType<Mapper>().As<IMapper>();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}
