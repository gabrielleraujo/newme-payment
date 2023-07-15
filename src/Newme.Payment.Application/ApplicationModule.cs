using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Newme.Payment.Application.Subscribers.PurchaseRefundAsExchangeVoucher;
using Newme.Payment.Application.AutoMapper;
using Newme.Payment.Application.Services;
using Newme.Payment.Application.Commands.ChangePaymentStatus;
using Autofac;

namespace Newme.Payment.Application
{
    public static class ApplicationModule
    {
        public static IServiceCollection AddApplicationModule(this IServiceCollection services)
        {
            services
                .AddSubscribers()
                .AddValidators()
                .AddSMediator()
                .AddApplicationServices()
                .AddAutoMapperConfiguration();

            return services;
        }

        private static IServiceCollection AddSMediator(this IServiceCollection services) {
            
            var builder = new ContainerBuilder();
            builder.RegisterGeneric(typeof(ChangePaymentStatusCommandHandler<>)).AsImplementedInterfaces();
                    
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            
            return services;
        }

        private static IServiceCollection AddSubscribers(this IServiceCollection services) {
            services.AddHostedService<PurchaseRefundAsExchangeVoucherSubscriber>();
            
            return services;
        }

        public static IServiceCollection AddValidators(this IServiceCollection services)
        {
            //services.AddValidatorsFromAssemblyContaining<RegisterPixValidation>(ServiceLifetime.Scoped);
            //services.AddValidatorsFromAssemblyContaining<RegisterDebitCardValidation>(ServiceLifetime.Scoped);
            //services.AddValidatorsFromAssemblyContaining<RegisterCreditCardValidation>(ServiceLifetime.Scoped);
            //services.AddValidatorsFromAssemblyContaining<ChangePaymentValidation>(ServiceLifetime.Scoped);

            return services;
        }

        private static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IPaymentService, PaymentService>();

            return services;
        }

        public static IServiceCollection AddAutoMapperConfiguration(this IServiceCollection services)
        {
            services.AddAutoMapper(
                typeof(InputModelToCommandMappingProfile)
            );

            return services;
        }
    }
}