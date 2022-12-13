using System.Reflection;
using FluentValidation;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using CompanyManagementSystem.Core;
using System.Threading.Tasks;
using CompanyManagementSystem.Core.DTOs;
using CompanyManagementSystem.Repository.UnitOfWorks;
using CompanyManagementSystem.Service.Exceptions;
using System.Text.Json;
using System.Linq;
using Module = Autofac.Module;
using Autofac.Extensions.DependencyInjection;
using CompanyManagementSystem.Repository.Repositories;
using CompanyManagementSystem.Core.Repositories;
using CompanyManagementSystem.Core.Services;
using CompanyManagementSystem.Core.UnitOfWorks;
using CompanyManagementSystem.Service.Mapping;
using CompanyManagementSystem.Service.Services;
using Autofac;
using CompanyManagementSystem.Core.Models;

namespace CompanyManagementSystem.WEB.Modules
{
    public class RepositoryServicesModules : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(GenericRepository<>)).As(typeof(IGenericRepository<>)).InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(GenericService<>)).As(typeof(IGenericService<>)).InstancePerLifetimeScope();
  
            builder.RegisterType<CompanyRepository>().As<ICompanyRepository>();
            builder.RegisterType<CompanyDealerRepository>().As<ICompanyDealerRepository>();
            builder.RegisterType<BranchOfficeRepository>().As<IBranchOfficeRepository>();
 




            builder.RegisterType<CompanyService>().As<ICompanyService>();
            builder.RegisterType<CompanyDealerService>().As<ICompanyDealerService>();
            builder.RegisterType<BranchOfficeService>().As<IBranchOfficeService>();





            builder.RegisterType<UnitOfWork>().As<IGenericUnitOfWork>();

            var repository =  Assembly.GetAssembly(typeof(AppContext));
            var service = Assembly.GetAssembly(typeof(MapProfiles));
            var api = Assembly.GetExecutingAssembly();


            builder.RegisterAssemblyTypes(repository, service, api).Where(x => x.Name.EndsWith("Repository")).AsImplementedInterfaces().InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(repository, service, api).Where(x => x.Name.EndsWith("Service")).AsImplementedInterfaces().InstancePerLifetimeScope();


        }
    }
}
