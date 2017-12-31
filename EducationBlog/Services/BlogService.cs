using EducationBlog.Dtos;
using EducationBlog.Models;
using EducationBlog.Models.Domain;
using System;
using System.Threading.Tasks;

namespace EducationBlog.Service
{
    public interface IBlogService
    {
        Task<bool> Add(BlogAddDto model);       
    }
    public class BlogService:IBlogService
    {
        private EducationBlogDBContext _context = null;

        public BlogService()
        {
            _context = new EducationBlogDBContext();
        }

        public async Task<bool> Add(BlogAddDto model)
        {
            try
            {
                Blog entity = new Blog
                {
                    Body = model.Body,
                    Header = model.Header,
                    Id = Guid.NewGuid()
                };

                _context.Blog.Add(entity);
                await _context.SaveChangesAsync();
                
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}