using BlogApp.Entity;

namespace BlogApp.Data.Abstract
{
    public interface IpostRepository
    {
        IQueryable<Post> Posts { get; }

        void CreatePost(Post post);
    }
}