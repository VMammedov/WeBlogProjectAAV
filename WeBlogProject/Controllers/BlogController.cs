using BusinessLayer.Concrete;
using BusinessLayer.ViewModels;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace WeBlogProject.Controllers
{
    public class BlogController : Controller
    {
        BlogManager bm = new BlogManager(new BlogRepository());

        public IActionResult Index(int page=1)
        {
            List<Blog> data = bm.GetList();
            List<BlogListViewModel> dataViewModel = new List<BlogListViewModel>();
            foreach (Blog item in data)
            {
                BlogListViewModel blog = new BlogListViewModel
                {
                    BlogId = item.BlogId,
                    BlogTitle = item.BlogTitle,
                    BlogContent = item.BlogContent,
                    BlogDate = item.BlogDate,
                    BlogImage = item.BlogImage
                };
                dataViewModel.Add(blog);
            }
            return View(dataViewModel.ToPagedList(page,3));
        }

        public IActionResult BlogDetails(int id)
        {
            Blog blog = bm.GetById(id);
            return View(blog);
        }
    }
}