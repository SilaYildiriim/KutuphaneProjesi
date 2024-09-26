using Autofac;
using AutoMapper;
using KutuphaneProjesi.Application.Profiles;
using KutuphaneProjesi.Application.Services.BookService;
using KutuphaneProjesi.Application.Services.UserService;
using KutuphaneProjesi.Domain.Repositories;
using KutuphaneProjesi.Infrastructure.Repositories;

namespace KutuphaneProjesi.Application.Extensions
{
    public class DependencyInjection : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<BookService>().As<IBookService>().InstancePerLifetimeScope();
            builder.RegisterType<UserService>().As<IUserService>().InstancePerLifetimeScope();

            builder.RegisterType<BookRepo>().As<IBookRepo>().InstancePerLifetimeScope();
            builder.RegisterType<UserRepo>().As<IUserRepo>().InstancePerLifetimeScope();
            builder.RegisterType<RoleRepo>().As<IRoleRepo>().InstancePerLifetimeScope();
            builder.RegisterType<UserRoleRepo>().As<IUserRoleRepo>().InstancePerLifetimeScope();

            builder.Register(context => new MapperConfiguration(config =>
            {
                config.AddProfile<MappingProfile>();
            })).AsSelf().SingleInstance();

            builder.Register(c =>
            {
                var context = c.Resolve<IComponentContext>();
                var config = context.Resolve<MapperConfiguration>();
                return config.CreateMapper(context.Resolve);

            }).As<IMapper>()
              .InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}
