using BLL.Abstract;
using ClosedXML.Excel;
using CoreDemo.Areas.Admin.Model;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogController : Controller
    {
        IBlogService blogService;

        public BlogController(IBlogService blogService)
        {
            this.blogService = blogService;
        }


        #region Database' den veri çekmeden Deneme amaçlı yapılmıştır
        //public IActionResult ExportStaticExellBlogList()
        //{

        //    using (var workbook = new XLWorkbook())
        //    {
        //        var workSheet = workbook.Worksheets.Add("Blog Listesi");
        //        workSheet.Cell(1, 1).Value = "BlogID";//1.satır 1. sütun
        //        workSheet.Cell(1, 2).Value = "Blog Adı";

        //        int BlogRowCount = 2; //Birinci satıra başlık yazılacağı için 2. satırdan başlattık..
        //        foreach (var item in GetBlogList())
        //        {
        //            workSheet.Cell(BlogRowCount, 1).Value = item.ID;
        //            workSheet.Cell(BlogRowCount, 2).Value = item.BlogName;
        //            BlogRowCount++;
        //        }

        //        using (var stream = new MemoryStream())
        //        {
        //            workbook.SaveAs(stream);
        //            var content = stream.ToArray();
        //            return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Calisma1.xlsx");
        //        }
        //    }


        //}

        //public List<BlogViewModelDeneme> GetBlogList()
        //{
        //    List<BlogViewModelDeneme> blogModel = new List<BlogViewModelDeneme>()
        //    {
        //        new BlogViewModelDeneme{ID=1,BlogName="C# Programlama Giriş"},
        //        new BlogViewModelDeneme{ID=2,BlogName="JS Programlama Giriş"},
        //        new BlogViewModelDeneme{ID=3,BlogName="Pyhton Programlama Giriş"},
        //    };

        //    return blogModel;
        //}


        #endregion
        public List<BlogVM> GetBlogListAll()
        {
            //Database'den gelen verileri wm tipine çevirdim.
            List<BlogVM> blogVMs = new List<BlogVM>();

            foreach (var item in blogService.GetList()) //bll-dal-model(data) çektiğimiz veriyi döndüm ve ViewModel' e aktardım.
            {
                blogVMs.Add(new BlogVM { BlogID = item.BlogID, BlogTitle = item.BlogTitle, BlogContent = item.BlogContent });
            }

            return blogVMs;
        }

        public IActionResult ExportDynamicExellBlogList()
        {

            //Excell tablosu oluşturma işlemi aşağıda yapılmıştır..
            //using ClosedXML.Excel; eklemesi yapıldı
            using (var workbook = new XLWorkbook())
            {
                var workSheet = workbook.Worksheets.Add("Blog Listesi"); //Çalışma Dosyası Adı
                workSheet.Cell(1, 1).Value = "BlogID";//1.satır 1. sütun
                workSheet.Cell(1, 2).Value = "Blog Başlık"; //1.satır 2. sütun
                workSheet.Cell(1, 3).Value = "Blog İçerik"; //1.satır 3. sütun

                int BlogRowCount = 2; //Birinci satıra başlık yazılacağı için 2. satırdan başlattık..
                foreach (var item in GetBlogListAll())
                {
                    workSheet.Cell(BlogRowCount, 1).Value = item.BlogID;
                    workSheet.Cell(BlogRowCount, 2).Value = item.BlogTitle;
                    workSheet.Cell(BlogRowCount, 3).Value = item.BlogContent;
                    BlogRowCount++; //aşağıya doğru satır artırma işlemi
                }

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Calisma1.xlsx"); //çalışma dosyası detay
                }
            }

        }


        public IActionResult BlogListExcell()
        {
            return View();
        }
    }
}
