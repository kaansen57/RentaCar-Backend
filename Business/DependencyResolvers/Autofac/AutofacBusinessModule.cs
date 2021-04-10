using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.CCS;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterType<CarManager>().As<ICarManager>().SingleInstance();
            builder.RegisterType<EfCarDal>().As<ICarDal>().SingleInstance();

            builder.RegisterType<BrandManager>().As<IBrandManager>().SingleInstance();
            builder.RegisterType<EfBrandDal>().As<IBrandDal>().SingleInstance();

            builder.RegisterType<ColorManager>().As<IColorManager>().SingleInstance();
            builder.RegisterType<EfColorDal>().As<IColorDal>().SingleInstance();

            builder.RegisterType<UserManager>().As<IUserManager>().SingleInstance();
            builder.RegisterType<EfUserDal>().As<IUserDal>().SingleInstance();

            builder.RegisterType<CustomerManager>().As<ICustomerManager>().SingleInstance();
            builder.RegisterType<EfCustomerDal>().As<ICustomerDal>().SingleInstance();

            builder.RegisterType<RentalManager>().As<IRentalManager>().SingleInstance();
            builder.RegisterType<EfRentalDal>().As<IRentalDal>().SingleInstance();

            builder.RegisterType<CarImageManager>().As<ICarImageManager>().SingleInstance();
            builder.RegisterType<EfCarImageDal>().As<ICarImageDal>().SingleInstance();

            builder.RegisterType<CarPropertyManager>().As<ICarPropertyManager>().SingleInstance();
            builder.RegisterType<EfCarPropertyDal>().As<ICarPropertyDal>().SingleInstance();

            builder.RegisterType<FuelManager>().As<IFuelManager>().SingleInstance();
            builder.RegisterType<EfFuelDal>().As<IFuelDal>().SingleInstance();

            builder.RegisterType<GearManager>().As<IGearManager>().SingleInstance();
            builder.RegisterType<EfGearDal>().As<IGearDal>().SingleInstance();

            builder.RegisterType<CarClassManager>().As<ICarClassManager>().SingleInstance();
            builder.RegisterType<EfCarClassDal>().As<ICarClassDal>().SingleInstance();

            builder.RegisterType<CreditCardManager>().As<ICreditCardManager>().SingleInstance();
            builder.RegisterType<EfCreditCardDal>().As<ICreditCardDal>().SingleInstance();

            builder.RegisterType<SavedCardManager>().As<ISavedCardManager>().SingleInstance();
            builder.RegisterType<EfSavedCardDal>().As<ISavedCardDal>().SingleInstance();

            builder.RegisterType<RentalTermManager>().As<IRentalTermManager>().SingleInstance();
            builder.RegisterType<EfRentalTermDal>().As<IRentalTermDal>().SingleInstance();

            builder.RegisterType<FileLogger>().As<ILogger>().SingleInstance();

            builder.RegisterType<UserJwtManager>().As<IUserJwtManager>();
            builder.RegisterType<EfUserJwtDal>().As<IUserJwtDal>();

            builder.RegisterType<AuthManager>().As<IAuthManager>();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();

           

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}
