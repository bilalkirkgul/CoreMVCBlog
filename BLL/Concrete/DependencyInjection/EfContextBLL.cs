using BLL.Abstract;
using DAL.Concrete.Repository.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Concrete.DependencyInjection
{
   public static class EfContextBLL
    {
        public static void AddScobeBLL(this IServiceCollection services)
        {
            services.AddScobeDAL();
            services.AddScoped<IBlogService, BlogManager>();
            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<ICommentService, CommentManager>();
            services.AddScoped<INewsLetterService, NewsLetterManager>();
            services.AddScoped<IWriterService, WriterManager>();
            services.AddScoped<IAboutService, AboutManager>();
        }


    }
}
