using System.Reflection.Metadata;
using System.Security.Claims;
using BlogApp.Data.Abstract;
using BlogApp.Data.Concrete.EfCore;
using BlogApp.Entity;
using BlogApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace BlogApp.Controllers
{

    public class PostsController : Controller
    {
        private IpostRepository _postrepository;
        private ICommentRepository _commentRepository;

        public PostsController(IpostRepository postrepository,ICommentRepository commentRepository)
        {
            _postrepository = postrepository;
            _commentRepository=commentRepository;

        }

        public async Task<IActionResult> Index(string tag)
        {
            var claims=User.Claims;


            var posts=_postrepository.Posts;

            if(!string.IsNullOrEmpty(tag))
            {
                posts=posts.Where(x=>x.Tags.Any(t=>t.Url==tag));

            }

            return View(new PostsViewModel{Posts = await posts.ToListAsync()});
        }


        public async Task<IActionResult> Details(string url)
        {
            return View(await _postrepository
            .Posts
            .Include(x=>x.Tags)
            .Include(x=>x.Comments)
            .ThenInclude(x=>x.User)
            .FirstOrDefaultAsync(p => p.Url == url)
            );
        }


        [HttpPost]
        public JsonResult AddComment(int PostId, string Text)
        {            // // bir return yolu // return Redirect("/posts/details/"+Url);

            // return RedirectToRoute("post_details", new{url=Url});
            // //program.cs e yazdığımız MapControllerRoute'a ulaşıp sonunu parametre olarak gönderdiğimiz bir seçenek
            
            var userId=User.FindFirstValue( ClaimTypes.NameIdentifier);
            var userName=User.FindFirstValue(ClaimTypes.Name);
            var avatar=User.FindFirstValue(ClaimTypes.UserData);

            
            var entity=new Comment{
                PostId=PostId,
                Text=Text,
                PublishhedOn=DateTime.Now,
                UserId=int.Parse(userId??"")
            
            };
            _commentRepository.CreateComment(entity);
            return Json(new {
                userName,
                Text,
                entity.PublishhedOn,
                avatar
                
            });
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(PostCreateViewModel model)
        {
            if(ModelState.IsValid)
            {
                var userId=User.FindFirstValue(ClaimTypes.NameIdentifier);
                _postrepository.CreatePost(
                    new Post{
                        PostTitle=model.PostTitle,
                        Content=model.Content,
                        Url=model.Url,
                        UserId=int.Parse(userId??""),
                        PublishhedOn=DateTime.Now,
                        Image="1.jpg",
                        IsActive=false
                    }
                );
                return RedirectToAction("Index");
            }

            return View(model);
        }













    }

}