using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Sample01.Models;

namespace Sample01.Controllers
{
    public class ContentController : Controller
    {
        private readonly Content contents;
        public ContentController(IOptions<Content> option)
        {
            contents = option.Value;
        }
        public IActionResult Index()
        {
            //var contents = new List<Content>();
            //for (int i = 0; i < 12; i++)
            //{
            //    contents.Add(new Content { Id = i, title = $"{i}'s title", content = $"{i}'s content", status = 1, add_time = DateTime.Now.AddDays(-i) });

            //}

            //return View( new ContentViewModel { Contents=contents});
            return View(new ContentViewModel { Contents = new List<Content> { contents } });
        
        }
    }
}