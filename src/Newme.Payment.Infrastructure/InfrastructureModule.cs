using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newme.Payment.Infrastructure.Persistence.Repositories;
using Newme.Payment.Domain.Messaging;
using Newme.Payment.Domain.Repositories;
using Newme.Payment.Infrastructure.Persistence;
using Newme.Payment.Infrastructure.Consulting;
using MongoDB.Driver;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Bson;
using Newme.Payment.Infrastructure.Persistence.Mappers;
using Newme.Payment.Infrastructure.Messaging;

namespace Newme.Payment.Infrastructure
{
    public static class InfrastructureModule
    {
        public static IServiceCollection AddInfrastructureModule(this IServiceCollection services)
        {            
            services
                .AddMongo()
                .AddRepositories()
                .AddMessageBus();

            return services;
        }
        
        private static IServiceCollection AddMongo(this IServiceCollection services)
        {
            services.AddSingleton<MongoDbOptions>(sp => {
                var options = new MongoDbOptions();
                var configuration = sp.GetService<IConfiguration>();

                configuration.GetSection("Mongo").Bind(options);

                return options;
            });

            services.AddSingleton<IMongoClient>(sp => {
                var options = sp.GetService<MongoDbOptions>();

                var client = new MongoClient(options.ConnectionString);
                var db = client.GetDatabase(options.Database);

                return client;
            });

            services.AddSingleton(sp => {
                BsonSerializer.RegisterSerializer(new GuidSerializer(BsonType.String));
                BsonSerializer.RegisterSerializer(new DateTimeSerializer(BsonType.String));

                MongoMapper.Configure();

                var options = sp.GetService<MongoDbOptions>();
                var mongoClient = sp.GetService<IMongoClient>();

                var db = mongoClient.GetDatabase(options.Database);

                return db;
            });

            return services;
        }

        private static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddSingleton<ICollection, Collection>();
            services.AddScoped<IMessageBusServer, RabbitMqService>();
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

            return services;
        }

        private static IServiceCollection AddMessageBus(this IServiceCollection services) {
            services.AddScoped<IMessageBusServer, RabbitMqService>();
            
            return services;
        }
    }
}