using BlogApp.Entity;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Data.Concrete.EfCore
{
    public static class SeedData
    {
        public static void TestVerileriniDoldur(IApplicationBuilder app)
        {
            var context = app.ApplicationServices.CreateScope().ServiceProvider.GetService<BlogContext>();


            if (context != null)
            {
                if (context.Database.GetPendingMigrations().Any())
                {
                    context.Database.Migrate();
                }

                if (!context.Tags.Any())
                {
                    context.Tags.AddRange(
                        new Tag { Text = "web programlama" , Url="web-programlama" , Color=TagColors.warning },
                        new Tag { Text = "backend" , Url="backend", Color=TagColors.info},
                        new Tag { Text = "frontend", Url="frontend", Color=TagColors.success},
                        new Tag { Text = "fullstack" ,Url="fullstack", Color=TagColors.secondary},
                        new Tag { Text = "php" ,Url="php", Color=TagColors.primary}


                    );
                    context.SaveChanges();
                }

                if (!context.Users.Any())
                {
                    context.Users.AddRange(
                        new User { UserName = "oguzhaniscn",Name="oguzhaniscn",Email="info@oguzhaniscn.com",Password="123456",Image="p1.jpg" },
                        new User { UserName = "sametiscn",Name="sametiscn",Email="info@sametiscn.com",Password="12345",Image="p2.jpg" }
                        

                    );
                    context.SaveChanges();
                }

                if (!context.Posts.Any())
                {
                    context.Posts.AddRange(
                        new Post
                        {
                            PostTitle = "asp.netcore",
                            Content = "asp.netcore dersleri",
                            Description = "asp.netcore dersleri",
                            Url="aspnet-core",
                            IsActive = true,
                            PublishhedOn = DateTime.Now.AddDays(-10),
                            Tags = context.Tags.Take(3).ToList(),
                            Image = "1.jpg",
                            UserId = 1,
                            Comments=new List<Comment>{
                                new Comment{Text="iyi bir kurs",PublishhedOn=DateTime.Now.AddDays(-20),UserId=1},
                                new Comment{Text="çok faydalandığım bir kurs",PublishhedOn=DateTime.Now.AddDays(-10),UserId=2}
                                }

                        },
                        new Post
                        {
                            PostTitle = "php",
                            Content = "php dersleri",
                            Description = "php dersleri",
                            Url="php",
                            IsActive = true,
                            PublishhedOn = DateTime.Now.AddDays(-20),
                            Tags = context.Tags.Take(2).ToList(),
                            Image = "2.jpg",

                            UserId = 1

                        },
                        new Post
                        {
                            PostTitle = "django",
                            Content = "django dersleri",
                            Description = "django dersleri",
                            Url="django",
                            IsActive = true,
                            PublishhedOn = DateTime.Now.AddDays(-30),
                            Tags = context.Tags.Take(4).ToList(),
                            Image = "3.jpg",
                            UserId = 2

                        },
                        new Post
                        {
                            PostTitle = "react dersleri",
                            Content = "react dersleri",
                            Description = "react dersleri",
                            Url="react-dersleri",
                            IsActive = true,
                            PublishhedOn = DateTime.Now.AddDays(-5),
                            Tags = context.Tags.Take(4).ToList(),
                            Image = "3.jpg",
                            UserId = 2

                        },
                        new Post
                        {
                            PostTitle = "angular",
                            Content = "angular dersleri",
                            Description = "angular dersleri",
                            Url="angular",
                            IsActive = true,
                            PublishhedOn = DateTime.Now.AddDays(-50),
                            Tags = context.Tags.Take(4).ToList(),
                            Image = "3.jpg",
                            UserId = 2

                        },
                        new Post
                        {
                            PostTitle = "web tasarım",
                            Content = "web tasarım dersleri",
                            Description = "web dersleri",
                            Url="web-tasarim",
                            IsActive = true,
                            PublishhedOn = DateTime.Now.AddDays(-60),
                            Tags = context.Tags.Take(4).ToList(),
                            Image = "3.jpg",
                            UserId = 2

                        }
                    );

                    context.SaveChanges();


                }






            }

        }
    }
}