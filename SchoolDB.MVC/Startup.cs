using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SchoolDB.Logic.Interfaces;
using SchoolDB.Logic.Logic;
using SchoolDB.Model.Models;
using SchoolDB.Repository.ImplementedRepos;
using SchoolDB.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolDB.MVC
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<SchoolDbContext>();

            services.AddTransient<IRepository<Student>,StudentRepository>();
            services.AddTransient<IRepository<Class>,ClassRepository>();
            services.AddTransient<IRepository<Grade>,GradeRepository>();
            services.AddTransient<IRepository<Subject>,SubjectRepository>();

            services.AddTransient<IClassLogic, ClassLogic>();
            services.AddTransient<IStudentLogic, StudentLogic>();
            services.AddTransient<IGradeLogic, GradeLogic>();
            services.AddTransient<ISubjectLogic, SubjectLogic>();

            services.AddControllersWithViews();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=ListAllGrades}/{id?}");
            });
        }
    }
}
