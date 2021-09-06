using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using Publy.Services.DTO;
using Publy.Api.ViewModels;
using Publy.Domain.Entities;
using Publy.Infra.Context;
using Publy.Infra.Interfaces;
using Publy.Infra.Repositories;
using Publy.Services.Interfaces;
using Publy.Services.Services;
using System.IO;
using System.Reflection;

namespace Publy.Api
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {

      services.AddControllers();

      #region AutoMapper

      MapperConfiguration autoMapperConfiguration = new MapperConfiguration(cfg =>
      {
        cfg.CreateMap<Collaborator, CollaboratorDTO>().ReverseMap();
        cfg.CreateMap<CreateCollaboratorViewModel, CollaboratorDTO>().ReverseMap();
        cfg.CreateMap<UpdateCollaboratorViewModel, CollaboratorDTO>().ReverseMap();

        cfg.CreateMap<Department, DepartmentDTO>().ReverseMap();
        cfg.CreateMap<CreateDepartmentViewModel, DepartmentDTO>().ReverseMap();
        cfg.CreateMap<UpdateDepartmentViewModel, DepartmentDTO>().ReverseMap();
      });

      services.AddSingleton(autoMapperConfiguration.CreateMapper());

      #endregion

      #region DependencyInjection

      services.AddSingleton(s => Configuration);
      services.AddDbContext<PublyContext>(options => options.UseNpgsql(Configuration.GetConnectionString("PublyDB")));

      services.AddScoped<ICollaboratorService, CollaboratorService>();
      services.AddScoped<ICollaboratorRepository, CollaboratorRepository>();

      services.AddScoped<IDepartmentService, DepartmentService>();
      services.AddScoped<IDepartmentRepository, DepartmentRepository>();

      #endregion

      #region Swagger

      services.AddSwaggerGen(options =>
      {
        options.SwaggerDoc("v1", new OpenApiInfo
        {
          Title = "Publy API",
          Version = "v1",
          Description = "API to manager Collaborators in your company",
          Contact = new OpenApiContact
          {
            Name = "Melk de Sousa"
          },
        });

        string xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
        string xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
        options.IncludeXmlComments(xmlPath);
      });

      #endregion
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Publy API | v1"));
      }

      app.UseRouting();

      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
    }
  }
}
