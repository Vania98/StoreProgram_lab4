using StoreProgram_lab4.Repository.Interfaces;
using StoreProgram_lab4.Repository;
using StoreProgram_lab4.Service.Interfaces;
using StoreProgram_lab4.Service;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StoreProgram_lab4.Configurations;
using MediatR;
using System.Reflection;
using StoreProgram_lab4.DTO.Responses;
using BusinessLogiLayer.MediatR.BasketFutures.Queries;
using BusinessLogicLayer.MediatR.BasketFutures.Queries;
using BusinessLogicLayer.MediatR.BasketFutures.Commands;

namespace StoreProgram_lab4
{
    public class Startup
    {
        public Startup(IConfiguration configuration) =>
            Configuration = configuration;

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            // Add services to the container.
            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(Configuration
                    .GetConnectionString("DefaultConnection"));
            });

            services.AddScoped<IBasketRepository, BasketRepository>();
            services.AddScoped<IClientRepository, ClientRepository>();

            services.AddScoped<IUnityOfWorkRepository, UnityOfWorkRepository>();

            services.AddScoped<IBasketService, BasketService>();
            services.AddScoped<IClientService, ClientService>();

            services.AddAutoMapper(typeof(AutoMapperProfile).Assembly);
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services.AddTransient<IRequestHandler<GetAllBasketQuery, IEnumerable<BasketResponse>>,
                GetAllBasketQuery.GetAllBasketQueryHandler>();
            services.AddTransient<IRequestHandler<GetBasketByIDQuery, BasketResponse>,
                GetBasketByIDQuery.GetBasketByIDQueryHandler>();
            services.AddTransient<IRequestHandler<CreateBasketCommand, BasketResponse>,
               CreateBasketCommand.CreateBasketCommandHandler>();
            services.AddTransient<IRequestHandler<DeleteBasketCommand, bool>,
                DeleteBasketCommand.DeleteBasketCommandHandler>();
            services.AddTransient<IRequestHandler<UpdateBasketCommand, BasketResponse>,
                UpdateBasketCommand.UpdateBasketCommandHandler>();

            services.AddControllers();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            // Configure the HTTP request pipeline.
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
