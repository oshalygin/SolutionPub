using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.Entity;
using SP.Entities;

namespace SP.DAL
{
    public class PostDataAccess : IPostDataAccess
    {
        private readonly BlogContext _context;

        public PostDataAccess()
        {
            _context = new BlogContext();
        }


        public IEnumerable<Post> GetPosts(int page, int pageSize)
        {
            return _context
                .Posts
                .Include(x => x.Tags)
                .Include(x => x.Comments)
                .OrderBy(x => x.PostedDate)
                .Skip(page*pageSize)
                .Take(pageSize);
        }

        public Post GetPost(int postId)
        {
            return _context
                .Posts
                .FirstOrDefault(x => x.Id == postId);
        }

     

        public IEnumerable<Post> GetRecentPosts(int quantity)
        {
            return _context
                .Posts
                .OrderBy(x => x.PostedDate)
                .Take(quantity);
        }

        public Post SaveNewPost(Post post)
        {
            _context.Add(post);
            _context.SaveChanges();
            return post;
        }

        public Post EditPost(Post post)
        {
            var postToEdit = _context.Posts
                .Include(x => x.Tags)
                .Include(x => x.Comments)
                .Single(x => x.Id == post.Id);

            postToEdit.Tags = post.Tags;
            postToEdit.Comments = post.Comments;
            postToEdit.Body = post.Body;
            postToEdit.Title = post.Title;
            postToEdit.UrlTitle = post.UrlTitle;
            postToEdit.PhotoPath = post.PhotoPath;
            postToEdit.Preview = post.Preview;
            postToEdit.DateEdited = DateTime.UtcNow;

            _context.Entry(postToEdit).State = EntityState.Modified;
            _context.SaveChanges();

            return postToEdit;
        }

        public int GetTotalNumberOfPosts(DateTime postedStartingDate, DateTime postedEndingDate)
        {
            return _context
                .Posts
                .Count(x => x.PostedDate >= postedStartingDate && x.PostedDate <= postedEndingDate);
        }

        public IEnumerable<Post> GetInactivePosts()
        {
            return _context
                .Posts
                .Where(x => x.Inactive);
        }


        public IEnumerable<Tag> GetTags()
        {
            return _context
                .Tags
                .OrderBy(x => x.TimesUsed);
        }

        
    }
}