using Orleans.CodeGeneration;

using System;
using System.Collections.Generic;
using System.Linq;
using Core;
using LanguageExt;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Orleans.Clustering.Redis;
using Orleans.Hosting;
using Orleans.Persistence;
using UserManagement;
using static LanguageExt.Prelude;
using HostBuilderContext = Microsoft.Extensions.Hosting.HostBuilderContext;

[assembly: KnownAssembly(typeof(UserManagementPort))]

static TryOption<string> OrleansConnectionString(HostBuilderContext ctx) => 
	TryOption(() => ctx.HostingEnvironment.IsDevelopment() ? None : Some($"{Environment.GetEnvironmentVariable("REDIS")}:6379"));

static IEnumerable<Func<ISiloBuilder>> NamesAsBuilderFuncs(IEnumerable<string> names, ISiloBuilder builder) =>
	names.Map<string, Func<ISiloBuilder>>(name => () => builder.AddMemoryGrainStorage(name));

static Action<RedisStorageOptions> ConfigureOptions(string connectionString) =>
	options => options.ConnectionString = connectionString;
static Action<RedisClusteringOptions> ConfigureClusteringOptions(string connectionString) =>
	options => options.ConnectionString = connectionString;


static IEnumerable<Func<ISiloBuilder>> NamesAsRedisBuilderFuncs(IEnumerable<string> names, ISiloBuilder builder, Option<string> connectionString) =>
	names.Map<string, Func<ISiloBuilder>>(name => () => 
		connectionString.Match(conn => builder.AddRedisGrainStorage(name, ConfigureOptions(conn)), 
			() => builder.AddMemoryGrainStorage(name)));

static void CallBuilderFunc(Func<ISiloBuilder> f) => f();

static Action DevOrleansConfig(ISiloBuilder builder, params string[] storageNames) =>
	() => new Func<ISiloBuilder>[]{() => builder.UseLocalhostClustering()}
		.Append(NamesAsBuilderFuncs(storageNames, builder))
		.ToList().ForEach(CallBuilderFunc);

static Action<string> DefaultOrleansConfig(ISiloBuilder builder, params string[] storageNames) =>
	connectionString => new Func<ISiloBuilder>[]
			{() => builder.UseRedisClustering(ConfigureClusteringOptions(connectionString))}
		.Append(NamesAsRedisBuilderFuncs(storageNames, builder, connectionString))
		.ToList().ForEach(CallBuilderFunc);

await Host.CreateDefaultBuilder(args)
	.UseOrleans((ctx, siloBuilder) =>
		OrleansConnectionString(ctx)
		.Match(
			DefaultOrleansConfig(siloBuilder, "users"), 
			DevOrleansConfig(siloBuilder, "users"), 
			Console.WriteLine))
	.ConfigureWebHostDefaults(webBuilder => 
		webBuilder
			.ConfigureServices(services =>
			{
				services
					.AddUserServices()
					.AddInMemoryBus()
					.AddControllers();
				services.AddSwaggerGen(c =>
        	    			{
        	    				c.SwaggerDoc("v1", new OpenApiInfo { Title = "WidgetMarketplace", Version = "v1" });
        	    			});
			})
			.Configure((ctx, app) =>
			{
				if (ctx.HostingEnvironment.IsDevelopment())
                {
                	app.UseDeveloperExceptionPage();
                }

				app.UseDefaultFiles();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WidgetMarketplace v1"));
                
                app.UseRouting();
                
                app.UseAuthorization();
                
                app.UseEndpoints(endpoints =>
                {
                	endpoints.MapControllers();
                });
			})
	)
	.ConfigureServices(services =>
	{
	})
	.RunConsoleAsync();
