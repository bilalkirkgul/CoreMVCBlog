using BLL.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic4 : ViewComponent
    {

       private readonly IAdminService adminService;

        public Statistic4(IAdminService adminService)
        {
            this.adminService = adminService;
        }
        public IViewComponentResult Invoke()
        {
            //int adminId = int.Parse(User.Identity.Name);
            //var dataValues = adminService.GetById(adminId);
            var dataValues = adminService.GetById(1);

            return View(dataValues);
        }


    }
}
