using BlogApp.Data.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.ViewComponents
{
    public class NewPosts : ViewComponent
    {
        private IpostRepository _postRepository;

        public NewPosts(IpostRepository postRepository)
        {
            _postRepository = postRepository;
        }


        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(await
                _postRepository
                .Posts
                .OrderByDescending(p => p.PublishhedOn)
                .Take(5)
                .ToListAsync());
        }


    }
}