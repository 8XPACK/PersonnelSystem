using PersonnelSystem.Api.Extensions;
using PersonnelSystem.Api.Profiles;
using System.Text.Json.Serialization;

namespace PersonnelSystem.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

            builder.Services.AddControllers()
                .AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
     
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContexts(builder.Configuration);
            builder.Services.AddCorsPolicy();
            builder.Services.AddAutoMapper(typeof(MappingProfile));
            builder.Services.RegisterApplicationServices();
            
            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseCors();
            app.MapControllers();

            app.Run();
        }
    }
}
