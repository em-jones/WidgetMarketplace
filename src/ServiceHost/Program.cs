using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

await Host.CreateDefaultBuilder(args)
	.ConfigureWebHostDefaults(webBuilder => 
		webBuilder
			.ConfigureServices(services =>
			{
				services.AddControllers();
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
