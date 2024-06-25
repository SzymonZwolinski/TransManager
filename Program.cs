using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Net.NetworkInformation;
using System.Reflection;
using TransManager.Common.Adapter;
using TransManager.Common.Persistance;
using TransManager.Common.Repositories;
using TransManager.Domain.Models;
using TransManager.Features.Movies;

namespace TransManager
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			builder.Services.AddRazorPages();
			builder.Services.AddServerSideBlazor();
			builder.Services.AddControllersWithViews();
			builder.Services.AddTransient<GetMovieController>();


			builder.Services.AddTransient<ITranslationAdapter, TranslationAdapter>();
			builder.Services.AddTransient<ITranslationRepository, TranslationRepository>();
			builder.Services.AddTransient<IRequestHandler<GetWordQuery, Movie>, GetMovieHandler>();
			builder.Services.AddTransient<FakeSQLDb>(); 

			builder.Services.AddDbContext<SqlLiteDb>();

			builder.Services.AddMediatR(cfg =>
				cfg.RegisterServicesFromAssembly(typeof(GetWordQuery).Assembly));

			var app = builder.Build();	

			using (var scope = app.Services.CreateScope())
			{
				var services = scope.ServiceProvider;
				try
				{
					var context = services.GetRequiredService<SqlLiteDb>();

					// Ensure database is created
					context.Database.EnsureCreated();

					// Apply any pending migrations
					context.Database.Migrate();
				}
				catch (Exception ex)
				{
					var logger = services.GetRequiredService<ILogger<Program>>();
					logger.LogError(ex, "An error occurred while creating or migrating the database.");
				}
			}

			// Configure the HTTP request pipeline.
			if (!app.Environment.IsDevelopment())
			{
				app.UseExceptionHandler("/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseHttpsRedirection();

			app.UseStaticFiles();

			app.UseRouting();

			app.MapBlazorHub();
			app.MapFallbackToPage("/_Host");

			app.Run();
		}
	}
}
