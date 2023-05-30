using Microsoft.OpenApi.Models;
using potg.Data.Mappers;
using potg.Database;
using potg.Database.Interfaces;
using potg.Database.Repositories;
using potg.RiotGames;
using potg.RiotGames.Services;
using potg.Services;
using potg.Tools;

namespace potg
{
    public static class Program
    {

        public static async Task Main(string[] args)
        {
            Console.Title = "POTG";

            var leagueVersion = await Utils.GetLatestLeagueVersion();
            if (leagueVersion == null) return;
            await DataDragon.Instance.Load(leagueVersion);

            var builder = WebApplication.CreateBuilder(new WebApplicationOptions
            {
                Args = args,
                ContentRootPath = Environment.CurrentDirectory
            });
            builder.Configuration.AddEnvironmentVariables();
            builder.Services.AddOptions();
            builder.Services.AddResponseCompression();
            builder.Services.AddControllers().AddNewtonsoftJson(o =>
            {
                // o.SerializerSettings.Converters.Add(new StringEnumConverter());
            });
            builder.Services.AddSwaggerGenNewtonsoftSupport();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.EnableAnnotations();

                c.SwaggerDoc("POTG v1", new OpenApiInfo { Title = "POTG v1", Version = "v1" });
                c.SwaggerDoc("POTG Summoner v1", new OpenApiInfo { Title = "POTG Summoner v1", Version = "v1" });
                c.SwaggerDoc("POTG Spectator v1", new OpenApiInfo { Title = "POTG Spectator v1", Version = "v1" });

                c.SwaggerDoc("Summoner v4", new OpenApiInfo {Title = "Summoner v4", Version = "v4"});
                c.SwaggerDoc("League v4", new OpenApiInfo {Title = "League v4", Version = "v4"});
                c.SwaggerDoc("Match v5", new OpenApiInfo {Title = "Match v5", Version = "v5"});
            });

            builder.Services.Configure<RouteOptions>(o => o.LowercaseUrls = true);
            builder.Services.Configure<MongoConfiguration>(builder.Configuration.GetSection("MongoConfiguration"));
            builder.Services.Configure<RiotApiConfiguration>(builder.Configuration.GetSection("RiotApiConfiguration"));

            builder.Services.AddSingleton(builder.Configuration);

            builder.Services.AddSingleton<LoggingService>();
            builder.Services.AddSingleton<IMongoContext, MongoContext>();
            builder.Services.AddSingleton<RateLimitService>();
            
            builder.Services.AddSingleton<SummonerService>();
            builder.Services.AddSingleton<LeagueService>();
            builder.Services.AddSingleton<MatchService>();
            builder.Services.AddSingleton<SpectatorService>();

            builder.Services.AddSingleton<JobQueueService>();

            builder.Services.AddTransient<SummonerRepository>();
            builder.Services.AddTransient<MatchRepository>();
            builder.Services.AddTransient<RawMatchRepository>();

            builder.Services.AddAutoMapper(typeof(SummonerMapper), typeof(MatchMapper));

            builder.Services.AddCors(options => options.AddPolicy(name: "POTG", policy => policy.WithOrigins("http://localhost:3000")));

            var app = builder.Build();
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/POTG v1/swagger.yaml", "POTG v1");
                    c.SwaggerEndpoint("/swagger/POTG Summoner v1/swagger.yaml", "POTG Summoner v1");
                    c.SwaggerEndpoint("/swagger/POTG Spectator v1/swagger.yaml", "POTG Spectator v1");

                    c.SwaggerEndpoint("/swagger/Summoner v4/swagger.yaml", "Summoner v4");
                    c.SwaggerEndpoint("/swagger/League v4/swagger.yaml", "League v4");
                    c.SwaggerEndpoint("/swagger/Match v5/swagger.yaml", "Match v5");

                    c.EnableTryItOutByDefault();
                    c.DisplayRequestDuration();
                });
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseCors("POTG");
            //app.UseAuthorization();
            //app.MapControllers();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller}/{action=Index}/{id?}");

            await app.RunAsync();
        }
    }
}