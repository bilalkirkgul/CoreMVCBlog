using BLL.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Helpers
{
    public class WriterHelpers
    {
        private readonly IWriterService _writerService;
        private readonly UserManager<AppUser> _userManager;

        public WriterHelpers(IWriterService writerService, UserManager<AppUser> userManager)
        {
            _writerService = writerService;
            _userManager = userManager;
        }

    

    }
}
