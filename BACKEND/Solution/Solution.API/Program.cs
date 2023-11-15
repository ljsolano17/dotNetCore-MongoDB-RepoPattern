using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Driver.Core;
using Solution.DAL.Mongo;
using Solution.DAL.Repository;
using Solution.DO.Objects;

namespace Solution.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Agregar la configuración del archivo appsettings.json
            builder.Configuration.AddJsonFile("appsettings.json");

            // Obtener el ConnectionString del archivo appsettings.json
            var connectionString = builder.Configuration.GetConnectionString("MongoDB:ConnectionString");
            var databaseName = builder.Configuration.GetSection("MongoDB:DatabaseName").Value;

            // Configurar servicios
            builder.Services.Configure<MongoDbSettings>(builder.Configuration.GetSection("MongoDbSettings"));
            builder.Services.AddSingleton<IMongoDbSettings>(serviceProvider =>
                serviceProvider.GetRequiredService<IOptions<MongoDbSettings>>().Value);

            builder.Services.AddScoped(typeof(IMongoRepository<>), typeof(MongoRepository<>));


            // Add services to the container.

            builder.Services.AddControllers();


            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}