using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.Entity;
using SP.Entities;
using static System.String;

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

        public Post GetPost(string postUrlTitle)
        {
            return _context
                .Posts
                .Include(t => t.Tags)
                .Include(c => c.Comments)
                .FirstOrDefault(x => string.Equals(x.UrlTitle, postUrlTitle, StringComparison.CurrentCultureIgnoreCase));
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

        public Post UpdatePost(Post post)
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

        public IEnumerable<Post> GetPostsByDateRange(DateTime postedStartingDate, DateTime postedEndingDate)
        {
            return _context
                .Posts
                .Where(x => x.PostedDate >= postedStartingDate && x.PostedDate <= postedEndingDate);
        }

        public bool DeletePost(int postId)
        {
            var postToDelete = _context
                .Posts
                .Single(x => x.Id == postId);

            _context.Posts.Remove(postToDelete);
            _context.Entry(postToDelete).State = EntityState.Deleted;
            return true;
        }
    }
}