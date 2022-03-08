using DAL.Abstract;
using DAL.Concrete.Repository.EntityFramework;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Concrete.Repository.DependencyInjection
{
   public static class EfContextDAL
    {
        public static void AddScobeDAL(this IServiceCollection services)
        {
            services.AddScoped<IAboutDAL, EfAboutRepository>();
            services.AddScoped<IBlogDAL, EfBlogRepository>();
            services.AddScoped<ICategoryDAL, EfCategoryRepository>();
            services.AddScoped<ICommentDAL, EfCommentRepository>();
            services.AddScoped<IContactDAL, EfContactRepository>();
            services.AddScoped<INewsLetterDAL, EfNewsLetterRepository>();
            services.AddScoped<IWriterDAL, EfWriterRepository>();
            services.AddScoped<INotificationDAL, EfNotificationRepository>();
        }
    }
}
