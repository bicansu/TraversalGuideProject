using CapstoneProject_BusinessLayer.Abstract;
using CapstoneProject_BusinessLayer.Abstract.AbstractUow;
using CapstoneProject_BusinessLayer.Concrete;
using CapstoneProject_BusinessLayer.Concrete.ConcreteUow;
using CapstoneProject_BusinessLayer.ValidationRules.ContactAddValidator;
using CapstoneProject_BusinessLayer.ValidationRules.ContactValidation;
using CapstoneProject_DataAccessLayer.Abstract;
using CapstoneProject_DataAccessLayer.EntityFramework;
using CapstoneProject_DataAccessLayer.UnitOfWork;
using CapstoneProject_DTOLayer.DTOs.ContactDTOs;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapstoneProject_BusinessLayer.DIContainer
{
    public static class Extensions
    {
        public static void ContainerDependencies(this IServiceCollection services)
        {
            
            services.AddScoped<IBannerService, BannerManager>();
            services.AddScoped<IBannerDal, EfBannerDal>();

            services.AddScoped<ITourInformaService, TourInformManager>();
            services.AddScoped<ITourInformDal, EfITourInformDal>();

            services.AddScoped<IContact3Service, Contact3Manager>();
            services.AddScoped<IContact3Dal, EfContact3Dal>();

            services.AddScoped<IOurInfoService, OurInfoManager>();
            services.AddScoped<IOurInfoDal, EfOurInfoDal>();

            services.AddScoped<ISubscriberService, SubscriberManager>();
            services.AddScoped<ISubscriberDal, EfSubscriberDal>();

            services.AddScoped<IAboutService, AboutManager>();
            services.AddScoped<IAboutDal, EfAboutDal>();

            services.AddScoped<IAccountService, AccountManager>();
            services.AddScoped<IAccountDal, EfAccountDal>();

            services.AddScoped<IExcelService, ExcelManager>();

            services.AddScoped<IMailRequestService, MailRequestManager>();
            services.AddScoped<IMailRequestDal, EfMailRequestDal>();



            services.AddScoped<IUowDal, UowDal>();
        }

        public static void CustomizeValidator(this IServiceCollection services)
        {
            services.AddTransient<IValidator<ContactAddDto>, ContactAddValidator>();
            services.AddTransient<IValidator<ContactUpdateDTO>, ContactUpdateValidator>();
        }
    }
}
